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

    public class PrepareMember1060 : IPrepareJob
    {
        public PrepareMember1060(RacerLoadJobReadOnlyProperties racerLoadJobProperties)
        {
            RacerReadOnlyProperties = racerLoadJobProperties;
        }

        #region DECLARATIONS
        private RacerLoadJobReadOnlyProperties racerProps = null;
        private string lookupInputMemberFile = string.Empty;
        private string mapperOutputMemberFile = string.Empty;
        private string formatFile = string.Empty;
        private FieldMapper fieldMapper;
        private int MEMBER_NO = -1;
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
            this.racerProps.LogWriter.Write(this.jobID, "PrepareMember1060", "Starting PrepareMember1060 - Time:" + DateTime.Now.ToString());

            this.isLookupInputFileSorted = SortLookupInputMemberFile();

            if (isLookupInputFileSorted)
            {
                this.isMapperOutputFileSorted = SortMapperOutputMemberFile();
            }
            if (!isMapperOutputFileSorted)
            {
                this.racerProps.LogWriter.Write(this.jobID, "PrepareMember1060", "Failed SortMapperOutputMemberFile - Time:" + DateTime.Now.ToString());

                return false;
            }

            this.racerProps.LogWriter.Write(this.jobID, "PrepareMember1060", "Ending PrepareMember1060  - Time:" + DateTime.Now.ToString());

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

            this.lookupInputMemberFile = this.racerProps.LookupInputMemberFilename;
            this.mapperOutputMemberFile = this.racerProps.MapperOutputMemberFilename;
            this.formatFile = this.racerProps.MapperOutputFmtMemberFilename;
            this.logSortFile = this.racerProps.LogSortFilename;

            ///Get field locations within the file
            this.fieldMapper = new FieldMapper();
            this.MEMBER_NO = fieldMapper.GetFieldNo("MEMBER_NO", this.formatFile);
        }

        private bool SortLookupInputMemberFile()
        {
            this.racerProps.LogWriter.Write(this.jobID, "SortLookupInputMemberFile", "Time:" + DateTime.Now.ToString());

            string successfulPrep = string.Empty;

            this.sortFactory = new SortJobFactory();
            this.sortJob = this.sortFactory.getSortJob(this.projectID);
            this.sortJob.ByPassHeaderRow = false;
            this.sortJob.InputFile = this.lookupInputMemberFile;
            this.sortJob.SortInPlace = true;
            this.sortJob.SortKeyAdd(1, SType.StandardCharacterData, SortDirection.Ascending);
            this.sortJob.DuplicateProcessing(iDups.OutputFirstFoundOnlyDupsAndUniques, "#" + 1);

            this.sortJob.LogProcess(true, this.logSortFile.ToString(), false);
            successfulPrep = this.sortJob.Sort();

            if (successfulPrep.Split('|')[1] != "0")
            {
                this.racerProps.LogWriter.Write(this.jobID, "SortLookupInputMemberFile FAILED!! ", "Time:" + DateTime.Now.ToString());
                throw new PayerException("SortLookupInputMemberFile - Time:" + DateTime.Now.ToString());
            }

            this.racerProps.LogWriter.Write(this.jobID, "SortLookupInputMemberFile SUCCESSFUL!! ", "Time:" + DateTime.Now.ToString());

            return true;
        }

        private bool SortMapperOutputMemberFile()
        {
            this.racerProps.LogWriter.Write(this.jobID, "SortMapperOutputMemberFile", "Time:" + DateTime.Now.ToString());

            string successfulPrep = string.Empty;

            this.sortFactory = new SortJobFactory();
            this.sortJob = this.sortFactory.getSortJob(this.projectID);
            this.sortJob.ByPassHeaderRow = true;
            this.sortJob.FieldDelimiter = "|";
            this.sortJob.InputFile = this.mapperOutputMemberFile;
            this.sortJob.SortInPlace = true;
            this.sortJob.SortKeyAdd(this.MEMBER_NO, SType.StandardCharacterData, SortDirection.Ascending);
            this.sortJob.DuplicateProcessing(iDups.OutputFirstFoundOnlyDupsAndUniques, "#" + this.MEMBER_NO);
            this.sortJob.LogProcess(true, this.logSortFile.ToString(), false);
            successfulPrep = this.sortJob.Sort();

            if (successfulPrep.Split('|')[1] != "0")
            {
                this.racerProps.LogWriter.Write(this.jobID, "SortMapperOutputMemberFile FAILED!! ", "Time:" + DateTime.Now.ToString());
                throw new PayerException("SortMapperOutputMemberFile - Time:" + DateTime.Now.ToString());
            }

            this.racerProps.LogWriter.Write(this.jobID, "SortMapperOutputMemberFile SUCCESSFUL!! ", "Time:" + DateTime.Now.ToString());

            return true;
        }
    }
}
