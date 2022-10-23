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
    public class PreprocessClaim1060Test
    {
        private static RacerLoadJob racerProps;
        private static PreprocessClaim1060 preprocess;

        [TestInitialize]
        public void TestInitialize()
        {
            var rawFiles = FilePrepare.InitializePreprocessAndRawFileMap();
            racerProps = RacerLoadJobFactory.GetRacerLoadJob(StepEnum.Preprocess, ".txt", rawFiles);
            preprocess = new PreprocessClaim1060(racerProps);
        }

        [TestMethod]
        ///[Ignore]
        public void TestPreprocessClaimExecute()
        {
            var ignoredColumns = new List<string> { "DATE_CREATED" };
            ///var namedColumns = new List<string> { "PROJECT_ID" };

            preprocess.Execute();

            var compare = new FileCompare(StepEnum.Preprocess);
            compare.AddFile("adHocClaimHeaderFileC");
            compare.AddFile("adHocClaimHeaderFileB");
            compare.AddFile("adHocClaimHeaderFileA");
            compare.AddFile("adHocClaimHeaderFile");

            compare.AddFile("lookupDataClaimHeaderFileA_LookupBeforeRollup");
            compare.AddFile("lookupDataClaimHeaderFileA_LookupPriorClaim");
            compare.AddFile("lookupDataClaimHeaderFileB_DiagLookup");
            compare.AddFile("lookupDataClaimHeaderFileB_IcdLookup");

            compare.AddFile("mapperOutputClaimHeaderFile", ignoredColumns);
            compare.AddFile("mapperOutputClaimLineFile", ignoredColumns);
            compare.AddFile("mapperOutputInsuranceGroupFile", ignoredColumns);
            ///compare.AddFile("mapperOutputSpecialFieldsFile");

            compare.AddFile("lookupInputClaimHeaderFile");
            compare.AddFile("lookupInputClaimLineFile");
            compare.AddFile("lookupInputInsuranceGroupFile");

            Assert.IsTrue(compare.Compare());
        }
    }
}
