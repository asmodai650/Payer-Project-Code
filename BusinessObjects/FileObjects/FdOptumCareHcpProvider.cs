using System.Text;
using Novus.Toolbox;
using Novus.Payer1060.BusinessObjects.Constants;
using Novus.Payer1060.BusinessObjects.Utilities;

namespace Novus.Payer1060.BusinessObjects.FileObjects
{
    public class FdOptumCareHcpProvider
    {
        #region CLASS_VARIABLES

        private readonly StringBuilder stringBuilder = new StringBuilder();
        #endregion CLASS_VARIABLES

        #region CONSTRUCTORS

        /// <summary>
        /// Initializes a new instance of the <see cref="FdOptumCareHcpProvider" /> class.
        /// </summary>
        public FdOptumCareHcpProvider()
        {
            this.Clear();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FdOptumCareHcpProvider" /> class.
        /// </summary>
        /// <param name="racerLoadJobReadOnlyProperties">The instance of RacerLoadJobReadOnlyProperties for this file load.</param>
        public FdOptumCareHcpProvider(RacerLoadJobReadOnlyProperties racerLoadJobReadOnlyProperties)
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

        public string PROVIDER_CLIENT_ID { get; set; }

        public string PROVIDER_ENTITY_TYPE_CODE { get; set; }

        public string PROVIDER_TYPE_CODE { get; set; }

        public string PROVIDER_NPI { get; set; }

        public string PROVIDER_TIN { get; set; }

        public string PROVIDER_MEDICARE_ID { get; set; }

        public string PROVIDER_MEDICAID_ID { get; set; }

        public string PROVIDER_FIRST_NAME { get; set; }

        public string PROVIDER_MIDDLE_NAME { get; set; }

        public string PROVIDER_LAST_ORGANIZATION_NAME { get; set; }

        public string PROVIDER_LAST_NAME_SUFFIX { get; set; }

        public string PROVIDER_DOB { get; set; }

        public string PROVIDER_DOD { get; set; }

        public string PROVIDER_GENDER { get; set; }

        public string PROVIDER_MAILING_STREET_ADDRESS_1 { get; set; }

        public string PROVIDER_MAILING_STREET_ADDRESS_2 { get; set; }

        public string PROVIDER_MAILING_STREET_ADDRESS_3 { get; set; }

        public string PROVIDER_MAILING_CITY { get; set; }

        public string PROVIDER_MAILING_STATE { get; set; }

        public string PROVIDER_MAILING_ZIP_CODE { get; set; }

        public string PROVIDER_MAILING_PHONE { get; set; }

        public string PROVIDER_MAILING_FAX { get; set; }

        public string PROVIDER_MAILING_EMAIL { get; set; }

        public string PROVIDER_PRACTICE_ORGANIZATION_NAME { get; set; }

        public string PROVIDER_PRACTICE_STREET_ADDRESS_1 { get; set; }

        public string PROVIDER_PRACTICE_STREET_ADDRESS_2 { get; set; }

        public string PROVIDER_PRACTICE_STREET_ADDRESS_3 { get; set; }

        public string PROVIDER_PRACTICE_CITY { get; set; }

        public string PROVIDER_PRACTICE_STATE { get; set; }

        public string PROVIDER_PRACTICE_ZIP_CODE { get; set; }

        public string PROVIDER_PRACTICE_PHONE { get; set; }

        public string PROVIDER_PRACTICE_FAX { get; set; }

        public string PROVIDER_PRACTICE_EMAIL { get; set; }

        public string PROVIDER_NUCC_TAXONOMY_CODE { get; set; }

        public string PROVIDER_SPECIALTY_PRIMARY_CODE { get; set; }

        public string PROVIDER_SPECIALTY_SECONDARY_CODE { get; set; }

        public string PROVIDER_SPECIALTY_OTHER_CODE { get; set; }

        public string PROVIDER_LICENSE_STATE { get; set; }

        public string PROVIDER_LICENSE_NUMBER { get; set; }

        public string PROVIDER_ENROLLMENT_STATUS { get; set; }

        public string PROVIDER_PCP_INDICATOR { get; set; }

        public string PROVIDER_GROUP_ORGANIZATION_TYPE { get; set; }

        public string PROVIDER_NO { get; set; }

        public string PROV_NAME { get; set; }

        public string PROVIDER_GROUP_CONTACT_PHONE_NUMBER { get; set; }

        public string PROVIDER_GROUP_CONTACT_NAME { get; set; }

        public string PROVIDER_GROUP_AFFILIATION_EFFECTIVE_DATE { get; set; }

        public string PROVIDER_GROUP_AFFILIATION_TERMINATION_DATE { get; set; }

        public string TAX_ID { get; set; }

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
                if (this.Fields.Length < 48 || this.Fields[0].ToString().ToLower().Contains("provider")) ///Header row
                {
                    this.IsValid = false;
                    return;
                }

                this.ColIdx = -1;

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_CLIENT_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_ENTITY_TYPE_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_TYPE_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_NPI = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_TIN = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_MEDICARE_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_MEDICAID_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_FIRST_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_MIDDLE_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_LAST_ORGANIZATION_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_LAST_NAME_SUFFIX = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_DOB = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_DOD = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_GENDER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_MAILING_STREET_ADDRESS_1 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_MAILING_STREET_ADDRESS_2 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_MAILING_STREET_ADDRESS_3 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_MAILING_CITY = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_MAILING_STATE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_MAILING_ZIP_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_MAILING_PHONE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_MAILING_FAX = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_MAILING_EMAIL = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_PRACTICE_ORGANIZATION_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_PRACTICE_STREET_ADDRESS_1 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_PRACTICE_STREET_ADDRESS_2 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_PRACTICE_STREET_ADDRESS_3 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_PRACTICE_CITY = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_PRACTICE_STATE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_PRACTICE_ZIP_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_PRACTICE_PHONE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_PRACTICE_FAX = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_PRACTICE_EMAIL = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_NUCC_TAXONOMY_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_SPECIALTY_PRIMARY_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_SPECIALTY_SECONDARY_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_SPECIALTY_OTHER_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_LICENSE_STATE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_LICENSE_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_ENROLLMENT_STATUS = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_PCP_INDICATOR = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_GROUP_ORGANIZATION_TYPE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_NO = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROV_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_GROUP_CONTACT_PHONE_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_GROUP_CONTACT_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_GROUP_AFFILIATION_EFFECTIVE_DATE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_GROUP_AFFILIATION_TERMINATION_DATE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
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
            this.PROVIDER_CLIENT_ID = string.Empty;
            this.PROVIDER_ENTITY_TYPE_CODE = string.Empty;
            this.PROVIDER_TYPE_CODE = string.Empty;
            this.PROVIDER_NPI = string.Empty;
            this.PROVIDER_TIN = string.Empty;
            this.PROVIDER_MEDICARE_ID = string.Empty;
            this.PROVIDER_MEDICAID_ID = string.Empty;
            this.PROVIDER_FIRST_NAME = string.Empty;
            this.PROVIDER_MIDDLE_NAME = string.Empty;
            this.PROVIDER_LAST_ORGANIZATION_NAME = string.Empty;
            this.PROVIDER_LAST_NAME_SUFFIX = string.Empty;
            this.PROVIDER_DOB = string.Empty;
            this.PROVIDER_DOD = string.Empty;
            this.PROVIDER_GENDER = string.Empty;
            this.PROVIDER_MAILING_STREET_ADDRESS_1 = string.Empty;
            this.PROVIDER_MAILING_STREET_ADDRESS_2 = string.Empty;
            this.PROVIDER_MAILING_STREET_ADDRESS_3 = string.Empty;
            this.PROVIDER_MAILING_CITY = string.Empty;
            this.PROVIDER_MAILING_STATE = string.Empty;
            this.PROVIDER_MAILING_ZIP_CODE = string.Empty;
            this.PROVIDER_MAILING_PHONE = string.Empty;
            this.PROVIDER_MAILING_FAX = string.Empty;
            this.PROVIDER_MAILING_EMAIL = string.Empty;
            this.PROVIDER_PRACTICE_ORGANIZATION_NAME = string.Empty;
            this.PROVIDER_PRACTICE_STREET_ADDRESS_1 = string.Empty;
            this.PROVIDER_PRACTICE_STREET_ADDRESS_2 = string.Empty;
            this.PROVIDER_PRACTICE_STREET_ADDRESS_3 = string.Empty;
            this.PROVIDER_PRACTICE_CITY = string.Empty;
            this.PROVIDER_PRACTICE_STATE = string.Empty;
            this.PROVIDER_PRACTICE_ZIP_CODE = string.Empty;
            this.PROVIDER_PRACTICE_PHONE = string.Empty;
            this.PROVIDER_PRACTICE_FAX = string.Empty;
            this.PROVIDER_PRACTICE_EMAIL = string.Empty;
            this.PROVIDER_NUCC_TAXONOMY_CODE = string.Empty;
            this.PROVIDER_SPECIALTY_PRIMARY_CODE = string.Empty;
            this.PROVIDER_SPECIALTY_SECONDARY_CODE = string.Empty;
            this.PROVIDER_SPECIALTY_OTHER_CODE = string.Empty;
            this.PROVIDER_LICENSE_STATE = string.Empty;
            this.PROVIDER_LICENSE_NUMBER = string.Empty;
            this.PROVIDER_ENROLLMENT_STATUS = string.Empty;
            this.PROVIDER_PCP_INDICATOR = string.Empty;
            this.PROVIDER_GROUP_ORGANIZATION_TYPE = string.Empty;
            this.PROVIDER_NO = string.Empty;
            this.PROV_NAME = string.Empty;
            this.PROVIDER_GROUP_CONTACT_PHONE_NUMBER = string.Empty;
            this.PROVIDER_GROUP_CONTACT_NAME = string.Empty;
            this.PROVIDER_GROUP_AFFILIATION_EFFECTIVE_DATE = string.Empty;
            this.PROVIDER_GROUP_AFFILIATION_TERMINATION_DATE = string.Empty;
            this.TAX_ID = string.Empty;

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
            this.AppendField(this.PROVIDER_CLIENT_ID);
            this.AppendField(this.PROVIDER_ENTITY_TYPE_CODE);
            this.AppendField(this.PROVIDER_TYPE_CODE);
            this.AppendField(this.PROVIDER_NPI);
            this.AppendField(this.PROVIDER_TIN);
            this.AppendField(this.PROVIDER_MEDICARE_ID);
            this.AppendField(this.PROVIDER_MEDICAID_ID);
            this.AppendField(this.PROVIDER_FIRST_NAME);
            this.AppendField(this.PROVIDER_MIDDLE_NAME);
            this.AppendField(this.PROVIDER_LAST_ORGANIZATION_NAME);
            this.AppendField(this.PROVIDER_LAST_NAME_SUFFIX);
            this.AppendField(this.PROVIDER_DOB);
            this.AppendField(this.PROVIDER_DOD);
            this.AppendField(this.PROVIDER_GENDER);
            this.AppendField(this.PROVIDER_MAILING_STREET_ADDRESS_1);
            this.AppendField(this.PROVIDER_MAILING_STREET_ADDRESS_2);
            this.AppendField(this.PROVIDER_MAILING_STREET_ADDRESS_3);
            this.AppendField(this.PROVIDER_MAILING_CITY);
            this.AppendField(this.PROVIDER_MAILING_STATE);
            this.AppendField(this.PROVIDER_MAILING_ZIP_CODE);
            this.AppendField(this.PROVIDER_MAILING_PHONE);
            this.AppendField(this.PROVIDER_MAILING_FAX);
            this.AppendField(this.PROVIDER_MAILING_EMAIL);
            this.AppendField(this.PROVIDER_PRACTICE_ORGANIZATION_NAME);
            this.AppendField(this.PROVIDER_PRACTICE_STREET_ADDRESS_1);
            this.AppendField(this.PROVIDER_PRACTICE_STREET_ADDRESS_2);
            this.AppendField(this.PROVIDER_PRACTICE_STREET_ADDRESS_3);
            this.AppendField(this.PROVIDER_PRACTICE_CITY);
            this.AppendField(this.PROVIDER_PRACTICE_STATE);
            this.AppendField(this.PROVIDER_PRACTICE_ZIP_CODE);
            this.AppendField(this.PROVIDER_PRACTICE_PHONE);
            this.AppendField(this.PROVIDER_PRACTICE_FAX);
            this.AppendField(this.PROVIDER_PRACTICE_EMAIL);
            this.AppendField(this.PROVIDER_NUCC_TAXONOMY_CODE);
            this.AppendField(this.PROVIDER_SPECIALTY_PRIMARY_CODE);
            this.AppendField(this.PROVIDER_SPECIALTY_SECONDARY_CODE);
            this.AppendField(this.PROVIDER_SPECIALTY_OTHER_CODE);
            this.AppendField(this.PROVIDER_LICENSE_STATE);
            this.AppendField(this.PROVIDER_LICENSE_NUMBER);
            this.AppendField(this.PROVIDER_ENROLLMENT_STATUS);
            this.AppendField(this.PROVIDER_PCP_INDICATOR);
            this.AppendField(this.PROVIDER_GROUP_ORGANIZATION_TYPE);
            this.AppendField(this.PROVIDER_NO);
            this.AppendField(this.PROV_NAME);
            this.AppendField(this.PROVIDER_GROUP_CONTACT_PHONE_NUMBER);
            this.AppendField(this.PROVIDER_GROUP_CONTACT_NAME);
            this.AppendField(this.PROVIDER_GROUP_AFFILIATION_EFFECTIVE_DATE);
            this.AppendField(this.PROVIDER_GROUP_AFFILIATION_TERMINATION_DATE);

            if (includeLookupFields)
            {
                this.AppendField(this.TAX_ID);
                AppendLookupFields();
            }
            else
            {
                this.AppendLastField(this.TAX_ID);
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
            this.AppendField(@"PROVIDER_CLIENT_ID");
            this.AppendField(@"PROVIDER_ENTITY_TYPE_CODE");
            this.AppendField(@"PROVIDER_TYPE_CODE");
            this.AppendField(@"PROVIDER_NPI");
            this.AppendField(@"PROVIDER_TIN");
            this.AppendField(@"PROVIDER_MEDICARE_ID");
            this.AppendField(@"PROVIDER_MEDICAID_ID");
            this.AppendField(@"PROVIDER_FIRST_NAME");
            this.AppendField(@"PROVIDER_MIDDLE_NAME");
            this.AppendField(@"PROVIDER_LAST_ORGANIZATION_NAME");
            this.AppendField(@"PROVIDER_LAST_NAME_SUFFIX");
            this.AppendField(@"PROVIDER_DOB");
            this.AppendField(@"PROVIDER_DOD");
            this.AppendField(@"PROVIDER_GENDER");
            this.AppendField(@"PROVIDER_MAILING_STREET_ADDRESS_1");
            this.AppendField(@"PROVIDER_MAILING_STREET_ADDRESS_2");
            this.AppendField(@"PROVIDER_MAILING_STREET_ADDRESS_3");
            this.AppendField(@"PROVIDER_MAILING_CITY");
            this.AppendField(@"PROVIDER_MAILING_STATE");
            this.AppendField(@"PROVIDER_MAILING_ZIP_CODE");
            this.AppendField(@"PROVIDER_MAILING_PHONE");
            this.AppendField(@"PROVIDER_MAILING_FAX");
            this.AppendField(@"PROVIDER_MAILING_EMAIL");
            this.AppendField(@"PROVIDER_PRACTICE_ORGANIZATION_NAME");
            this.AppendField(@"PROVIDER_PRACTICE_STREET_ADDRESS_1");
            this.AppendField(@"PROVIDER_PRACTICE_STREET_ADDRESS_2");
            this.AppendField(@"PROVIDER_PRACTICE_STREET_ADDRESS_3");
            this.AppendField(@"PROVIDER_PRACTICE_CITY");
            this.AppendField(@"PROVIDER_PRACTICE_STATE");
            this.AppendField(@"PROVIDER_PRACTICE_ZIP_CODE");
            this.AppendField(@"PROVIDER_PRACTICE_PHONE");
            this.AppendField(@"PROVIDER_PRACTICE_FAX");
            this.AppendField(@"PROVIDER_PRACTICE_EMAIL");
            this.AppendField(@"PROVIDER_NUCC_TAXONOMY_CODE");
            this.AppendField(@"PROVIDER_SPECIALTY_PRIMARY_CODE");
            this.AppendField(@"PROVIDER_SPECIALTY_SECONDARY_CODE");
            this.AppendField(@"PROVIDER_SPECIALTY_OTHER_CODE");
            this.AppendField(@"PROVIDER_LICENSE_STATE");
            this.AppendField(@"PROVIDER_LICENSE_NUMBER");
            this.AppendField(@"PROVIDER_ENROLLMENT_STATUS");
            this.AppendField(@"PROVIDER_PCP_INDICATOR");
            this.AppendField(@"PROVIDER_GROUP_ORGANIZATION_TYPE");
            this.AppendField(@"PROVIDER_NO");
            this.AppendField(@"PROV_NAME");
            this.AppendField(@"PROVIDER_GROUP_CONTACT_PHONE_NUMBER");
            this.AppendField(@"PROVIDER_GROUP_CONTACT_NAME");
            this.AppendField(@"PROVIDER_GROUP_AFFILIATION_EFFECTIVE_DATE");
            this.AppendField(@"PROVIDER_GROUP_AFFILIATION_TERMINATION_DATE");

            if (includeLookupFields)
            {
                this.AppendField(@"TAX_ID");
                AppendLookupFieldsHeader();
            }
            else
            {
                this.AppendLastField(@"TAX_ID");
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
                    this.PROVIDER_CLIENT_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_ENTITY_TYPE_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_TYPE_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_NPI = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_TIN = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_MEDICARE_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_MEDICAID_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_FIRST_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_MIDDLE_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_LAST_ORGANIZATION_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_LAST_NAME_SUFFIX = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_DOB = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_DOD = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_GENDER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_MAILING_STREET_ADDRESS_1 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_MAILING_STREET_ADDRESS_2 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_MAILING_STREET_ADDRESS_3 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_MAILING_CITY = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_MAILING_STATE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_MAILING_ZIP_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_MAILING_PHONE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_MAILING_FAX = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_MAILING_EMAIL = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_PRACTICE_ORGANIZATION_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_PRACTICE_STREET_ADDRESS_1 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_PRACTICE_STREET_ADDRESS_2 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_PRACTICE_STREET_ADDRESS_3 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_PRACTICE_CITY = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_PRACTICE_STATE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_PRACTICE_ZIP_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_PRACTICE_PHONE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_PRACTICE_FAX = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_PRACTICE_EMAIL = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_NUCC_TAXONOMY_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_SPECIALTY_PRIMARY_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_SPECIALTY_SECONDARY_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_SPECIALTY_OTHER_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_LICENSE_STATE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_LICENSE_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_ENROLLMENT_STATUS = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_PCP_INDICATOR = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_GROUP_ORGANIZATION_TYPE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_NO = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROV_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_GROUP_CONTACT_PHONE_NUMBER = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_GROUP_CONTACT_NAME = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_GROUP_AFFILIATION_EFFECTIVE_DATE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROVIDER_GROUP_AFFILIATION_TERMINATION_DATE = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.TAX_ID = this.Fields[this.ColIdx].ToString().Trim();
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
            this.TAX_ID = !string.IsNullOrEmpty(PROVIDER_TIN) ? PROVIDER_TIN.Replace("-", "").Trim() : string.Empty;
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
