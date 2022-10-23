using System;
using Novus.PayerBase;
using Novus.Toolbox;
using Novus.Payer1060.BusinessObjects.Constants;
using Novus.Payer1060.BusinessObjects.FileObjects;
using Novus.Payer1060.BusinessObjects.Utilities;

namespace Novus.Payer1060
{
    public class PrepareMergeClaim1060 : PrepareClaimHeaderBase
    {
        #region DECLARATIONS

        ///Mapper Claim File
        private readonly string mapperClaimHeaderFileName;
        private readonly FO_BcpPlusClaimHeader racerClaim;

        ///Lookup Diag to Racer Claim Mapper
        private readonly string diagLookupFileName;
        private readonly MergeUtilities mergeDiagWithClaimMapper;

        ///Common to all files
        private LoadRerun loadRerun;
        private readonly LogUtilities log;
        #endregion DECLARATIONS

        #region CONSTRUCTOR

        public PrepareMergeClaim1060(RacerLoadJobReadOnlyProperties racerProps)
        {
            base.racerLoadJobProperties = racerProps;
            base.LoadRacerVariables();
            InitializeLoadRerun();

            this.mapperClaimHeaderFileName = racerLoadJobProperties.MapperOutputClaimHeaderFilename;
            this.racerClaim = new FO_BcpPlusClaimHeader();

            this.diagLookupFileName = racerLoadJobProperties.LookupDataClaimHeaderFilename.Replace("File.txt", "FileB_DiagLookup.txt");

            this.mergeDiagWithClaimMapper = new MergeUtilities();
            this.log = new LogUtilities(racerLoadJobProperties);

            this.log.Write("PrepareMergeClaim1060 Racer variables loaded.");
        }
        #endregion CONSTRUCTOR

        #region PREPARE_EXECUTE

        public override bool Execute()
        {
            try
            {
                if (!this.loadRerun.IsStepComplete(Constant.PrepareMergeClaimLookupSort))
                {
                    this.log.Write($"Starting {this.GetType().Name} Execute()");

                    /// Bypass sorting when running unit tests
                    if (!this.racerLoadJobProperties.UseMockRawFiles)
                        SortLookupFile();

                    this.loadRerun.UpdateStepStatus(Constant.PrepareMergeClaimLookupSort, 1);
                    this.loadRerun.WriteRerunStats();
                }

                if (!this.loadRerun.IsStepComplete(Constant.PrepareMergeClaimLookupMerge))
                {
                    this.log.Write($"Starting {this.GetType().Name} Execute()");

                    SortAndMergeDiagLookupWithMapper();

                    this.loadRerun.UpdateStepStatus(Constant.PrepareMergeClaimLookupMerge, 1);
                    this.loadRerun.WriteRerunStats();
                }

                this.loadRerun.UpdateStepStatus(Constant.PrepareMergeClaim, 1);
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
            this.loadRerun.Init(Constant.PrepareMergeClaim);
            this.loadRerun.Init(Constant.PrepareMergeClaimLookupSort);
            this.loadRerun.Init(Constant.PrepareMergeClaimLookupMerge);

            loadRerun.WriteRerunStats();
        }

        private void SortLookupFile()
        {
            var diagLookupBeforeSort = new SortUtilities(racerLoadJobProperties);

            diagLookupBeforeSort.Clear();
            diagLookupBeforeSort.SetFile(this.diagLookupFileName, true);
            diagLookupBeforeSort.AddSortField(1, Sort.SType.StandardCharacterData, dedupe: false);
            diagLookupBeforeSort.AddSortField(2, Sort.SType.StandardCharacterData, dedupe: false);
            diagLookupBeforeSort.Sort();
        }

        private void SortAndMergeDiagLookupWithMapper()
        {
            var mapperClaimHeaderFileSort = new SortUtilities(racerLoadJobProperties);
            var mapperClaimHeaderFileIndex = FieldIndexUtilities.GetOneBasedFieldIndexes(racerClaim.EmitHeaderLine());

            /// Bypass sorting when running unit tests
            if (!this.racerLoadJobProperties.UseMockRawFiles)
            {
                mapperClaimHeaderFileSort.Clear();
                mapperClaimHeaderFileSort.SetFile(this.mapperClaimHeaderFileName, true);
                mapperClaimHeaderFileSort.AddSortField(mapperClaimHeaderFileIndex["CLAIM_NO"], Sort.SType.StandardCharacterData);
                mapperClaimHeaderFileSort.Sort();
            }

            this.mergeDiagWithClaimMapper.Clear();
            this.mergeDiagWithClaimMapper.SetSourceFile(this.diagLookupFileName, 1);
            this.mergeDiagWithClaimMapper.SetTargetFile(this.mapperClaimHeaderFileName, mapperClaimHeaderFileIndex["CLAIM_NO"]);
            this.mergeDiagWithClaimMapper.AddFieldToMove(2, mapperClaimHeaderFileIndex["PRINCIPAL_DIAG"]);
            this.mergeDiagWithClaimMapper.Merge();
        }
        #endregion PRIVATE_METHODS
    }
}
