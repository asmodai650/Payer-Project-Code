using System;
using Novus.Toolbox;
using Novus.Payer1060.BusinessObjects.Constants;
using Novus.Payer1060.BusinessObjects.FileObjects;
using Novus.Payer1060.BusinessObjects.Utilities;

namespace Novus.Payer1060
{
    public class PrepareMergeClaimToMapper1060
    {
        #region DECLARATIONS

        ///AdHoc Files
        private readonly string adHocClaimHeaderFile;
        private readonly FdOptumCareHcpClaim fdClaimHeader;
        private readonly MergeUtilities mergeAdHocClaimHeaderWithMapper;

        ///Racer Claim streamWriter and Mapper
        private readonly string racerClaimFile;
        private readonly FO_BcpPlusClaimHeader racerClaim;

        ///Common to all files
        private LoadRerun loadRerun;
        private readonly LogUtilities log;
        private readonly RacerLoadJobReadOnlyProperties racerLoadJobProperties;
        #endregion DECLARATIONS

        #region CONSTRUCTOR

        public PrepareMergeClaimToMapper1060(RacerLoadJobReadOnlyProperties racerProps)
        {
            this.racerLoadJobProperties = racerProps;
            InitializeLoadRerun();

            this.adHocClaimHeaderFile = racerLoadJobProperties.AdHocClaimHeaderFilename;
            this.fdClaimHeader = new FdOptumCareHcpClaim();
            this.mergeAdHocClaimHeaderWithMapper = new MergeUtilities();

            this.racerClaimFile = racerLoadJobProperties.MapperOutputClaimHeaderFilename;
            this.racerClaim = new FO_BcpPlusClaimHeader();

            this.log = new LogUtilities(racerLoadJobProperties);

            this.log.Write("PrepareMergeClaimToMapper1060 Racer variables loaded.");
        }
        #endregion CONSTRUCTOR

        #region PREPARE_EXECUTE

        public bool Execute()
        {
            try
            {
                if (!this.loadRerun.IsStepComplete(Constant.PrepareMergeAdhocSort))
                {
                    this.log.Write($"Starting {this.GetType().Name} Execute()");

                    /// Bypass sorting when running unit tests
                    if (!this.racerLoadJobProperties.UseMockRawFiles)
                        SortAdHocFile();

                    this.loadRerun.UpdateStepStatus(Constant.PrepareMergeAdhocSort, 1);
                    this.loadRerun.WriteRerunStats();
                }
                if (!this.loadRerun.IsStepComplete(Constant.PrepareMergeAdhocToMapper))
                {
                    this.log.Write($"Starting {this.GetType().Name} Execute()");

                    MergeAdhocToMapper();

                    this.loadRerun.UpdateStepStatus(Constant.PrepareMergeAdhocToMapper, 1);
                    this.loadRerun.WriteRerunStats();
                }

                this.loadRerun.UpdateStepStatus(Constant.PrepareMergeClaimToMapper, 1);
                return true;
            }

            catch (Exception exception)
            {
                this.log.Write($"Error in {this.GetType().Name} : " + exception.StackTrace);
                throw new PayerException($"Failure in  {this.GetType().Name} . See Log File for details.");
            }
        }
        #endregion PREPARE_EXECUTE

        #region PRIVATE_METHODS

        private void InitializeLoadRerun()
        {
            this.loadRerun = new LoadRerun(this.racerLoadJobProperties);
            this.loadRerun.Init(Constant.PrepareMergeClaimToMapper);
            this.loadRerun.Init(Constant.PrepareMergeAdhocSort);
            this.loadRerun.Init(Constant.PrepareMergeDiagSort);
            this.loadRerun.Init(Constant.PrepareMergeAdhocToMapper);

            loadRerun.WriteRerunStats();
        }

        private void SortAdHocFile()
        {
            var adHocClaimHeaderBeforeSort = new SortUtilities(racerLoadJobProperties);
            var adHocClaimHeaderFileIndex = FieldIndexUtilities.GetOneBasedFieldIndexes(fdClaimHeader.EmitHeaderLine(false));

            ///Sort adHocClaimHeader by CLAIM_NO
            adHocClaimHeaderBeforeSort.Clear();
            adHocClaimHeaderBeforeSort.SetFile(this.adHocClaimHeaderFile, true);
            adHocClaimHeaderBeforeSort.AddSortField(adHocClaimHeaderFileIndex["CLAIM_NO"], Sort.SType.StandardCharacterData, dedupe: false);
            adHocClaimHeaderBeforeSort.Sort();
        }

        private void MergeAdhocToMapper()
        {
            var racerMapperClaimBeforeSort = new SortUtilities(racerLoadJobProperties);

            var racerMapperClaimFileIndex = FieldIndexUtilities.GetOneBasedFieldIndexes(racerClaim.EmitHeaderLine());
            var adHocClaimHeaderFileIndex = FieldIndexUtilities.GetOneBasedFieldIndexes(fdClaimHeader.EmitHeaderLine(false));

            /// Bypass sorting when running unit tests
            if (!this.racerLoadJobProperties.UseMockRawFiles)
            {
                racerMapperClaimBeforeSort.Clear();
                racerMapperClaimBeforeSort.SetFile(this.racerClaimFile, true);
                racerMapperClaimBeforeSort.AddSortField(racerMapperClaimFileIndex["CLAIM_NO"], Sort.SType.StandardCharacterData, dedupe: false);
                racerMapperClaimBeforeSort.Sort();
            }

            /// Merge adHocClaimHeader after rollups with racerMapperClaim based on CLAIM_NO
            this.mergeAdHocClaimHeaderWithMapper.Clear();
            this.mergeAdHocClaimHeaderWithMapper.SetSourceFile(this.adHocClaimHeaderFile, adHocClaimHeaderFileIndex["CLAIM_NO"]);
            this.mergeAdHocClaimHeaderWithMapper.SetTargetFile(this.racerClaimFile, racerMapperClaimFileIndex["CLAIM_NO"]);
            this.mergeAdHocClaimHeaderWithMapper.AddFieldToMove(adHocClaimHeaderFileIndex["DATE_OF_SERVICE_BEG"], racerMapperClaimFileIndex["DATE_OF_SERVICE_BEG"]);
            this.mergeAdHocClaimHeaderWithMapper.AddFieldToMove(adHocClaimHeaderFileIndex["DATE_OF_SERVICE_END"], racerMapperClaimFileIndex["DATE_OF_SERVICE_END"]);
            this.mergeAdHocClaimHeaderWithMapper.AddFieldToMove(adHocClaimHeaderFileIndex["AMT_BILLED"], racerMapperClaimFileIndex["AMT_BILLED"]);
            this.mergeAdHocClaimHeaderWithMapper.Merge();
        }
        #endregion PRIVATE_METHODS
    }
}
