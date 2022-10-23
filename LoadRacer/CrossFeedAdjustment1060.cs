using System;
using Novus.Payer1060.BusinessObjects.Utilities;
using Novus.PayerBase;
using Novus.Toolbox;

namespace Novus.Payer1060
{
    /// <summary>
    /// class CrossFeedAdjustment1060.
    /// </summary>
    public class CrossFeedAdjustment1060 : CrossFeedAdjPostProcessBase
    {
        #region CONSTRUCTORS

        /// <summary>
        /// Initializes a new instance of the CrossFeedAdjustment1060 class.
        /// </summary>
        /// <param name="racerProperties"> Racer properties </param>
        public CrossFeedAdjustment1060(RacerLoadJobReadOnlyProperties racerProperties)
        {
            RacerReadOnlyProperties = racerProperties;
        }
        #endregion

        #region METHODS
        /// <summary>
        /// Executes various methods here 
        /// </summary>
        /// <returns> Returns of type bool </returns>
        public override bool Execute()
        {
            RacerReadOnlyProperties.LogWriter.Write(JobId, "Starting Cross Feed Adjustment Update. " + RacerReadOnlyProperties.ProjectName, DateTime.Now.ToString());

            bool result = true;

            ///This stored procedure is used to set the adjusted flag to 2 for adjusted claims that are not in protected status.

            result = ExecuteSP("HdsAppCrossFeedAdjOptumCareHCP_1060", ProjectId, FeedId);

            if (!result)
            {
                throw new PayerException("CrossFeedAdjustment1060 failed!");
            }

            RacerReadOnlyProperties.LogWriter.Write(JobId, "Cross Feed Adjustment Update Completed. " + RacerReadOnlyProperties.ProjectName, DateTime.Now.ToString());

            return true;
        }
        #endregion
    }
}