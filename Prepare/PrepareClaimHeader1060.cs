using System.IO;
using System.Reflection;
using Novus.PayerBase;
using Novus.Sort;
using Novus.Toolbox;
using Novus.Payer1060.BusinessObjects.Constants;
using Novus.Payer1060.BusinessObjects.Utilities;

namespace Novus.Payer1060
{
    public class PrepareClaimHeader1060 : PrepareClaimHeaderBase
    {
        private LoadRerun loadRerun;
        private readonly LogUtilities log;
        private readonly SortUtilities sorter;

        private readonly string adHocClaim;
        private readonly string adHocClaimFmt;

        private readonly string lookupInput;

        public PrepareClaimHeader1060(RacerLoadJobReadOnlyProperties racerProperties)
        {
            this.racerLoadJobProperties = racerProperties;
            this.log = new LogUtilities(this.racerLoadJobProperties);
            this.sorter = new SortUtilities(this.racerLoadJobProperties);

            InitializeLoadRerun();

            this.adHocClaim = this.racerLoadJobProperties.AdHocClaimHeaderFilename;
            this.adHocClaimFmt = this.racerLoadJobProperties.AdHocClaimHeaderFilename.Replace(".txt", ".fmt");

            this.lookupInput = this.racerLoadJobProperties.LookupInputClaimHeaderFilename;
        }

        public override bool Execute()
        {
            //this file is required for PrepareSpecialFieldsStandard (a base class called in the child prepare step)
            if (!File.Exists(this.racerLoadJobProperties.MapperOutputFmtSpecialFieldsFilename))
                BcpFormatFileUtilities.CreateRacerFormatFile(this.racerLoadJobProperties.MapperOutputFmtSpecialFieldsFilename, BulkCopy.BcpFileFormats.mapperOutputSpecialFieldsFile);

            if (!this.loadRerun.IsStepComplete(Constant.SortClaimHeader))
            {
                SortAdHoc();

                this.loadRerun.UpdateStepStatus(Constant.SortClaimHeader, 1);
                this.loadRerun.WriteRerunStats();
            }
            if (!this.loadRerun.IsStepComplete(Constant.SortLookupInput))
            {
                SortLookupInput();

                this.loadRerun.UpdateStepStatus(Constant.SortLookupInput, 1);
                this.loadRerun.UpdateStepStatus(Constant.PrepareClaimHeader, 1);
                this.loadRerun.WriteRerunStats();
            }
            else
            {
                this.log.Write($"{Constant.PrepareClaimHeader} is already complete!");
            }

            return true;
        }

        private void InitializeLoadRerun()
        {
            this.loadRerun = new LoadRerun(this.racerLoadJobProperties);
            this.loadRerun.Init(Constant.PrepareClaimHeader);
            this.loadRerun.WriteRerunStats();
        }

        private void SortAdHoc()
        {
            this.log.Write($"Starting {MethodBase.GetCurrentMethod().Name}");

            if (!this.racerLoadJobProperties.UseMockRawFiles)
                BcpFormatFileUtilities.CreateFormatFile(this.racerLoadJobProperties.AdHocConnectionString, "FD_OPTUMCARE_HCP_CLM", this.adHocClaim);

            this.sorter.Clear();
            this.sorter.SetFile(this.adHocClaim, true);
            this.sorter.SetFormatFile(this.adHocClaimFmt);
            this.sorter.AddSortField("CLAIM_NO", SType.StandardCharacterData);
            this.sorter.Sort();

            this.log.Write($"Completed {MethodBase.GetCurrentMethod().Name}");
        }

        private void SortLookupInput()
        {
            this.log.Write($"Starting {MethodBase.GetCurrentMethod().Name}");

            this.sorter.Clear();
            this.sorter.SetFile(this.lookupInput, false);
            this.sorter.AddSortField(1, SType.StandardCharacterData);
            this.sorter.Sort();

            this.log.Write($"Completed {MethodBase.GetCurrentMethod().Name}");
        }
    }
}