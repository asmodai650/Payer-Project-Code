using Microsoft.VisualStudio.TestTools.UnitTesting;
using Novus.Payer1060.BusinessObjects.Lookups;

namespace Payer1060.Test.BusinessObjects.Lookups
{
    [TestClass]
    public class RelInsGrpLookup1060Test
    {
        [DataTestMethod]
        [DataRow("M", "11")]
        [DataRow("m", "11")]
        [DataRow("F", "12")]
        [DataRow("f", "12")]
        [DataRow("x", "13")]
        [DataRow("", "13")]
        public void RelInsGroupTest(string relLookup, string expected)
        {
            var actual = LookupRelationshipToInsuredId1060.InsIdLookup(relLookup);

            Assert.AreEqual(expected, actual);
        }
    }
}
