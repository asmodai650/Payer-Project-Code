using System.Text;
using Novus.Toolbox;
using Novus.Payer1060.BusinessObjects.Constants;
using System.Linq;

namespace Novus.Payer1060.BusinessObjects.FileObjects
{
    public class FdOptumCareHcpDiag
    {
        #region CLASS_VARIABLES

        private readonly StringBuilder stringBuilder = new StringBuilder();
        #endregion CLASS_VARIABLES

        #region CONSTRUCTORS

        /// <summary>
        /// Initializes a new instance of the <see cref="FdOptumCareHcpDiag" /> class.
        /// </summary>
        public FdOptumCareHcpDiag()
        {
            this.Clear();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FdOptumCareHcpDiag" /> class.
        /// </summary>
        /// <param name="racerLoadJobReadOnlyProperties">The instance of RacerLoadJobReadOnlyProperties for this file load.</param>
        public FdOptumCareHcpDiag(RacerLoadJobReadOnlyProperties racerLoadJobReadOnlyProperties)
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

        public string HMO { get; set; }

        public string CLIENT_CLAIM_ID { get; set; }

        public string PRINCIPAL_DIAG { get; set; }

        public string DIAGNOSIS_1 { get; set; }

        public string DIAGNOSIS_2 { get; set; }

        public string DIAGNOSIS_3 { get; set; }

        public string DIAGNOSIS_4 { get; set; }

        public string DIAGNOSIS_5 { get; set; }

        public string DIAGNOSIS_6 { get; set; }

        public string DIAGNOSIS_7 { get; set; }

        public string DIAGNOSIS_8 { get; set; }

        public string DIAGNOSIS_9 { get; set; }

        public string DIAGNOSIS_10 { get; set; }

        public string DIAGNOSIS_11 { get; set; }

        public string DIAGNOSIS_12 { get; set; }

        public string DIAGNOSIS_13 { get; set; }

        public string DIAGNOSIS_14 { get; set; }

        public string DIAGNOSIS_15 { get; set; }

        public string DIAGNOSIS_16 { get; set; }

        public string DIAGNOSIS_17 { get; set; }

        public string DIAGNOSIS_18 { get; set; }

        public string DIAGNOSIS_19 { get; set; }

        public string DIAGNOSIS_20 { get; set; }

        public string DIAGNOSIS_21 { get; set; }

        public string DIAGNOSIS_22 { get; set; }

        public string DIAGNOSIS_23 { get; set; }

        public string DX1_POA { get; set; }

        public string DX2_POA { get; set; }

        public string DX3_POA { get; set; }

        public string DX4_POA { get; set; }

        public string DX5_POA { get; set; }

        public string DX6_POA { get; set; }

        public string DX7_POA { get; set; }

        public string DX8_POA { get; set; }

        public string DX9_POA { get; set; }

        public string DX10_POA { get; set; }

        public string DX11_POA { get; set; }

        public string DX12_POA { get; set; }

        public string DX13_POA { get; set; }

        public string DX14_POA { get; set; }

        public string DX15_POA { get; set; }

        public string DX16_POA { get; set; }

        public string DX17_POA { get; set; }

        public string DX18_POA { get; set; }

        public string DX19_POA { get; set; }

        public string DX20_POA { get; set; }

        public string DX21_POA { get; set; }

        public string DX22_POA { get; set; }

        public string DX23_POA { get; set; }

        public string DX24_POA { get; set; }

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
                
                ///Check for Header Row
                if (this.Fields.Length < 50 || this.Fields[0].ToString().ToLower().Contains("hmo"))
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
                    this.PRINCIPAL_DIAG = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_1 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_2 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_3 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_4 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_5 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_6 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_7 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_8 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_9 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_10 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_11 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_12 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_13 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_14 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_15 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_16 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_17 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_18 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_19 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_20 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_21 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_22 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_23 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX1_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX2_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX3_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX4_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX5_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX6_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX7_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX8_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX9_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX10_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX11_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX12_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX13_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX14_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX15_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX16_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX17_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX18_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX19_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX20_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX21_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX22_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX23_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX24_POA = this.Fields[this.ColIdx].ToString().Trim();
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
            this.HMO = string.Empty;
            this.CLIENT_CLAIM_ID = string.Empty;
            this.PRINCIPAL_DIAG = string.Empty;
            this.DIAGNOSIS_1 = string.Empty;
            this.DIAGNOSIS_2 = string.Empty;
            this.DIAGNOSIS_3 = string.Empty;
            this.DIAGNOSIS_4 = string.Empty;
            this.DIAGNOSIS_5 = string.Empty;
            this.DIAGNOSIS_6 = string.Empty;
            this.DIAGNOSIS_7 = string.Empty;
            this.DIAGNOSIS_8 = string.Empty;
            this.DIAGNOSIS_9 = string.Empty;
            this.DIAGNOSIS_10 = string.Empty;
            this.DIAGNOSIS_11 = string.Empty;
            this.DIAGNOSIS_12 = string.Empty;
            this.DIAGNOSIS_13 = string.Empty;
            this.DIAGNOSIS_14 = string.Empty;
            this.DIAGNOSIS_15 = string.Empty;
            this.DIAGNOSIS_16 = string.Empty;
            this.DIAGNOSIS_17 = string.Empty;
            this.DIAGNOSIS_18 = string.Empty;
            this.DIAGNOSIS_19 = string.Empty;
            this.DIAGNOSIS_20 = string.Empty;
            this.DIAGNOSIS_21 = string.Empty;
            this.DIAGNOSIS_22 = string.Empty;
            this.DIAGNOSIS_23 = string.Empty;
            this.DX1_POA = string.Empty;
            this.DX2_POA = string.Empty;
            this.DX3_POA = string.Empty;
            this.DX4_POA = string.Empty;
            this.DX5_POA = string.Empty;
            this.DX6_POA = string.Empty;
            this.DX7_POA = string.Empty;
            this.DX8_POA = string.Empty;
            this.DX9_POA = string.Empty;
            this.DX10_POA = string.Empty;
            this.DX11_POA = string.Empty;
            this.DX12_POA = string.Empty;
            this.DX13_POA = string.Empty;
            this.DX14_POA = string.Empty;
            this.DX15_POA = string.Empty;
            this.DX16_POA = string.Empty;
            this.DX17_POA = string.Empty;
            this.DX18_POA = string.Empty;
            this.DX19_POA = string.Empty;
            this.DX20_POA = string.Empty;
            this.DX21_POA = string.Empty;
            this.DX22_POA = string.Empty;
            this.DX23_POA = string.Empty;
            this.DX24_POA = string.Empty;
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
            this.AppendField(this.HMO);
            this.AppendField(this.CLIENT_CLAIM_ID);
            this.AppendField(this.PRINCIPAL_DIAG);
            this.AppendField(this.DIAGNOSIS_1);
            this.AppendField(this.DIAGNOSIS_2);
            this.AppendField(this.DIAGNOSIS_3);
            this.AppendField(this.DIAGNOSIS_4);
            this.AppendField(this.DIAGNOSIS_5);
            this.AppendField(this.DIAGNOSIS_6);
            this.AppendField(this.DIAGNOSIS_7);
            this.AppendField(this.DIAGNOSIS_8);
            this.AppendField(this.DIAGNOSIS_9);
            this.AppendField(this.DIAGNOSIS_10);
            this.AppendField(this.DIAGNOSIS_11);
            this.AppendField(this.DIAGNOSIS_12);
            this.AppendField(this.DIAGNOSIS_13);
            this.AppendField(this.DIAGNOSIS_14);
            this.AppendField(this.DIAGNOSIS_15);
            this.AppendField(this.DIAGNOSIS_16);
            this.AppendField(this.DIAGNOSIS_17);
            this.AppendField(this.DIAGNOSIS_18);
            this.AppendField(this.DIAGNOSIS_19);
            this.AppendField(this.DIAGNOSIS_20);
            this.AppendField(this.DIAGNOSIS_21);
            this.AppendField(this.DIAGNOSIS_22);
            this.AppendField(this.DIAGNOSIS_23);
            this.AppendField(this.DX1_POA);
            this.AppendField(this.DX2_POA);
            this.AppendField(this.DX3_POA);
            this.AppendField(this.DX4_POA);
            this.AppendField(this.DX5_POA);
            this.AppendField(this.DX6_POA);
            this.AppendField(this.DX7_POA);
            this.AppendField(this.DX8_POA);
            this.AppendField(this.DX9_POA);
            this.AppendField(this.DX10_POA);
            this.AppendField(this.DX11_POA);
            this.AppendField(this.DX12_POA);
            this.AppendField(this.DX13_POA);
            this.AppendField(this.DX14_POA);
            this.AppendField(this.DX15_POA);
            this.AppendField(this.DX16_POA);
            this.AppendField(this.DX17_POA);
            this.AppendField(this.DX18_POA);
            this.AppendField(this.DX19_POA);
            this.AppendField(this.DX20_POA);
            this.AppendField(this.DX21_POA);
            this.AppendField(this.DX22_POA);
            this.AppendField(this.DX23_POA);
            this.AppendField(this.DX24_POA);

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
            this.AppendField(@"HMO");
            this.AppendField(@"CLIENT_CLAIM_ID");
            this.AppendField(@"PRINCIPAL_DIAG");
            this.AppendField(@"DIAGNOSIS_1");
            this.AppendField(@"DIAGNOSIS_2");
            this.AppendField(@"DIAGNOSIS_3");
            this.AppendField(@"DIAGNOSIS_4");
            this.AppendField(@"DIAGNOSIS_5");
            this.AppendField(@"DIAGNOSIS_6");
            this.AppendField(@"DIAGNOSIS_7");
            this.AppendField(@"DIAGNOSIS_8");
            this.AppendField(@"DIAGNOSIS_9");
            this.AppendField(@"DIAGNOSIS_10");
            this.AppendField(@"DIAGNOSIS_11");
            this.AppendField(@"DIAGNOSIS_12");
            this.AppendField(@"DIAGNOSIS_13");
            this.AppendField(@"DIAGNOSIS_14");
            this.AppendField(@"DIAGNOSIS_15");
            this.AppendField(@"DIAGNOSIS_16");
            this.AppendField(@"DIAGNOSIS_17");
            this.AppendField(@"DIAGNOSIS_18");
            this.AppendField(@"DIAGNOSIS_19");
            this.AppendField(@"DIAGNOSIS_20");
            this.AppendField(@"DIAGNOSIS_21");
            this.AppendField(@"DIAGNOSIS_22");
            this.AppendField(@"DIAGNOSIS_23");
            this.AppendField(@"DX1_POA");
            this.AppendField(@"DX2_POA");
            this.AppendField(@"DX3_POA");
            this.AppendField(@"DX4_POA");
            this.AppendField(@"DX5_POA");
            this.AppendField(@"DX6_POA");
            this.AppendField(@"DX7_POA");
            this.AppendField(@"DX8_POA");
            this.AppendField(@"DX9_POA");
            this.AppendField(@"DX10_POA");
            this.AppendField(@"DX11_POA");
            this.AppendField(@"DX12_POA");
            this.AppendField(@"DX13_POA");
            this.AppendField(@"DX14_POA");
            this.AppendField(@"DX15_POA");
            this.AppendField(@"DX16_POA");
            this.AppendField(@"DX17_POA");
            this.AppendField(@"DX18_POA");
            this.AppendField(@"DX19_POA");
            this.AppendField(@"DX20_POA");
            this.AppendField(@"DX21_POA");
            this.AppendField(@"DX22_POA");
            this.AppendField(@"DX23_POA");
            this.AppendField(@"DX24_POA");

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
                    this.HMO = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLIENT_CLAIM_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PRINCIPAL_DIAG = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_1 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_2 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_3 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_4 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_5 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_6 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_7 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_8 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_9 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_10 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_11 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_12 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_13 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_14 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_15 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_16 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_17 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_18 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_19 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_20 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_21 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_22 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DIAGNOSIS_23 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX1_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX2_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX3_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX4_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX5_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX6_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX7_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX8_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX9_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX10_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX11_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX12_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX13_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX14_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX15_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX16_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX17_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX18_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX19_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX20_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX21_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX22_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX23_POA = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.DX24_POA = this.Fields[this.ColIdx].ToString().Trim();
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

        /// <summary>
        /// Concatenate HMO + '-' + CLIENT_CLAIM_ID.
        /// </summary>
        public void SetAdditionalFields()
        {
            this.CLAIM_NO = this.HMO + "-" + this.CLIENT_CLAIM_ID;
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
