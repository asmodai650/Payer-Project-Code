using System;
using System.IO;
using Novus.PayerBase;
using Novus.Toolbox;
using Novus.Sort;
using Novus.Interfaces;
using Novus.Payer1060.BusinessObjects.Constants;
using Novus.Payer1060.BusinessObjects.FileObjects;
using Novus.Payer1060.BusinessObjects.Utilities;

namespace Novus.Payer1060
{

    public class PrepareProvider1060 : IPrepareJob
    {
        public PrepareProvider1060(RacerLoadJobReadOnlyProperties racerLoadJobProperties)
        {
            RacerReadOnlyProperties = racerLoadJobProperties;
        }

        #region DECLARATIONS
        private RacerLoadJobReadOnlyProperties racerProps = null;
        private string lookupInputProviderFile = string.Empty;
        private string mapperOutputProviderFile = string.Empty;
        private string formatFile = string.Empty;
        private FieldMapper fieldMapper;
        private int PROVIDER_NO = -1;
        private SortJobFactory sortFactory;
        private ISortJob sortJob;
        private string[] successfulPrepString = new string[2];
        private string logSortFile = string.Empty;
        private int jobID = 0;
        private int projectID = 0;
        private bool isLookupInputFileSorted = false;
        private bool isMapperOutputFileSorted = false;
        #endregion DECLARATIONS

        #region PROPERTIES

        public RacerLoadJobReadOnlyProperties RacerReadOnlyProperties
        {
            set
            {
                this.racerProps = value;
                LoadRacerVariables();
            }
            get
            {
                return this.racerProps;
            }
        }
        #endregion PROPERTIES

        public bool Execute()
        {
            this.racerProps.LogWriter.Write(this.jobID, "PrepareProvider1060", "Starting PrepareProvider1060 - Time:" + DateTime.Now.ToString());

            this.isLookupInputFileSorted = SortLookupInputProviderFile();

            if (isLookupInputFileSorted)
            {
                this.isMapperOutputFileSorted = SortMapperOutputProviderFile();
            }
            if (!isMapperOutputFileSorted)
            {
                this.racerProps.LogWriter.Write(this.jobID, "PrepareProvider1060", "Failed SortMapperOutputProviderFile - Time:" + DateTime.Now.ToString());

                return false;
            }

            this.racerProps.LogWriter.Write(this.jobID, "PrepareProvider1060", "Ending PrepareProvider1060  - Time:" + DateTime.Now.ToString());

            return true;
        }

        public bool Execute(RacerLoadJobReadOnlyProperties racerLoadJobProperties)
        {
            RacerReadOnlyProperties = racerLoadJobProperties;
            return Execute();
        }

        private void LoadRacerVariables()
        {
            this.jobID = this.racerProps.JobID;
            this.projectID = this.racerProps.ProjectID;

            this.lookupInputProviderFile = this.racerProps.LookupInputProviderFilename;
            this.mapperOutputProviderFile = this.racerProps.MapperOutputProviderFilename;
            this.formatFile = this.racerProps.MapperOutputFmtProviderFilename;
            this.logSortFile = this.racerProps.LogSortFilename;

            ///Get field locations within the file
            this.fieldMapper = new FieldMapper();
            this.PROVIDER_NO = fieldMapper.GetFieldNo("PROVIDER_NO", this.formatFile);
        }

        private bool SortLookupInputProviderFile()
        {
            this.racerProps.LogWriter.Write(this.jobID, "SortLookupInputProviderFile", "Time:" + DateTime.Now.ToString());

            string successfulPrep = string.Empty;

            this.sortFactory = new SortJobFactory();
            this.sortJob = this.sortFactory.getSortJob(this.projectID);
            this.sortJob.ByPassHeaderRow = false;
            this.sortJob.InputFile = this.lookupInputProviderFile;
            this.sortJob.SortInPlace = true;
            this.sortJob.SortKeyAdd(1, SType.StandardCharacterData, SortDirection.Ascending);
            this.sortJob.DuplicateProcessing(iDups.OutputFirstFoundOnlyDupsAndUniques, "#" + 1);

            this.sortJob.LogProcess(true, this.logSortFile.ToString(), false);
            successfulPrep = this.sortJob.Sort();

            if (successfulPrep.Split('|')[1] != "0")
            {
                this.racerProps.LogWriter.Write(this.jobID, "SortLookupInputProviderFile FAILED!! ", "Time:" + DateTime.Now.ToString());
                throw new PayerException("SortLookupInputProviderFile - Time:" + DateTime.Now.ToString());
            }

            this.racerProps.LogWriter.Write(this.jobID, "SortLookupInputProviderFile SUCCESSFUL!! ", "Time:" + DateTime.Now.ToString());

            return true;
        }

        private bool SortMapperOutputProviderFile()
        {
            this.racerProps.LogWriter.Write(this.jobID, "SortMapperOutputProviderFile", "Time:" + DateTime.Now.ToString());

            string successfulPrep = string.Empty;

            this.sortFactory = new SortJobFactory();
            this.sortJob = this.sortFactory.getSortJob(this.projectID);
            this.sortJob.ByPassHeaderRow = true;
            this.sortJob.FieldDelimiter = "|";
            this.sortJob.InputFile = this.mapperOutputProviderFile;
            this.sortJob.SortInPlace = true;
            this.sortJob.SortKeyAdd(this.PROVIDER_NO, SType.StandardCharacterData, SortDirection.Ascending);
            this.sortJob.DuplicateProcessing(iDups.OutputFirstFoundOnlyDupsAndUniques, "#" + this.PROVIDER_NO);
            this.sortJob.LogProcess(true, this.logSortFile.ToString(), false);
            successfulPrep = this.sortJob.Sort();

            if (successfulPrep.Split('|')[1] != "0")
            {
                this.racerProps.LogWriter.Write(this.jobID, "SortMapperOutputProviderFile FAILED!! ", "Time:" + DateTime.Now.ToString());
                throw new PayerException("SortMapperOutputProviderFile - Time:" + DateTime.Now.ToString());
            }

            this.racerProps.LogWriter.Write(this.jobID, "SortMapperOutputProviderFile SUCCESSFUL!! ", "Time:" + DateTime.Now.ToString());

            return true;
        }
    }
}
