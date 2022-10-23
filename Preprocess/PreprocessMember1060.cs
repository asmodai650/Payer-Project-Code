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
    public class PreprocessMember1060 : PreProcessMemberBaseAuto
    {
        #region DECLARATIONS

        //Member
        private readonly FdOptumCareHcpMem memberRawObject;

        //RacerStreamWriters
        private readonly FO_Member racerMember;
        private readonly StreamWriter racerMemberWriter;
        private readonly StreamWriter racerLookupInputMemberWriter;

        //Common to all files
        private readonly CountUtilities counts;
        private LoadRerun loadRerun;
        private readonly LogUtilities log;
        #endregion DECLARATIONS

        #region CONSTRUCTORS

        public PreprocessMember1060(RacerLoadJobReadOnlyProperties racerProps)
        {
            base.racerLoadJobProperties = racerProps;
            base.LoadRacerVariables();
            InitializeLoadRerun();

            this.memberRawObject = new FdOptumCareHcpMem(racerLoadJobProperties);
            this.racerMember = new FO_Member();

            this.counts = new CountUtilities();
            this.log = new LogUtilities(racerLoadJobProperties);

            if (!loadRerun.IsStepComplete(Constant.PreprocessMemAdhocFile))
            {
                AddRacerProvisionalRawFileReader(DTStreamReaderArray.FileOutputType.RacerAndProvisionalOutput, false, false, 0, "\r\n", 0);
                AddStepCounts(Constant.PreprocessMemAdhocFile);

                racerMemberWriter = new StreamWriter(racerProps.MapperOutputMemberFilename.Replace(".txt", "Racer.txt"));
                racerMemberWriter.WriteLine(MemberMapper.EmitHeaderLine());

                racerLookupInputMemberWriter = new StreamWriter(racerProps.LookupInputMemberFilename);
            }

            this.log.Write("PreprocessMember1060 Racer variables loaded.");
        }
        #endregion CONSTRUCTORS

        #region PREPROCESS_EXECUTE

        public override bool Execute()
        {
            try
            {
                if (!this.loadRerun.IsStepComplete(Constant.PreprocessMember))
                {
                    this.log.Write($"Starting {this.GetType().Name} Execute()");

                    base.Execute();

                    this.loadRerun.UpdateStepStatus(Constant.PreprocessMember, 1);
                    this.loadRerun.WriteRerunStats();
                }

                if (!this.loadRerun.IsStepComplete(Constant.PreprocessMemberCleanup))
                {
                    this.log.Write($"Starting {this.GetType().Name} Execute()");

                    RemoveFiles();

                    this.loadRerun.UpdateStepStatus(Constant.PreprocessMemberCleanup, 1);
                    this.loadRerun.WriteRerunStats();
                }

                return true;
            }

            catch (Exception exception)
            {
                this.log.Write($"Error in {this.GetType().Name} : " + exception.StackTrace);
                throw new PayerException($"Failure in  {this.GetType().Name} . See Log File for details.");
            }
        }
        #endregion PREPROCESS_EXECUTE

        #region PRIVATE_METHODS

        private void InitializeLoadRerun()
        {
            loadRerun = new LoadRerun(this.racerLoadJobProperties);
            loadRerun.Init(Constant.PreprocessMember);
            loadRerun.Init(Constant.PreprocessMemberCleanup);
            loadRerun.Init(Constant.PreprocessMemAdhocFile);

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
            var mapperMemberFile = racerLoadJobProperties.MapperOutputMemberFilename;
            var mapperMemberTmpFile = racerLoadJobProperties.MapperOutputMemberFilename.Replace(".txt", "Racer.txt");

            if (File.Exists(mapperMemberFile) && File.Exists(mapperMemberTmpFile))
            {
                File.Delete(mapperMemberFile);
                File.Move(mapperMemberTmpFile, mapperMemberFile);
            }
            else
            {
                File.Move(mapperMemberTmpFile, mapperMemberFile);
            }

            this.log.Write($"Renamed Provider Mapper Temp Files!");
        }

        protected override void closeAdditionalRacerStreamWriters()
        {
            loadRerun.UpdateStepStatus(Constant.PreprocessMemAdhocFile, 1);
            racerMemberWriter?.FlushAndClose();
            racerLookupInputMemberWriter?.FlushAndClose();

            this.log.Write("PreprocessMember1060 MEMBER ");
            this.log.Write("                     MEMBER Records in : " + counts.GetCount(Constant.PreprocessMemAdhocFile, Constant.Total).ToString() + "    Time: ");
            this.log.Write("                     MEMBER Records out : " + counts.GetCount(Constant.PreprocessMemAdhocFile, Constant.Success).ToString() + "    Time: ");

            loadRerun.WriteRerunStats();
        }
        #endregion PRIVATE_METHODS

        #region PROVISIONAL_PROCESSING_METHODS

        protected override string EmitProvisionalHeaderLine()
        {
            return this.memberRawObject.EmitHeaderLine(false);
        }

        protected override string EmitProvisionalLine(string line, char[] eLine)
        {
            counts.Add(Constant.PreprocessMemAdhocFile, Constant.Total);

            this.memberRawObject.LoadFromRaw(Constant.LineScrubRegex.Replace(line, string.Empty));

            if (this.memberRawObject.IsValid)
            {
                CreateRacerMemberMappers();

                counts.Add(Constant.PreprocessMemAdhocFile, Constant.Success);

                return this.memberRawObject.ToString(false);
            }
            else
            {
                counts.Add(Constant.PreprocessMemAdhocFile, Constant.Exception);
                emitExceptionLine("File MEMBER: " + line);
                ExceptionUtilities.CountChecker("MEMBER",
                                                counts.GetCount(Constant.PreprocessMemAdhocFile, Constant.Total),
                                                counts.GetCount(Constant.PreprocessMemAdhocFile, Constant.Success),
                                                counts.GetCount(Constant.PreprocessMemAdhocFile, Constant.Exception));
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

        private void CreateRacerMemberMappers()
        {
            if (!String.IsNullOrEmpty(this.memberRawObject.PAT_MEMBER_NO))
            {
                this.racerMemberWriter.WriteLine(MemberMapper.EmitRacerLine(this.memberRawObject));
                this.racerLookupInputMemberWriter.WriteLine(this.memberRawObject.PAT_MEMBER_NO);
            }
        }
        #endregion RACER_PROCESSING_METHODS
    }
}
