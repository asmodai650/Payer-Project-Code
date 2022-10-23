using Microsoft.VisualStudio.TestTools.UnitTesting;

using Novus.Payer1060.BusinessObjects.FileObjects;

namespace Payer1060.Test.BusinessObjects.FileObjects
{
    [TestClass]
    public class FdOptumCareHcpDiagTest
    {
        [TestMethod]
        public void TestGoodLineLength()
        {
            var goodRow = @"12|23261510|S72.401A|M97.11XA|B37.0|C92.01|D68.69|D84.821|E27.1|I69.951|M54.9|T38.0X5A|E03.9|E78.00|E78.5|F32.5|F40.240|G40.909|G90.9|I10|I48.0|I70.0|I73.9|K21.9|K44.9|Z88.5|Y|Y|Y|Y|Y|Y|Y||Y|Y|Y|Y|Y|Y|Y|Y|Y|Y|Y|Y|Y|Y|Y|";

            var goodLength = new FdOptumCareHcpDiag();
            goodLength.LoadFromRaw(goodRow);

            Assert.IsTrue(goodLength.IsValid);
        }

        [TestMethod]
        public void TestBadLineLength()
        {
            var badRow = @"S72.401A|M97.11XA|B37.0|C92.01|D68.69|D84.821|E27.1|I69.951|M54.9|T38.0X5A|E03.9|E78.00|E78.5|F32.5|F40.240|G40.909|G90.9|I10|I48.0|I70.0|I73.9|K21.9|K44.9|Z88.5|Y|Y|Y|Y|Y|Y|Y||Y|Y|Y|Y|Y|Y|Y|Y|Y|Y|Y|Y|Y|Y|Y|";

            var badLength = new FdOptumCareHcpDiag();
            badLength.LoadFromRaw(badRow);

            Assert.IsFalse(badLength.IsValid);
        }

    }
}
