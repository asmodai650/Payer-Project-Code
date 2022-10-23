using System.IO;
using System.Linq;
using Novus.PayerBase;
using Novus.Toolbox;
using Novus.Payer1060.BusinessObjects.Constants;
using Novus.Payer1060.BusinessObjects.Utilities;

namespace Novus.Payer1060
{
    public class ProvisionalLoad1060 : ProvisionalLoadBase
    {
        private readonly LogUtilities log;
        public ProvisionalLoad1060(RacerLoadJobReadOnlyProperties racerProperties)
        {
            this.RacerReadOnlyProperties = racerProperties;
            this.log = new LogUtilities(this.RacerReadOnlyProperties);
        }

        public override bool Execute()
        {
            this.log.Write("Starting Provisional Load: " + this._racerProps.ProjectName);
            this.FileDirectory = Path.Combine(this._racerProps.FeedDirectoryName, this._racerProps.FeedID.ToString());

            ///get table and file pairs from Constants
            var tableFiles = Constant.GetProvisionalTableFileMap(this._racerProps.ProjectID).ToArray();

            bool isSucceeded = false;
            foreach (var tableFile in tableFiles)
            {
                var tableName = tableFile.Split(',')[0].Trim();
                var stageTableName = (tableFile.Split(',')[0].Trim() + "_STAGE");
                var dataFileName = (tableFile.Split(',')[1].Trim() + ".txt");

                isSucceeded = LoadToTable(stageTableName, tableName, dataFileName);

                if (!isSucceeded)
                {
                    throw new PayerException($"BASE CLASS FAILURE IN EXECUTE ProvisionalLoad PROCESS: table {tableName} file {dataFileName}");
                }
            }

            this.log.Write("Completed Provisional Load: " + this._racerProps.ProjectName);

            return isSucceeded;
        }

        private bool LoadToTable(string stageTableName, string tableName, string dataFileName)
        {
            bool isSucceeded;
            if (this._racerProps.FeedID > 0 && this._racerProps.FeedID < 14000 && this._racerProps.ServerType == ServerType.ProductionServer)
            {
                isSucceeded = LoadByPartitionSwitch(stageTableName, tableName, dataFileName);
            }
            else
            {
                isSucceeded = LoadDirect(tableName, dataFileName);
            }
            return isSucceeded;
        }

        private bool LoadDirect(string tableName, string dataFileName)
        {
            bool isSucceeded = true;
            if (File.Exists(Path.Combine(this.FileDirectory, dataFileName)))
            {
                isSucceeded = ExecuteLoad(tableName, dataFileName);
            }
            return isSucceeded;
        }

        private bool LoadByPartitionSwitch(string stageTableName, string tableName, string dataFileName)
        {
            bool isSucceeded = true;
            if (File.Exists(Path.Combine(this.FileDirectory, dataFileName)))
            {
                if (CheckFeedAlreadyLoaded(tableName))
                {
                    TruncateStageTables(stageTableName);
                    isSucceeded = ExecuteLoad(stageTableName, Constant.pathDelimeter + dataFileName, true, true);

                    if (isSucceeded)
                        isSucceeded = LoadedPartitionSwitchTables(stageTableName, tableName, this.FeedId);
                }
                else
                {
                    this.log.Write(
                        "Information : Skipping load to stage table " + stageTableName + " because rows existed in primary table for feed. " +
                        "Skipping loading for this table. ");
                    isSucceeded = true;
                }
            }
            return isSucceeded;
        }
    }
}
