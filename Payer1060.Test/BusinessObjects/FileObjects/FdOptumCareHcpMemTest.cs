using Microsoft.VisualStudio.TestTools.UnitTesting;

using Novus.Payer1060.BusinessObjects.FileObjects;

namespace Payer1060.Test.BusinessObjects.FileObjects
{
    [TestClass]
    public class FdOptumCareHcpMemTest
    {
        [TestMethod]
        public void TestGoodLineLength()
        {
            var goodRow = @"3016585|3016585|SELF|123456789-01||4HT3M29MK91|4HT3M29MK91|2/1/2020 0:00:00|3/31/2022 0:00:00|FIRSTNAME|NA|LASTNAME||9999 W 9TH ST||CITY,CA|CA|99999|999-999-9999|F|5/24/1945 0:00:00||3||SH5425M|SCAN (SH5425M)|NA||NA|NA||123456789-01|LASTNAME, FIRSTNAME|145001|SCAN HEALTH PLAN||SENIOR|NA|NA|NA|NA|NA||3/31/2022 0:00:00|2/1/2020 0:00:00|6/1/2010 0:00:00||12|1/1/2021 0:00:00|12/31/2021 0:00:00||";

            var goodLength = new FdOptumCareHcpMem();
            goodLength.LoadFromRaw(goodRow);

            Assert.IsTrue(goodLength.IsValid);
        }

        [TestMethod]
        public void TestBadLineLength()
        {
            var badRow = @"SELF|123456789-01||4HT3M29MK91|4HT3M29MK91|2/1/2020 0:00:00|3/31/2022 0:00:00|FIRSTNAME|NA|LASTNAME||9999 W 9TH ST||CITY,CA|CA|99999|999-999-9999|F|5/24/1945 0:00:00||3||SH5425M|SCAN (SH5425M)|NA||NA|NA||123456789-01|LASTNAME, FIRSTNAME|145001|SCAN HEALTH PLAN||SENIOR|NA|NA|NA|NA|NA||3/31/2022 0:00:00|2/1/2020 0:00:00|6/1/2010 0:00:00||12|1/1/2021 0:00:00|12/31/2021 0:00:00||";

            var badLength = new FdOptumCareHcpMem();
            badLength.LoadFromRaw(badRow);

            Assert.IsFalse(badLength.IsValid);
        }

    }
}
