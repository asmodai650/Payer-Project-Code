using Microsoft.VisualStudio.TestTools.UnitTesting;

using Novus.Payer1060.BusinessObjects.FileObjects;

namespace Payer1060.Test.BusinessObjects.FileObjects
{
    [TestClass]
    public class FdOptumCareHcpProviderTest
    {
        [TestMethod]
        public void TestGoodLineLength()
        {
            var goodRow = @"20427|Entity|03|1972514503|01-1111111|||||HOMECARE PHARMACY|||||PO BOX 999|||CITY, CA  99999-9999|||||||99 ATLANTIC AVE||||CITY, CA 99999-9999||999-999-9999||||33||||||||796|CITY MEM MED CTR INC|||1/1/2003|";

            var goodLength = new FdOptumCareHcpProvider();
            goodLength.LoadFromRaw(goodRow);

            Assert.IsTrue(goodLength.IsValid);
        }

        [TestMethod]
        public void TestBadLineLength()
        {
            var badRow = @"03|1972514503|01-1111111|||||HOMECARE PHARMACY|||||PO BOX 999|||CITY, CA  99999-9999|||||||99 ATLANTIC AVE||||CITY, CA 99999-9999||999-999-9999||||33||||||||796|CITY MEM MED CTR INC|||1/1/2003|";

            var badLength = new FdOptumCareHcpProvider();
            badLength.LoadFromRaw(badRow);

            Assert.IsFalse(badLength.IsValid);
        }

    }
}
