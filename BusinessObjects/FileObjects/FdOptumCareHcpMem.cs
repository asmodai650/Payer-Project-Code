using System.Text;
using Novus.Toolbox;
using Novus.Payer1060.BusinessObjects.Constants;
using Novus.Payer1060.BusinessObjects.Utilities;

namespace Novus.Payer1060.BusinessObjects.FileObjects
{
    public class FdOptumCareHcpMem
    {
        #region CLASS_VARIABLES

        private readonly StringBuilder stringBuilder = new StringBuilder();
        #endregion CLASS_VARIABLES

        #region CONSTRUCTORS

        /// <summary>
        /// Initializes a new instance of the <see cref="FdOptumCareHcpMem" /> class.
        /// </summary>
        public FdOptumCareHcpMem()
        {
            this.Clear();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FdOptumCareHcpMem" /> class.
        /// </summary>
        /// <param name="racerLoadJobReadOnlyProperties">The instance of RacerLoadJobReadOnlyProperties for this file load.</param>
        public FdOptumCareHcpMem(RacerLoadJobReadOnlyProperties racerLoadJobReadOnlyProperties)
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

        public string PAT_MEMBER_NO { get; set; }

        public string MEMBER_ALTERNATIVE_ID { get; set; }

        public string MEMBER_RELATIONSHIP_TO_SUBSCRIBER_CODE { get; set; }

        public string MEMBER_ASSOCIATED_TO_SUBSCRIBER_ID { get; set; }

        public string MEMBER_TIN { get; set; }

        public string HICN { get; set; }

        public string MEMBER_MEDICARE_ID { get; set; }

        public string MEMBER_ACTIVE_DATE { get; set; }

        public string MEMBER_INACTIVE_DATE { get; set; }

        public string FIRST_NAME { get; set; }

        public string MEMBER_MIDDLE_NAME { get; set; }

        public string LAST_NAME { get; set; }

        public string MEMBER_LAST_NAME_SUFFIX { get; set; }

        public string MEMBER_STREET_ADDRESS_1 { get; set; }

        public string MEMBER_STREET_ADDRESS_2 { get; set; }

        public string CTY_ST { get; set; }

        public string MEMBER_STATE { get; set; }

        public string MEMBER_ZIP_CODE { get; set; }

        public string MEMBER_PHONE_NUMBER { get; set; }

        public string SEX { get; set; }

        public string PAT_DATE_OF_BIRTH { get; set; }

        public string DEACT_DT { get; set; }

        public string MARITAL_STATUS { get; set; }

        public string MEMBER_MASTER_GROUP_NUMBER { get; set; }

        public string MEMBER_GROUP_NUMBER { get; set; }

        public string MEMBER_GROUP_NAME { get; set; }

        public string MEMBER_GROUP_SIZE { get; set; }

        public string MEMBER_GROUP_PHONE_NUMBER { get; set; }

        public string INSURER_PAYMENT_SEQUENCE { get; set; }

        public string INSURER_ID { get; set; }

        public string INSURER_TIN { get; set; }

        public string INSURER_HP_ID { get; set; }

        public string INSURER_NAME { get; set; }

        public string INSURANCE_PLAN_NUMBER { get; set; }

        public string INSURANCE_PLAN_NAME { get; set; }

        public string INSURANCE_PLAN_METAL_LEVEL { get; set; }

        public string INSURANCE_PLAN_LOB_MARKET { get; set; }

        public string INSURANCE_PLAN_REGION_SEGMENT { get; set; }

        public string INSURANCE_PLAN_FUNDING_ARRANGEMENT_CODE { get; set; }

        public string INSURANCE_PLAN_PRODUCT_CODE { get; set; }

        public string INSURANCE_PLAN_TYPE_CODE { get; set; }

        public string INSURANCE_PLAN_STATE_CODE { get; set; }

        public string INSURANCE_PLAN_COVERAGE_ELECTION { get; set; }

        public string ELIG_END_DT { get; set; }

        public string ELIG_START_DT { get; set; }

        public string PAT_DATE_EFFECTIVE { get; set; }

        public string PAT_DATE_EXPIRATION { get; set; }

        public string HMO { get; set; }

        public string BENEFIT_PLAN_BENEFIT_START_DT { get; set; }

        public string BENEFIT_PLAN_BENEFIT_END_DT { get; set; }

        public string ELIGIBILITY_BENEFITS_BENEFIT_START_DT { get; set; }

        public string ELIGIBILITY_BENEFITS_BENEFIT_END_DT { get; set; }

        public string PAT_SSN { get; set; }

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

            // If any essential field fails to load successfully IsValid can be set to false.
            this.IsValid = true;

            try
            {
                this.Fields = line.Split('|');
               if (this.Fields.Length < 52 || this.Fields[0].ToString().ToLower().Contains("member")) ///Header row
                {
                  this.IsValid = false;
                  return;
                }

                this.ColIdx = -1;

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PAT_MEMBER_NO = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_ALTERNATIVE_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_RELATIONSHIP_TO_SUBSCRIBER_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_ASSOCIATED_TO_SUBSCRIBER_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_TIN = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.HICN = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_MEDICARE_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_ACTIVE_DATE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_INACTIVE_DATE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.FIRST_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_MIDDLE_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LAST_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_LAST_NAME_SUFFIX = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_STREET_ADDRESS_1 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_STREET_ADDRESS_2 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CTY_ST = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_STATE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_ZIP_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_PHONE_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SEX = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PAT_DATE_OF_BIRTH = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DEACT_DT = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MARITAL_STATUS = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_MASTER_GROUP_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_GROUP_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_GROUP_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_GROUP_SIZE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_GROUP_PHONE_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURER_PAYMENT_SEQUENCE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURER_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURER_TIN = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURER_HP_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURER_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURANCE_PLAN_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURANCE_PLAN_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURANCE_PLAN_METAL_LEVEL = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURANCE_PLAN_LOB_MARKET = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURANCE_PLAN_REGION_SEGMENT = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURANCE_PLAN_FUNDING_ARRANGEMENT_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURANCE_PLAN_PRODUCT_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURANCE_PLAN_TYPE_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURANCE_PLAN_STATE_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURANCE_PLAN_COVERAGE_ELECTION = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ELIG_END_DT = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ELIG_START_DT = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PAT_DATE_EFFECTIVE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PAT_DATE_EXPIRATION = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.HMO = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.BENEFIT_PLAN_BENEFIT_START_DT = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.BENEFIT_PLAN_BENEFIT_END_DT = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ELIGIBILITY_BENEFITS_BENEFIT_START_DT = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ELIGIBILITY_BENEFITS_BENEFIT_END_DT = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
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
            this.PAT_MEMBER_NO = string.Empty;
            this.MEMBER_ALTERNATIVE_ID = string.Empty;
            this.MEMBER_RELATIONSHIP_TO_SUBSCRIBER_CODE = string.Empty;
            this.MEMBER_ASSOCIATED_TO_SUBSCRIBER_ID = string.Empty;
            this.MEMBER_TIN = string.Empty;
            this.HICN = string.Empty;
            this.MEMBER_MEDICARE_ID = string.Empty;
            this.MEMBER_ACTIVE_DATE = string.Empty;
            this.MEMBER_INACTIVE_DATE = string.Empty;
            this.FIRST_NAME = string.Empty;
            this.MEMBER_MIDDLE_NAME = string.Empty;
            this.LAST_NAME = string.Empty;
            this.MEMBER_LAST_NAME_SUFFIX = string.Empty;
            this.MEMBER_STREET_ADDRESS_1 = string.Empty;
            this.MEMBER_STREET_ADDRESS_2 = string.Empty;
            this.CTY_ST = string.Empty;
            this.MEMBER_STATE = string.Empty;
            this.MEMBER_ZIP_CODE = string.Empty;
            this.MEMBER_PHONE_NUMBER = string.Empty;
            this.SEX = string.Empty;
            this.PAT_DATE_OF_BIRTH = string.Empty;
            this.DEACT_DT = string.Empty;
            this.MARITAL_STATUS = string.Empty;
            this.MEMBER_MASTER_GROUP_NUMBER = string.Empty;
            this.MEMBER_GROUP_NUMBER = string.Empty;
            this.MEMBER_GROUP_NAME = string.Empty;
            this.MEMBER_GROUP_SIZE = string.Empty;
            this.MEMBER_GROUP_PHONE_NUMBER = string.Empty;
            this.INSURER_PAYMENT_SEQUENCE = string.Empty;
            this.INSURER_ID = string.Empty;
            this.INSURER_TIN = string.Empty;
            this.INSURER_HP_ID = string.Empty;
            this.INSURER_NAME = string.Empty;
            this.INSURANCE_PLAN_NUMBER = string.Empty;
            this.INSURANCE_PLAN_NAME = string.Empty;
            this.INSURANCE_PLAN_METAL_LEVEL = string.Empty;
            this.INSURANCE_PLAN_LOB_MARKET = string.Empty;
            this.INSURANCE_PLAN_REGION_SEGMENT = string.Empty;
            this.INSURANCE_PLAN_FUNDING_ARRANGEMENT_CODE = string.Empty;
            this.INSURANCE_PLAN_PRODUCT_CODE = string.Empty;
            this.INSURANCE_PLAN_TYPE_CODE = string.Empty;
            this.INSURANCE_PLAN_STATE_CODE = string.Empty;
            this.INSURANCE_PLAN_COVERAGE_ELECTION = string.Empty;
            this.ELIG_END_DT = string.Empty;
            this.ELIG_START_DT = string.Empty;
            this.PAT_DATE_EFFECTIVE = string.Empty;
            this.PAT_DATE_EXPIRATION = string.Empty;
            this.HMO = string.Empty;
            this.BENEFIT_PLAN_BENEFIT_START_DT = string.Empty;
            this.BENEFIT_PLAN_BENEFIT_END_DT = string.Empty;
            this.ELIGIBILITY_BENEFITS_BENEFIT_START_DT = string.Empty;
            this.ELIGIBILITY_BENEFITS_BENEFIT_END_DT = string.Empty;
            this.PAT_SSN = string.Empty;

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
            this.AppendField(this.PAT_MEMBER_NO);
            this.AppendField(this.MEMBER_ALTERNATIVE_ID);
            this.AppendField(this.MEMBER_RELATIONSHIP_TO_SUBSCRIBER_CODE);
            this.AppendField(this.MEMBER_ASSOCIATED_TO_SUBSCRIBER_ID);
            this.AppendField(this.MEMBER_TIN);
            this.AppendField(this.HICN);
            this.AppendField(this.MEMBER_MEDICARE_ID);
            this.AppendField(this.MEMBER_ACTIVE_DATE);
            this.AppendField(this.MEMBER_INACTIVE_DATE);
            this.AppendField(this.FIRST_NAME);
            this.AppendField(this.MEMBER_MIDDLE_NAME);
            this.AppendField(this.LAST_NAME);
            this.AppendField(this.MEMBER_LAST_NAME_SUFFIX);
            this.AppendField(this.MEMBER_STREET_ADDRESS_1);
            this.AppendField(this.MEMBER_STREET_ADDRESS_2);
            this.AppendField(this.CTY_ST);
            this.AppendField(this.MEMBER_STATE);
            this.AppendField(this.MEMBER_ZIP_CODE);
            this.AppendField(this.MEMBER_PHONE_NUMBER);
            this.AppendField(this.SEX);
            this.AppendField(this.PAT_DATE_OF_BIRTH);
            this.AppendField(this.DEACT_DT);
            this.AppendField(this.MARITAL_STATUS);
            this.AppendField(this.MEMBER_MASTER_GROUP_NUMBER);
            this.AppendField(this.MEMBER_GROUP_NUMBER);
            this.AppendField(this.MEMBER_GROUP_NAME);
            this.AppendField(this.MEMBER_GROUP_SIZE);
            this.AppendField(this.MEMBER_GROUP_PHONE_NUMBER);
            this.AppendField(this.INSURER_PAYMENT_SEQUENCE);
            this.AppendField(this.INSURER_ID);
            this.AppendField(this.INSURER_TIN);
            this.AppendField(this.INSURER_HP_ID);
            this.AppendField(this.INSURER_NAME);
            this.AppendField(this.INSURANCE_PLAN_NUMBER);
            this.AppendField(this.INSURANCE_PLAN_NAME);
            this.AppendField(this.INSURANCE_PLAN_METAL_LEVEL);
            this.AppendField(this.INSURANCE_PLAN_LOB_MARKET);
            this.AppendField(this.INSURANCE_PLAN_REGION_SEGMENT);
            this.AppendField(this.INSURANCE_PLAN_FUNDING_ARRANGEMENT_CODE);
            this.AppendField(this.INSURANCE_PLAN_PRODUCT_CODE);
            this.AppendField(this.INSURANCE_PLAN_TYPE_CODE);
            this.AppendField(this.INSURANCE_PLAN_STATE_CODE);
            this.AppendField(this.INSURANCE_PLAN_COVERAGE_ELECTION);
            this.AppendField(this.ELIG_END_DT);
            this.AppendField(this.ELIG_START_DT);
            this.AppendField(this.PAT_DATE_EFFECTIVE);
            this.AppendField(this.PAT_DATE_EXPIRATION);
            this.AppendField(this.HMO);
            this.AppendField(this.BENEFIT_PLAN_BENEFIT_START_DT);
            this.AppendField(this.BENEFIT_PLAN_BENEFIT_END_DT);
            this.AppendField(this.ELIGIBILITY_BENEFITS_BENEFIT_START_DT);
            this.AppendField(this.ELIGIBILITY_BENEFITS_BENEFIT_END_DT);

            if (includeLookupFields)
            {
                this.AppendField(this.PAT_SSN);
                AppendLookupFields();
            }
            else
            {
                this.AppendLastField(this.PAT_SSN);
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
            this.AppendField(@"PAT_MEMBER_NO");
            this.AppendField(@"MEMBER_ALTERNATIVE_ID");
            this.AppendField(@"MEMBER_RELATIONSHIP_TO_SUBSCRIBER_CODE");
            this.AppendField(@"MEMBER_ASSOCIATED_TO_SUBSCRIBER_ID");
            this.AppendField(@"MEMBER_TIN");
            this.AppendField(@"HICN");
            this.AppendField(@"MEMBER_MEDICARE_ID");
            this.AppendField(@"MEMBER_ACTIVE_DATE");
            this.AppendField(@"MEMBER_INACTIVE_DATE");
            this.AppendField(@"FIRST_NAME");
            this.AppendField(@"MEMBER_MIDDLE_NAME");
            this.AppendField(@"LAST_NAME");
            this.AppendField(@"MEMBER_LAST_NAME_SUFFIX");
            this.AppendField(@"MEMBER_STREET_ADDRESS_1");
            this.AppendField(@"MEMBER_STREET_ADDRESS_2");
            this.AppendField(@"CTY_ST");
            this.AppendField(@"MEMBER_STATE");
            this.AppendField(@"MEMBER_ZIP_CODE");
            this.AppendField(@"MEMBER_PHONE_NUMBER");
            this.AppendField(@"SEX");
            this.AppendField(@"PAT_DATE_OF_BIRTH");
            this.AppendField(@"DEACT_DT");
            this.AppendField(@"MARITAL_STATUS");
            this.AppendField(@"MEMBER_MASTER_GROUP_NUMBER");
            this.AppendField(@"MEMBER_GROUP_NUMBER");
            this.AppendField(@"MEMBER_GROUP_NAME");
            this.AppendField(@"MEMBER_GROUP_SIZE");
            this.AppendField(@"MEMBER_GROUP_PHONE_NUMBER");
            this.AppendField(@"INSURER_PAYMENT_SEQUENCE");
            this.AppendField(@"INSURER_ID");
            this.AppendField(@"INSURER_TIN");
            this.AppendField(@"INSURER_HP_ID");
            this.AppendField(@"INSURER_NAME");
            this.AppendField(@"INSURANCE_PLAN_NUMBER");
            this.AppendField(@"INSURANCE_PLAN_NAME");
            this.AppendField(@"INSURANCE_PLAN_METAL_LEVEL");
            this.AppendField(@"INSURANCE_PLAN_LOB_MARKET");
            this.AppendField(@"INSURANCE_PLAN_REGION_SEGMENT");
            this.AppendField(@"INSURANCE_PLAN_FUNDING_ARRANGEMENT_CODE");
            this.AppendField(@"INSURANCE_PLAN_PRODUCT_CODE");
            this.AppendField(@"INSURANCE_PLAN_TYPE_CODE");
            this.AppendField(@"INSURANCE_PLAN_STATE_CODE");
            this.AppendField(@"INSURANCE_PLAN_COVERAGE_ELECTION");
            this.AppendField(@"ELIG_END_DT");
            this.AppendField(@"ELIG_START_DT");
            this.AppendField(@"PAT_DATE_EFFECTIVE");
            this.AppendField(@"PAT_DATE_EXPIRATION");
            this.AppendField(@"HMO");
            this.AppendField(@"BENEFIT_PLAN_BENEFIT_START_DT");
            this.AppendField(@"BENEFIT_PLAN_BENEFIT_END_DT");
            this.AppendField(@"ELIGIBILITY_BENEFITS_BENEFIT_START_DT");
            this.AppendField(@"ELIGIBILITY_BENEFITS_BENEFIT_END_DT");

            if (includeLookupFields)
            {
                this.AppendField(@"PAT_SSN");
                AppendLookupFieldsHeader();
            }
            else
            {
                this.AppendLastField(@"PAT_SSN");
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
                    this.PAT_MEMBER_NO = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_ALTERNATIVE_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_RELATIONSHIP_TO_SUBSCRIBER_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_ASSOCIATED_TO_SUBSCRIBER_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_TIN = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.HICN = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_MEDICARE_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_ACTIVE_DATE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_INACTIVE_DATE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.FIRST_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_MIDDLE_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.LAST_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_LAST_NAME_SUFFIX = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_STREET_ADDRESS_1 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_STREET_ADDRESS_2 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CTY_ST = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_STATE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_ZIP_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_PHONE_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.SEX = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PAT_DATE_OF_BIRTH = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DEACT_DT = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MARITAL_STATUS = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_MASTER_GROUP_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_GROUP_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_GROUP_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_GROUP_SIZE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.MEMBER_GROUP_PHONE_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURER_PAYMENT_SEQUENCE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURER_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURER_TIN = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURER_HP_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURER_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURANCE_PLAN_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURANCE_PLAN_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURANCE_PLAN_METAL_LEVEL = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURANCE_PLAN_LOB_MARKET = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURANCE_PLAN_REGION_SEGMENT = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURANCE_PLAN_FUNDING_ARRANGEMENT_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURANCE_PLAN_PRODUCT_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURANCE_PLAN_TYPE_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURANCE_PLAN_STATE_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.INSURANCE_PLAN_COVERAGE_ELECTION = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ELIG_END_DT = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ELIG_START_DT = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PAT_DATE_EFFECTIVE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PAT_DATE_EXPIRATION = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.HMO = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.BENEFIT_PLAN_BENEFIT_START_DT = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.BENEFIT_PLAN_BENEFIT_END_DT = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ELIGIBILITY_BENEFITS_BENEFIT_START_DT = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ELIGIBILITY_BENEFITS_BENEFIT_END_DT = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PAT_SSN = this.Fields[this.ColIdx].ToString().Trim();
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
            this.PAT_SSN = !string.IsNullOrEmpty(MEMBER_TIN) ? MEMBER_TIN.Replace("-", "").Trim() : string.Empty;
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
