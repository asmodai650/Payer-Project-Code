using Microsoft.VisualStudio.TestTools.UnitTesting;

using Novus.Payer1060.BusinessObjects.FileObjects;

namespace Payer1060.Test.BusinessObjects.FileObjects
{
    [TestClass]
    public class FdOptumCareHcpClaimTest
    {
        [TestMethod]
        public void TestGoodLineLength()
        {
            var goodRow = @"12|23261510|ORIGINAL|||||2/16/2021 0:00:00|N|||PROVIDER||25-1086037||||SENIOR|Fee for Service||||APPROVED|PAID|4/12/2021 0:00:00|76200104997300||Institutional|NA|111|21||||$181790.24|$0.00|$0.00||$0.00|$0.00|$0.00|$150026.43|$31763.81|$0.00|$0.00|$0.00|$0.00|$0.00|$31763.81|4/12/2021 0:00:00|4/12/2021 0:00:00|6683473|2/7/2021 0:00:00|2/12/2021 0:00:00|5911800||ELECTIVE|TRANSFER FROM A SNF|2/7/2021 0:00:00|08:29PM|DISCHARGE - HOME|2/12/2021 0:00:00|12:00PM|3016585|SELF|3016585|310852659-01|SCAN HEALTH PLAN|SH5425M|SCAN (SH5425M)|SENIOR|CA|275758||42-1672810|203BP0100X|FACILITY SERVICES|20580|1902844988|203BP0100X|A0|Y|||1902844988|0|||1104236330||||||ICD10|||||||467||||M97.11XA||||||NA|||||11|2/7/2021 0:00:00|||||||||||||||||||80|5||||||||||||||REGION III";

            var goodLength = new FdOptumCareHcpClaim();
            goodLength.LoadFromRaw(goodRow);

            Assert.IsTrue(goodLength.IsValid);
        }

        [TestMethod]
        public void TestBadLineLength()
        {
            var badRow = @"23261510|ORIGINAL|||||2/16/2021 0:00:00|N|||PROVIDER||25-1086037||||SENIOR|Fee for Service||||APPROVED|PAID|4/12/2021 0:00:00|76200104997300||Institutional|NA|111|21||||$181790.24|$0.00|$0.00||$0.00|$0.00|$0.00|$150026.43|$31763.81|$0.00|$0.00|$0.00|$0.00|$0.00|$31763.81|4/12/2021 0:00:00|4/12/2021 0:00:00|6683473|2/7/2021 0:00:00|2/12/2021 0:00:00|5911800||ELECTIVE|TRANSFER FROM A SNF|2/7/2021 0:00:00|08:29PM|DISCHARGE - HOME|2/12/2021 0:00:00|12:00PM|3016585|SELF|3016585|310852659-01|SCAN HEALTH PLAN|SH5425M|SCAN (SH5425M)|SENIOR|CA|275758||42-1672810|203BP0100X|FACILITY SERVICES|20580|1902844988|203BP0100X|A0|Y|||1902844988|0|||1104236330||||||ICD10|||||||467||||M97.11XA||||||NA|||||11|2/7/2021 0:00:00|||||||||||||||||||80|5||||||||||||||REGION III";

            var badLength = new FdOptumCareHcpClaim();
            badLength.LoadFromRaw(badRow);

            Assert.IsFalse(badLength.IsValid);
        }

    }
}
