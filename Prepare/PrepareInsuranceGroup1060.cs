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

    public class PrepareInsuranceGroup1060 : IPrepareJob
    {
        public PrepareInsuranceGroup1060(RacerLoadJobReadOnlyProperties racerLoadJobProperties)
        {
            RacerReadOnlyProperties = racerLoadJobProperties;
        }

        #region DECLARATIONS
        private RacerLoadJobReadOnlyProperties racerProps = null;
        private string lookupInputInsGroupFile = string.Empty;
        private string mapperOutputInsGroupFile = string.Empty;
        private string formatFile = string.Empty;
        private FieldMapper fieldMapper;
        private int INS_GROUP_NO = -1;
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
            this.racerProps.LogWriter.Write(this.jobID, "PrepareInsGroup1060", "Starting PrepareInsGroup1060 - Time:" + DateTime.Now.ToString());

            this.isLookupInputFileSorted = SortLookupInputInsGroupFile();

            if (isLookupInputFileSorted)
            {
                this.isMapperOutputFileSorted = SortMapperOutputInsGroupFile();
            }
            if (!isMapperOutputFileSorted)
            {
                this.racerProps.LogWriter.Write(this.jobID, "PrepareInsGroup1060", "Failed PrepareInsGroup1060 - Time:" + DateTime.Now.ToString());

                return false;
            }

            this.racerProps.LogWriter.Write(this.jobID, "PrepareInsGroup1060", "Ending PrepareInsGroup1060  - Time:" + DateTime.Now.ToString());

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

            this.lookupInputInsGroupFile = this.racerProps.LookupInputInsuranceGroupFilename;
            this.mapperOutputInsGroupFile = this.racerProps.MapperOutputInsuranceGroupFilename;
            this.formatFile = this.racerProps.MapperOutputFmtInsuranceGroupFilename;
            this.logSortFile = this.racerProps.LogSortFilename;

            ///Get field locations within the file
            this.fieldMapper = new FieldMapper();
            this.INS_GROUP_NO = fieldMapper.GetFieldNo("INS_GROUP_NO", this.formatFile);
        }

        private bool SortLookupInputInsGroupFile()
        {
            this.racerProps.LogWriter.Write(this.jobID, "SortLookupInputInsGroupFile", "Time:" + DateTime.Now.ToString());

            string successfulPrep = string.Empty;

            this.sortFactory = new SortJobFactory();
            this.sortJob = this.sortFactory.getSortJob(this.projectID);
            this.sortJob.ByPassHeaderRow = false;
            this.sortJob.InputFile = this.lookupInputInsGroupFile;
            this.sortJob.SortInPlace = true;
            this.sortJob.SortKeyAdd(1, SType.StandardCharacterData, SortDirection.Ascending);
            this.sortJob.DuplicateProcessing(iDups.OutputFirstFoundOnlyDupsAndUniques, "#" + 1);

            this.sortJob.LogProcess(true, this.logSortFile.ToString(), false);
            successfulPrep = this.sortJob.Sort();

            if (successfulPrep.Split('|')[1] != "0")
            {
                this.racerProps.LogWriter.Write(this.jobID, "SortLookupInputInsGroupFile FAILED!! ", "Time:" + DateTime.Now.ToString());
                throw new PayerException("SortLookupInputInsGroupFile - Time:" + DateTime.Now.ToString());
            }

            this.racerProps.LogWriter.Write(this.jobID, "SortLookupInputInsGroupFile SUCCESSFUL!! ", "Time:" + DateTime.Now.ToString());

            return true;
        }

        private bool SortMapperOutputInsGroupFile()
        {
            this.racerProps.LogWriter.Write(this.jobID, "SortMapperOutputInsGroupFile", "Time:" + DateTime.Now.ToString());

            string successfulPrep = string.Empty;

            this.sortFactory = new SortJobFactory();
            this.sortJob = this.sortFactory.getSortJob(this.projectID);
            this.sortJob.ByPassHeaderRow = true;
            this.sortJob.FieldDelimiter = "|";
            this.sortJob.InputFile = this.mapperOutputInsGroupFile;
            this.sortJob.SortInPlace = true;
            this.sortJob.SortKeyAdd(this.INS_GROUP_NO, SType.StandardCharacterData, SortDirection.Ascending);
            this.sortJob.DuplicateProcessing(iDups.OutputFirstFoundOnlyDupsAndUniques, "#" + this.INS_GROUP_NO);
            this.sortJob.LogProcess(true, this.logSortFile.ToString(), false);
            successfulPrep = this.sortJob.Sort();

            if (successfulPrep.Split('|')[1] != "0")
            {
                this.racerProps.LogWriter.Write(this.jobID, "SortMapperOutputInsGroupFile FAILED!! ", "Time:" + DateTime.Now.ToString());
                throw new PayerException("SortMapperOutputInsGroupFile - Time:" + DateTime.Now.ToString());
            }

            this.racerProps.LogWriter.Write(this.jobID, "SortMapperOutputInsGroupFile SUCCESSFUL!! ", "Time:" + DateTime.Now.ToString());

            return true;
        }
    }
}
