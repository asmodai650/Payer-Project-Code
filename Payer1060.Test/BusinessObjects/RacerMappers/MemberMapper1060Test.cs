using Microsoft.VisualStudio.TestTools.UnitTesting;
using Novus.Payer1060.BusinessObjects.RacerMappers;

namespace Payer1060.Test.BusinessObjects.RacerMappers
{
    [TestClass]
    public class MemberMapper1060Test
    {
        [DataTestMethod]
        [DataRow(" EL MONTE,CA", "EL MONTE")]
        [DataRow("PAHRUMP             NV89041", "PAHRUMP")]
        [DataRow("NASHVILLE, TN", "NASHVILLE")]
        [DataRow(".", ".")]
        [DataRow(".CA", ".CA")]
        [DataRow("", "")]
        public void GetCityTest(string ctySt, string expected)
        {
            var actual = MemberMapper.GetCityFromCtySt(ctySt);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(" EL MONTE,CA", "CA")]
        [DataRow("PAHRUMP             NV89041", "NV")]
        [DataRow("NASHVILLE, TN", "TN")]
        [DataRow(".", "")]
        [DataRow(".CA", "")]
        [DataRow("", "")]
        public void GetStateTest(string ctySt, string expected)
        {
            var actual = MemberMapper.GetStateFromCtySt(ctySt);
            Assert.AreEqual(expected, actual);
        }
    }
}
