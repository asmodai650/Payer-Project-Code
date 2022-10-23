using Microsoft.VisualStudio.TestTools.UnitTesting;
using Novus.Payer1060.BusinessObjects.Utilities;

namespace Payer1060.Test.BusinessObjects.Utilities
{
    [TestClass]
    public class MoneyUtilities1060Test
    {
        [DataTestMethod]
        [DataRow("$100.00", "100.00")]
        [DataRow("($100.00)", "-100.00")]
        [DataRow("100.00", "100.00")]
        [DataRow("0", "0.00")]
        [DataRow("","")]
        public void FormatMoneyTest(string dollar, string expected)
        {
            var actual = MoneyUtilities.FormatMoney(dollar);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("0", "0.00")]
        [DataRow("1", "0.01")]
        [DataRow("10", "0.10")]
        [DataRow("100", "1.00")]
        [DataRow("1000", "10.00")]
        [DataRow("10000", "100.00")]
        [DataRow("123456789", "1234567.89")]
        [DataRow("", "")]
        public void AmountFormatTest(string amount, string expected)
        {
            var actual = MoneyUtilities.AmountFormat(amount);

            Assert.AreEqual(expected, actual);
        }
    }
}
