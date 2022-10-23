using Microsoft.VisualStudio.TestTools.UnitTesting;

using Novus.Payer1060.BusinessObjects.FileObjects;

namespace Payer1060.Test.BusinessObjects.FileObjects
{
    [TestClass]
    public class FdOptumCareHcpClaimLineTest
    {
        [TestMethod]
        public void TestGoodLineLength()
        {
            var goodRow = @"12|23261510|1||210216963742I||2/7/2021 0:00:00|2/12/2021 0:00:00|121|121||||||21||||5911800||||($10000.00)|$0.00|$0.00|$31763.81|$0.00|$0.00|$0.00|($13963.81)|$31763.81|$0.00|$0.00|$0.00|$0.00|$0.00|$31763.81|4/12/2021 0:00:00|20580|1902844988|203BP0100X|FACILITY SERVICES|Y||PROVIDENCE LCM MED CTR TORRANC|1902844988||Fee for Service|Provider|4/7/2021 0:00:00|REJECTION|45| ||||";

            var goodLength = new FdOptumCareHcpClaimLine();
            goodLength.LoadFromRaw(goodRow);

            Assert.IsTrue(goodLength.IsValid);
        }

        [TestMethod]
        public void TestBadLineLength()
        {
            var badRow = @"1||210216963742I||2/7/2021 0:00:00|2/12/2021 0:00:00|121|121||||||21||||5911800||||($10000.00)|$0.00|$0.00|$31763.81|$0.00|$0.00|$0.00|($13963.81)|$31763.81|$0.00|$0.00|$0.00|$0.00|$0.00|$31763.81|4/12/2021 0:00:00|20580|1902844988|203BP0100X|FACILITY SERVICES|Y||PROVIDENCE LCM MED CTR TORRANC|1902844988||Fee for Service|Provider|4/7/2021 0:00:00|REJECTION|45| ||||";

            var badLength = new FdOptumCareHcpClaimLine();
            badLength.LoadFromRaw(badRow);

            Assert.IsFalse(badLength.IsValid);
        }

    }
}
