using System.IO;
using Novus.Payer1060.BusinessObjects.Utilities;
using Novus.PayerShared;
using Novus.Toolbox;

namespace Novus.Payer1060
{
    /// <summary>
    /// This class is a replacement for Novus.PayerShared.PreSplitStandard. The methods of PreSplitStandard are not marked virtual or abstract and cannot be overridden.
    /// This version voids deleting bcpPlus files for icd9 and special fields which were created in Prepare.
    /// </summary>
    public class PreRacer1060
    {
        protected RacerLoadJobReadOnlyProperties _racerProps;
        protected int _jobID;

        private readonly LogUtilities log;

        public PreRacer1060()
        {
        }

        public PreRacer1060(RacerLoadJobReadOnlyProperties passedRacerLoadJobReadOnlyProperties)
        {
            _racerProps = passedRacerLoadJobReadOnlyProperties;
            _jobID = _racerProps.JobID;

            this.log = new LogUtilities(_racerProps);
        }

        public bool Execute()
        {
            this.log.Write("PreRacer1060");

            ///clean the bcp files before split runs.
            DeleteExistingBCPFiles();

            AdditionalPreProcessesToRun();

            this.log.Write("PreRacer1060");

            return true;
        }

        /// <summary>
        /// Use this method to add additional pre processes to run for all clients before the
        /// normal pre process steps
        /// </summary>
        protected virtual void AdditionalPreProcessesToRun()
        {
           /// If you wish to customize this format creator process then override this method.
            BaseFormatCreator formatCreator = new BaseFormatCreator(_racerProps);
            formatCreator.CreateBCPFormatFile();

            if (!File.Exists(this._racerProps.MapperOutputFmtClaimHeaderFilename))
                BcpFormatFileUtilities.CreateRacerFormatFile(this._racerProps.MapperOutputFmtClaimHeaderFilename, BulkCopy.BcpFileFormats.mapperOutputClaimHeaderFile);

            if (!File.Exists(this._racerProps.MapperOutputFmtClaimLineFilename))
                BcpFormatFileUtilities.CreateRacerFormatFile(this._racerProps.MapperOutputFmtClaimLineFilename, BulkCopy.BcpFileFormats.mapperOutputClaimLineFile);

            if (!File.Exists(this._racerProps.MapperOutputFmtICD9Filename))
                BcpFormatFileUtilities.CreateRacerFormatFile(this._racerProps.MapperOutputFmtICD9Filename, BulkCopy.BcpFileFormats.mapperOutputICD9File);

            if (!File.Exists(this._racerProps.MapperOutputFmtSpecialFieldsFilename))
                BcpFormatFileUtilities.CreateRacerFormatFile(this._racerProps.MapperOutputFmtSpecialFieldsFilename, BulkCopy.BcpFileFormats.mapperOutputSpecialFieldsFile);

            if (!File.Exists(this._racerProps.MapperOutputFmtInsuranceGroupFilename))
                BcpFormatFileUtilities.CreateRacerFormatFile(this._racerProps.MapperOutputFmtInsuranceGroupFilename, BulkCopy.BcpFileFormats.mapperOutputInsuranceGroupFile);

            if (!File.Exists(this._racerProps.MapperOutputFmtMemberFilename))
                BcpFormatFileUtilities.CreateRacerFormatFile(this._racerProps.MapperOutputFmtMemberFilename, BulkCopy.BcpFileFormats.mapperOutputMemberFile);

            if (!File.Exists(this._racerProps.MapperOutputFmtProviderFilename))
                BcpFormatFileUtilities.CreateRacerFormatFile(this._racerProps.MapperOutputFmtProviderFilename, BulkCopy.BcpFileFormats.mapperOutputProviderFile);
        }

        protected bool DeleteExistingBCPFiles()
        {
            //-- delete all BCPPlus files with prefixes as noted in the execute
            int indx = _racerProps.BcpPlusAdjustmentFlagFilename.ToString().LastIndexOf("\\");
            string dir = _racerProps.BcpPlusFmtClaimHeaderFilename.Substring(0, indx);
            string[] files = Directory.GetFiles(dir);

            try
            {
                foreach (string f in files)
                {
                    //Check if we have a file to delete
                    if (f.ToUpper().IndexOf("BCPPLUSCLAIMHEADERFILE") > -1)
                        File.Delete(f);
                    if (f.ToUpper().IndexOf("BCPPLUSCLAIMLINEFILE") > -1)
                        File.Delete(f);
                    if (f.ToUpper().IndexOf("BCPPLUSICD9FILE") > -1)
                        File.Delete(f);
                    if (f.ToUpper().IndexOf("BCPPLUSSPECIALFIELDSFILE") > -1)
                        File.Delete(f);
                    if (f.ToUpper().IndexOf("BCPPLUSINSURANCEGROUPFILE") > -1)
                        File.Delete(f);
                    if (f.ToUpper().IndexOf("BCPPLUSMEMBERFILE") > -1)
                        File.Delete(f);
                    if (f.ToUpper().IndexOf("BCPPLUSPROVIDERFILE") > -1)
                        File.Delete(f);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
