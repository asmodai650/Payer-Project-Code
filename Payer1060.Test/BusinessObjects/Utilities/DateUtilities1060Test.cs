using Microsoft.VisualStudio.TestTools.UnitTesting;
using Novus.Payer1060.BusinessObjects.Utilities;

namespace Payer1060.Test.BusinessObjects.Utilities
{
    [TestClass]
    public class DateUtilities1060Test
    {
        [DataTestMethod]
        [DataRow("05/06/1995", "1995-05-06 00:00:00.000")]
        [DataRow("1995-05-06", "1995-05-06 00:00:00.000")]
        public void CheckDateTest(string rawDate, string expected)
        {
            var actual = DateUtilities.CheckDate(rawDate);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("1700-05-06 00:00:00.000", "")]
        [DataRow("1995-05-06 00:00:00.000", "1995-05-06 00:00:00.000")]
        [DataRow("10000-05-06 00:00:00.000", "")]
        public void GetDateTest(string yearDate, string expected)
        {
            var actual = DateUtilities.CheckDate(yearDate);

            Assert.AreEqual(expected, actual);
        }


        [DataTestMethod]
        [DataRow("1700-05-06 00:00:00.000", "")]
        [DataRow("1995-05-06 00:00:00.000", "1995-05-06")]
        [DataRow("10000-05-06 00:00:00.000", "")]
        public void GetRacerDateTest(string yearDate, string expected)
        {
            var actual = DateUtilities.GetRacerDate(yearDate);

            Assert.AreEqual(expected, actual);
        }
    }
}
