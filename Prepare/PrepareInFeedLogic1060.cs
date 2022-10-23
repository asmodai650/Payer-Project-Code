using System;
using System.IO;
using System.Collections.Generic;
using Novus.Toolbox;
using Novus.Payer1060.BusinessObjects.Constants;
using Novus.Payer1060.BusinessObjects.Utilities;

namespace Novus.Payer1060
{
    public class PrepareInFeedLogic1060
    {
        #region DECLARATIONS

        ///Prior ClaimId Lookup File
        private readonly List<string> priorClaimId;

        ///Racer Claim streamWriter and Mapper
        private readonly string racerClaimFileBefore;
        private readonly string racerClaimFile;

        ///Common to all files
        private LoadRerun loadRerun;
        private readonly LogUtilities log;
        private readonly RacerLoadJobReadOnlyProperties racerLoadJobProperties;
        #endregion DECLARATIONS

        #region CONSTRUCTOR

        public PrepareInFeedLogic1060(RacerLoadJobReadOnlyProperties racerProps)
        {
            this.racerLoadJobProperties = racerProps;
            InitializeLoadRerun();

            this.priorClaimId = new List<string>();

            this.racerClaimFileBefore = racerLoadJobProperties.MapperOutputClaimHeaderFilename;

            this.racerClaimFile = racerLoadJobProperties.MapperOutputClaimHeaderFilename.Replace(".txt", "InFeedAdjust.txt");

            this.log = new LogUtilities(racerLoadJobProperties);

            this.log.Write("PrepareInFeedLogic1060 Racer variables loaded.");
        }
        #endregion CONSTRUCTOR

        #region PREPARE_EXECUTE

        public bool Execute()
        {
            try
            {
                if (!this.loadRerun.IsStepComplete(Constant.PrepareInFeedWrite))
                {
                    this.log.Write($"Starting {this.GetType().Name} Execute()");

                    LoadPriorClaimId();
                    WriteClaimMapperFile();
                    RemoveFile()
;
                    this.loadRerun.UpdateStepStatus(Constant.PrepareInFeedWrite, 1);
                    this.loadRerun.WriteRerunStats();
                }

                this.loadRerun.UpdateStepStatus(Constant.PrepareInFeedLogic, 1);
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
            this.loadRerun.Init(Constant.PrepareInFeedLogic);
            this.loadRerun.Init(Constant.PrepareInFeedWrite);

            loadRerun.WriteRerunStats();
        }

        private void LoadPriorClaimId()
        {
            using (var priorClaimIdLookupReader = new StreamReader(racerLoadJobProperties.LookupDataClaimHeaderFilename.Replace("File.txt", "FileA_LookupPriorClaim.txt")))
            {
                var lookupLine = string.Empty;
                while ((lookupLine = priorClaimIdLookupReader.ReadLine()) != null)
                {
                    if (!priorClaimId.Contains(lookupLine))
                    {
                        priorClaimId.Add(lookupLine);
                    }
                }
            }
        }

        private void WriteClaimMapperFile()
        {
            FO_BcpPlusClaimHeader racerClaim;

            using (var racerClaimFileBeforeReader = new StreamReader(this.racerClaimFileBefore))
            using (var racerClaimWriter = new StreamWriter(this.racerClaimFile))
            {
                var mapperLine = string.Empty;
                while ((mapperLine = racerClaimFileBeforeReader.ReadLine()) != null)
                {
                    racerClaim = new FO_BcpPlusClaimHeader();
                    racerClaim.LoadFromString(mapperLine);

                    if (!priorClaimId.Contains(racerClaim.CLAIM_NO))
                    {
                        racerClaimWriter.WriteLine(mapperLine);
                    }
                }
            }
        }

        private void RemoveFile()
        {
            if (File.Exists(racerClaimFileBefore) && File.Exists(racerClaimFile))
            {
                File.Delete(racerClaimFileBefore);
                File.Move(racerClaimFile, racerClaimFileBefore);
            }
            else
            {
                File.Move(racerClaimFile, racerClaimFileBefore);
            }

            this.log.Write($"Renamed Claim Mapper Temp Files!");
        }
        #endregion PRIVATE_METHODS
    }
}
