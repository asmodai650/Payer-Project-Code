using Microsoft.VisualStudio.TestTools.UnitTesting;

using Novus.Payer1060.BusinessObjects.FileObjects;

namespace Payer1060.Test.BusinessObjects.FileObjects
{
    [TestClass]
    public class LookupDiagProcToIcdMapperTest
    {
        [TestMethod]
        public void TestGoodLineLength()
        {
            var goodRow = @"1454|1|23270514|F03.91||||||||||||||||||||||||XW033E5|5A1955Z|XW033H5|0BH18EZ|05HM33Z|05HN33Z|B544ZZA||||||||||||||||||G30.9|ICD10";

            var goodLength = new LookupDiagProcToIcdMapper();
            goodLength.LoadFromRaw(goodRow);

            Assert.IsTrue(goodLength.IsValid);
        }

        [TestMethod]
        public void TestBadLineLength()
        {
            var badRow = @"|23270514|F03.91||||||||||||||||||||||||XW033E5|5A1955Z|XW033H5|0BH18EZ|05HM33Z|05HN33Z|B544ZZA||||||||||||||||||G30.9|ICD10";

            var badLength = new LookupDiagProcToIcdMapper();
            badLength.LoadFromRaw(badRow);

            Assert.IsFalse(badLength.IsValid);
        }

    }
}
