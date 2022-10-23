using Microsoft.VisualStudio.TestTools.UnitTesting;
using Novus.Payer1060.BusinessObjects.RacerMappers;

namespace Payer1060.Test.BusinessObjects.RacerMappers
{
    [TestClass]
    public class ProviderMapper1060Test
    {
        [DataTestMethod]
        [DataRow("FT. WORTH, TX  76104", "FT. WORTH")]
        [DataRow("MILWAUKEE, WI  53216-2298", "MILWAUKEE")]
        [DataRow("S. PORTLAND, ME  04106", "S. PORTLAND")]
        [DataRow("ST LOUIS. MO  63126-031", "ST LOUIS. MO  63126-031")]
        [DataRow("W. COVINA, CA  ", "W. COVINA")]
        [DataRow("", "")]
        public void GetCityTest(string provMailCity, string expected)
        {
            var actual = ProviderMapper.GetCityFromProvMailCity(provMailCity);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("FT. WORTH, TX  76104", "TX")]
        [DataRow("MILWAUKEE, WI  53216-2298", "WI")]
        [DataRow("S. PORTLAND, ME  04106", "ME")]
        [DataRow("ST LOUIS. MO  63126-031", "")]
        [DataRow("W. COVINA, CA  ", "CA")]
        [DataRow("", "")]
        public void GetStateTest(string provMailState, string expected)
        {
            var actual = ProviderMapper.GetStateFromProvMailCity(provMailState);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("FT. WORTH, TX  76104", "76104")]
        [DataRow("MILWAUKEE, WI  53216-2298", "53216-2298")]
        [DataRow("S. PORTLAND, ME  04106", "04106")]
        [DataRow("ST LOUIS. MO  63126-031", "63126-031")]
        [DataRow("W. COVINA, CA  ", "")]
        [DataRow("", "")]
        [DataRow("NASHVILLE, TN  3721-0001", "3721-0001")]
        public void GetZipCodeTest(string provMailZip, string expected)
        {
            var actual = ProviderMapper.GetZipFromProvMailCity(provMailZip);
            Assert.AreEqual(expected, actual);
        }
    }
}
