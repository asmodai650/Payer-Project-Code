using System;
using System.IO;
using Novus.Toolbox;
using Novus.Payer1060.BusinessObjects.Constants;
using Novus.Payer1060.BusinessObjects.FileObjects;
using Novus.Payer1060.BusinessObjects.Utilities;
using Novus.Payer1060.BusinessObjects.RacerMappers;

namespace Novus.Payer1060
{
    public class PrepareMergeClaimToIcd1060
    {
        #region DECLARATIONS

        ///AdHoc Files
        private readonly string adHocClaimHeaderFile;
        private readonly FdOptumCareHcpClaim fdClaimHeader;
        private readonly string adHocClaimHeaderFileC;
        private readonly FdOptumCareHcpProc fdProc;

        ///Lookup to Racer Icd Mapper
        private readonly LookupDiagProcToIcdMapper icdLookupFile;
        private readonly string icdLookupFileName;
        private readonly MergeUtilities mergeAdHocClaimHeaderWithIcdLookup;
        private readonly MergeUtilities mergeAdHocClaimHeaderCwithIcdLookup;

        ///Racer ICD9 streamWriter and Mapper
        private readonly FO_BcpPlusICD9 racerIcd;
        private readonly StreamWriter racerIcdMapperWriter;
        private readonly StreamWriter racerIcdLookupInputWriter;

        ///Common to all files
        private LoadRerun loadRerun;
        private readonly LogUtilities log;
        private readonly RacerLoadJobReadOnlyProperties racerLoadJobProperties;
        #endregion DECLARATIONS

        #region CONSTRUCTOR

        public PrepareMergeClaimToIcd1060(RacerLoadJobReadOnlyProperties racerProps)
        {
            this.racerLoadJobProperties = racerProps;
            InitializeLoadRerun();

            this.adHocClaimHeaderFile = racerLoadJobProperties.AdHocClaimHeaderFilename;
            this.fdClaimHeader = new FdOptumCareHcpClaim();
            this.adHocClaimHeaderFileC = racerLoadJobProperties.AdHocClaimHeaderFilename.Replace("File.txt", "FileC.txt");
            this.fdProc = new FdOptumCareHcpProc();

            this.icdLookupFile = new LookupDiagProcToIcdMapper();
            this.icdLookupFileName = racerLoadJobProperties.LookupDataClaimHeaderFilename.Replace("File.txt", "FileB_IcdLookup.txt");
            
            this.racerIcd = new FO_BcpPlusICD9();

            this.mergeAdHocClaimHeaderWithIcdLookup = new MergeUtilities();
            this.mergeAdHocClaimHeaderCwithIcdLookup = new MergeUtilities();
            this.log = new LogUtilities(racerLoadJobProperties);

            if (!loadRerun.IsStepComplete(Constant.PrepareIcd))
            {
                racerIcdMapperWriter = new StreamWriter(racerProps.MapperOutputICD9Filename);
                racerIcdMapperWriter.WriteLine(IcdMapper.EmitIcdHeader());

                racerIcdLookupInputWriter = new StreamWriter(racerProps.LookupInputICD9Filename);
            }

            this.log.Write("PrepareMergeIcdToClaim1060 Racer variables loaded.");
        }
        #endregion CONSTRUCTOR

        #region PREPARE_EXECUTE

        public bool Execute()
        {
            try
            {
                if (!this.loadRerun.IsStepComplete(Constant.PrepareMergeIcdLookupSort))
                {
                    this.log.Write($"Starting {this.GetType().Name} Execute()");

                    /// Bypass sorting when running unit tests
                    if (!this.racerLoadJobProperties.UseMockRawFiles)
                        SortAdHocFiles();

                    this.loadRerun.UpdateStepStatus(Constant.PrepareMergeIcdLookupSort, 1);
                    this.loadRerun.WriteRerunStats();
                }

                if (!this.loadRerun.IsStepComplete(Constant.PrepareMergeIcdLookup))
                {
                    this.log.Write($"Starting {this.GetType().Name} Execute()");

                    SortAndMergeLookup();

                    this.loadRerun.UpdateStepStatus(Constant.PrepareMergeIcdLookup, 1);
                    this.loadRerun.WriteRerunStats();
                }

                if (!this.loadRerun.IsStepComplete(Constant.PrepareMergeIcdMapper))
                {
                    this.log.Write($"Starting {this.GetType().Name} Execute()");

                    PrepareICD9RacerLine();
                    racerIcdMapperWriter?.FlushAndClose();
                    racerIcdLookupInputWriter?.FlushAndClose();

                    this.loadRerun.UpdateStepStatus(Constant.PrepareMergeIcdMapper, 1);
                    this.loadRerun.WriteRerunStats();
                }

                this.loadRerun.UpdateStepStatus(Constant.PrepareMergeIcd, 1);
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
            this.loadRerun.Init(Constant.PrepareMergeIcd);
            this.loadRerun.Init(Constant.PrepareMergeIcdLookupSort);
            this.loadRerun.Init(Constant.PrepareMergeIcdLookup);

            loadRerun.WriteRerunStats();
        }

        private void SortAdHocFiles()
        {
            var adHocClaimHeaderBeforeSort = new SortUtilities(racerLoadJobProperties);
            var adHocClaimHeaderFileIndex = FieldIndexUtilities.GetOneBasedFieldIndexes(fdClaimHeader.EmitHeaderLine(false));
            var adHocClaimHeaderCbeforeSort = new SortUtilities(racerLoadJobProperties);
            var adHocClaimHeaderFileCindex = FieldIndexUtilities.GetOneBasedFieldIndexes(fdProc.EmitHeaderLine(false));

            ///Sort adHocClaimHeader by CLAIM_NO
            adHocClaimHeaderBeforeSort.Clear();
            adHocClaimHeaderBeforeSort.SetFile(this.adHocClaimHeaderFile, true);
            adHocClaimHeaderBeforeSort.AddSortField(adHocClaimHeaderFileIndex["CLAIM_NO"], Sort.SType.StandardCharacterData, dedupe: false);
            adHocClaimHeaderBeforeSort.Sort();

            ///Sort adHocClaimHeaderC by CLAIM_NO
            adHocClaimHeaderCbeforeSort.Clear();
            adHocClaimHeaderCbeforeSort.SetFile(this.adHocClaimHeaderFileC, true);
            adHocClaimHeaderCbeforeSort.AddSortField(adHocClaimHeaderFileCindex["CLAIM_NO"], Sort.SType.StandardCharacterData, dedupe: false);
            adHocClaimHeaderCbeforeSort.Sort();
        }

        private void SortAndMergeLookup()
        {
            var icdLookupBeforeSort = new SortUtilities(racerLoadJobProperties);
            var icdLookupFileIndex = FieldIndexUtilities.GetOneBasedFieldIndexes(Constant.IcdLookupHeader);
            var adHocClaimHeaderFileCindex = FieldIndexUtilities.GetOneBasedFieldIndexes(fdProc.EmitHeaderLine(false));
            var adHocClaimHeaderFileIndex = FieldIndexUtilities.GetOneBasedFieldIndexes(fdClaimHeader.EmitHeaderLine(false));

            /// Bypass sorting when running unit tests
            if (!this.racerLoadJobProperties.UseMockRawFiles)
            {
                icdLookupBeforeSort.Clear();
                icdLookupBeforeSort.SetFile(this.icdLookupFileName, true);
                icdLookupBeforeSort.AddSortField(icdLookupFileIndex["CLAIM_NO"], Sort.SType.StandardCharacterData);
                icdLookupBeforeSort.Sort();
            }

            ///merge adHocClaimHeaderC with icdLookup based on CLAIM_NO
            this.mergeAdHocClaimHeaderCwithIcdLookup.Clear();
            this.mergeAdHocClaimHeaderCwithIcdLookup.SetSourceFile(this.adHocClaimHeaderFileC, adHocClaimHeaderFileCindex["CLAIM_NO"]);
            this.mergeAdHocClaimHeaderCwithIcdLookup.SetTargetFile(this.icdLookupFileName, icdLookupFileIndex["CLAIM_NO"]);
            this.mergeAdHocClaimHeaderCwithIcdLookup.AddFieldToMove(adHocClaimHeaderFileCindex["PRINCIPAL_PROC"], icdLookupFileIndex["PRINCIPAL_PROC"]);
            this.mergeAdHocClaimHeaderCwithIcdLookup.AddFieldToMove(adHocClaimHeaderFileCindex["PROCEDURE_1"], icdLookupFileIndex["PROCEDURE_1"]);
            this.mergeAdHocClaimHeaderCwithIcdLookup.AddFieldToMove(adHocClaimHeaderFileCindex["PROCEDURE_2"], icdLookupFileIndex["PROCEDURE_2"]);
            this.mergeAdHocClaimHeaderCwithIcdLookup.AddFieldToMove(adHocClaimHeaderFileCindex["PROCEDURE_3"], icdLookupFileIndex["PROCEDURE_3"]);
            this.mergeAdHocClaimHeaderCwithIcdLookup.AddFieldToMove(adHocClaimHeaderFileCindex["PROCEDURE_4"], icdLookupFileIndex["PROCEDURE_4"]);
            this.mergeAdHocClaimHeaderCwithIcdLookup.AddFieldToMove(adHocClaimHeaderFileCindex["PROCEDURE_5"], icdLookupFileIndex["PROCEDURE_5"]);
            this.mergeAdHocClaimHeaderCwithIcdLookup.AddFieldToMove(adHocClaimHeaderFileCindex["PROCEDURE_6"], icdLookupFileIndex["PROCEDURE_6"]);
            this.mergeAdHocClaimHeaderCwithIcdLookup.AddFieldToMove(adHocClaimHeaderFileCindex["PROCEDURE_7"], icdLookupFileIndex["PROCEDURE_7"]);
            this.mergeAdHocClaimHeaderCwithIcdLookup.AddFieldToMove(adHocClaimHeaderFileCindex["PROCEDURE_8"], icdLookupFileIndex["PROCEDURE_8"]);
            this.mergeAdHocClaimHeaderCwithIcdLookup.AddFieldToMove(adHocClaimHeaderFileCindex["PROCEDURE_9"], icdLookupFileIndex["PROCEDURE_9"]);
            this.mergeAdHocClaimHeaderCwithIcdLookup.AddFieldToMove(adHocClaimHeaderFileCindex["PROCEDURE_10"], icdLookupFileIndex["PROCEDURE_10"]);
            this.mergeAdHocClaimHeaderCwithIcdLookup.AddFieldToMove(adHocClaimHeaderFileCindex["PROCEDURE_11"], icdLookupFileIndex["PROCEDURE_11"]);
            this.mergeAdHocClaimHeaderCwithIcdLookup.AddFieldToMove(adHocClaimHeaderFileCindex["PROCEDURE_12"], icdLookupFileIndex["PROCEDURE_12"]);
            this.mergeAdHocClaimHeaderCwithIcdLookup.AddFieldToMove(adHocClaimHeaderFileCindex["PROCEDURE_13"], icdLookupFileIndex["PROCEDURE_13"]);
            this.mergeAdHocClaimHeaderCwithIcdLookup.AddFieldToMove(adHocClaimHeaderFileCindex["PROCEDURE_14"], icdLookupFileIndex["PROCEDURE_14"]);
            this.mergeAdHocClaimHeaderCwithIcdLookup.AddFieldToMove(adHocClaimHeaderFileCindex["PROCEDURE_15"], icdLookupFileIndex["PROCEDURE_15"]);
            this.mergeAdHocClaimHeaderCwithIcdLookup.AddFieldToMove(adHocClaimHeaderFileCindex["PROCEDURE_16"], icdLookupFileIndex["PROCEDURE_16"]);
            this.mergeAdHocClaimHeaderCwithIcdLookup.AddFieldToMove(adHocClaimHeaderFileCindex["PROCEDURE_17"], icdLookupFileIndex["PROCEDURE_17"]);
            this.mergeAdHocClaimHeaderCwithIcdLookup.AddFieldToMove(adHocClaimHeaderFileCindex["PROCEDURE_18"], icdLookupFileIndex["PROCEDURE_18"]);
            this.mergeAdHocClaimHeaderCwithIcdLookup.AddFieldToMove(adHocClaimHeaderFileCindex["PROCEDURE_19"], icdLookupFileIndex["PROCEDURE_19"]);
            this.mergeAdHocClaimHeaderCwithIcdLookup.AddFieldToMove(adHocClaimHeaderFileCindex["PROCEDURE_20"], icdLookupFileIndex["PROCEDURE_20"]);
            this.mergeAdHocClaimHeaderCwithIcdLookup.AddFieldToMove(adHocClaimHeaderFileCindex["PROCEDURE_21"], icdLookupFileIndex["PROCEDURE_21"]);
            this.mergeAdHocClaimHeaderCwithIcdLookup.AddFieldToMove(adHocClaimHeaderFileCindex["PROCEDURE_22"], icdLookupFileIndex["PROCEDURE_22"]);
            this.mergeAdHocClaimHeaderCwithIcdLookup.AddFieldToMove(adHocClaimHeaderFileCindex["PROCEDURE_23"], icdLookupFileIndex["PROCEDURE_23"]);
            this.mergeAdHocClaimHeaderCwithIcdLookup.Merge();

            ///merge adHocClaimHeader with icdLookup based on CLAIM_NO
            this.mergeAdHocClaimHeaderWithIcdLookup.Clear();
            this.mergeAdHocClaimHeaderWithIcdLookup.SetSourceFile(this.adHocClaimHeaderFile, adHocClaimHeaderFileIndex["CLAIM_NO"]);
            this.mergeAdHocClaimHeaderWithIcdLookup.SetTargetFile(this.icdLookupFileName, icdLookupFileIndex["CLAIM_NO"]);
            this.mergeAdHocClaimHeaderWithIcdLookup.AddFieldToMove(adHocClaimHeaderFileIndex["ADMITTING_DIAGNOSIS_CODE"], icdLookupFileIndex["ADMITTING_DIAGNOSIS_CODE"]);
            this.mergeAdHocClaimHeaderWithIcdLookup.AddFieldToMove(adHocClaimHeaderFileIndex["CLAIM_ICD_VERSION_INDICATOR"], icdLookupFileIndex["CLAIM_ICD_VERSION_INDICATOR"]);
            this.mergeAdHocClaimHeaderWithIcdLookup.Merge();
        }

        protected string PrepareICD9RacerLine()
        {
            try
            {
                using (StreamReader icdLookupReader = new StreamReader(racerLoadJobProperties.LookupDataClaimHeaderFilename.Replace("File.txt", "FileB_IcdLookup.txt")))
                {
                    string line;

                    while ((line = icdLookupReader.ReadLine()) != null)                 
                    {
                        this.icdLookupFile.LoadFromRaw(line);

                        if (this.icdLookupFile.IsValid && (!string.IsNullOrEmpty(this.icdLookupFile.CLAIM_NO)))
                        {
                            WriteIcdLines(icdLookupFile);
                        }
                    }
                }

                return string.Empty;
            }
            catch (Exception exception)
            {
                this.log.Write($"Error in {this.GetType().Name} : " + exception.StackTrace);
                throw new PayerException($"Failure in  {this.GetType().Name} . See Log File for details.");
            }
        }

        /// <summary>
        /// Write lines to the mapperOutputIcd9 and the lookupInputIcd9 files.
        /// </summary>
        private void WriteIcdLines(LookupDiagProcToIcdMapper lookup)
        {
            var mapperLookup = IcdMapper.EmitRacerIcdLines(lookup);
            var mapperLine = mapperLookup.Item1;
            var lookupLine = mapperLookup.Item2;

            if (!string.IsNullOrEmpty(mapperLine))
                racerIcdMapperWriter.WriteLine(mapperLine);
            if (!string.IsNullOrEmpty(lookupLine))
                racerIcdLookupInputWriter.WriteLine(lookupLine);
        }
        #endregion PRIVATE_METHODS
    }
}
