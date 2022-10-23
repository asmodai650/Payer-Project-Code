using Microsoft.VisualStudio.TestTools.UnitTesting;
using Novus.Payer1060.BusinessObjects.Lookups;

namespace Payer1060.Test.BusinessObjects.Lookups
{
    [TestClass]
    public class LobLookup1060Test
    {
        [DataTestMethod]
        [DataRow("commercial", "1")]
        [DataRow("point OF service", "1")]
        [DataRow("medi-cal", "6")]
        [DataRow("senior", "8")]
        [DataRow("xxyyzz", "0")]
        [DataRow("", "0")]
        public void ClientLobTest(string lobLookup, string expected)
        {
            var actual = LookupLineOfBusinessId1060.LobLookup(lobLookup);

            Assert.AreEqual(expected, actual);
        }
    }
}
