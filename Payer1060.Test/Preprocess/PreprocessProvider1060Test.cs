using Microsoft.VisualStudio.TestTools.UnitTesting;
using Novus.Payer1060;
using Novus.Shared;
using System.Collections.Generic;
using TestFramework.Common;
using TestFramework.FileValidation.Utilities;
using TestFramework.RacerMocks;

namespace Payer1060.Test.Preprocess
{
    [TestClass]
    public class PreprocessProvider1060Test
    {
        private static RacerLoadJob racerProps;
        private static PreprocessProvider1060 preprocess;

        [TestInitialize]
        public void TestInitialize()
        {
            var rawFiles = FilePrepare.InitializePreprocessAndRawFileMap();
            racerProps = RacerLoadJobFactory.GetRacerLoadJob(StepEnum.Preprocess, ".txt", rawFiles);
            preprocess = new PreprocessProvider1060(racerProps);
        }

        [TestMethod]
        //[Ignore]
        public void TestPreprocessProviderExecute()
        {
            var ignoredColumns = new List<string> { "DATE_CREATED" };

            preprocess.Execute();

            var compare = new FileCompare(StepEnum.Preprocess);
            compare.AddFile("adHocProviderFile");
            compare.AddFile("mapperOutputProviderFile", ignoredColumns);
            compare.AddFile("lookupInputProviderFile");

            Assert.IsTrue(compare.Compare());
        }
    }
}
