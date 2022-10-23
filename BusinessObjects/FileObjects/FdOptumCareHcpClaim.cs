using System.Text;
using Novus.Toolbox;
using Novus.Payer1060.BusinessObjects.Constants;
using Novus.Payer1060.BusinessObjects.Utilities;

namespace Novus.Payer1060.BusinessObjects.FileObjects
{
    public class FdOptumCareHcpClaim
    {
        #region CLASS_VARIABLES

        private readonly StringBuilder stringBuilder = new StringBuilder();
        #endregion CLASS_VARIABLES

        #region CONSTRUCTORS

        /// <summary>
        /// Initializes a new instance of the <see cref="FdOptumCareHcpClaim" /> class.
        /// </summary>
        public FdOptumCareHcpClaim()
        {
            this.Clear();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FdOptumCareHcpClaim" /> class.
        /// </summary>
        /// <param name="racerLoadJobReadOnlyProperties">The instance of RacerLoadJobReadOnlyProperties for this file load.</param>
        public FdOptumCareHcpClaim(RacerLoadJobReadOnlyProperties racerLoadJobReadOnlyProperties)
            : this()
        {
            this.PROJECT_ID = Constant.ParentProjectId.ToString();
            this.FEED_ID = racerLoadJobReadOnlyProperties.FeedID.ToString();
        }
        #endregion CONSTRUCTORS

        #region PUBLIC_PROPERTIES

        /// <summary>
        /// Gets or sets the delimiter used between fields.
        /// </summary>
        public string Delimiter { get; set; } = "|";

        /// <summary>
        /// Gets a value indicating whether this row object is populated with valid values.
        /// </summary>
        public bool IsValid { get; private set; }

        public string ROWID { get; set; }

        public string PROJECT_ID { get; private set; }

        public string FEED_ID { get; private set; }

        public string CLAIM_ID { get; set; }

        public string HMO { get; set; }

        public string CLIENT_CLAIM_ID { get; set; }

        public string CLIENT_CLAIM_SEQUENCE_TYPE { get; set; }

        public string CLIENT_CLAIM_SEQUENCE_NUMBER { get; set; }

        public string CLIENT_PRIOR_CLAIM_ID { get; set; }

        public string CLIENT_ORIGINAL_CLAIM_ID { get; set; }

        public string CLIENT_CLAIM_BYPASS_CODE { get; set; }

        public string CLIENT_CLAIM_RECEIPT_DATE { get; set; }

        public string CLIENT_CLAIM_ENCOUNTER_CAPITATION_INDICATOR { get; set; }

        public string CLIENT_CLAIM_BCBS_ITS_CLAIM_INDICATOR { get; set; }

        public string CLIENT_CLAIM_BCBS_ITS_SCCF_NUMBER { get; set; }

        public string CLIENT_CLAIM_PAYMENT_CODE { get; set; }

        public string CLIENT_MEDICAL_RECORD_INDICATOR { get; set; }

        public string CLIENT_MEDICAL_RECORD_NUMBER { get; set; }

        public string CLIENT_COMPANY_CODE { get; set; }

        public string CLIENT_BUSINESS_UNIT_CODE { get; set; }

        public string CLIENT_REGION_CODE { get; set; }

        public string CLIENT_LOB_CODE { get; set; }

        public string CLIENT_CLAIM_PRICING_METHODOLOGY { get; set; }

        public string CLIENT_CLAIM_COB_PAYER_SEQUENCE { get; set; }

        public string CLIENT_ADJUDICATION_PLATFORM_ID { get; set; }

        public string CLIENT_CLAIM_ADJUDICATION_LIFECYCLE_CODE { get; set; }

        public string CLIENT_CLAIM_ADJUDICATION_STATUS_CODE { get; set; }

        public string CLIENT_CLAIM_ADJUDICATION_REASON_CODE { get; set; }

        public string CLIENT_CLAIM_ADJUDICATION_DATE { get; set; }

        public string PATIENT_ACCT_NO { get; set; }

        public string PAYER_ORIGINAL_CLAIM_CONTROL_NUMBER { get; set; }

        public string TYPE_OF_CLAIM { get; set; }

        public string CLAIM_FREQUENCY_OF_SUBMISSION_CODE { get; set; }

        public string BILL_TYPE { get; set; }

        public string PLACE_OF_SERVICE { get; set; }

        public string CLAIM_FILING_INDICATOR_CODE { get; set; }

        public string BENEFITS_ASSIGNMENT_CERTIFICATION_INDICATOR { get; set; }

        public string RELEASE_OF_INFORMATION_CODE { get; set; }

        public string CLAIM_TOTAL_BILLED_AMOUNT { get; set; }

        public string CLAIM_TOTAL_PATIENT_LIABILITY_AMOUNT { get; set; }

        public string CLAIM_TOTAL_PATIENT_COPAY_AMOUNT { get; set; }

        public string AMT_ALLOWED { get; set; }

        public string AMT_COB_PAID { get; set; }

        public string CLAIM_TOTAL_COINSURANCE_AMOUNT { get; set; }

        public string CLAIM_TOTAL_DEDUCTIBLE_AMOUNT { get; set; }

        public string CLAIM_TOTAL_NON_COVERED_AMOUNT { get; set; }

        public string CLAIM_TOTAL_COVERED_AMOUNT { get; set; }

        public string CLAIM_TOTAL_TAX_AMOUNT { get; set; }

        public string CLAIM_TOTAL_DISCOUNT_AMOUNT { get; set; }

        public string CLAIM_TOTAL_WITHHOLD_AMOUNT { get; set; }

        public string CLAIM_TOTAL_OTHER_REDUCTION_AMOUNT { get; set; }

        public string CLAIM_TOTAL_INTEREST_AMOUNT { get; set; }

        public string AMT_PAID { get; set; }

        public string CLAIM_POST_DATE { get; set; }

        public string CLAIM_PAID_DATE { get; set; }

        public string CLAIM_CHECK_EFT_TRACE_NUMBER { get; set; }

        public string CLAIM_STATEMENT_FROM_DATE { get; set; }

        public string CLAIM_STATEMENT_TO_DATE { get; set; }

        public string CLAIM_PRIOR_AUTHORIZATION_NUMBER { get; set; }

        public string CLIA_NUMBER { get; set; }

        public string PATIENT_TYPE_OF_ADMISSION { get; set; }

        public string PATIENT_SOURCE_OF_ADMISSION { get; set; }

        public string PATIENT_ADMISSION_DATE { get; set; }

        public string PATIENT_ADMISSION_TIME { get; set; }

        public string PATIENT_DISCHARGE_STATUS_CODE { get; set; }

        public string PATIENT_DISCHARGE_DATE { get; set; }

        public string PATIENT_DISCHARGE_TIME { get; set; }

        public string PAT_MEMBER_NO { get; set; }

        public string PATIENT_RELATIONSHIP_TO_SUBSCRIBER_CODE { get; set; }

        public string SUB_MEMBER_NO { get; set; }

        public string SUBSCRIBER_INSURER_PAYER_ID { get; set; }

        public string SUBSCRIBER_INSURER_PAYER_NAME { get; set; }

        public string SUBSCRIBER_GROUP_POLICY_NUMBER { get; set; }

        public string SUBSCRIBER_GROUP_POLICY_NAME { get; set; }

        public string SUBSCRIBER_PLAN_PRODUCT_CODE { get; set; }

        public string SUBSCRIBER_PLAN_STATE_CODE { get; set; }

        public string PROVIDER_NO { get; set; }

        public string BILLING_PROVIDER_NPI { get; set; }

        public string BILLING_PROVIDER_TIN { get; set; }

        public string BILLING_PROVIDER_TAXONOMY_CODE { get; set; }

        public string BILLING_PROVIDER_SPECIALTY_CODE { get; set; }

        public string RENDERING_PROVIDER_CLIENT_ID { get; set; }

        public string RENDERING_PROVIDER_NPI { get; set; }

        public string RENDERING_PROVIDER_TAXONOMY_CODE { get; set; }

        public string RENDERING_PROVIDER_SPECIALTY_CODE { get; set; }

        public string RENDERING_PROVIDER_PAR_INDICATOR { get; set; }

        public string RENDERING_PROVIDER_CONTRACT_ID { get; set; }

        public string SERVICE_LOCATION_CLIENT_ID { get; set; }

        public string SERVICE_LOCATION_CLIENT_NPI { get; set; }

        public string REFERRING_PROVIDER_CLIENT_ID { get; set; }

        public string REFERRING_PROVIDER_CLIENT_NPI { get; set; }

        public string ATTENDING_PROVIDER_CLIENT_ID { get; set; }

        public string ATTENDING_PROVIDER_CLIENT_NPI { get; set; }

        public string ATTENDING_PROVIDER_TAXONOMY_CODE { get; set; }

        public string ACCIDENT_STATE { get; set; }

        public string ACCIDENT_DATE { get; set; }

        public string ACCIDENT_RELATED_CAUSE_1 { get; set; }

        public string ACCIDENT_RELATED_CAUSE_2 { get; set; }

        public string CLAIM_ICD_VERSION_INDICATOR { get; set; }

        public string SUBMITTED_DRG_CODE { get; set; }

        public string ADJUDICATED_DRG_CODE { get; set; }

        public string ADJUDICATED_DRG_WEIGHT { get; set; }

        public string DRG_GROUPER { get; set; }

        public string DRG_VERSION { get; set; }

        public string DRG_LEVEL { get; set; }

        public string DRG_SEVERITY_OF_ILLNESS { get; set; }

        public string DRG_OUTLIER_DAY_COUNT { get; set; }

        public string DRG_COVERED_DAY_COUNT { get; set; }

        public string DRG_NON_COVERED_DAY_COUNT { get; set; }

        public string ADMITTING_DIAGNOSIS_CODE { get; set; }

        public string PRINCIPAL_DIAGNOSIS_CODE { get; set; }

        public string PRINCIPAL_PROCEDURE_CODE { get; set; }

        public string CONDITION_CODES { get; set; }

        public string EXTERNALCAUSE_OF_INJURY_CODES { get; set; }

        public string EXTERNAL_CAUSE_OF_INJURY_POA_INDICATOR { get; set; }

        public string PATIENT_REASON_FOR_VISIT_CODE { get; set; }

        public string SPAN_CODES { get; set; }

        public string SPAN_DATE_FROM { get; set; }

        public string SPAN_DATE_TO { get; set; }

        public string TREATMENT_CODES { get; set; }

        public string OCCURRENCE_CODE_1 { get; set; }

        public string OCCURRENCE_DATE_1 { get; set; }

        public string OCCURRENCE_CODE_2 { get; set; }

        public string OCCURRENCE_DATE_2 { get; set; }

        public string OCCURRENCE_CODE_3 { get; set; }

        public string OCCURRENCE_DATE_3 { get; set; }

        public string OCCURRENCE_CODE_4 { get; set; }

        public string OCCURRENCE_DATE_4 { get; set; }

        public string OCCURRENCE_CODE_5 { get; set; }

        public string OCCURRENCE_DATE_5 { get; set; }

        public string OCCURRENCE_CODE_6 { get; set; }

        public string OCCURRENCE_DATE_6 { get; set; }

        public string OCCURRENCE_CODE_7 { get; set; }

        public string OCCURRENCE_DATE_7 { get; set; }

        public string OCCURRENCE_CODE_8 { get; set; }

        public string OCCURRENCE_DATE_8 { get; set; }

        public string CONDITION_CODE_1 { get; set; }

        public string CONDITION_CODE_2 { get; set; }

        public string CONDITION_CODE_3 { get; set; }

        public string CONDITION_CODE_4 { get; set; }

        public string VALUE_CODE_1 { get; set; }

        public string VALUE_AMOUNT_1 { get; set; }

        public string VALUE_CODE_2 { get; set; }

        public string VALUE_AMOUNT_2 { get; set; }

        public string VALUE_CODE_3 { get; set; }

        public string VALUE_AMOUNT_3 { get; set; }

        public string VALUE_CODE_4 { get; set; }

        public string VALUE_AMOUNT_4 { get; set; }

        public string VALUE_CODE_5 { get; set; }

        public string VALUE_AMOUNT_5 { get; set; }

        public string VALUE_CODE_6 { get; set; }

        public string VALUE_AMOUNT_6 { get; set; }

        public string OCCURRENCE_SPAN_CODES { get; set; }

        public string OCCURRENCE_SPAN_DATE_FROM { get; set; }

        public string OCCURRENCE_SPAN_DATE_TO { get; set; }

        public string OPTUM_REGION_NAME { get; set; }

        public string DRG { get; set; }

        public string DATE_OF_SERVICE_BEG { get; set; }

        public string DATE_OF_SERVICE_END { get; set; }

        public string AMT_BILLED { get; set; }

        public string DATE_PAID { get; set; }

        public string CLAIM_NO { get; set; }

        public string CLAIM_SUFFIX {  get; set; }

        public string CLAIM_NO_KEY { get; set; }
        #endregion PUBLIC_PROPERTIES

        #region PRIVATE_PROPERTIES

        private object[] Fields { get; set; }

        private int ColIdx { get; set; }
        #endregion PRIVATE_PROPERTIES

        #region METHODS

        /// <summary>
        /// Loads a line of raw input provided by an external source and populates the properties.
        /// </summary>
        /// <param name="line">The line of raw data to load.</param>
        public void LoadFromRaw(string line)
        {
            this.Clear();

            /// If any essential field fails to load successfully IsValid can be set to false.
            this.IsValid = true;

            try
            {
                this.Fields = line.Split('|');

                ///Check for Header Row
                if (this.Fields.Length < 152 || this.Fields[0].ToString().ToLower().Contains("hmo"))
                {
                    this.IsValid = false;
                    return;
                }

                ///Check for Empty HMO and CLIENT_CLAIM_ID fields
                if (string.IsNullOrEmpty(this.Fields[0].ToString()) || string.IsNullOrEmpty(this.Fields[1].ToString()))
                {
                    this.IsValid = false;
                    return;
                }

                this.ColIdx = -1;

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.HMO = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_SEQUENCE_TYPE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_SEQUENCE_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_PRIOR_CLAIM_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_ORIGINAL_CLAIM_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_BYPASS_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_RECEIPT_DATE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_ENCOUNTER_CAPITATION_INDICATOR = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_BCBS_ITS_CLAIM_INDICATOR = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_BCBS_ITS_SCCF_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_PAYMENT_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_MEDICAL_RECORD_INDICATOR = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_MEDICAL_RECORD_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_COMPANY_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_BUSINESS_UNIT_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_REGION_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_LOB_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_PRICING_METHODOLOGY = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_COB_PAYER_SEQUENCE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_ADJUDICATION_PLATFORM_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_ADJUDICATION_LIFECYCLE_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_ADJUDICATION_STATUS_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_ADJUDICATION_REASON_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_ADJUDICATION_DATE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PATIENT_ACCT_NO = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PAYER_ORIGINAL_CLAIM_CONTROL_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.TYPE_OF_CLAIM = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_FREQUENCY_OF_SUBMISSION_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.BILL_TYPE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PLACE_OF_SERVICE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_FILING_INDICATOR_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.BENEFITS_ASSIGNMENT_CERTIFICATION_INDICATOR = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.RELEASE_OF_INFORMATION_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_TOTAL_BILLED_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_TOTAL_PATIENT_LIABILITY_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_TOTAL_PATIENT_COPAY_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.AMT_ALLOWED = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.AMT_COB_PAID = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_TOTAL_COINSURANCE_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_TOTAL_DEDUCTIBLE_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_TOTAL_NON_COVERED_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_TOTAL_COVERED_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_TOTAL_TAX_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_TOTAL_DISCOUNT_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_TOTAL_WITHHOLD_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_TOTAL_OTHER_REDUCTION_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_TOTAL_INTEREST_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.AMT_PAID = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_POST_DATE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_PAID_DATE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_CHECK_EFT_TRACE_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_STATEMENT_FROM_DATE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_STATEMENT_TO_DATE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_PRIOR_AUTHORIZATION_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIA_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PATIENT_TYPE_OF_ADMISSION = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PATIENT_SOURCE_OF_ADMISSION = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PATIENT_ADMISSION_DATE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PATIENT_ADMISSION_TIME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PATIENT_DISCHARGE_STATUS_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PATIENT_DISCHARGE_DATE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PATIENT_DISCHARGE_TIME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PAT_MEMBER_NO = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PATIENT_RELATIONSHIP_TO_SUBSCRIBER_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SUB_MEMBER_NO = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SUBSCRIBER_INSURER_PAYER_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SUBSCRIBER_INSURER_PAYER_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SUBSCRIBER_GROUP_POLICY_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SUBSCRIBER_GROUP_POLICY_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SUBSCRIBER_PLAN_PRODUCT_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SUBSCRIBER_PLAN_STATE_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_NO = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.BILLING_PROVIDER_NPI = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.BILLING_PROVIDER_TIN = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.BILLING_PROVIDER_TAXONOMY_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.BILLING_PROVIDER_SPECIALTY_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.RENDERING_PROVIDER_CLIENT_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.RENDERING_PROVIDER_NPI = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.RENDERING_PROVIDER_TAXONOMY_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.RENDERING_PROVIDER_SPECIALTY_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.RENDERING_PROVIDER_PAR_INDICATOR = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.RENDERING_PROVIDER_CONTRACT_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SERVICE_LOCATION_CLIENT_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SERVICE_LOCATION_CLIENT_NPI = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.REFERRING_PROVIDER_CLIENT_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.REFERRING_PROVIDER_CLIENT_NPI = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ATTENDING_PROVIDER_CLIENT_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ATTENDING_PROVIDER_CLIENT_NPI = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ATTENDING_PROVIDER_TAXONOMY_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ACCIDENT_STATE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ACCIDENT_DATE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ACCIDENT_RELATED_CAUSE_1 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ACCIDENT_RELATED_CAUSE_2 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_ICD_VERSION_INDICATOR = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SUBMITTED_DRG_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ADJUDICATED_DRG_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ADJUDICATED_DRG_WEIGHT = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DRG_GROUPER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DRG_VERSION = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DRG_LEVEL = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DRG_SEVERITY_OF_ILLNESS = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DRG_OUTLIER_DAY_COUNT = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DRG_COVERED_DAY_COUNT = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DRG_NON_COVERED_DAY_COUNT = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ADMITTING_DIAGNOSIS_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PRINCIPAL_DIAGNOSIS_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PRINCIPAL_PROCEDURE_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CONDITION_CODES = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.EXTERNALCAUSE_OF_INJURY_CODES = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.EXTERNAL_CAUSE_OF_INJURY_POA_INDICATOR = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PATIENT_REASON_FOR_VISIT_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SPAN_CODES = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SPAN_DATE_FROM = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SPAN_DATE_TO = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.TREATMENT_CODES = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_CODE_1 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_DATE_1 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_CODE_2 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_DATE_2 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_CODE_3 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_DATE_3 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_CODE_4 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_DATE_4 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_CODE_5 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_DATE_5 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_CODE_6 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_DATE_6 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_CODE_7 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_DATE_7 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_CODE_8 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_DATE_8 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CONDITION_CODE_1 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CONDITION_CODE_2 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CONDITION_CODE_3 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CONDITION_CODE_4 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.VALUE_CODE_1 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.VALUE_AMOUNT_1 = MoneyUtilities.AmountFormat(this.Fields[this.ColIdx].ToString());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.VALUE_CODE_2 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.VALUE_AMOUNT_2 = MoneyUtilities.AmountFormat(this.Fields[this.ColIdx].ToString());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.VALUE_CODE_3 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.VALUE_AMOUNT_3 = MoneyUtilities.AmountFormat(this.Fields[this.ColIdx].ToString());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.VALUE_CODE_4 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.VALUE_AMOUNT_4 = MoneyUtilities.AmountFormat(this.Fields[this.ColIdx].ToString());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.VALUE_CODE_5 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.VALUE_AMOUNT_5 = MoneyUtilities.AmountFormat(this.Fields[this.ColIdx].ToString());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.VALUE_CODE_6 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.VALUE_AMOUNT_6 = MoneyUtilities.AmountFormat(this.Fields[this.ColIdx].ToString());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_SPAN_CODES = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_SPAN_DATE_FROM = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_SPAN_DATE_TO = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OPTUM_REGION_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                SetAdditionalFields();
                SetLookupFields();
            }
            catch
            {
                this.IsValid = false;
            }
        }

        /// <summary>
        /// Loads a line written by the ToString of this class and populates the properties.
        /// </summary>
        /// <param name="line">The line to load.</param>
        public void LoadFromString(string line)
        {
            this.Fields = line?.Split('|');
            this.LoadFromFieldsArray();
        }

        /// <summary>
        /// Loads a line written by the ToString of this class and populates the properties.
        /// </summary>
        /// <param name="fields">The fields to load.</param>
        public void LoadFromString(object[] fields)
        {
            this.Fields = fields;
            this.LoadFromFieldsArray();
        }

        /// <summary>
        /// Clears all of the properties of their respective values.
        /// </summary>
        public void Clear()
        {
            this.IsValid = false;
            this.ROWID = string.Empty;
            this.CLAIM_ID = string.Empty;
            this.HMO = string.Empty;
            this.CLIENT_CLAIM_ID = string.Empty;
            this.CLIENT_CLAIM_SEQUENCE_TYPE = string.Empty;
            this.CLIENT_CLAIM_SEQUENCE_NUMBER = string.Empty;
            this.CLIENT_PRIOR_CLAIM_ID = string.Empty;
            this.CLIENT_ORIGINAL_CLAIM_ID = string.Empty;
            this.CLIENT_CLAIM_BYPASS_CODE = string.Empty;
            this.CLIENT_CLAIM_RECEIPT_DATE = string.Empty;
            this.CLIENT_CLAIM_ENCOUNTER_CAPITATION_INDICATOR = string.Empty;
            this.CLIENT_CLAIM_BCBS_ITS_CLAIM_INDICATOR = string.Empty;
            this.CLIENT_CLAIM_BCBS_ITS_SCCF_NUMBER = string.Empty;
            this.CLIENT_CLAIM_PAYMENT_CODE = string.Empty;
            this.CLIENT_MEDICAL_RECORD_INDICATOR = string.Empty;
            this.CLIENT_MEDICAL_RECORD_NUMBER = string.Empty;
            this.CLIENT_COMPANY_CODE = string.Empty;
            this.CLIENT_BUSINESS_UNIT_CODE = string.Empty;
            this.CLIENT_REGION_CODE = string.Empty;
            this.CLIENT_LOB_CODE = string.Empty;
            this.CLIENT_CLAIM_PRICING_METHODOLOGY = string.Empty;
            this.CLIENT_CLAIM_COB_PAYER_SEQUENCE = string.Empty;
            this.CLIENT_ADJUDICATION_PLATFORM_ID = string.Empty;
            this.CLIENT_CLAIM_ADJUDICATION_LIFECYCLE_CODE = string.Empty;
            this.CLIENT_CLAIM_ADJUDICATION_STATUS_CODE = string.Empty;
            this.CLIENT_CLAIM_ADJUDICATION_REASON_CODE = string.Empty;
            this.CLIENT_CLAIM_ADJUDICATION_DATE = string.Empty;
            this.PATIENT_ACCT_NO = string.Empty;
            this.PAYER_ORIGINAL_CLAIM_CONTROL_NUMBER = string.Empty;
            this.TYPE_OF_CLAIM = string.Empty;
            this.CLAIM_FREQUENCY_OF_SUBMISSION_CODE = string.Empty;
            this.BILL_TYPE = string.Empty;
            this.PLACE_OF_SERVICE = string.Empty;
            this.CLAIM_FILING_INDICATOR_CODE = string.Empty;
            this.BENEFITS_ASSIGNMENT_CERTIFICATION_INDICATOR = string.Empty;
            this.RELEASE_OF_INFORMATION_CODE = string.Empty;
            this.CLAIM_TOTAL_BILLED_AMOUNT = string.Empty;
            this.CLAIM_TOTAL_PATIENT_LIABILITY_AMOUNT = string.Empty;
            this.CLAIM_TOTAL_PATIENT_COPAY_AMOUNT = string.Empty;
            this.AMT_ALLOWED = string.Empty;
            this.AMT_COB_PAID = string.Empty;
            this.CLAIM_TOTAL_COINSURANCE_AMOUNT = string.Empty;
            this.CLAIM_TOTAL_DEDUCTIBLE_AMOUNT = string.Empty;
            this.CLAIM_TOTAL_NON_COVERED_AMOUNT = string.Empty;
            this.CLAIM_TOTAL_COVERED_AMOUNT = string.Empty;
            this.CLAIM_TOTAL_TAX_AMOUNT = string.Empty;
            this.CLAIM_TOTAL_DISCOUNT_AMOUNT = string.Empty;
            this.CLAIM_TOTAL_WITHHOLD_AMOUNT = string.Empty;
            this.CLAIM_TOTAL_OTHER_REDUCTION_AMOUNT = string.Empty;
            this.CLAIM_TOTAL_INTEREST_AMOUNT = string.Empty;
            this.AMT_PAID = string.Empty;
            this.CLAIM_POST_DATE = string.Empty;
            this.CLAIM_PAID_DATE = string.Empty;
            this.CLAIM_CHECK_EFT_TRACE_NUMBER = string.Empty;
            this.CLAIM_STATEMENT_FROM_DATE = string.Empty;
            this.CLAIM_STATEMENT_TO_DATE = string.Empty;
            this.CLAIM_PRIOR_AUTHORIZATION_NUMBER = string.Empty;
            this.CLIA_NUMBER = string.Empty;
            this.PATIENT_TYPE_OF_ADMISSION = string.Empty;
            this.PATIENT_SOURCE_OF_ADMISSION = string.Empty;
            this.PATIENT_ADMISSION_DATE = string.Empty;
            this.PATIENT_ADMISSION_TIME = string.Empty;
            this.PATIENT_DISCHARGE_STATUS_CODE = string.Empty;
            this.PATIENT_DISCHARGE_DATE = string.Empty;
            this.PATIENT_DISCHARGE_TIME = string.Empty;
            this.PAT_MEMBER_NO = string.Empty;
            this.PATIENT_RELATIONSHIP_TO_SUBSCRIBER_CODE = string.Empty;
            this.SUB_MEMBER_NO = string.Empty;
            this.SUBSCRIBER_INSURER_PAYER_ID = string.Empty;
            this.SUBSCRIBER_INSURER_PAYER_NAME = string.Empty;
            this.SUBSCRIBER_GROUP_POLICY_NUMBER = string.Empty;
            this.SUBSCRIBER_GROUP_POLICY_NAME = string.Empty;
            this.SUBSCRIBER_PLAN_PRODUCT_CODE = string.Empty;
            this.SUBSCRIBER_PLAN_STATE_CODE = string.Empty;
            this.PROVIDER_NO = string.Empty;
            this.BILLING_PROVIDER_NPI = string.Empty;
            this.BILLING_PROVIDER_TIN = string.Empty;
            this.BILLING_PROVIDER_TAXONOMY_CODE = string.Empty;
            this.BILLING_PROVIDER_SPECIALTY_CODE = string.Empty;
            this.RENDERING_PROVIDER_CLIENT_ID = string.Empty;
            this.RENDERING_PROVIDER_NPI = string.Empty;
            this.RENDERING_PROVIDER_TAXONOMY_CODE = string.Empty;
            this.RENDERING_PROVIDER_SPECIALTY_CODE = string.Empty;
            this.RENDERING_PROVIDER_PAR_INDICATOR = string.Empty;
            this.RENDERING_PROVIDER_CONTRACT_ID = string.Empty;
            this.SERVICE_LOCATION_CLIENT_ID = string.Empty;
            this.SERVICE_LOCATION_CLIENT_NPI = string.Empty;
            this.REFERRING_PROVIDER_CLIENT_ID = string.Empty;
            this.REFERRING_PROVIDER_CLIENT_NPI = string.Empty;
            this.ATTENDING_PROVIDER_CLIENT_ID = string.Empty;
            this.ATTENDING_PROVIDER_CLIENT_NPI = string.Empty;
            this.ATTENDING_PROVIDER_TAXONOMY_CODE = string.Empty;
            this.ACCIDENT_STATE = string.Empty;
            this.ACCIDENT_DATE = string.Empty;
            this.ACCIDENT_RELATED_CAUSE_1 = string.Empty;
            this.ACCIDENT_RELATED_CAUSE_2 = string.Empty;
            this.CLAIM_ICD_VERSION_INDICATOR = string.Empty;
            this.SUBMITTED_DRG_CODE = string.Empty;
            this.ADJUDICATED_DRG_CODE = string.Empty;
            this.ADJUDICATED_DRG_WEIGHT = string.Empty;
            this.DRG_GROUPER = string.Empty;
            this.DRG_VERSION = string.Empty;
            this.DRG_LEVEL = string.Empty;
            this.DRG_SEVERITY_OF_ILLNESS = string.Empty;
            this.DRG_OUTLIER_DAY_COUNT = string.Empty;
            this.DRG_COVERED_DAY_COUNT = string.Empty;
            this.DRG_NON_COVERED_DAY_COUNT = string.Empty;
            this.ADMITTING_DIAGNOSIS_CODE = string.Empty;
            this.PRINCIPAL_DIAGNOSIS_CODE = string.Empty;
            this.PRINCIPAL_PROCEDURE_CODE = string.Empty;
            this.CONDITION_CODES = string.Empty;
            this.EXTERNALCAUSE_OF_INJURY_CODES = string.Empty;
            this.EXTERNAL_CAUSE_OF_INJURY_POA_INDICATOR = string.Empty;
            this.PATIENT_REASON_FOR_VISIT_CODE = string.Empty;
            this.SPAN_CODES = string.Empty;
            this.SPAN_DATE_FROM = string.Empty;
            this.SPAN_DATE_TO = string.Empty;
            this.TREATMENT_CODES = string.Empty;
            this.OCCURRENCE_CODE_1 = string.Empty;
            this.OCCURRENCE_DATE_1 = string.Empty;
            this.OCCURRENCE_CODE_2 = string.Empty;
            this.OCCURRENCE_DATE_2 = string.Empty;
            this.OCCURRENCE_CODE_3 = string.Empty;
            this.OCCURRENCE_DATE_3 = string.Empty;
            this.OCCURRENCE_CODE_4 = string.Empty;
            this.OCCURRENCE_DATE_4 = string.Empty;
            this.OCCURRENCE_CODE_5 = string.Empty;
            this.OCCURRENCE_DATE_5 = string.Empty;
            this.OCCURRENCE_CODE_6 = string.Empty;
            this.OCCURRENCE_DATE_6 = string.Empty;
            this.OCCURRENCE_CODE_7 = string.Empty;
            this.OCCURRENCE_DATE_7 = string.Empty;
            this.OCCURRENCE_CODE_8 = string.Empty;
            this.OCCURRENCE_DATE_8 = string.Empty;
            this.CONDITION_CODE_1 = string.Empty;
            this.CONDITION_CODE_2 = string.Empty;
            this.CONDITION_CODE_3 = string.Empty;
            this.CONDITION_CODE_4 = string.Empty;
            this.VALUE_CODE_1 = string.Empty;
            this.VALUE_AMOUNT_1 = string.Empty;
            this.VALUE_CODE_2 = string.Empty;
            this.VALUE_AMOUNT_2 = string.Empty;
            this.VALUE_CODE_3 = string.Empty;
            this.VALUE_AMOUNT_3 = string.Empty;
            this.VALUE_CODE_4 = string.Empty;
            this.VALUE_AMOUNT_4 = string.Empty;
            this.VALUE_CODE_5 = string.Empty;
            this.VALUE_AMOUNT_5 = string.Empty;
            this.VALUE_CODE_6 = string.Empty;
            this.VALUE_AMOUNT_6 = string.Empty;
            this.OCCURRENCE_SPAN_CODES = string.Empty;
            this.OCCURRENCE_SPAN_DATE_FROM = string.Empty;
            this.OCCURRENCE_SPAN_DATE_TO = string.Empty;
            this.OPTUM_REGION_NAME = string.Empty;
            this.DRG = string.Empty;
            this.DATE_OF_SERVICE_BEG = string.Empty;
            this.DATE_OF_SERVICE_END = string.Empty;
            this.AMT_BILLED = string.Empty;
            this.DATE_PAID = string.Empty;
            this.CLAIM_NO = string.Empty;
            this.CLAIM_SUFFIX = string.Empty;

            ClearLookupFields();
        }

        /// <summary>
        /// Overriding ToString here to prevent someone from accidentally calling object.ToString().
        /// <br/>I can't override ToString() like we usually do for FileObjects b/c this.ToString() requires a bool.
        /// <br/>This writes out the field data without the lookup fields.
        /// </summary>
        public override string ToString()
        {
            return this.ToString(false);
        }

        /// <summary>
        /// Outputs one line created from the concatenation of the properties in order they occur in the database table.
        /// <br/> Use 'includeLookupFields' to toggle writing lookup fields.
        /// </summary>
        /// <returns>The concatenated line of property values.</returns>
        public string ToString(bool includeLookupFields)
        {
            this.stringBuilder.Length = 0;

            this.AppendField(this.ROWID);
            this.AppendField(this.PROJECT_ID);
            this.AppendField(this.FEED_ID);
            this.AppendField(this.CLAIM_ID);
            this.AppendField(this.HMO);
            this.AppendField(this.CLIENT_CLAIM_ID);
            this.AppendField(this.CLIENT_CLAIM_SEQUENCE_TYPE);
            this.AppendField(this.CLIENT_CLAIM_SEQUENCE_NUMBER);
            this.AppendField(this.CLIENT_PRIOR_CLAIM_ID);
            this.AppendField(this.CLIENT_ORIGINAL_CLAIM_ID);
            this.AppendField(this.CLIENT_CLAIM_BYPASS_CODE);
            this.AppendField(this.CLIENT_CLAIM_RECEIPT_DATE);
            this.AppendField(this.CLIENT_CLAIM_ENCOUNTER_CAPITATION_INDICATOR);
            this.AppendField(this.CLIENT_CLAIM_BCBS_ITS_CLAIM_INDICATOR);
            this.AppendField(this.CLIENT_CLAIM_BCBS_ITS_SCCF_NUMBER);
            this.AppendField(this.CLIENT_CLAIM_PAYMENT_CODE);
            this.AppendField(this.CLIENT_MEDICAL_RECORD_INDICATOR);
            this.AppendField(this.CLIENT_MEDICAL_RECORD_NUMBER);
            this.AppendField(this.CLIENT_COMPANY_CODE);
            this.AppendField(this.CLIENT_BUSINESS_UNIT_CODE);
            this.AppendField(this.CLIENT_REGION_CODE);
            this.AppendField(this.CLIENT_LOB_CODE);
            this.AppendField(this.CLIENT_CLAIM_PRICING_METHODOLOGY);
            this.AppendField(this.CLIENT_CLAIM_COB_PAYER_SEQUENCE);
            this.AppendField(this.CLIENT_ADJUDICATION_PLATFORM_ID);
            this.AppendField(this.CLIENT_CLAIM_ADJUDICATION_LIFECYCLE_CODE);
            this.AppendField(this.CLIENT_CLAIM_ADJUDICATION_STATUS_CODE);
            this.AppendField(this.CLIENT_CLAIM_ADJUDICATION_REASON_CODE);
            this.AppendField(this.CLIENT_CLAIM_ADJUDICATION_DATE);
            this.AppendField(this.PATIENT_ACCT_NO);
            this.AppendField(this.PAYER_ORIGINAL_CLAIM_CONTROL_NUMBER);
            this.AppendField(this.TYPE_OF_CLAIM);
            this.AppendField(this.CLAIM_FREQUENCY_OF_SUBMISSION_CODE);
            this.AppendField(this.BILL_TYPE);
            this.AppendField(this.PLACE_OF_SERVICE);
            this.AppendField(this.CLAIM_FILING_INDICATOR_CODE);
            this.AppendField(this.BENEFITS_ASSIGNMENT_CERTIFICATION_INDICATOR);
            this.AppendField(this.RELEASE_OF_INFORMATION_CODE);
            this.AppendField(this.CLAIM_TOTAL_BILLED_AMOUNT);
            this.AppendField(this.CLAIM_TOTAL_PATIENT_LIABILITY_AMOUNT);
            this.AppendField(this.CLAIM_TOTAL_PATIENT_COPAY_AMOUNT);
            this.AppendField(this.AMT_ALLOWED);
            this.AppendField(this.AMT_COB_PAID);
            this.AppendField(this.CLAIM_TOTAL_COINSURANCE_AMOUNT);
            this.AppendField(this.CLAIM_TOTAL_DEDUCTIBLE_AMOUNT);
            this.AppendField(this.CLAIM_TOTAL_NON_COVERED_AMOUNT);
            this.AppendField(this.CLAIM_TOTAL_COVERED_AMOUNT);
            this.AppendField(this.CLAIM_TOTAL_TAX_AMOUNT);
            this.AppendField(this.CLAIM_TOTAL_DISCOUNT_AMOUNT);
            this.AppendField(this.CLAIM_TOTAL_WITHHOLD_AMOUNT);
            this.AppendField(this.CLAIM_TOTAL_OTHER_REDUCTION_AMOUNT);
            this.AppendField(this.CLAIM_TOTAL_INTEREST_AMOUNT);
            this.AppendField(this.AMT_PAID);
            this.AppendField(this.CLAIM_POST_DATE);
            this.AppendField(this.CLAIM_PAID_DATE);
            this.AppendField(this.CLAIM_CHECK_EFT_TRACE_NUMBER);
            this.AppendField(this.CLAIM_STATEMENT_FROM_DATE);
            this.AppendField(this.CLAIM_STATEMENT_TO_DATE);
            this.AppendField(this.CLAIM_PRIOR_AUTHORIZATION_NUMBER);
            this.AppendField(this.CLIA_NUMBER);
            this.AppendField(this.PATIENT_TYPE_OF_ADMISSION);
            this.AppendField(this.PATIENT_SOURCE_OF_ADMISSION);
            this.AppendField(this.PATIENT_ADMISSION_DATE);
            this.AppendField(this.PATIENT_ADMISSION_TIME);
            this.AppendField(this.PATIENT_DISCHARGE_STATUS_CODE);
            this.AppendField(this.PATIENT_DISCHARGE_DATE);
            this.AppendField(this.PATIENT_DISCHARGE_TIME);
            this.AppendField(this.PAT_MEMBER_NO);
            this.AppendField(this.PATIENT_RELATIONSHIP_TO_SUBSCRIBER_CODE);
            this.AppendField(this.SUB_MEMBER_NO);
            this.AppendField(this.SUBSCRIBER_INSURER_PAYER_ID);
            this.AppendField(this.SUBSCRIBER_INSURER_PAYER_NAME);
            this.AppendField(this.SUBSCRIBER_GROUP_POLICY_NUMBER);
            this.AppendField(this.SUBSCRIBER_GROUP_POLICY_NAME);
            this.AppendField(this.SUBSCRIBER_PLAN_PRODUCT_CODE);
            this.AppendField(this.SUBSCRIBER_PLAN_STATE_CODE);
            this.AppendField(this.PROVIDER_NO);
            this.AppendField(this.BILLING_PROVIDER_NPI);
            this.AppendField(this.BILLING_PROVIDER_TIN);
            this.AppendField(this.BILLING_PROVIDER_TAXONOMY_CODE);
            this.AppendField(this.BILLING_PROVIDER_SPECIALTY_CODE);
            this.AppendField(this.RENDERING_PROVIDER_CLIENT_ID);
            this.AppendField(this.RENDERING_PROVIDER_NPI);
            this.AppendField(this.RENDERING_PROVIDER_TAXONOMY_CODE);
            this.AppendField(this.RENDERING_PROVIDER_SPECIALTY_CODE);
            this.AppendField(this.RENDERING_PROVIDER_PAR_INDICATOR);
            this.AppendField(this.RENDERING_PROVIDER_CONTRACT_ID);
            this.AppendField(this.SERVICE_LOCATION_CLIENT_ID);
            this.AppendField(this.SERVICE_LOCATION_CLIENT_NPI);
            this.AppendField(this.REFERRING_PROVIDER_CLIENT_ID);
            this.AppendField(this.REFERRING_PROVIDER_CLIENT_NPI);
            this.AppendField(this.ATTENDING_PROVIDER_CLIENT_ID);
            this.AppendField(this.ATTENDING_PROVIDER_CLIENT_NPI);
            this.AppendField(this.ATTENDING_PROVIDER_TAXONOMY_CODE);
            this.AppendField(this.ACCIDENT_STATE);
            this.AppendField(this.ACCIDENT_DATE);
            this.AppendField(this.ACCIDENT_RELATED_CAUSE_1);
            this.AppendField(this.ACCIDENT_RELATED_CAUSE_2);
            this.AppendField(this.CLAIM_ICD_VERSION_INDICATOR);
            this.AppendField(this.SUBMITTED_DRG_CODE);
            this.AppendField(this.ADJUDICATED_DRG_CODE);
            this.AppendField(this.ADJUDICATED_DRG_WEIGHT);
            this.AppendField(this.DRG_GROUPER);
            this.AppendField(this.DRG_VERSION);
            this.AppendField(this.DRG_LEVEL);
            this.AppendField(this.DRG_SEVERITY_OF_ILLNESS);
            this.AppendField(this.DRG_OUTLIER_DAY_COUNT);
            this.AppendField(this.DRG_COVERED_DAY_COUNT);
            this.AppendField(this.DRG_NON_COVERED_DAY_COUNT);
            this.AppendField(this.ADMITTING_DIAGNOSIS_CODE);
            this.AppendField(this.PRINCIPAL_DIAGNOSIS_CODE);
            this.AppendField(this.PRINCIPAL_PROCEDURE_CODE);
            this.AppendField(this.CONDITION_CODES);
            this.AppendField(this.EXTERNALCAUSE_OF_INJURY_CODES);
            this.AppendField(this.EXTERNAL_CAUSE_OF_INJURY_POA_INDICATOR);
            this.AppendField(this.PATIENT_REASON_FOR_VISIT_CODE);
            this.AppendField(this.SPAN_CODES);
            this.AppendField(this.SPAN_DATE_FROM);
            this.AppendField(this.SPAN_DATE_TO);
            this.AppendField(this.TREATMENT_CODES);
            this.AppendField(this.OCCURRENCE_CODE_1);
            this.AppendField(this.OCCURRENCE_DATE_1);
            this.AppendField(this.OCCURRENCE_CODE_2);
            this.AppendField(this.OCCURRENCE_DATE_2);
            this.AppendField(this.OCCURRENCE_CODE_3);
            this.AppendField(this.OCCURRENCE_DATE_3);
            this.AppendField(this.OCCURRENCE_CODE_4);
            this.AppendField(this.OCCURRENCE_DATE_4);
            this.AppendField(this.OCCURRENCE_CODE_5);
            this.AppendField(this.OCCURRENCE_DATE_5);
            this.AppendField(this.OCCURRENCE_CODE_6);
            this.AppendField(this.OCCURRENCE_DATE_6);
            this.AppendField(this.OCCURRENCE_CODE_7);
            this.AppendField(this.OCCURRENCE_DATE_7);
            this.AppendField(this.OCCURRENCE_CODE_8);
            this.AppendField(this.OCCURRENCE_DATE_8);
            this.AppendField(this.CONDITION_CODE_1);
            this.AppendField(this.CONDITION_CODE_2);
            this.AppendField(this.CONDITION_CODE_3);
            this.AppendField(this.CONDITION_CODE_4);
            this.AppendField(this.VALUE_CODE_1);
            this.AppendField(this.VALUE_AMOUNT_1);
            this.AppendField(this.VALUE_CODE_2);
            this.AppendField(this.VALUE_AMOUNT_2);
            this.AppendField(this.VALUE_CODE_3);
            this.AppendField(this.VALUE_AMOUNT_3);
            this.AppendField(this.VALUE_CODE_4);
            this.AppendField(this.VALUE_AMOUNT_4);
            this.AppendField(this.VALUE_CODE_5);
            this.AppendField(this.VALUE_AMOUNT_5);
            this.AppendField(this.VALUE_CODE_6);
            this.AppendField(this.VALUE_AMOUNT_6);
            this.AppendField(this.OCCURRENCE_SPAN_CODES);
            this.AppendField(this.OCCURRENCE_SPAN_DATE_FROM);
            this.AppendField(this.OCCURRENCE_SPAN_DATE_TO);
            this.AppendField(this.OPTUM_REGION_NAME);
            this.AppendField(this.DRG);
            this.AppendField(this.DATE_OF_SERVICE_BEG);
            this.AppendField(this.DATE_OF_SERVICE_END);
            this.AppendField(this.AMT_BILLED);
            this.AppendField(this.DATE_PAID);
            this.AppendField(this.CLAIM_NO);

            if (includeLookupFields)
            {
                this.AppendField(this.CLAIM_SUFFIX);
                AppendLookupFields();
            }
            else
            {
                this.AppendLastField(this.CLAIM_SUFFIX);
            }

            return this.stringBuilder.ToString();
        }

        /// <summary>
        /// Outputs the header column names in order they occur in the database table.
        /// </summary>
        /// <returns>The concatenated line of header values.</returns>
        public string EmitHeaderLine(bool includeLookupFields)
        {
            this.stringBuilder.Length = 0;

            this.AppendField(@"ROWID");
            this.AppendField(@"PROJECT_ID");
            this.AppendField(@"FEED_ID");
            this.AppendField(@"CLAIM_ID");
            this.AppendField(@"HMO");
            this.AppendField(@"CLIENT_CLAIM_ID");
            this.AppendField(@"CLIENT_CLAIM_SEQUENCE_TYPE");
            this.AppendField(@"CLIENT_CLAIM_SEQUENCE_NUMBER");
            this.AppendField(@"CLIENT_PRIOR_CLAIM_ID");
            this.AppendField(@"CLIENT_ORIGINAL_CLAIM_ID");
            this.AppendField(@"CLIENT_CLAIM_BYPASS_CODE");
            this.AppendField(@"CLIENT_CLAIM_RECEIPT_DATE");
            this.AppendField(@"CLIENT_CLAIM_ENCOUNTER_CAPITATION_INDICATOR");
            this.AppendField(@"CLIENT_CLAIM_BCBS_ITS_CLAIM_INDICATOR");
            this.AppendField(@"CLIENT_CLAIM_BCBS_ITS_SCCF_NUMBER");
            this.AppendField(@"CLIENT_CLAIM_PAYMENT_CODE");
            this.AppendField(@"CLIENT_MEDICAL_RECORD_INDICATOR");
            this.AppendField(@"CLIENT_MEDICAL_RECORD_NUMBER");
            this.AppendField(@"CLIENT_COMPANY_CODE");
            this.AppendField(@"CLIENT_BUSINESS_UNIT_CODE");
            this.AppendField(@"CLIENT_REGION_CODE");
            this.AppendField(@"CLIENT_LOB_CODE");
            this.AppendField(@"CLIENT_CLAIM_PRICING_METHODOLOGY");
            this.AppendField(@"CLIENT_CLAIM_COB_PAYER_SEQUENCE");
            this.AppendField(@"CLIENT_ADJUDICATION_PLATFORM_ID");
            this.AppendField(@"CLIENT_CLAIM_ADJUDICATION_LIFECYCLE_CODE");
            this.AppendField(@"CLIENT_CLAIM_ADJUDICATION_STATUS_CODE");
            this.AppendField(@"CLIENT_CLAIM_ADJUDICATION_REASON_CODE");
            this.AppendField(@"CLIENT_CLAIM_ADJUDICATION_DATE");
            this.AppendField(@"PATIENT_ACCT_NO");
            this.AppendField(@"PAYER_ORIGINAL_CLAIM_CONTROL_NUMBER");
            this.AppendField(@"TYPE_OF_CLAIM");
            this.AppendField(@"CLAIM_FREQUENCY_OF_SUBMISSION_CODE");
            this.AppendField(@"BILL_TYPE");
            this.AppendField(@"PLACE_OF_SERVICE");
            this.AppendField(@"CLAIM_FILING_INDICATOR_CODE");
            this.AppendField(@"BENEFITS_ASSIGNMENT_CERTIFICATION_INDICATOR");
            this.AppendField(@"RELEASE_OF_INFORMATION_CODE");
            this.AppendField(@"CLAIM_TOTAL_BILLED_AMOUNT");
            this.AppendField(@"CLAIM_TOTAL_PATIENT_LIABILITY_AMOUNT");
            this.AppendField(@"CLAIM_TOTAL_PATIENT_COPAY_AMOUNT");
            this.AppendField(@"AMT_ALLOWED");
            this.AppendField(@"AMT_COB_PAID");
            this.AppendField(@"CLAIM_TOTAL_COINSURANCE_AMOUNT");
            this.AppendField(@"CLAIM_TOTAL_DEDUCTIBLE_AMOUNT");
            this.AppendField(@"CLAIM_TOTAL_NON_COVERED_AMOUNT");
            this.AppendField(@"CLAIM_TOTAL_COVERED_AMOUNT");
            this.AppendField(@"CLAIM_TOTAL_TAX_AMOUNT");
            this.AppendField(@"CLAIM_TOTAL_DISCOUNT_AMOUNT");
            this.AppendField(@"CLAIM_TOTAL_WITHHOLD_AMOUNT");
            this.AppendField(@"CLAIM_TOTAL_OTHER_REDUCTION_AMOUNT");
            this.AppendField(@"CLAIM_TOTAL_INTEREST_AMOUNT");
            this.AppendField(@"AMT_PAID");
            this.AppendField(@"CLAIM_POST_DATE");
            this.AppendField(@"CLAIM_PAID_DATE");
            this.AppendField(@"CLAIM_CHECK_EFT_TRACE_NUMBER");
            this.AppendField(@"CLAIM_STATEMENT_FROM_DATE");
            this.AppendField(@"CLAIM_STATEMENT_TO_DATE");
            this.AppendField(@"CLAIM_PRIOR_AUTHORIZATION_NUMBER");
            this.AppendField(@"CLIA_NUMBER");
            this.AppendField(@"PATIENT_TYPE_OF_ADMISSION");
            this.AppendField(@"PATIENT_SOURCE_OF_ADMISSION");
            this.AppendField(@"PATIENT_ADMISSION_DATE");
            this.AppendField(@"PATIENT_ADMISSION_TIME");
            this.AppendField(@"PATIENT_DISCHARGE_STATUS_CODE");
            this.AppendField(@"PATIENT_DISCHARGE_DATE");
            this.AppendField(@"PATIENT_DISCHARGE_TIME");
            this.AppendField(@"PAT_MEMBER_NO");
            this.AppendField(@"PATIENT_RELATIONSHIP_TO_SUBSCRIBER_CODE");
            this.AppendField(@"SUB_MEMBER_NO");
            this.AppendField(@"SUBSCRIBER_INSURER_PAYER_ID");
            this.AppendField(@"SUBSCRIBER_INSURER_PAYER_NAME");
            this.AppendField(@"SUBSCRIBER_GROUP_POLICY_NUMBER");
            this.AppendField(@"SUBSCRIBER_GROUP_POLICY_NAME");
            this.AppendField(@"SUBSCRIBER_PLAN_PRODUCT_CODE");
            this.AppendField(@"SUBSCRIBER_PLAN_STATE_CODE");
            this.AppendField(@"PROVIDER_NO");
            this.AppendField(@"BILLING_PROVIDER_NPI");
            this.AppendField(@"BILLING_PROVIDER_TIN");
            this.AppendField(@"BILLING_PROVIDER_TAXONOMY_CODE");
            this.AppendField(@"BILLING_PROVIDER_SPECIALTY_CODE");
            this.AppendField(@"RENDERING_PROVIDER_CLIENT_ID");
            this.AppendField(@"RENDERING_PROVIDER_NPI");
            this.AppendField(@"RENDERING_PROVIDER_TAXONOMY_CODE");
            this.AppendField(@"RENDERING_PROVIDER_SPECIALTY_CODE");
            this.AppendField(@"RENDERING_PROVIDER_PAR_INDICATOR");
            this.AppendField(@"RENDERING_PROVIDER_CONTRACT_ID");
            this.AppendField(@"SERVICE_LOCATION_CLIENT_ID");
            this.AppendField(@"SERVICE_LOCATION_CLIENT_NPI");
            this.AppendField(@"REFERRING_PROVIDER_CLIENT_ID");
            this.AppendField(@"REFERRING_PROVIDER_CLIENT_NPI");
            this.AppendField(@"ATTENDING_PROVIDER_CLIENT_ID");
            this.AppendField(@"ATTENDING_PROVIDER_CLIENT_NPI");
            this.AppendField(@"ATTENDING_PROVIDER_TAXONOMY_CODE");
            this.AppendField(@"ACCIDENT_STATE");
            this.AppendField(@"ACCIDENT_DATE");
            this.AppendField(@"ACCIDENT_RELATED_CAUSE_1");
            this.AppendField(@"ACCIDENT_RELATED_CAUSE_2");
            this.AppendField(@"CLAIM_ICD_VERSION_INDICATOR");
            this.AppendField(@"SUBMITTED_DRG_CODE");
            this.AppendField(@"ADJUDICATED_DRG_CODE");
            this.AppendField(@"ADJUDICATED_DRG_WEIGHT");
            this.AppendField(@"DRG_GROUPER");
            this.AppendField(@"DRG_VERSION");
            this.AppendField(@"DRG_LEVEL");
            this.AppendField(@"DRG_SEVERITY_OF_ILLNESS");
            this.AppendField(@"DRG_OUTLIER_DAY_COUNT");
            this.AppendField(@"DRG_COVERED_DAY_COUNT");
            this.AppendField(@"DRG_NON_COVERED_DAY_COUNT");
            this.AppendField(@"ADMITTING_DIAGNOSIS_CODE");
            this.AppendField(@"PRINCIPAL_DIAGNOSIS_CODE");
            this.AppendField(@"PRINCIPAL_PROCEDURE_CODE");
            this.AppendField(@"CONDITION_CODES");
            this.AppendField(@"EXTERNALCAUSE_OF_INJURY_CODES");
            this.AppendField(@"EXTERNAL_CAUSE_OF_INJURY_POA_INDICATOR");
            this.AppendField(@"PATIENT_REASON_FOR_VISIT_CODE");
            this.AppendField(@"SPAN_CODES");
            this.AppendField(@"SPAN_DATE_FROM");
            this.AppendField(@"SPAN_DATE_TO");
            this.AppendField(@"TREATMENT_CODES");
            this.AppendField(@"OCCURRENCE_CODE_1");
            this.AppendField(@"OCCURRENCE_DATE_1");
            this.AppendField(@"OCCURRENCE_CODE_2");
            this.AppendField(@"OCCURRENCE_DATE_2");
            this.AppendField(@"OCCURRENCE_CODE_3");
            this.AppendField(@"OCCURRENCE_DATE_3");
            this.AppendField(@"OCCURRENCE_CODE_4");
            this.AppendField(@"OCCURRENCE_DATE_4");
            this.AppendField(@"OCCURRENCE_CODE_5");
            this.AppendField(@"OCCURRENCE_DATE_5");
            this.AppendField(@"OCCURRENCE_CODE_6");
            this.AppendField(@"OCCURRENCE_DATE_6");
            this.AppendField(@"OCCURRENCE_CODE_7");
            this.AppendField(@"OCCURRENCE_DATE_7");
            this.AppendField(@"OCCURRENCE_CODE_8");
            this.AppendField(@"OCCURRENCE_DATE_8");
            this.AppendField(@"CONDITION_CODE_1");
            this.AppendField(@"CONDITION_CODE_2");
            this.AppendField(@"CONDITION_CODE_3");
            this.AppendField(@"CONDITION_CODE_4");
            this.AppendField(@"VALUE_CODE_1");
            this.AppendField(@"VALUE_AMOUNT_1");
            this.AppendField(@"VALUE_CODE_2");
            this.AppendField(@"VALUE_AMOUNT_2");
            this.AppendField(@"VALUE_CODE_3");
            this.AppendField(@"VALUE_AMOUNT_3");
            this.AppendField(@"VALUE_CODE_4");
            this.AppendField(@"VALUE_AMOUNT_4");
            this.AppendField(@"VALUE_CODE_5");
            this.AppendField(@"VALUE_AMOUNT_5");
            this.AppendField(@"VALUE_CODE_6");
            this.AppendField(@"VALUE_AMOUNT_6");
            this.AppendField(@"OCCURRENCE_SPAN_CODES");
            this.AppendField(@"OCCURRENCE_SPAN_DATE_FROM");
            this.AppendField(@"OCCURRENCE_SPAN_DATE_TO");
            this.AppendField(@"OPTUM_REGION_NAME");
            this.AppendField(@"DRG");
            this.AppendField(@"DATE_OF_SERVICE_BEG");
            this.AppendField(@"DATE_OF_SERVICE_END");
            this.AppendField(@"AMT_BILLED");
            this.AppendField(@"DATE_PAID");
            this.AppendField(@"CLAIM_NO");

            if (includeLookupFields)
            {
                this.AppendField(@"CLAIM_SUFFIX");
                AppendLookupFieldsHeader();
            }
            else
            {
                this.AppendLastField(@"CLAIM_SUFFIX");
            }

            return this.stringBuilder.ToString();
        }

        /// <summary>
        /// Loads a line from this.Fields.
        /// </summary>
        private void LoadFromFieldsArray()
        {
            this.Clear();

            // If any essential field fails to load successfully IsValid can be set to false.
            this.IsValid = true;

            try
            {
                this.ColIdx = -1;

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ROWID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROJECT_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.FEED_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.HMO = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_SEQUENCE_TYPE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_SEQUENCE_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_PRIOR_CLAIM_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_ORIGINAL_CLAIM_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_BYPASS_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_RECEIPT_DATE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_ENCOUNTER_CAPITATION_INDICATOR = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_BCBS_ITS_CLAIM_INDICATOR = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_BCBS_ITS_SCCF_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_PAYMENT_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_MEDICAL_RECORD_INDICATOR = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_MEDICAL_RECORD_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_COMPANY_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_BUSINESS_UNIT_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_REGION_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_LOB_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_PRICING_METHODOLOGY = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_COB_PAYER_SEQUENCE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_ADJUDICATION_PLATFORM_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_ADJUDICATION_LIFECYCLE_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_ADJUDICATION_STATUS_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_ADJUDICATION_REASON_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_ADJUDICATION_DATE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PATIENT_ACCT_NO = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PAYER_ORIGINAL_CLAIM_CONTROL_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.TYPE_OF_CLAIM = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_FREQUENCY_OF_SUBMISSION_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.BILL_TYPE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PLACE_OF_SERVICE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_FILING_INDICATOR_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.BENEFITS_ASSIGNMENT_CERTIFICATION_INDICATOR = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.RELEASE_OF_INFORMATION_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_TOTAL_BILLED_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_TOTAL_PATIENT_LIABILITY_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_TOTAL_PATIENT_COPAY_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.AMT_ALLOWED = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.AMT_COB_PAID = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_TOTAL_COINSURANCE_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_TOTAL_DEDUCTIBLE_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_TOTAL_NON_COVERED_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_TOTAL_COVERED_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_TOTAL_TAX_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_TOTAL_DISCOUNT_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_TOTAL_WITHHOLD_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_TOTAL_OTHER_REDUCTION_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_TOTAL_INTEREST_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.AMT_PAID = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_POST_DATE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_PAID_DATE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_CHECK_EFT_TRACE_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_STATEMENT_FROM_DATE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_STATEMENT_TO_DATE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_PRIOR_AUTHORIZATION_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIA_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PATIENT_TYPE_OF_ADMISSION = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PATIENT_SOURCE_OF_ADMISSION = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PATIENT_ADMISSION_DATE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PATIENT_ADMISSION_TIME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PATIENT_DISCHARGE_STATUS_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PATIENT_DISCHARGE_DATE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PATIENT_DISCHARGE_TIME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PAT_MEMBER_NO = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PATIENT_RELATIONSHIP_TO_SUBSCRIBER_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SUB_MEMBER_NO = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SUBSCRIBER_INSURER_PAYER_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SUBSCRIBER_INSURER_PAYER_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SUBSCRIBER_GROUP_POLICY_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SUBSCRIBER_GROUP_POLICY_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SUBSCRIBER_PLAN_PRODUCT_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SUBSCRIBER_PLAN_STATE_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_NO = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.BILLING_PROVIDER_NPI = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.BILLING_PROVIDER_TIN = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.BILLING_PROVIDER_TAXONOMY_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.BILLING_PROVIDER_SPECIALTY_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.RENDERING_PROVIDER_CLIENT_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.RENDERING_PROVIDER_NPI = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.RENDERING_PROVIDER_TAXONOMY_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.RENDERING_PROVIDER_SPECIALTY_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.RENDERING_PROVIDER_PAR_INDICATOR = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.RENDERING_PROVIDER_CONTRACT_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SERVICE_LOCATION_CLIENT_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SERVICE_LOCATION_CLIENT_NPI = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.REFERRING_PROVIDER_CLIENT_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.REFERRING_PROVIDER_CLIENT_NPI = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ATTENDING_PROVIDER_CLIENT_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ATTENDING_PROVIDER_CLIENT_NPI = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ATTENDING_PROVIDER_TAXONOMY_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ACCIDENT_STATE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ACCIDENT_DATE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ACCIDENT_RELATED_CAUSE_1 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ACCIDENT_RELATED_CAUSE_2 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_ICD_VERSION_INDICATOR = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SUBMITTED_DRG_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ADJUDICATED_DRG_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ADJUDICATED_DRG_WEIGHT = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DRG_GROUPER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DRG_VERSION = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DRG_LEVEL = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DRG_SEVERITY_OF_ILLNESS = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DRG_OUTLIER_DAY_COUNT = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DRG_COVERED_DAY_COUNT = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DRG_NON_COVERED_DAY_COUNT = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ADMITTING_DIAGNOSIS_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PRINCIPAL_DIAGNOSIS_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PRINCIPAL_PROCEDURE_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CONDITION_CODES = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.EXTERNALCAUSE_OF_INJURY_CODES = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.EXTERNAL_CAUSE_OF_INJURY_POA_INDICATOR = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PATIENT_REASON_FOR_VISIT_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SPAN_CODES = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SPAN_DATE_FROM = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SPAN_DATE_TO = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.TREATMENT_CODES = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_CODE_1 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_DATE_1 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_CODE_2 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_DATE_2 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_CODE_3 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_DATE_3 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_CODE_4 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_DATE_4 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_CODE_5 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_DATE_5 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_CODE_6 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_DATE_6 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_CODE_7 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_DATE_7 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_CODE_8 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_DATE_8 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CONDITION_CODE_1 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CONDITION_CODE_2 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CONDITION_CODE_3 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CONDITION_CODE_4 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.VALUE_CODE_1 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.VALUE_AMOUNT_1 = MoneyUtilities.AmountFormat(this.Fields[this.ColIdx].ToString());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.VALUE_CODE_2 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.VALUE_AMOUNT_2 = MoneyUtilities.AmountFormat(this.Fields[this.ColIdx].ToString());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.VALUE_CODE_3 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.VALUE_AMOUNT_3 = MoneyUtilities.AmountFormat(this.Fields[this.ColIdx].ToString());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.VALUE_CODE_4 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.VALUE_AMOUNT_4 = MoneyUtilities.AmountFormat(this.Fields[this.ColIdx].ToString());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.VALUE_CODE_5 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.VALUE_AMOUNT_5 = MoneyUtilities.AmountFormat(this.Fields[this.ColIdx].ToString());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.VALUE_CODE_6 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.VALUE_AMOUNT_6 = MoneyUtilities.AmountFormat(this.Fields[this.ColIdx].ToString());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_SPAN_CODES = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_SPAN_DATE_FROM = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OCCURRENCE_SPAN_DATE_TO = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OPTUM_REGION_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DRG = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DATE_OF_SERVICE_BEG = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DATE_OF_SERVICE_END = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.AMT_BILLED = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DATE_PAID = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_NO = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_SUFFIX = this.Fields[this.ColIdx].ToString().Trim();
                }

                LoadFromFieldsArrayLookupFields();
            }
            catch
            {
                this.IsValid = false;
            }
        }

        /// <summary>
        /// Appends the string and adds the delimitor after it.
        /// </summary>
        /// <param name="s">The string to be appended.</param>
        private void AppendField(string s)
        {
            this.stringBuilder.Append(s);
            this.stringBuilder.Append(this.Delimiter);
        }

        /// <summary>
        /// Appends the string but does not add the delimitor after it.
        /// </summary>
        /// <param name="s">The string to be appended.</param>
        private void AppendLastField(string s)
        {
            this.stringBuilder.Append(s);
        }

        private void SetAdditionalFields()
        {
            this.DRG = int.TryParse(this.DRG_SEVERITY_OF_ILLNESS, out var drg) ? drg.ToString() : string.Empty;

            /// DoSBeg, DoSEnd, and Amt_Billed will come from ClaimLine File            
            this.DATE_OF_SERVICE_BEG = string.Empty;
            this.DATE_OF_SERVICE_END = string.Empty;
            this.AMT_BILLED = string.Empty;

            SetDatePaid();
            SetClaimNo();
            SetClaimSuffix();
        }

        /// <summary>
        /// Copy from CLAIM_PAID_DATE. If CLAIM_PAID_DATE is null, copy from CLIENT_CLAIM_ADJUDICATION_DATE.
        /// </summary>
        public string SetDatePaid()
        {
            if (!string.IsNullOrEmpty(this.CLAIM_PAID_DATE))
                this.DATE_PAID = this.CLAIM_PAID_DATE;
            else
                this.DATE_PAID = !string.IsNullOrEmpty(this.CLIENT_CLAIM_ADJUDICATION_DATE) ? this.CLIENT_CLAIM_ADJUDICATION_DATE : string.Empty;

            return this.DATE_PAID;
        }

        /// <summary>
        /// Concatenate HMO + '-' + CLIENT_CLAIM_ID.
        /// </summary>
        public string SetClaimNo()
        {
            this.CLAIM_NO = this.HMO + "-" + this.CLIENT_CLAIM_ID;

            return this.CLAIM_NO;
        }

        /// <summary>
        /// Concatenate HMO + '-' + CLIENT_PRIOR_CLAIM_ID. CLIENT_PRIOR_CLAIM_ID is only populated 0.01% of the time.
        /// </summary>
        public string SetClaimSuffix()
        {
            if (string.IsNullOrEmpty(this.CLIENT_PRIOR_CLAIM_ID))
                this.CLAIM_SUFFIX = string.Empty;
            else
                this.CLAIM_SUFFIX = this.HMO + "-" + this.CLIENT_PRIOR_CLAIM_ID;

            return this.CLAIM_SUFFIX;
        }
        #endregion METHODS

        #region LOOKUP_FIELDS

        /// <summary>
        /// Appends delimiter for this field to be merged into.
        /// These are used to set SUB_MEMBER_NO in the adHocMemberFile.
        /// </summary>
        private void AppendLookupFields()
        {
            this.AppendLastField(this.CLAIM_NO_KEY);
        }

        /// <summary>
        /// Add header rows for these empty fields that will be merged into in the prepare claim step.
        /// These are used to set SUB_MEMBER_NO in the adHocMemberFile.
        /// </summary>
        private void AppendLookupFieldsHeader()
        {
            this.AppendLastField(@"CLAIM_NO_KEY");
        }

        /// <summary>
        /// Set lookup fields from raw.
        /// </summary>
        private void SetLookupFields()
        {
            this.CLAIM_NO_KEY = string.Empty;
        }

        /// <summary>
        /// Sets lookup fields when LoadFromString is called.
        /// </summary>
        private void LoadFromFieldsArrayLookupFields()
        {
            if (++this.ColIdx < this.Fields.Length)
            {
                this.CLAIM_NO_KEY = this.Fields[this.ColIdx].ToString().Trim();
            }
        }

        private void ClearLookupFields()
        {
            this.CLAIM_NO_KEY = string.Empty;
        }
        #endregion LOOKUP_FIELDS
    }
}
