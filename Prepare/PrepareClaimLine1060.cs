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

    public class PrepareClaimLine1060 : IPrepareJob
    {
        public PrepareClaimLine1060(RacerLoadJobReadOnlyProperties racerLoadJobProperties)
        {
            RacerReadOnlyProperties = racerLoadJobProperties;
        }

        #region DECLARATIONS
        private RacerLoadJobReadOnlyProperties racerProps = null;
        private string lookupInputClaimLineFile = string.Empty;
        private string mapperOutputClaimLineFile = string.Empty;
        private string formatFile = string.Empty;
        private FieldMapper fieldMapper;
        private int CLAIM_NO = -1;
        private int LINE_NO = -1;
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
            this.racerProps.LogWriter.Write(this.jobID, "PrepareClaimLine1060", "Starting PrepareClaimLine1060 - Time:" + DateTime.Now.ToString());

            this.isLookupInputFileSorted = SortLookupInputClaimLineFile();

            if (isLookupInputFileSorted)
            {
                this.isMapperOutputFileSorted = SortMapperOutputClaimLineFile();
            }
            if (!isMapperOutputFileSorted)
            {
                this.racerProps.LogWriter.Write(this.jobID, "PrepareClaimLine1060", "Failed PrepareClaimLine1060 - Time:" + DateTime.Now.ToString());

                return false;
            }

            this.racerProps.LogWriter.Write(this.jobID, "PrepareClaimLine1060", "Ending PrepareClaimLine1060  - Time:" + DateTime.Now.ToString());

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

            this.lookupInputClaimLineFile = this.racerProps.LookupInputClaimLineFilename;
            this.mapperOutputClaimLineFile = this.racerProps.MapperOutputClaimLineFilename;
            this.formatFile = this.racerProps.MapperOutputFmtClaimLineFilename;
            this.logSortFile = this.racerProps.LogSortFilename;

            ///Get field locations within the file
            this.fieldMapper = new FieldMapper();
            this.CLAIM_NO = fieldMapper.GetFieldNo("CLAIM_NO", this.formatFile);
            this.LINE_NO = fieldMapper.GetFieldNo("LINE_NO", this.formatFile);
        }

        private bool SortLookupInputClaimLineFile()
        {
            this.racerProps.LogWriter.Write(this.jobID, "SortLookupInputClaimLineFile", "Time:" + DateTime.Now.ToString());

            string successfulPrep = string.Empty;

            this.sortFactory = new SortJobFactory();
            this.sortJob = this.sortFactory.getSortJob(this.projectID);
            this.sortJob.ByPassHeaderRow = false;
            this.sortJob.FieldDelimiter = "|";
            this.sortJob.InputFile = this.lookupInputClaimLineFile;
            this.sortJob.SortInPlace = true;
            this.sortJob.SortKeyAdd(1, SType.StandardCharacterData, SortDirection.Ascending);
            this.sortJob.SortKeyAdd(2, SType.StandardCharacterData, SortDirection.Ascending);
            this.sortJob.DuplicateProcessing(iDups.OutputFirstFoundOnlyDupsAndUniques, "#" + 1 + ",#" + 2);

            this.sortJob.LogProcess(true, this.logSortFile.ToString(), false);
            successfulPrep = this.sortJob.Sort();

            if (successfulPrep.Split('|')[1] != "0")
            {
                this.racerProps.LogWriter.Write(this.jobID, "SortLookupInputClaimLineFile FAILED!! ", "Time:" + DateTime.Now.ToString());
                throw new PayerException("SortLookupInputClaimLineFile - Time:" + DateTime.Now.ToString());
            }

            this.racerProps.LogWriter.Write(this.jobID, "SortLookupInputClaimLineFile SUCCESSFUL!! ", "Time:" + DateTime.Now.ToString());

            return true;
        }

        private bool SortMapperOutputClaimLineFile()
        {
            this.racerProps.LogWriter.Write(this.jobID, "SortMapperOutputClaimLineFile", "Time:" + DateTime.Now.ToString());

            string successfulPrep = string.Empty;

            this.sortFactory = new SortJobFactory();
            this.sortJob = this.sortFactory.getSortJob(this.projectID);
            this.sortJob.ByPassHeaderRow = true;
            this.sortJob.FieldDelimiter = "|";
            this.sortJob.InputFile = this.mapperOutputClaimLineFile;
            this.sortJob.SortInPlace = true;
            this.sortJob.SortKeyAdd(this.CLAIM_NO, SType.StandardCharacterData, SortDirection.Ascending);
            this.sortJob.SortKeyAdd(this.LINE_NO, SType.StandardCharacterData, SortDirection.Ascending);
            this.sortJob.DuplicateProcessing(iDups.OutputFirstFoundOnlyDupsAndUniques, "#" + this.CLAIM_NO + ",#" + this.LINE_NO);
            this.sortJob.LogProcess(true, this.logSortFile.ToString(), false);
            successfulPrep = this.sortJob.Sort();

            if (successfulPrep.Split('|')[1] != "0")
            {
                this.racerProps.LogWriter.Write(this.jobID, "SortMapperOutputClaimLineFile FAILED!! ", "Time:" + DateTime.Now.ToString());
                throw new PayerException("SortMapperOutputClaimLineFile - Time:" + DateTime.Now.ToString());
            }

            this.racerProps.LogWriter.Write(this.jobID, "SortMapperOutputClaimLineFile SUCCESSFUL!! ", "Time:" + DateTime.Now.ToString());

            return true;
        }
    }
}
