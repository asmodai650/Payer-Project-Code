using Microsoft.VisualStudio.TestTools.UnitTesting;

using Novus.Payer1060.BusinessObjects.FileObjects;

namespace Payer1060.Test.BusinessObjects.FileObjects
{
    [TestClass]
    public class FdOptumCareHcpClaimLineLookupTest
    {
        [TestMethod]
        public void TestGoodLineLength()
        {
            var goodRow = @"23261510|2021-02-07 00:00:00.000|2021-02-12 00:00:00.000|-10000.00";

            var goodLength = new FdOptumCareHcpClaimLineLookup();
            goodLength.LoadFromRaw(goodRow);

            Assert.IsTrue(goodLength.IsValid);
        }

        [TestMethod]
        public void TestBadLineLength()
        {
            var badRow = @"2021-02-07 00:00:00.000|2021-02-12 00:00:00.000|-10000.00";

            var badLength = new FdOptumCareHcpClaimLineLookup();
            badLength.LoadFromRaw(badRow);

            Assert.IsFalse(badLength.IsValid);
        }

    }
}
