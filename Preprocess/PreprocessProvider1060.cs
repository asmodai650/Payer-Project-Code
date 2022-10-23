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
    public class PreprocessProvider1060 : PreProcessProviderBaseAuto
    {
        #region DECLARATIONS

        //Provider
        private readonly FdOptumCareHcpProvider providerRawObject;

        //RacerStreamWriters
        private readonly FO_Provider racerProvider;
        private readonly StreamWriter racerProviderWriter;
        private readonly StreamWriter racerLookupInputProviderWriter;

        //Common to all files
        private readonly CountUtilities counts;
        private LoadRerun loadRerun;
        private readonly LogUtilities log;
        #endregion DECLARATIONS

        #region CONSTRUCTORS

        public PreprocessProvider1060(RacerLoadJobReadOnlyProperties racerProps)
        {
            base.racerLoadJobProperties = racerProps;
            base.LoadRacerVariables();
            InitializeLoadRerun();

            this.providerRawObject = new FdOptumCareHcpProvider(racerLoadJobProperties);
            this.racerProvider = new FO_Provider();

            this.counts = new CountUtilities();
            this.log = new LogUtilities(racerLoadJobProperties);

            if (!loadRerun.IsStepComplete(Constant.PreprocessProvAdhocFile))
            {
                AddRacerProvisionalRawFileReader(DTStreamReaderArray.FileOutputType.RacerAndProvisionalOutput, false, false, 0, "\r\n", 0);
                AddStepCounts(Constant.PreprocessProvAdhocFile);

                racerProviderWriter = new StreamWriter(racerProps.MapperOutputProviderFilename.Replace(".txt", "Racer.txt"));
                racerProviderWriter.WriteLine(ProviderMapper.EmitHeaderLine());

                racerLookupInputProviderWriter = new StreamWriter(racerProps.LookupInputProviderFilename);
            }

            this.log.Write("PreprocessProvider1060 Racer variables loaded.");
        }
        #endregion CONSTRUCTORS

        #region PREPROCESS_EXECUTE

        public override bool Execute()
        {
            try
            {
                if (!this.loadRerun.IsStepComplete(Constant.PreprocessProvider))
                {
                    this.log.Write($"Starting {this.GetType().Name} Execute()");

                    base.Execute();

                    this.loadRerun.UpdateStepStatus(Constant.PreprocessProvider, 1);
                    this.loadRerun.WriteRerunStats();
                }

                if (!this.loadRerun.IsStepComplete(Constant.PreprocessProviderCleanup))
                {
                    this.log.Write($"Starting {this.GetType().Name} Execute()");

                    RemoveFiles();

                    this.loadRerun.UpdateStepStatus(Constant.PreprocessProviderCleanup, 1);
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
            loadRerun.Init(Constant.PreprocessProvider);
            loadRerun.Init(Constant.PreprocessProviderCleanup);
            loadRerun.Init(Constant.PreprocessProvAdhocFile);

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
            var mapperProviderFile = racerLoadJobProperties.MapperOutputProviderFilename;
            var mapperProviderTmpFile = racerLoadJobProperties.MapperOutputProviderFilename.Replace(".txt", "Racer.txt");

            if (File.Exists(mapperProviderFile) && File.Exists(mapperProviderTmpFile))
            {
                File.Delete(mapperProviderFile);
                File.Move(mapperProviderTmpFile, mapperProviderFile);
            }
            else
            {
                File.Move(mapperProviderTmpFile, mapperProviderFile);
            }

            this.log.Write($"Renamed Provider Mapper Temp Files!");
        }

        protected override void closeAdditionalRacerStreamWriters()
        {
            loadRerun.UpdateStepStatus(Constant.PreprocessProvAdhocFile, 1);
            racerProviderWriter?.FlushAndClose();
            racerLookupInputProviderWriter?.FlushAndClose();

            this.log.Write("PreprocessProvider1060 PROVIDER ");
            this.log.Write("                       PROVIDER Records in : " + counts.GetCount(Constant.PreprocessProvAdhocFile, Constant.Total).ToString() + "    Time: ");
            this.log.Write("                       PROVIDER Records out : " + counts.GetCount(Constant.PreprocessProvAdhocFile, Constant.Success).ToString() + "    Time: ");

            loadRerun.WriteRerunStats();
        }
        #endregion PRIVATE_METHODS

        #region PROVISIONAL_PROCESSING_METHODS

        protected override string EmitProvisionalHeaderLine()
        {
            return this.providerRawObject.EmitHeaderLine(false);
        }

        protected override string EmitProvisionalLine(string line, char[] eLine)
        {
            counts.Add(Constant.PreprocessProvAdhocFile, Constant.Total);

            this.providerRawObject.LoadFromRaw(Constant.LineScrubRegex.Replace(line, string.Empty));

            if (this.providerRawObject.IsValid)
            {
                CreateRacerProviderMappers();

                counts.Add(Constant.PreprocessProvAdhocFile, Constant.Success);
                return this.providerRawObject.ToString(false);
            }
            else
            {
                counts.Add(Constant.PreprocessProvAdhocFile, Constant.Exception);
                emitExceptionLine("File PROVIDER: " + line);
                ExceptionUtilities.CountChecker("PROVIDER",
                                                counts.GetCount(Constant.PreprocessProvAdhocFile, Constant.Total),
                                                counts.GetCount(Constant.PreprocessProvAdhocFile, Constant.Success),
                                                counts.GetCount(Constant.PreprocessProvAdhocFile, Constant.Exception));
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

        private void CreateRacerProviderMappers()
        {
            if (!String.IsNullOrEmpty(this.providerRawObject.PROVIDER_NO))
            {
                this.racerProviderWriter.WriteLine(ProviderMapper.EmitRacerLine(this.providerRawObject));
                this.racerLookupInputProviderWriter.WriteLine(this.providerRawObject.PROVIDER_NO);
            }
        }
        #endregion RACER_PROCESSING_METHODS
    }
}
