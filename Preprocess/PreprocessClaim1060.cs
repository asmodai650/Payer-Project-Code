using System;
using System.IO;
using Novus.PayerBase;
using Novus.Toolbox;
using Novus.Payer1060.BusinessObjects.Constants;
using Novus.Payer1060.BusinessObjects.FileObjects;
using Novus.Payer1060.BusinessObjects.Utilities;
using Novus.Payer1060.BusinessObjects.RacerMappers;

namespace Novus.Payer1060
{
    public class PreprocessClaim1060 : PreProcessClaimHeaderBaseAuto
    {
        #region DECLARATIONS

        ///Claim Header ( adHocClaimHeaderFile )
        private readonly FdOptumCareHcpClaim claimHeaderRawFile;
        private readonly string adHocClaimHeaderFileName;
        private readonly StreamWriter priorClaimIdLookupWriter;
        private readonly string priorClaimIdLookupFile;

        ///Claim Line ( adHocClaimHeaderFileA )
        private readonly FdOptumCareHcpClaimLine claimLineRawFile;
        private readonly string claimLineFile;

        ///Lookup ClaimLine to ClaimHeader
        private readonly StreamWriter claimLineLookupWriter;
        private readonly string claimLineLookupBeforeRollupFile;

        ///Diagnosis ( adHocClaimHeaderFileB )
        private readonly FdOptumCareHcpDiag diagRawFile;
        private readonly StreamWriter diagLookupWriter;
        private readonly string diagLookupFile;
        private readonly StreamWriter icdLookupWriter;
        private readonly string icdLookupFile;

        ///Procedure ( adHocClaimHeaderFileC )
        private readonly FdOptumCareHcpProc procRawFile;

        ///Racer StreamWriters and Mappers
        private readonly FO_BcpPlusClaimHeader racerClaim;
        private readonly StreamWriter racerClaimHeaderWriter;
        private readonly StreamWriter racerLookupInputClaimHeaderWriter;

        private readonly FO_BcpPlusClaimLine racerClaimLine;
        private readonly StreamWriter racerClaimLineWriter;
        private readonly StreamWriter racerLookupInputClaimLineWriter;

        private readonly FO_InsGroup racerInsGroup;
        private readonly StreamWriter racerInsGroupWriter;
        private readonly StreamWriter racerLookupInputInsGroupWriter;

        private readonly FO_BcpPlusSpecialFields racerSpecialFields;
        private readonly StreamWriter racerSpecialFieldsWriter;

        private readonly StreamWriter racerLookupInputProviderWriter;

        private readonly StreamWriter racerLookupInputMemberWriter;

        ///Common to all files
        private readonly CountUtilities counts;
        private LoadRerun loadRerun;
        private readonly LogUtilities log;
        #endregion DECLARATIONS

        #region CONSTRUCTOR

        public PreprocessClaim1060(RacerLoadJobReadOnlyProperties racerProps)
        {
            base.racerLoadJobProperties = racerProps;
            base.LoadRacerVariables();
            InitializeLoadRerun();

            this.claimHeaderRawFile = new FdOptumCareHcpClaim(racerLoadJobProperties);
            this.adHocClaimHeaderFileName = racerLoadJobProperties.AdHocClaimHeaderFilename;
            this.priorClaimIdLookupFile = racerLoadJobProperties.LookupDataClaimHeaderFilename.Replace("File.txt", "FileA_LookupPriorClaim.txt");
            this.racerClaim = new FO_BcpPlusClaimHeader();
            this.racerInsGroup = new FO_InsGroup();
            this.racerSpecialFields = new FO_BcpPlusSpecialFields();

            this.claimLineRawFile = new FdOptumCareHcpClaimLine(racerLoadJobProperties);
            this.claimLineFile = racerLoadJobProperties.AdHocClaimHeaderFilename.Replace("File.txt", "FileA.txt");
            this.claimLineLookupBeforeRollupFile = racerLoadJobProperties.LookupDataClaimHeaderFilename.Replace("File.txt", "FileA_LookupBeforeRollup.txt");
            this.racerClaimLine = new FO_BcpPlusClaimLine();

            this.diagRawFile = new FdOptumCareHcpDiag(racerLoadJobProperties);
            this.diagLookupFile = racerLoadJobProperties.LookupDataClaimHeaderFilename.Replace("File.txt", "FileB_DiagLookup.txt");
            this.icdLookupFile = racerLoadJobProperties.LookupDataClaimHeaderFilename.Replace("File.txt", "FileB_IcdLookup.txt");

            this.procRawFile = new FdOptumCareHcpProc(racerLoadJobProperties);

            this.counts = new CountUtilities();
            this.log = new LogUtilities(racerLoadJobProperties);

            if (!loadRerun.IsStepComplete(Constant.PreprocessClaimAdhocFile))
            {
                AddRacerProvisionalRawFileReader(DTStreamReaderArray.FileOutputType.RacerAndProvisionalOutput, false, false, 0, "\r\n", 0);
                AddStepCounts(Constant.PreprocessClaimAdhocFile);

                priorClaimIdLookupWriter = new StreamWriter(this.priorClaimIdLookupFile);

                racerClaimHeaderWriter = new StreamWriter(racerProps.MapperOutputClaimHeaderFilename.Replace(".txt", "Racer.txt"));
                racerClaimHeaderWriter.WriteLine(racerClaim.EmitHeaderLine());
                racerLookupInputClaimHeaderWriter = new StreamWriter(racerProps.LookupInputClaimHeaderFilename);

                racerInsGroupWriter = new StreamWriter(racerProps.MapperOutputInsuranceGroupFilename);
                racerInsGroupWriter.WriteLine(InsGroupMapper.EmitHeaderLine());
                racerLookupInputInsGroupWriter = new StreamWriter(racerProps.LookupInputInsuranceGroupFilename);

                racerSpecialFieldsWriter = new StreamWriter(racerProps.MapperOutputSpecialFieldsFilename);
                racerSpecialFieldsWriter.WriteLine(ClaimMapper.EmitSpecialFieldsHeader());

                racerLookupInputProviderWriter = new StreamWriter(racerProps.LookupInputProviderFilename, true);
                racerLookupInputMemberWriter = new StreamWriter(racerProps.LookupInputMemberFilename, true);
            }

            if (!loadRerun.IsStepComplete(Constant.PreprocessClaimAdhocFileA))
            {
                AddRacerProvisionalRawFileReader(DTStreamReaderArray.FileOutputType.ProvisionalA, false, false, 0, "\r\n", 0);
                AddStepCounts(Constant.PreprocessClaimAdhocFileA);

                claimLineLookupWriter = new StreamWriter(this.claimLineLookupBeforeRollupFile);
                claimLineLookupWriter.WriteLine(Constant.ClaimLineLookupHeader);

                racerClaimLineWriter = new StreamWriter(racerProps.MapperOutputClaimLineFilename);
                racerClaimLineWriter.WriteLine(ClaimMapper.EmitClaimLineHeader());
                racerLookupInputClaimLineWriter = new StreamWriter(racerProps.LookupInputClaimLineFilename);
            }

            if (!loadRerun.IsStepComplete(Constant.PreprocessClaimAdhocFileB))
            {
                AddRacerProvisionalRawFileReader(DTStreamReaderArray.FileOutputType.ProvisionalB, false, false, 0, "\r\n", 0);
                AddStepCounts(Constant.PreprocessClaimAdhocFileB);

                diagLookupWriter = new StreamWriter(this.diagLookupFile);
                diagLookupWriter.WriteLine(Constant.DiagToClaimLookupHeader);

                icdLookupWriter = new StreamWriter(this.icdLookupFile);
                icdLookupWriter.WriteLine(Constant.IcdLookupHeader);
            }

            if (!loadRerun.IsStepComplete(Constant.PreprocessClaimAdhocFileC))
            {
                AddRacerProvisionalRawFileReader(DTStreamReaderArray.FileOutputType.ProvisionalC, false, false, 0, "\r\n", 0);
                AddStepCounts(Constant.PreprocessClaimAdhocFileC);
            }

            this.log.Write("PreprocessClaim1060 Racer variables loaded.");
        }
        #endregion CONSTRUCTOR

        #region PREPROCESS_EXECUTE

        public override bool Execute()
        {
            try
            {
                if (!this.loadRerun.IsStepComplete(Constant.PreprocessClaim))
                {
                    this.log.Write($"Starting {this.GetType().Name} Execute()");

                    base.Execute();

                    this.loadRerun.UpdateStepStatus(Constant.PreprocessClaim, 1);
                    this.loadRerun.WriteRerunStats();
                }

                if (!this.loadRerun.IsStepComplete(Constant.PreprocessClaimCleanup))
                {
                    this.log.Write($"Starting {this.GetType().Name} Execute()");
                
                    RemoveFiles();
                
                    this.loadRerun.UpdateStepStatus(Constant.PreprocessClaimCleanup, 1);
                    this.loadRerun.WriteRerunStats();
                }

                return true;
            }

            catch (Exception exception)
            {
                this.log.Write($"Error in {this.GetType().Name} : " + exception);
                this.log.Write(exception.StackTrace);

                throw new PayerException($"Failure in  {this.GetType().Name} . See Log File for details.");
            }
        }
        #endregion PREPROCESS_EXECUTE

        #region PRIVATE_METHODS

        private void InitializeLoadRerun()
        {
            this.loadRerun = new LoadRerun(this.racerLoadJobProperties);
            this.loadRerun.Init(Constant.PreprocessClaim);
            this.loadRerun.Init(Constant.PreprocessClaimCleanup);
            this.loadRerun.Init(Constant.PreprocessClaimAdhocFile);
            this.loadRerun.Init(Constant.PreprocessClaimAdhocFileA);
            this.loadRerun.Init(Constant.PreprocessClaimAdhocFileB);
            this.loadRerun.Init(Constant.PreprocessClaimAdhocFileC);

            loadRerun.WriteRerunStats();
        }

        private void AddStepCounts(string step)
        {
            this.counts.AddCounter(step, Constant.Total);
            this.counts.AddCounter(step, Constant.Success);
            this.counts.AddCounter(step, Constant.Exception);
        }

        private void RemoveFiles()
        {
            var mapperHeaderHeaderFile = racerLoadJobProperties.MapperOutputFmtClaimHeaderFilename;
            var mapperHeaderFile = racerLoadJobProperties.MapperOutputClaimHeaderFilename;
            var mapperHeaderTmpFile = racerLoadJobProperties.MapperOutputClaimHeaderFilename.Replace(".txt", "Racer.txt");

            if (File.Exists(mapperHeaderHeaderFile))
                File.Delete(mapperHeaderHeaderFile);

            if (File.Exists(mapperHeaderFile) && File.Exists(mapperHeaderTmpFile))
            {
                File.Delete(mapperHeaderFile);
                File.Move(mapperHeaderTmpFile, mapperHeaderFile);
            }
            else
            {
                File.Move(mapperHeaderTmpFile, mapperHeaderFile);
            }

            this.log.Write($"Renamed Claim Mapper Temp Files!");
        }

        protected override void closeAdditionalRacerStreamWriters()
        {
            this.log.Write($"Starting {this.GetType().Name} Execute()");

            switch (_provisionalFileType)
            {
                case DTStreamReaderArray.FileOutputType.RacerAndProvisionalOutput:
                    loadRerun.UpdateStepStatus(Constant.PreprocessClaimAdhocFile, 1);
                    priorClaimIdLookupWriter?.FlushAndClose();
                    racerClaimHeaderWriter?.FlushAndClose();
                    racerLookupInputClaimHeaderWriter?.FlushAndClose();
                    racerInsGroupWriter?.FlushAndClose();
                    racerLookupInputInsGroupWriter?.FlushAndClose();
                    racerSpecialFieldsWriter?.FlushAndClose();
                    racerLookupInputProviderWriter?.FlushAndClose();
                    racerLookupInputMemberWriter?.FlushAndClose();

                    this.log.Write("PreprocessClaim1060 CLAIM HEADER ");
                    this.log.Write("                    CLAIM HEADER Records in : " + counts.GetCount(Constant.PreprocessClaimAdhocFile, Constant.Total).ToString() + "    Time: ");
                    this.log.Write("                    CLAIM HEADER Records out : " + counts.GetCount(Constant.PreprocessClaimAdhocFile, Constant.Success).ToString() + "    Time: ");
                    break;

                case DTStreamReaderArray.FileOutputType.ProvisionalA:
                    loadRerun.UpdateStepStatus(Constant.PreprocessClaimAdhocFileA, 1);
                    racerClaimLineWriter?.FlushAndClose();
                    racerLookupInputClaimLineWriter?.FlushAndClose();
                    claimLineLookupWriter?.FlushAndClose();

                    this.log.Write("PreprocessClaim1060 CLAIM LINE");
                    this.log.Write("                    CLAIM LINE Records in : " + counts.GetCount(Constant.PreprocessClaimAdhocFileA, Constant.Total).ToString() + "    Time: ");
                    this.log.Write("                    CLAIM LINE Records out : " + counts.GetCount(Constant.PreprocessClaimAdhocFileA, Constant.Success).ToString() + "    Time: ");
                    break;

                case DTStreamReaderArray.FileOutputType.ProvisionalB:
                    loadRerun.UpdateStepStatus(Constant.PreprocessClaimAdhocFileB, 1);
                    diagLookupWriter?.FlushAndClose();
                    icdLookupWriter?.FlushAndClose();

                    this.log.Write("PreprocessClaim1060 DIAG ");
                    this.log.Write("                    DIAG Records in : " + counts.GetCount(Constant.PreprocessClaimAdhocFileB, Constant.Total).ToString() + "    Time: ");
                    this.log.Write("                    DIAG Records out : " + counts.GetCount(Constant.PreprocessClaimAdhocFileB, Constant.Success).ToString() + "    Time: ");
                    break;

                case DTStreamReaderArray.FileOutputType.ProvisionalC:
                    loadRerun.UpdateStepStatus(Constant.PreprocessClaimAdhocFileC, 1);

                    this.log.Write("PreprocessClaim1060 PROC ");
                    this.log.Write("                    PROC Records in : " + counts.GetCount(Constant.PreprocessClaimAdhocFileC, Constant.Total).ToString() + "    Time: ");
                    this.log.Write("                    PROC Records out : " + counts.GetCount(Constant.PreprocessClaimAdhocFileC, Constant.Success).ToString() + "    Time: ");
                    break;

                default:
                    break;
            }

            loadRerun.WriteRerunStats();
        }
        #endregion PRIVATE_METHODS

        #region PROVISIONAL_PROCESSING_METHODS

        protected override string EmitProvisionalHeaderLine()
        {
            return this.claimHeaderRawFile.EmitHeaderLine(false);
        }

        protected override string EmitProvisionalLine(string line, char[] eLine)
        {
            counts.Add(Constant.PreprocessClaimAdhocFile, Constant.Total);

            this.claimHeaderRawFile.LoadFromRaw(Constant.LineScrubRegex.Replace(line, string.Empty));

            if (this.claimHeaderRawFile.IsValid)
            {
                CreateRacerClaimMappers();

                if (!string.IsNullOrEmpty(claimHeaderRawFile.CLAIM_SUFFIX))
                {
                    priorClaimIdLookupWriter.WriteLine(claimHeaderRawFile.CLAIM_SUFFIX);
                }

                counts.Add(Constant.PreprocessClaimAdhocFile, Constant.Success);
                return this.claimHeaderRawFile.ToString(false);
            }
            else
            {
                counts.Add(Constant.PreprocessClaimAdhocFile, Constant.Exception);
                emitExceptionLine("File CLAIM HEADER: " + line);
                ExceptionUtilities.CountChecker("CLAIM HEADER",
                                                counts.GetCount(Constant.PreprocessClaimAdhocFile, Constant.Total),
                                                counts.GetCount(Constant.PreprocessClaimAdhocFile, Constant.Success),
                                                counts.GetCount(Constant.PreprocessClaimAdhocFile, Constant.Exception));
            }

            return string.Empty;
        }

        protected override string EmitProvisionalHeaderLineA()
        {
            return this.claimLineRawFile.EmitHeaderLine(false);
        }

        protected override string EmitProvisionalLineA(string line, char[] eLine)
        {
            counts.Add(Constant.PreprocessClaimAdhocFileA, Constant.Total);

            this.claimLineRawFile.LoadFromRaw(Constant.LineScrubRegex.Replace(line, string.Empty));

            if (this.claimLineRawFile.IsValid)
            {
                var claimNoKey = claimLineRawFile.CLAIM_NO.Trim();
                this.claimLineRawFile.CL_DATE_OF_SERVICE_BEG = claimLineRawFile.CL_DATE_OF_SERVICE_BEG;
                this.claimLineRawFile.CL_DATE_OF_SERVICE_END = claimLineRawFile.CL_DATE_OF_SERVICE_END;
                this.claimLineRawFile.CL_AMT_BILLED = claimLineRawFile.CL_AMT_BILLED;

                if (!string.IsNullOrEmpty(claimNoKey))
                {
                    claimLineLookupWriter.WriteLine($"{claimNoKey}|{claimLineRawFile.CL_DATE_OF_SERVICE_BEG}|" +
                        $"{claimLineRawFile.CL_DATE_OF_SERVICE_END}|{claimLineRawFile.CL_AMT_BILLED}");
                }

                CreateRacerClaimLineMappers();

                counts.Add(Constant.PreprocessClaimAdhocFileA, Constant.Success);
                return this.claimLineRawFile.ToString(false);
            }
            else
            {
                counts.Add(Constant.PreprocessClaimAdhocFileA, Constant.Exception);
                emitExceptionLine("File CLAIM LINE: " + line);
                ExceptionUtilities.CountChecker("CLAIM LINE",
                                                counts.GetCount(Constant.PreprocessClaimAdhocFileA, Constant.Total),
                                                counts.GetCount(Constant.PreprocessClaimAdhocFileA, Constant.Success),
                                                counts.GetCount(Constant.PreprocessClaimAdhocFileA, Constant.Exception));
            }

            return string.Empty;
        }

        protected override string EmitProvisionalHeaderLineB()
        {
            return this.diagRawFile.EmitHeaderLine(false);
        }

        protected override string EmitProvisionalLineB(string line, char[] eLine)
        {
            counts.Add(Constant.PreprocessClaimAdhocFileB, Constant.Total);

            this.diagRawFile.LoadFromRaw(Constant.LineScrubRegex.Replace(line, string.Empty));

            if (this.diagRawFile.IsValid)
            {
                if (!string.IsNullOrEmpty(this.diagRawFile.CLAIM_NO))
                {
                    diagLookupWriter.WriteLine($"{diagRawFile.CLAIM_NO}|{diagRawFile.PRINCIPAL_DIAG}");
                    icdLookupWriter.WriteLine($"{Constant.ParentProjectId}|{diagRawFile.FEED_ID}|{diagRawFile.CLAIM_NO}|{diagRawFile.PRINCIPAL_DIAG}|" +
                        $"{diagRawFile.DIAGNOSIS_1}|{diagRawFile.DIAGNOSIS_2}|{diagRawFile.DIAGNOSIS_3}|{diagRawFile.DIAGNOSIS_4}|{diagRawFile.DIAGNOSIS_5}|" +
                        $"{diagRawFile.DIAGNOSIS_6}|{diagRawFile.DIAGNOSIS_7}|{diagRawFile.DIAGNOSIS_8}|{diagRawFile.DIAGNOSIS_9}|{diagRawFile.DIAGNOSIS_10}|" +
                        $"{diagRawFile.DIAGNOSIS_11}|{diagRawFile.DIAGNOSIS_12}|{diagRawFile.DIAGNOSIS_13}|{diagRawFile.DIAGNOSIS_14}|{diagRawFile.DIAGNOSIS_15}|" +
                        $"{diagRawFile.DIAGNOSIS_16}|{diagRawFile.DIAGNOSIS_17}|{diagRawFile.DIAGNOSIS_18}|{diagRawFile.DIAGNOSIS_19}|{diagRawFile.DIAGNOSIS_20}|" +
                        $"{diagRawFile.DIAGNOSIS_21}|{diagRawFile.DIAGNOSIS_22}|{diagRawFile.DIAGNOSIS_23}|{Constant.IcdLookupPlaceholders}");
                }

                counts.Add(Constant.PreprocessClaimAdhocFileB, Constant.Success);
                return this.diagRawFile.ToString(false);
            }
            else
            {
                counts.Add(Constant.PreprocessClaimAdhocFileB, Constant.Exception);
                emitExceptionLine("File DIAG: " + line);
                ExceptionUtilities.CountChecker("DIAG",
                                                counts.GetCount(Constant.PreprocessClaimAdhocFileB, Constant.Total),
                                                counts.GetCount(Constant.PreprocessClaimAdhocFileB, Constant.Success),
                                                counts.GetCount(Constant.PreprocessClaimAdhocFileB, Constant.Exception));
            }

            return string.Empty;
        }

        protected override string EmitProvisionalHeaderLineC()
        {
            return this.procRawFile.EmitHeaderLine(false);
        }

        protected override string EmitProvisionalLineC(string line, char[] eLine)
        {
            this.counts.Add(Constant.PreprocessClaimAdhocFileC, Constant.Total);

            this.procRawFile.LoadFromRaw(Constant.LineScrubRegex.Replace(line, string.Empty));

            if (this.procRawFile.IsValid)
            {
                this.counts.Add(Constant.PreprocessClaimAdhocFileC, Constant.Success);

                return this.procRawFile.ToString(false);
            }
            else
            {
                this.counts.Add(Constant.PreprocessClaimAdhocFileC, Constant.Exception);
                this.emitExceptionLine("File PROC: " + line);
                ExceptionUtilities.CountChecker("PROC",
                                                counts.GetCount(Constant.PreprocessClaimAdhocFileC, Constant.Total),
                                                counts.GetCount(Constant.PreprocessClaimAdhocFileC, Constant.Success),
                                                counts.GetCount(Constant.PreprocessClaimAdhocFileC, Constant.Exception));
            }

            return string.Empty;
        }
        #endregion PROVISIONAL_PROCESSING_METHODS

        #region RACER_PROCESSING_METHODS

        protected override string EmitRacerLine(string line, char[] eLine)
        {
            try
            {
                return string.Empty;
            }
            catch (Exception exception)
            {
                this.log.Write($"Error in {this.GetType().Name} : " + exception.StackTrace);
                throw new PayerException($"Failure in  {this.GetType().Name} . See Log File for details.");
            }
        }

        private void CreateRacerClaimMappers()
        {
            if (!string.IsNullOrEmpty(this.claimHeaderRawFile.CLAIM_NO))
            {
                racerSpecialFieldsWriter.WriteLine(ClaimMapper.EmitRacerSpecialFields(this.claimHeaderRawFile));
                racerClaimHeaderWriter.WriteLine(ClaimMapper.EmitRacerClaimHeader(this.claimHeaderRawFile));
                racerLookupInputClaimHeaderWriter.WriteLine(this.claimHeaderRawFile.CLAIM_NO);
            }

            if (!string.IsNullOrEmpty(this.claimHeaderRawFile.SUBSCRIBER_GROUP_POLICY_NUMBER))
            {
                racerInsGroupWriter.WriteLine(InsGroupMapper.EmitRacerInsGrpLines(this.claimHeaderRawFile));
                racerLookupInputInsGroupWriter.WriteLine(this.claimHeaderRawFile.SUBSCRIBER_GROUP_POLICY_NUMBER);
            }

            if (!string.IsNullOrEmpty(this.claimHeaderRawFile.PAT_MEMBER_NO))
            {
                racerLookupInputMemberWriter.WriteLine(this.claimHeaderRawFile.PAT_MEMBER_NO);
            }

            if (!string.IsNullOrEmpty(this.claimHeaderRawFile.SUB_MEMBER_NO))
            {
                racerLookupInputMemberWriter.WriteLine(this.claimHeaderRawFile.SUB_MEMBER_NO);
            }

            if (!string.IsNullOrEmpty(this.claimHeaderRawFile.PROVIDER_NO))
            {
                racerLookupInputProviderWriter.WriteLine(this.claimHeaderRawFile.PROVIDER_NO);
            }
        }

        private void CreateRacerClaimLineMappers()
        {
            if (!string.IsNullOrEmpty(this.claimLineRawFile.CLAIM_NO) && !string.IsNullOrEmpty(this.claimLineRawFile.LINE_NO))
            {
                racerClaimLineWriter.WriteLine(ClaimMapper.EmitRacerClaimLine(this.claimLineRawFile));
                racerLookupInputClaimLineWriter.WriteLine($"{this.claimLineRawFile.CLAIM_NO}|{this.claimLineRawFile.LINE_NO}");
            }
        }
        #endregion RACER_PROCESSING_METHODS
    }
}
