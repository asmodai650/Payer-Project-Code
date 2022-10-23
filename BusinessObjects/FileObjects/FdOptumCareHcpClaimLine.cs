using System.Text;
using Novus.Toolbox;
using Novus.Payer1060.BusinessObjects.Constants;
using Novus.Payer1060.BusinessObjects.Utilities;

namespace Novus.Payer1060.BusinessObjects.FileObjects
{
    public class FdOptumCareHcpClaimLine
    {
        #region CLASS_VARIABLES

        private readonly StringBuilder stringBuilder = new StringBuilder();
        #endregion CLASS_VARIABLES

        #region CONSTRUCTORS

        /// <summary>
        /// Initializes a new instance of the <see cref="FdOptumCareHcpClaimLine" /> class.
        /// </summary>
        public FdOptumCareHcpClaimLine()
        {
            this.Clear();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FdOptumCareHcpClaimLine" /> class.
        /// </summary>
        /// <param name="racerLoadJobReadOnlyProperties">The instance of RacerLoadJobReadOnlyProperties for this file load.</param>
        public FdOptumCareHcpClaimLine(RacerLoadJobReadOnlyProperties racerLoadJobReadOnlyProperties)
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

        public string LINE_NO { get; set; }

        public string CLIENT_CLAIM_LINE_PRIOR_NUMBER { get; set; }

        public string DCN { get; set; }

        public string BILLING_PROVIDER_CLAIM_LINE_CONTROL_NUMBER { get; set; }

        public string CL_DATE_OF_SERVICE_BEG { get; set; }

        public string CL_DATE_OF_SERVICE_END { get; set; }

        public string C_REVENUE_CODE { get; set; }

        public string PROCEDURE_CODE { get; set; }

        public string CPT_MODIFIER { get; set; }

        public string MODIFIER_2 { get; set; }

        public string MODIFIER_3 { get; set; }

        public string MODIFIER_4 { get; set; }

        public string UNITS { get; set; }

        public string LINE_PLACE_OF_SERVICE_CODE { get; set; }

        public string LINE_NATIONAL_DRUG_CODE { get; set; }

        public string LINE_NATIONAL_DRUG_UNIT_OF_MEASUREMENT_CODE { get; set; }

        public string LINE_NATIONAL_DRUG_UNIT_COUNT { get; set; }

        public string LINE_PRIOR_AUTHORIZATION_NUMBER { get; set; }

        public string LINE_APC_PAYMENT_STATUS_INDICATOR { get; set; }

        public string LINE_APC_CODE { get; set; }

        public string LINE_ASC_RATE_CODE { get; set; }

        public string CL_AMT_BILLED { get; set; }

        public string LINE_PATIENT_LIABILITY_AMOUNT { get; set; }

        public string LINE_PATIENT_COPAY_AMOUNT { get; set; }

        public string CL_AMT_ALLOWED { get; set; }

        public string CL_AMT_COB_PAID { get; set; }

        public string LINE_COINSURANCE_AMOUNT { get; set; }

        public string DED_AMT { get; set; }

        public string LINE_NON_COVERED_AMOUNT { get; set; }

        public string LINE_COVERED_AMOUNT { get; set; }

        public string LINE_TAX_AMOUNT { get; set; }

        public string LINE_DISCOUNT_AMOUNT { get; set; }

        public string WITH_AMT { get; set; }

        public string LINE_OTHER_REDUCTION_AMOUNT { get; set; }

        public string LINE_INTEREST_AMOUNT { get; set; }

        public string CL_AMT_PAID { get; set; }

        public string AP_POST_DATE { get; set; }

        public string SERVICE_RENDERING_PROVIDER_CLIENT_ID { get; set; }

        public string SERVICE_RENDERING_PROVIDER_NPI { get; set; }

        public string SERVICE_RENDERING_PROVIDER_TAXONOMY { get; set; }

        public string SERVICE_RENDERING_PROVIDER_SPECIALTY { get; set; }

        public string SERVICE_RENDERING_PROVIDER_PAR_INDICATOR { get; set; }

        public string SERVICE_RENDERING_PROVIDER_CONTRACT_ID { get; set; }

        public string LINE_SERVICE_LOCATION_ID { get; set; }

        public string LINE_SERVICE_LOCATION_NPI { get; set; }

        public string CLIENT_LINE_BYPASS_INDICATOR { get; set; }

        public string CLIENT_LINE_PRICING_METHODOLOGY { get; set; }

        public string CLIENT_LINE_PAYMENT_CODE { get; set; }

        public string ADJUDICATION_DATE { get; set; }

        public string CLIENT_LINE_ADJUDICATION_STATUS_CODE { get; set; }

        public string CLIENT_LINE_ADJUDICATION_REASON_CODE { get; set; }

        public string CLIENT_LINE_ADJUDICATION_REMARK_CODE { get; set; }

        public string LINE_DIAGNOSIS_POINTER_1 { get; set; }

        public string LINE_DIAGNOSIS_POINTER_2 { get; set; }

        public string LINE_DIAGNOSIS_POINTER_3 { get; set; }

        public string LINE_DIAGNOSIS_POINTER_4 { get; set; }

        public string REVENUE_CODE { get; set; }

        public string CPT { get; set; }

        public string UNITS_BILLED { get; set; }

        public string CL_DATE_PAID { get; set; }

        public string CLAIM_NO { get; set; }

        public string CLAIM_NO_KEY { get; set; }
        #endregion PUBLIC_PROPERTIES

        #region PRIVATE_PROPERTIES

        /// <summary>
        /// Gets or sets an array of fields split out of the line using the delimiter.
        /// </summary>
        private object[] Fields { get; set; }

        /// <summary>
        /// Gets or sets a column index used to load from string.
        /// </summary>
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
               
                ///Check for Header row
                if (this.Fields.Length < 58 || this.Fields[0].ToString().ToLower().Contains("hmo"))
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
                    this.LINE_NO = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_LINE_PRIOR_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DCN = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.BILLING_PROVIDER_CLAIM_LINE_CONTROL_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CL_DATE_OF_SERVICE_BEG = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CL_DATE_OF_SERVICE_END = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.C_REVENUE_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CPT_MODIFIER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MODIFIER_2 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MODIFIER_3 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MODIFIER_4 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.UNITS = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_PLACE_OF_SERVICE_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_NATIONAL_DRUG_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_NATIONAL_DRUG_UNIT_OF_MEASUREMENT_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_NATIONAL_DRUG_UNIT_COUNT = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_PRIOR_AUTHORIZATION_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_APC_PAYMENT_STATUS_INDICATOR = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_APC_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_ASC_RATE_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CL_AMT_BILLED = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_PATIENT_LIABILITY_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_PATIENT_COPAY_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CL_AMT_ALLOWED = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CL_AMT_COB_PAID = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_COINSURANCE_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DED_AMT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_NON_COVERED_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_COVERED_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_TAX_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_DISCOUNT_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.WITH_AMT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_OTHER_REDUCTION_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_INTEREST_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CL_AMT_PAID = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.AP_POST_DATE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SERVICE_RENDERING_PROVIDER_CLIENT_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SERVICE_RENDERING_PROVIDER_NPI = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SERVICE_RENDERING_PROVIDER_TAXONOMY = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SERVICE_RENDERING_PROVIDER_SPECIALTY = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SERVICE_RENDERING_PROVIDER_PAR_INDICATOR = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SERVICE_RENDERING_PROVIDER_CONTRACT_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_SERVICE_LOCATION_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_SERVICE_LOCATION_NPI = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_LINE_BYPASS_INDICATOR = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_LINE_PRICING_METHODOLOGY = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_LINE_PAYMENT_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ADJUDICATION_DATE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_LINE_ADJUDICATION_STATUS_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_LINE_ADJUDICATION_REASON_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_LINE_ADJUDICATION_REMARK_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_DIAGNOSIS_POINTER_1 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_DIAGNOSIS_POINTER_2 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_DIAGNOSIS_POINTER_3 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_DIAGNOSIS_POINTER_4 = this.Fields[this.ColIdx].ToString().Trim();
                }

                //set fields not directly read from raw client file
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
            this.LINE_NO = string.Empty;
            this.CLIENT_CLAIM_LINE_PRIOR_NUMBER = string.Empty;
            this.DCN = string.Empty;
            this.BILLING_PROVIDER_CLAIM_LINE_CONTROL_NUMBER = string.Empty;
            this.CL_DATE_OF_SERVICE_BEG = string.Empty;
            this.CL_DATE_OF_SERVICE_END = string.Empty;
            this.C_REVENUE_CODE = string.Empty;
            this.PROCEDURE_CODE = string.Empty;
            this.CPT_MODIFIER = string.Empty;
            this.MODIFIER_2 = string.Empty;
            this.MODIFIER_3 = string.Empty;
            this.MODIFIER_4 = string.Empty;
            this.UNITS = string.Empty;
            this.LINE_PLACE_OF_SERVICE_CODE = string.Empty;
            this.LINE_NATIONAL_DRUG_CODE = string.Empty;
            this.LINE_NATIONAL_DRUG_UNIT_OF_MEASUREMENT_CODE = string.Empty;
            this.LINE_NATIONAL_DRUG_UNIT_COUNT = string.Empty;
            this.LINE_PRIOR_AUTHORIZATION_NUMBER = string.Empty;
            this.LINE_APC_PAYMENT_STATUS_INDICATOR = string.Empty;
            this.LINE_APC_CODE = string.Empty;
            this.LINE_ASC_RATE_CODE = string.Empty;
            this.CL_AMT_BILLED = string.Empty;
            this.LINE_PATIENT_LIABILITY_AMOUNT = string.Empty;
            this.LINE_PATIENT_COPAY_AMOUNT = string.Empty;
            this.CL_AMT_ALLOWED = string.Empty;
            this.CL_AMT_COB_PAID = string.Empty;
            this.LINE_COINSURANCE_AMOUNT = string.Empty;
            this.DED_AMT = string.Empty;
            this.LINE_NON_COVERED_AMOUNT = string.Empty;
            this.LINE_COVERED_AMOUNT = string.Empty;
            this.LINE_TAX_AMOUNT = string.Empty;
            this.LINE_DISCOUNT_AMOUNT = string.Empty;
            this.WITH_AMT = string.Empty;
            this.LINE_OTHER_REDUCTION_AMOUNT = string.Empty;
            this.LINE_INTEREST_AMOUNT = string.Empty;
            this.CL_AMT_PAID = string.Empty;
            this.AP_POST_DATE = string.Empty;
            this.SERVICE_RENDERING_PROVIDER_CLIENT_ID = string.Empty;
            this.SERVICE_RENDERING_PROVIDER_NPI = string.Empty;
            this.SERVICE_RENDERING_PROVIDER_TAXONOMY = string.Empty;
            this.SERVICE_RENDERING_PROVIDER_SPECIALTY = string.Empty;
            this.SERVICE_RENDERING_PROVIDER_PAR_INDICATOR = string.Empty;
            this.SERVICE_RENDERING_PROVIDER_CONTRACT_ID = string.Empty;
            this.LINE_SERVICE_LOCATION_ID = string.Empty;
            this.LINE_SERVICE_LOCATION_NPI = string.Empty;
            this.CLIENT_LINE_BYPASS_INDICATOR = string.Empty;
            this.CLIENT_LINE_PRICING_METHODOLOGY = string.Empty;
            this.CLIENT_LINE_PAYMENT_CODE = string.Empty;
            this.ADJUDICATION_DATE = string.Empty;
            this.CLIENT_LINE_ADJUDICATION_STATUS_CODE = string.Empty;
            this.CLIENT_LINE_ADJUDICATION_REASON_CODE = string.Empty;
            this.CLIENT_LINE_ADJUDICATION_REMARK_CODE = string.Empty;
            this.LINE_DIAGNOSIS_POINTER_1 = string.Empty;
            this.LINE_DIAGNOSIS_POINTER_2 = string.Empty;
            this.LINE_DIAGNOSIS_POINTER_3 = string.Empty;
            this.LINE_DIAGNOSIS_POINTER_4 = string.Empty;
            this.REVENUE_CODE = string.Empty;
            this.CPT = string.Empty;
            this.UNITS_BILLED = string.Empty;
            this.CL_DATE_PAID = string.Empty;
            this.CLAIM_NO = string.Empty;

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
            this.AppendField(this.LINE_NO);
            this.AppendField(this.CLIENT_CLAIM_LINE_PRIOR_NUMBER);
            this.AppendField(this.DCN);
            this.AppendField(this.BILLING_PROVIDER_CLAIM_LINE_CONTROL_NUMBER);
            this.AppendField(this.CL_DATE_OF_SERVICE_BEG);
            this.AppendField(this.CL_DATE_OF_SERVICE_END);
            this.AppendField(this.C_REVENUE_CODE);
            this.AppendField(this.PROCEDURE_CODE);
            this.AppendField(this.CPT_MODIFIER);
            this.AppendField(this.MODIFIER_2);
            this.AppendField(this.MODIFIER_3);
            this.AppendField(this.MODIFIER_4);
            this.AppendField(this.UNITS);
            this.AppendField(this.LINE_PLACE_OF_SERVICE_CODE);
            this.AppendField(this.LINE_NATIONAL_DRUG_CODE);
            this.AppendField(this.LINE_NATIONAL_DRUG_UNIT_OF_MEASUREMENT_CODE);
            this.AppendField(this.LINE_NATIONAL_DRUG_UNIT_COUNT);
            this.AppendField(this.LINE_PRIOR_AUTHORIZATION_NUMBER);
            this.AppendField(this.LINE_APC_PAYMENT_STATUS_INDICATOR);
            this.AppendField(this.LINE_APC_CODE);
            this.AppendField(this.LINE_ASC_RATE_CODE);
            this.AppendField(this.CL_AMT_BILLED);
            this.AppendField(this.LINE_PATIENT_LIABILITY_AMOUNT);
            this.AppendField(this.LINE_PATIENT_COPAY_AMOUNT);
            this.AppendField(this.CL_AMT_ALLOWED);
            this.AppendField(this.CL_AMT_COB_PAID);
            this.AppendField(this.LINE_COINSURANCE_AMOUNT);
            this.AppendField(this.DED_AMT);
            this.AppendField(this.LINE_NON_COVERED_AMOUNT);
            this.AppendField(this.LINE_COVERED_AMOUNT);
            this.AppendField(this.LINE_TAX_AMOUNT);
            this.AppendField(this.LINE_DISCOUNT_AMOUNT);
            this.AppendField(this.WITH_AMT);
            this.AppendField(this.LINE_OTHER_REDUCTION_AMOUNT);
            this.AppendField(this.LINE_INTEREST_AMOUNT);
            this.AppendField(this.CL_AMT_PAID);
            this.AppendField(this.AP_POST_DATE);
            this.AppendField(this.SERVICE_RENDERING_PROVIDER_CLIENT_ID);
            this.AppendField(this.SERVICE_RENDERING_PROVIDER_NPI);
            this.AppendField(this.SERVICE_RENDERING_PROVIDER_TAXONOMY);
            this.AppendField(this.SERVICE_RENDERING_PROVIDER_SPECIALTY);
            this.AppendField(this.SERVICE_RENDERING_PROVIDER_PAR_INDICATOR);
            this.AppendField(this.SERVICE_RENDERING_PROVIDER_CONTRACT_ID);
            this.AppendField(this.LINE_SERVICE_LOCATION_ID);
            this.AppendField(this.LINE_SERVICE_LOCATION_NPI);
            this.AppendField(this.CLIENT_LINE_BYPASS_INDICATOR);
            this.AppendField(this.CLIENT_LINE_PRICING_METHODOLOGY);
            this.AppendField(this.CLIENT_LINE_PAYMENT_CODE);
            this.AppendField(this.ADJUDICATION_DATE);
            this.AppendField(this.CLIENT_LINE_ADJUDICATION_STATUS_CODE);
            this.AppendField(this.CLIENT_LINE_ADJUDICATION_REASON_CODE);
            this.AppendField(this.CLIENT_LINE_ADJUDICATION_REMARK_CODE);
            this.AppendField(this.LINE_DIAGNOSIS_POINTER_1);
            this.AppendField(this.LINE_DIAGNOSIS_POINTER_2);
            this.AppendField(this.LINE_DIAGNOSIS_POINTER_3);
            this.AppendField(this.LINE_DIAGNOSIS_POINTER_4);
            this.AppendField(this.REVENUE_CODE);
            this.AppendField(this.CPT);
            this.AppendField(this.UNITS_BILLED);
            this.AppendField(this.CL_DATE_PAID);

            if (includeLookupFields)
            {
                this.AppendField(this.CLAIM_NO);
                AppendLookupFields();
            }
            else
            {
                this.AppendLastField(this.CLAIM_NO);
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
            this.AppendField(@"LINE_NO");
            this.AppendField(@"CLIENT_CLAIM_LINE_PRIOR_NUMBER");
            this.AppendField(@"DCN");
            this.AppendField(@"BILLING_PROVIDER_CLAIM_LINE_CONTROL_NUMBER");
            this.AppendField(@"CL_DATE_OF_SERVICE_BEG");
            this.AppendField(@"CL_DATE_OF_SERVICE_END");
            this.AppendField(@"C_REVENUE_CODE");
            this.AppendField(@"PROCEDURE_CODE");
            this.AppendField(@"CPT_MODIFIER");
            this.AppendField(@"MODIFIER_2");
            this.AppendField(@"MODIFIER_3");
            this.AppendField(@"MODIFIER_4");
            this.AppendField(@"UNITS");
            this.AppendField(@"LINE_PLACE_OF_SERVICE_CODE");
            this.AppendField(@"LINE_NATIONAL_DRUG_CODE");
            this.AppendField(@"LINE_NATIONAL_DRUG_UNIT_OF_MEASUREMENT_CODE");
            this.AppendField(@"LINE_NATIONAL_DRUG_UNIT_COUNT");
            this.AppendField(@"LINE_PRIOR_AUTHORIZATION_NUMBER");
            this.AppendField(@"LINE_APC_PAYMENT_STATUS_INDICATOR");
            this.AppendField(@"LINE_APC_CODE");
            this.AppendField(@"LINE_ASC_RATE_CODE");
            this.AppendField(@"CL_AMT_BILLED");
            this.AppendField(@"LINE_PATIENT_LIABILITY_AMOUNT");
            this.AppendField(@"LINE_PATIENT_COPAY_AMOUNT");
            this.AppendField(@"CL_AMT_ALLOWED");
            this.AppendField(@"CL_AMT_COB_PAID");
            this.AppendField(@"LINE_COINSURANCE_AMOUNT");
            this.AppendField(@"DED_AMT");
            this.AppendField(@"LINE_NON_COVERED_AMOUNT");
            this.AppendField(@"LINE_COVERED_AMOUNT");
            this.AppendField(@"LINE_TAX_AMOUNT");
            this.AppendField(@"LINE_DISCOUNT_AMOUNT");
            this.AppendField(@"WITH_AMT");
            this.AppendField(@"LINE_OTHER_REDUCTION_AMOUNT");
            this.AppendField(@"LINE_INTEREST_AMOUNT");
            this.AppendField(@"CL_AMT_PAID");
            this.AppendField(@"AP_POST_DATE");
            this.AppendField(@"SERVICE_RENDERING_PROVIDER_CLIENT_ID");
            this.AppendField(@"SERVICE_RENDERING_PROVIDER_NPI");
            this.AppendField(@"SERVICE_RENDERING_PROVIDER_TAXONOMY");
            this.AppendField(@"SERVICE_RENDERING_PROVIDER_SPECIALTY");
            this.AppendField(@"SERVICE_RENDERING_PROVIDER_PAR_INDICATOR");
            this.AppendField(@"SERVICE_RENDERING_PROVIDER_CONTRACT_ID");
            this.AppendField(@"LINE_SERVICE_LOCATION_ID");
            this.AppendField(@"LINE_SERVICE_LOCATION_NPI");
            this.AppendField(@"CLIENT_LINE_BYPASS_INDICATOR");
            this.AppendField(@"CLIENT_LINE_PRICING_METHODOLOGY");
            this.AppendField(@"CLIENT_LINE_PAYMENT_CODE");
            this.AppendField(@"ADJUDICATION_DATE");
            this.AppendField(@"CLIENT_LINE_ADJUDICATION_STATUS_CODE");
            this.AppendField(@"CLIENT_LINE_ADJUDICATION_REASON_CODE");
            this.AppendField(@"CLIENT_LINE_ADJUDICATION_REMARK_CODE");
            this.AppendField(@"LINE_DIAGNOSIS_POINTER_1");
            this.AppendField(@"LINE_DIAGNOSIS_POINTER_2");
            this.AppendField(@"LINE_DIAGNOSIS_POINTER_3");
            this.AppendField(@"LINE_DIAGNOSIS_POINTER_4");
            this.AppendField(@"REVENUE_CODE");
            this.AppendField(@"CPT");
            this.AppendField(@"UNITS_BILLED");
            this.AppendField(@"CL_DATE_PAID");

            if (includeLookupFields)
            {
                this.AppendField(@"CLAIM_NO");
                AppendLookupFieldsHeader();
            }
            else
            {
                this.AppendLastField(@"CLAIM_NO");
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
                    this.LINE_NO = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_LINE_PRIOR_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DCN = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.BILLING_PROVIDER_CLAIM_LINE_CONTROL_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CL_DATE_OF_SERVICE_BEG = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CL_DATE_OF_SERVICE_END = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.C_REVENUE_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CPT_MODIFIER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MODIFIER_2 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MODIFIER_3 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MODIFIER_4 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.UNITS = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_PLACE_OF_SERVICE_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_NATIONAL_DRUG_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_NATIONAL_DRUG_UNIT_OF_MEASUREMENT_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_NATIONAL_DRUG_UNIT_COUNT = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_PRIOR_AUTHORIZATION_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_APC_PAYMENT_STATUS_INDICATOR = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_APC_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_ASC_RATE_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CL_AMT_BILLED = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_PATIENT_LIABILITY_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_PATIENT_COPAY_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CL_AMT_ALLOWED = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CL_AMT_COB_PAID = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_COINSURANCE_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DED_AMT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_NON_COVERED_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_COVERED_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_TAX_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_DISCOUNT_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.WITH_AMT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_OTHER_REDUCTION_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_INTEREST_AMOUNT = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CL_AMT_PAID = MoneyUtilities.FormatMoney(this.Fields[this.ColIdx].ToString().Trim());
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.AP_POST_DATE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SERVICE_RENDERING_PROVIDER_CLIENT_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SERVICE_RENDERING_PROVIDER_NPI = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SERVICE_RENDERING_PROVIDER_TAXONOMY = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SERVICE_RENDERING_PROVIDER_SPECIALTY = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SERVICE_RENDERING_PROVIDER_PAR_INDICATOR = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SERVICE_RENDERING_PROVIDER_CONTRACT_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_SERVICE_LOCATION_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_SERVICE_LOCATION_NPI = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_LINE_BYPASS_INDICATOR = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_LINE_PRICING_METHODOLOGY = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_LINE_PAYMENT_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ADJUDICATION_DATE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_LINE_ADJUDICATION_STATUS_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_LINE_ADJUDICATION_REASON_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_LINE_ADJUDICATION_REMARK_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_DIAGNOSIS_POINTER_1 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_DIAGNOSIS_POINTER_2 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_DIAGNOSIS_POINTER_3 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LINE_DIAGNOSIS_POINTER_4 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.REVENUE_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CPT = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.UNITS_BILLED = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CL_DATE_PAID = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_NO = this.Fields[this.ColIdx].ToString().Trim();
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
            this.REVENUE_CODE = int.TryParse(this.C_REVENUE_CODE, out var rev) ? rev.ToString() : string.Empty;
            this.CPT = (!string.IsNullOrEmpty(this.PROCEDURE_CODE) && this.PROCEDURE_CODE.Length == 5) ? this.PROCEDURE_CODE : string.Empty;
            this.UNITS_BILLED = int.TryParse(this.UNITS, out var unit) ? unit.ToString() : string.Empty;

            SetClDatePaid();
            SetClClaimNo();
        }

        /// <summary>
        /// Copy from CLAIM_PAID_DATE. If CLAIM_PAID_DATE is null, copy from CLIENT_CLAIM_ADJUDICATION_DATE.
        /// </summary>
        public string SetClDatePaid()
        {
            if (!string.IsNullOrEmpty(this.AP_POST_DATE))
                this.CL_DATE_PAID = this.AP_POST_DATE;
            else
                this.CL_DATE_PAID = !string.IsNullOrEmpty(this.ADJUDICATION_DATE) ? this.ADJUDICATION_DATE : string.Empty;

            return this.CL_DATE_PAID;
        }


        /// <summary>
        /// Concatenate HMO + '-' + CLIENT_CLAIM_ID.
        /// </summary>
        public string SetClClaimNo()
        {
            this.CLAIM_NO = this.HMO + "-" + this.CLIENT_CLAIM_ID;

            return this.CLAIM_NO;
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
