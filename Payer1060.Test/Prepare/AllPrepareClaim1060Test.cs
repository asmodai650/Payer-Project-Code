using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using TestFramework.FileValidation.Utilities;
using TestFramework.Common;
using TestFramework.RacerMocks;

using Novus.Shared;

using Novus.Payer1060;

namespace Payer1060.Test.Prepare
{
    [TestClass]
    public class AllPrepareClaim1060Test
    {
        private static RacerLoadJob racerProps;
        private static PrepareRollupClaim1060 prepareRollupClaim;
        private static PrepareMergeClaim1060 prepareMergeClaim;
        private static PrepareMergeClaimToIcd1060 prepareMergeClaimToIcd;
        private static PrepareMergeClaimToMapper1060 prepareMergeClaimToMapper;
        private static PrepareInFeedLogic1060 prepareInFeedLogic;

        [TestInitialize]
        public void TestInitialize()
        {
            FilePrepare.InitializePrepare();
            racerProps = RacerLoadJobFactory.GetRacerLoadJob(StepEnum.Prepare, 1454, 9999);
            prepareRollupClaim = new PrepareRollupClaim1060(racerProps);
            prepareMergeClaim = new PrepareMergeClaim1060(racerProps);
            prepareMergeClaimToIcd = new PrepareMergeClaimToIcd1060(racerProps);
            prepareMergeClaimToMapper = new PrepareMergeClaimToMapper1060(racerProps);
            prepareInFeedLogic = new PrepareInFeedLogic1060(racerProps);
        }

        [TestMethod]
        //[Ignore]
        public void TestPrepareExecute()
        {
            var ignoredColumns = new List<string> { "DATE_CREATED" };

            prepareRollupClaim.Execute();
            prepareMergeClaim.Execute();
            prepareMergeClaimToIcd.Execute();
            prepareMergeClaimToMapper.Execute();
            prepareInFeedLogic.Execute();

            var compare = new FileCompare(StepEnum.Prepare);
            compare.AddFile("adHocClaimHeaderFile");
            compare.AddFile("mapperOutputClaimHeaderFile", ignoredColumns);
            compare.AddFile("lookupDataClaimHeaderFileB_IcdLookup");
            compare.AddFile("mapperOutputICD9File", ignoredColumns);
            compare.AddFile("lookupInputICD9File");
            compare.AddFile("mapperOutputInsuranceGroupFile", ignoredColumns);
            compare.AddFile("lookupInputInsuranceGroupFile");

            Assert.IsTrue(compare.Compare(true));
        }
    }
}
