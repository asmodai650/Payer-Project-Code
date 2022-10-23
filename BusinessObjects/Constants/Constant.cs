using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Novus.Payer1060.BusinessObjects.Constants
{
    public static class Constant
    {
        public const int ParentProjectId = 1454;

        public static readonly List<int> ProjectIdList = new List<int> { 1454 };

        public static readonly Regex FileNameRegex = new Regex("^(?i)lookup.*$");
        public static readonly Regex LogFileNameRegex = new Regex("^(?!.*log)(?!.*exception)(?!.*rerun).*$");
        public static readonly Regex LookupFileNameRegex = new Regex("^(?i)lookup.*$");

        /// <summary>
        /// LineScrubRegex && MoneyScrubRegex searches for chars between the [], and replaces them with the char after the \
        /// Removed \| as raw files are pipe delimited
        /// </summary>
        public static readonly Regex LineScrubRegex = new Regex(@"[^\x20-\x7E\t]|\""");
        public static readonly Regex MoneyScrubRegex = new Regex(@"[$]|[($]|[)]|\""");

        public static readonly string LoadingUserName = "NovusLoading";
        public static readonly string Delimiter = "|";
        public static readonly string pathDelimeter = @"\";

        public static readonly string ProductLineId = "1"; /// claimheader mapper object
        public static readonly string RelInsGroupid = "1"; /// member mapper object

        ///datetime format required to load to MS SQL Server - note the colons separating hours, minutes, seconds
        public static readonly string OutputDateFormat = "yyyy-MM-dd HH:mm:ss.fff";
        public static readonly string RacerMapperDateFormat = "yyyy-MM-dd";
        public static readonly DateTime minDateSql = new DateTime(1753, 1, 1);
        public static readonly DateTime maxDateSql = new DateTime(9999, 12, 31);

        ///file identifiers
        public static readonly string MapperClaimHeaderFile = "MapperClaimHeader";
        public static readonly string MapperClaimLineFile = "MapperClaimLine";
        public static readonly string MapperMemberFile = "MapperMember";
        public static readonly string MapperProviderFile = "MapperProvider";
        public static readonly string MapperInsGroupFile = "MapperInsGroup";
        public static readonly string MapperSpecialFieldsFile = "MapperSpecialFields";
        public static readonly string MapperIcd9File = "MapperIcd9";

        ///lookup step names
        public static readonly string LookupInsGroupFile = "LookupInsGroup";
        public static readonly string LookupSpecialFieldsFile = "LookupSpecialFields";
        public static readonly string LookupMemberFile = "LookupMember";
        public static readonly string LookupProviderFile = "LookupProvider";

        ///preprocess step names for Claim
        public static readonly string PreprocessClaim = "PreprocessClaim";
        public static readonly string PreprocessClaimCleanup = "PreprocessClaimCleanup";
        public static readonly string PreprocessClaimAdhocFile = "PreprocessClaimAdhoc"; /// ClaimHeader
        public static readonly string PreprocessClaimAdhocFileA = "PreprocessClaimAdhocA"; /// ClaimLine
        public static readonly string PreprocessClaimAdhocFileB = "PreprocessClaimAdhocB"; /// Diag
        public static readonly string PreprocessClaimAdhocFileC = "PreprocessClaimAdhocC"; /// Proc

        ///preprocess step names for Member
        public static readonly string PreprocessMember = "PreprocessMember";
        public static readonly string PreprocessMemberCleanup = "PreprocessMemberCleanup";
        public static readonly string PreprocessMemAdhocFile = "PreprocessMemAdhoc";

        ///preprocess step names for Provider
        public static readonly string PreprocessProvider = "PreprocessProvider";
        public static readonly string PreprocessProviderCleanup = "PreprocessProviderCleanup";
        public static readonly string PreprocessProvAdhocFile = "PreprocessProvAdhoc";

        ///prepare step names for Claim Rollup
        public static readonly string PrepareClaimAdhocFile = "PrepareClaimAdhoc"; /// ClaimHeader
        public static readonly string PrepareClaimAdhocFileA = "PrepareClaimAdhocA"; /// ClaimLine
        public static readonly string PrepareClaimDiagLookup = "PrepareClaimDiagLookup";
        public static readonly string PrepareClaimLineLookupSort = "PrepareClaimLineLookupSort";
        public static readonly string PrepareClaimLineRollupSort = "PrepareClaimLineRollupSort";
        public static readonly string PrepareClaimLineRollup = "PrepareClaimLineRollup";
        public static readonly string PrepareClaimHeaderMerge = "PrepareClaimHeaderMerge";

        ///prepare step names for Merge Claim
        public static readonly string PrepareMergeClaim = "PrepareMergeClaim";
        public static readonly string PrepareMergeClaimLookupSort = "PrepareMergeClaimLookupSort";
        public static readonly string PrepareMergeClaimLookupMerge = "PrepareMergeClaimLookupMerge";

        ///prepare step names for Merge Claim to Icd
        public static readonly string PrepareMergeIcd = "PrepareMergeIcd";
        public static readonly string PrepareMergeIcdLookupSort = "PrepareMergeIcdLookupSort";
        public static readonly string PrepareMergeIcdLookup = "PrepareMergeIcdLookup";
        public static readonly string PrepareMergeIcdMapper = "PrepareMergeIcdMapper";

        ///prepare step names for Merge Claim to Mapper
        public static readonly string PrepareMergeClaimToMapper = "PrepareMergeClaimToMapper";
        public static readonly string PrepareMergeAdhocSort = "PrepareMergeAdhocSort";
        public static readonly string PrepareMergeDiagSort = "PrepareMergeDiagSort";
        public static readonly string PrepareMergeAdhocToMapper = "PrepareMergeAdhocToMapper";
        public static readonly String PrepareMergeDiagToMapper = "PrepareMergeDiagToMapper";

        ///prepare step names for InFeed Adjustment
        public static readonly string PrepareInFeedLogic = "PrepareInFeedLogic";
        public static readonly string PrepareInFeedWrite = "PrepareInFeedWrite";

        ///prepare standard step names
        public static readonly string PrepareProvider = "PrepareProvider";
        public static readonly string PrepareMember = "PrepareMember";
        public static readonly string PrepareClaimHeader = "PrepareClaimHeader";
        public static readonly string SortClaimHeader = "SortClaimHeader";
        public static readonly string SortLookupInput = "SortLookupInput";
        public static readonly string PrepareClaimLine = "PrepareClaimLine";
        public static readonly string PrepareIcd = "PrepareIcd";
        public static readonly string PrepareInsGroup = "PrepareInsGroup";
        public static readonly string PrepareSpecialFields = "PrepareSpecialFields";

        ///counter types
        public static readonly string Total = "Total";
        public static readonly string Success = "Success";
        public static readonly string Exception = "Exception";
        public static readonly string Parent = "Parent";

        ///File Headers for sorting
        public static readonly string DiagToClaimLookupHeader = "CLAIM_NO|PRINCIPAL_DIAG";
        public static readonly string ClaimLineLookupHeader = "CLAIM_NO_KEY|CL_DATE_OF_SERVICE_BEG|CL_DATE_OF_SERVICE_END|CL_AMT_BILLED";
        public static readonly string IcdLookupHeader = "PROJECT_ID|FEED_ID|CLAIM_NO|PRINCIPAL_DIAG|DIAGNOSIS_1|DIAGNOSIS_2|DIAGNOSIS_3|DIAGNOSIS_4|DIAGNOSIS_5|DIAGNOSIS_6|DIAGNOSIS_7|DIAGNOSIS_8|DIAGNOSIS_9|DIAGNOSIS_10|DIAGNOSIS_11|DIAGNOSIS_12|DIAGNOSIS_13|DIAGNOSIS_14|DIAGNOSIS_15|DIAGNOSIS_16|DIAGNOSIS_17|DIAGNOSIS_18|DIAGNOSIS_19|DIAGNOSIS_20|DIAGNOSIS_21|DIAGNOSIS_22|DIAGNOSIS_23|PRINCIPAL_PROC|PROCEDURE_1|PROCEDURE_2|PROCEDURE_3|PROCEDURE_4|PROCEDURE_5|PROCEDURE_6|PROCEDURE_7|PROCEDURE_8|PROCEDURE_9|PROCEDURE_10|PROCEDURE_11|PROCEDURE_12|PROCEDURE_13|PROCEDURE_14|PROCEDURE_15|PROCEDURE_16|PROCEDURE_17|PROCEDURE_18|PROCEDURE_19|PROCEDURE_20|PROCEDURE_21|PROCEDURE_22|PROCEDURE_23|ADMITTING_DIAGNOSIS_CODE|CLAIM_ICD_VERSION_INDICATOR";
        public static readonly string IcdLookupPlaceholders = "|||||||||||||||||||||||||"; ///placeholders for merging to proc and claim header file in PrepareIcd
        public static readonly string MapperClaimFileHeader = "CLAIM_ID|PROJECT_ID|CLAIM_NO|FEED_ID|CLAIM_SUFFIX|DATE_RECEIVED|DATE_ENTERED|DATE_OF_SERVICE_BEG|DATE_OF_SERVICE_END|DATE_ADMITTED|DATE_DISCHARGED|PATIENT_ID|PATIENT_AGE|PATIENT_DOB|PATIENT_GENDER|MEDICAL_RECNO|SUBSCRIBER_ID|SUBSCRIBER_AGE|SUBSCRIBER_DOB|INS_GROUP_ID|GROUP_SIZE|REL_TO_INS_ID|REL_TO_INS_GROUP_ID|PROVIDER_ID|DRG|ATTENDING_PROV_ID|PLACE_OF_SERVICE|LINE_OF_BUSINESS_ID|PRODUCT_LINE_ID|BILL_TYPE|AMT_BILLED|AMT_ALLOWED|AMT_COPAY|AMT_DEDUCTIBLE|AMT_COINSURANCE|AMT_DISALLOWED|AMT_COB_PAID|AMT_DISCOUNT|AMT_COVERED|AMT_NOT_COVERED|AMT_PAID|DATE_PAID|CHECK_NUMBER|COB_SUSPECT|COB_PRIMARY|PRINCIPAL_DIAG|CASE_HITS|ORIG_SRC_TABID|ORIG_SRC_RECNO|DATE_CREATED|DATE_UPDATED|USERNAME|ADJ_CLAIM_FLAG|PAR|PATIENT_ACCT_NO|EMP_STATUS|EMPLOYMENT_STATUS|VENDOR_ID|PATIENT_ACCT_NO_CLIENT|PAR_CLIENT|CHECK_NUMBER_CLIENT|AMT_PAID_CLIENT|AMT_BILLED_CLIENT|AMT_ALLOWED_CLIENT|SERVICE_ID|ROWID|INTEREST_PAID|INS_GROUP_NO|PROVIDER_NO|PAT_MEM_NO|SUB_MEM_NO";

        /// provisional table mappings
        public static string[] GetProvisionalTableFileMap(int projectId)
        {
            if (projectId == ParentProjectId)
            {
                return new[]
                {
                    "FD_OPTUMCARE_HCP_CLM, adHocClaimHeaderFile", ///Header_DX_month year.txt
                    "FD_OPTUMCARE_HCP_CLIN, adHocClaimHeaderFileA", ///Line_Month year.txt
                    "FD_OPTUMCARE_HCP_DIAG, adHocClaimHeaderFileB", ///Header_DX_month year.txt
                    "FD_OPTUMCARE_HCP_PROC, adHocClaimHeaderFileC", ///Header_OTHER PX AND DATES_Month year.txt
                    "FD_OPTUMCARE_HCP_MEM, adHocMemberFile", ///Patient_File.txt
                    "FD_OPTUMCARE_HCP_PROV, adHocProviderFile" ///Provider_File_Month year.txt
                };
            }

            return Array.Empty<string>();
        }
    }
}
