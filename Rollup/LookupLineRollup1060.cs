using System.Collections.Generic;
using Novus.Toolbox;
using Novus.Payer1060.BusinessObjects.FileObjects;

namespace Novus.Payer1060
{
    /// <summary>
    /// Extension of the basic ClaimRollup class.
    /// Contains list of claim(line) objects that will have some values summed.
    /// </summary>
    public class LookupLineRollup1060 : ClaimRollup
    {
        /// <summary>
        /// Holds all non accumulated values and allows for easy ToString() functionality.
        /// </summary>
        public List<FdOptumCareHcpClaimLineLookup> LookupLineList { get; set; }

        /// <summary>
        /// Expose the current claim objects for easy comparisons.
        /// </summary>
        public string ClaimNo { get; set; }

        public string DosBeg { get; set; }

        public string DosEnd { get; set; }

        public string AmtBilled { get; set; }

        public LookupLineRollup1060()
        {
            this.LookupLineList = new List<FdOptumCareHcpClaimLineLookup>();
            this.ClaimNo = string.Empty;
            this.DosBeg = string.Empty;
            this.DosEnd = string.Empty;
            this.AmtBilled = string.Empty;
        }

        public override void Clear()
        {
            this.LookupLineList?.Clear();
            this.LookupLineList?.TrimExcess();
            this.ClaimNo = string.Empty;
            this.DosBeg = string.Empty;
            this.DosEnd = string.Empty;
            this.AmtBilled = string.Empty;

            base.Clear();
        }
    }
}
