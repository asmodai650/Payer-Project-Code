using System;
using Novus.Extensions;
using Novus.Toolbox;
using Novus.Payer1060.BusinessObjects.Constants;
using Novus.Payer1060.BusinessObjects.FileObjects;
using Novus.Payer1060.BusinessObjects.Lookups;
using Novus.Payer1060.BusinessObjects.Utilities;

namespace Novus.Payer1060.BusinessObjects.RacerMappers
{
    public static class ClaimMapper
    {
        private static readonly FO_BcpPlusClaimHeader claimHeader = new FO_BcpPlusClaimHeader();
        private static readonly FO_BcpPlusClaimLine claimLine = new FO_BcpPlusClaimLine();
        private static readonly FO_BcpPlusSpecialFields specialFields = new FO_BcpPlusSpecialFields();

        public static string EmitClaimHeaderHeader()
        {
            return claimHeader.EmitHeaderLine();
        }

        public static string EmitClaimLineHeader()
        {
            return claimLine.EmitHeaderLine();
        }

        public static string EmitSpecialFieldsHeader()
        {
            return specialFields.EmitHeaderLine();
        }

        public static string EmitRacerClaimHeader(FdOptumCareHcpClaim clm)
        {
            claimHeader.Clear();

            claimHeader.PROJECT_ID = clm.PROJECT_ID.ToString();
            claimHeader.CLAIM_NO = clm.CLAIM_NO;
            claimHeader.FEED_ID = clm.FEED_ID.ToString();
            claimHeader.CLAIM_SUFFIX = clm.CLAIM_SUFFIX;
            claimHeader.DATE_RECEIVED = DateUtilities.GetRacerDate(clm.CLIENT_CLAIM_RECEIPT_DATE);
            claimHeader.DATE_ADMITTED = DateUtilities.GetRacerDate(clm.PATIENT_ADMISSION_DATE);
            claimHeader.DATE_DISCHARGED = DateUtilities.GetRacerDate(clm.PATIENT_DISCHARGE_DATE);
            claimHeader.MEDICAL_RECNO = clm.CLIENT_MEDICAL_RECORD_NUMBER;
            claimHeader.DRG = clm.DRG;
            claimHeader.PLACE_OF_SERVICE = clm.PLACE_OF_SERVICE;
            claimHeader.LINE_OF_BUSINESS_ID = LookupLineOfBusinessId1060.LobLookup(clm.CLIENT_LOB_CODE);
            claimHeader.PRODUCT_LINE_ID = Constant.ProductLineId;
            claimHeader.BILL_TYPE = clm.BILL_TYPE;
            claimHeader.AMT_ALLOWED = clm.AMT_ALLOWED;
            claimHeader.AMT_COPAY = clm.CLAIM_TOTAL_PATIENT_COPAY_AMOUNT;
            claimHeader.AMT_DEDUCTIBLE = clm.CLAIM_TOTAL_DEDUCTIBLE_AMOUNT;
            claimHeader.AMT_COINSURANCE = clm.CLAIM_TOTAL_COINSURANCE_AMOUNT;
            claimHeader.AMT_COB_PAID = clm.AMT_COB_PAID;
            claimHeader.AMT_DISCOUNT = clm.CLAIM_TOTAL_DISCOUNT_AMOUNT;
            claimHeader.AMT_COVERED = clm.CLAIM_TOTAL_COVERED_AMOUNT;
            claimHeader.AMT_NOT_COVERED = clm.CLAIM_TOTAL_NON_COVERED_AMOUNT;
            claimHeader.AMT_PAID = clm.AMT_PAID;
            claimHeader.DATE_PAID = DateUtilities.GetRacerDate(clm.DATE_PAID);
            claimHeader.CHECK_NUMBER = clm.CLAIM_CHECK_EFT_TRACE_NUMBER;
            claimHeader.DATE_CREATED = DateTime.Now.ToString(Constant.RacerMapperDateFormat);
            claimHeader.USERNAME = Constant.LoadingUserName;

            ///Set field to zero for In-Feed adjustment logic. Cross Feed adjustment logic will update to "2" if needed.
            claimHeader.ADJ_CLAIM_FLAG = "0";

            claimHeader.PAR = clm.RENDERING_PROVIDER_PAR_INDICATOR;
            claimHeader.PATIENT_ACCT_NO = clm.PATIENT_ACCT_NO;
            claimHeader.SERVICE_ID = clm.TYPE_OF_CLAIM.ToUpper() == "PROFESSIONAL" ? "2" : "1";
            claimHeader.INTEREST_PAID = clm.CLAIM_TOTAL_INTEREST_AMOUNT;

            ///foreign keys - not actually in target table
            claimHeader.PAT_MEM_NO = clm.PAT_MEMBER_NO;
            claimHeader.SUB_MEM_NO = clm.SUB_MEMBER_NO;
            claimHeader.PROVIDER_NO = clm.PROVIDER_NO;
            claimHeader.INS_GROUP_NO = clm.SUBSCRIBER_GROUP_POLICY_NUMBER.ToUpper();

            ///NOTE: These fields are populated in PrepareMergeClaimToMapper after rollups are created in PrepareRollupClaim
            ///claimHeader.DATE_OF_SERVICE_BEG = claim.DATE_OF_SERVICE_BEG; uses rolled values to get min date from claim line file
            ///claimHeader.DATE_OF_SERVICE_END = claim.DATE_OF_SERVICE_END; uses rolled values to get max date from claim line file
            ///claimHeader.PRINCIPAL_DIAG = diag.PRINCIPAL_DIAG; merged from diag to claim lookup
            ///claimHeader.AMT_BILLED = claim.AMT_BILLED; uses rolled values to get sum from claim line file

            return claimHeader.ToString();
        }

        public static string EmitRacerClaimLine(FdOptumCareHcpClaimLine clmLine)
        {
            claimLine.Clear();

            claimLine.PROJECT_ID = clmLine.PROJECT_ID.ToString();
            claimLine.LINE_NO = clmLine.LINE_NO;
            claimLine.FEED_ID = clmLine.FEED_ID.ToString();
            claimLine.DATE_OF_SERVICE_BEG = DateUtilities.GetRacerDate(clmLine.CL_DATE_OF_SERVICE_BEG);
            claimLine.DATE_OF_SERVICE_END = DateUtilities.GetRacerDate(clmLine.CL_DATE_OF_SERVICE_END);
            claimLine.AUTHORIZATION_CODE = clmLine.LINE_PRIOR_AUTHORIZATION_NUMBER;
            claimLine.CPT = clmLine.CPT;
            claimLine.CPT_MODIFIER = clmLine.CPT_MODIFIER.SubstringNovus(0, 2);
            claimLine.UNITS_BILLED = clmLine.UNITS_BILLED.ToIntegerString();
            claimLine.UNITS_ALLOWED = clmLine.UNITS_BILLED.ToIntegerString();
            claimLine.CAPITATION_FLAG = clmLine.CLIENT_LINE_PRICING_METHODOLOGY.ToUpper() == "CAPITATION" ? "Y" : "N";
            claimLine.REVENUE_CODE = clmLine.REVENUE_CODE.ToIntegerString();
            claimLine.AMT_BILLED = clmLine.CL_AMT_BILLED;
            claimLine.AMT_ALLOWED = clmLine.CL_AMT_ALLOWED;
            claimLine.AMT_COPAY = clmLine.LINE_PATIENT_COPAY_AMOUNT;
            claimLine.AMT_DEDUCTIBLE = clmLine.DED_AMT;
            claimLine.AMT_COINSURANCE = clmLine.LINE_COINSURANCE_AMOUNT;
            claimLine.AMT_COB_PAID = clmLine.CL_AMT_COB_PAID;
            claimLine.AMT_DISCOUNT = clmLine.LINE_DISCOUNT_AMOUNT;
            claimLine.AMT_COVERED = clmLine.LINE_COVERED_AMOUNT;
            claimLine.AMT_NOT_COVERED = clmLine.LINE_NON_COVERED_AMOUNT;
            claimLine.AMT_PAID = clmLine.CL_AMT_PAID;
            claimLine.DATE_PAID = DateUtilities.GetRacerDate(clmLine.CL_DATE_PAID);
            claimLine.DATE_CREATED = DateTime.Now.ToString(Constant.RacerMapperDateFormat);
            claimLine.USERNAME = Constant.LoadingUserName;
            claimLine.INTEREST_PAID = clmLine.LINE_INTEREST_AMOUNT;
            claimLine.INCLUDE_INTEREST = "N";

            ///foreign key - not actually in target table
            claimLine.CLAIM_NO = clmLine.CLAIM_NO;

            return claimLine.ToString();
        }

        public static string EmitRacerSpecialFields(FdOptumCareHcpClaim clm)
        {
            specialFields.Clear();
            
            specialFields.PROJECT_ID = clm.PROJECT_ID.ToString();            
            specialFields.TABLE_NAME = "CLAIM";
            specialFields.PRIM_KEY = "CLAIM_ID";
            specialFields.FEED_ID = clm.FEED_ID.ToString();           
            specialFields.FIELD1 = clm.HMO;
            specialFields.FIELD2 = clm.OPTUM_REGION_NAME;
            specialFields.FIELD3 = clm.CLIENT_LOB_CODE;
            specialFields.FIELD4 = clm.SUBMITTED_DRG_CODE;
            specialFields.FIELD5 = clm.CLIENT_CLAIM_ID;

            ///foreign key - not actually in target table
            specialFields.CLAIM_NO = clm.CLAIM_NO;

            return specialFields.ToString();
        }

        private static string ToIntegerString(this string value)
        {
            return int.TryParse(value, out var i) ? i.ToString() : string.Empty;
        }
    }
}
