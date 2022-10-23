using System;
using Novus.PayerBase;
using Novus.Toolbox;
using Novus.Payer1060.BusinessObjects.Utilities;

namespace Novus.Payer1060
{
    public class ClaimIdPostProcess1060 : ClaimIdPostProcessBase
    {
        #region Constructors

        public ClaimIdPostProcess1060(RacerLoadJobReadOnlyProperties racerProperties)
        {
            this.RacerReadOnlyProperties = racerProperties;
        }
        #endregion Constructors

        #region Methods

        public override bool Execute()
        {
            this._racerProps.LogWriter.Write(this._jobID, "Starting Optumcare HCP ClaimId Update. " + this._racerProps.ProjectName, DateTime.Now.ToString());

            bool result = true;

            result = ExecuteSP("usp_ProvisionalClaimIdUpdate", "FD_OPTUMCARE_HCP_CLM");
            result = ExecuteSP("usp_ProvisionalClaimIdUpdate", "FD_OPTUMCARE_HCP_CLIN");

            if (!result)
            {
                throw new PayerException("BASE CLASS FAILURE IN EXECUTE ClaimIdPostProcess CLM TABLE PROCESS - PROCESSING STOPPED!");
            }

            _racerProps.LogWriter.Write(this._jobID, "Optumcare HCP ClaimId Update Completed. " + _racerProps.ProjectName, DateTime.Now.ToString());

            return result;
        }
        #endregion Methods
    }
}
