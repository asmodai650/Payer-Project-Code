using Microsoft.VisualStudio.TestTools.UnitTesting;
using Novus.Payer1060.BusinessObjects.Constants;

namespace Payer1060.Test.BusinessObjects.Constants
{
    [TestClass]
    public class Constants1060Test
    {
        [TestMethod]
        public void ProjectIDTest()
        {
            int relCode = 1454;
            string productLineId = "1";
            string relInsGroupid = "1";

            Assert.AreEqual(relCode, Constant.ParentProjectId);
            Assert.AreEqual(productLineId, Constant.ProductLineId);
            Assert.AreEqual(relInsGroupid, Constant.RelInsGroupid);
        }
    }
}
