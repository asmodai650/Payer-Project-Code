using Microsoft.VisualStudio.TestTools.UnitTesting;

using Novus.Payer1060.BusinessObjects.FileObjects;

namespace Payer1060.Test.BusinessObjects.FileObjects
{
    [TestClass]
    public class FdOptumCareHcpProcTest
    {
        [TestMethod]
        public void TestGoodLineLength()
        {
            var goodRow = @"1|12|23261510|0SPC0JZ|0SRC0J9|0SBC0ZZ|3E0U029|||||||||||||||||||||2/8/2021 0:00:00|2/8/2021 0:00:00|2/8/2021 0:00:00|2/8/2021 0:00:00||||||||||||||||||||";

            var goodLength = new FdOptumCareHcpProc();
            goodLength.LoadFromRaw(goodRow);

            Assert.IsTrue(goodLength.IsValid);
        }

        [TestMethod]
        public void TestBadLineLength()
        {
            var badRow = @"23261510|0SPC0JZ|0SRC0J9|0SBC0ZZ|3E0U029|||||||||||||||||||||2/8/2021 0:00:00|2/8/2021 0:00:00|2/8/2021 0:00:00|2/8/2021 0:00:00||||||||||||||||||||";

            var badLength = new FdOptumCareHcpProc();
            badLength.LoadFromRaw(badRow);

            Assert.IsFalse(badLength.IsValid);
        }

    }
}
