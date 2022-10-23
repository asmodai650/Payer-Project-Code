using System;
using Novus.Toolbox;
using Novus.Payer1060.BusinessObjects.Constants;
using Novus.Payer1060.BusinessObjects.FileObjects;

namespace Novus.Payer1060.BusinessObjects.RacerMappers
{
    public static class InsGroupMapper
    {
        private static readonly FO_InsGroup insGroup = new FO_InsGroup();

        public static string EmitHeaderLine()
        {
            return insGroup.EmitHeaderLine();
        }

        public static string EmitRacerInsGrpLines(FdOptumCareHcpClaim clm)
        {
            insGroup.Clear();

            insGroup.PROJECT_ID = clm.PROJECT_ID;
            insGroup.INS_GROUP_NO = clm.SUBSCRIBER_GROUP_POLICY_NUMBER.ToUpper();
            insGroup.NAME = clm.SUBSCRIBER_GROUP_POLICY_NAME;
            insGroup.DATE_CREATED = DateTime.Now.ToString(Constant.RacerMapperDateFormat);
            insGroup.USERNAME = Constant.LoadingUserName;

            return insGroup.ToString();
        }
    }
}
