using System.Text;
using Novus.Toolbox;
using System.Linq;
using Novus.Payer1060.BusinessObjects.Constants;
using Novus.Payer1060.BusinessObjects.Utilities;

namespace Novus.Payer1060.BusinessObjects.FileObjects
{
    public class FdOptumCareHcpProc
    {
        #region CLASS_VARIABLES

        private readonly StringBuilder stringBuilder = new StringBuilder();
        #endregion CLASS_VARIABLES

        #region CONSTRUCTORS

        /// <summary>
        /// Initializes a new instance of the <see cref="FdOptumCareHcpProc" /> class.
        /// </summary>
        public FdOptumCareHcpProc()
        {
            this.Clear();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FdOptumCareHcpProc" /> class.
        /// </summary>
        /// <param name="racerLoadJobReadOnlyProperties">The instance of RacerLoadJobReadOnlyProperties for this file load.</param>
        public FdOptumCareHcpProc(RacerLoadJobReadOnlyProperties racerLoadJobReadOnlyProperties)
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

        public string ID { get; set; }

        public string HMO { get; set; }

        public string CLIENT_CLAIM_ID { get; set; }

        public string PRINCIPAL_PROC { get; set; }

        public string PROCEDURE_1 { get; set; }

        public string PROCEDURE_2 { get; set; }

        public string PROCEDURE_3 { get; set; }

        public string PROCEDURE_4 { get; set; }

        public string PROCEDURE_5 { get; set; }

        public string PROCEDURE_6 { get; set; }

        public string PROCEDURE_7 { get; set; }

        public string PROCEDURE_8 { get; set; }

        public string PROCEDURE_9 { get; set; }

        public string PROCEDURE_10 { get; set; }

        public string PROCEDURE_11 { get; set; }

        public string PROCEDURE_12 { get; set; }

        public string PROCEDURE_13 { get; set; }

        public string PROCEDURE_14 { get; set; }

        public string PROCEDURE_15 { get; set; }

        public string PROCEDURE_16 { get; set; }

        public string PROCEDURE_17 { get; set; }

        public string PROCEDURE_18 { get; set; }

        public string PROCEDURE_19 { get; set; }

        public string PROCEDURE_20 { get; set; }

        public string PROCEDURE_21 { get; set; }

        public string PROCEDURE_22 { get; set; }

        public string PROCEDURE_23 { get; set; }

        public string OTHER_PX_DATE_1 { get; set; }

        public string OTHER_PX_DATE_2 { get; set; }

        public string OTHER_PX_DATE_3 { get; set; }

        public string OTHER_PX_DATE_4 { get; set; }

        public string OTHER_PX_DATE_5 { get; set; }

        public string OTHER_PX_DATE_6 { get; set; }

        public string OTHER_PX_DATE_7 { get; set; }

        public string OTHER_PX_DATE_8 { get; set; }

        public string OTHER_PX_DATE_9 { get; set; }

        public string OTHER_PX_DATE_10 { get; set; }

        public string OTHER_PX_DATE_11 { get; set; }

        public string OTHER_PX_DATE_12 { get; set; }

        public string OTHER_PX_DATE_13 { get; set; }

        public string OTHER_PX_DATE_14 { get; set; }

        public string OTHER_PX_DATE_15 { get; set; }

        public string OTHER_PX_DATE_16 { get; set; }

        public string OTHER_PX_DATE_17 { get; set; }

        public string OTHER_PX_DATE_18 { get; set; }

        public string OTHER_PX_DATE_19 { get; set; }

        public string OTHER_PX_DATE_20 { get; set; }

        public string OTHER_PX_DATE_21 { get; set; }

        public string OTHER_PX_DATE_22 { get; set; }

        public string OTHER_PX_DATE_23 { get; set; }

        public string OTHER_PX_DATE_24 { get; set; }

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
                if (this.Fields.Length < 51 || this.Fields[0].ToString().ToLower().Contains("id"))
                {
                    this.IsValid = false;
                    return;
                }

                ///Check for Empty HMO and CLIENT_CLAIM_ID fields
                if (string.IsNullOrEmpty(this.Fields[1].ToString()) || string.IsNullOrEmpty(this.Fields[2].ToString()))
                {
                    this.IsValid = false;
                    return;
                }

                this.ColIdx = -1;

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.ID = this.Fields[this.ColIdx].ToString().Trim();
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
                    this.PRINCIPAL_PROC = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_1 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_2 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_3 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_4 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_5 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_6 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_7 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_8 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_9 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_10 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_11 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_12 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_13 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_14 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_15 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_16 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_17 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_18 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_19 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_20 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_21 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_22 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_23 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_1 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_2 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_3 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_4 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_5 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_6 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_7 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_8 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_9 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_10 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_11 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_12 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_13 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_14 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_15 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_16 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_17 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_18 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_19 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_20 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_21 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_22 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_23 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_24 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
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
            this.ID = string.Empty;
            this.HMO = string.Empty;
            this.CLIENT_CLAIM_ID = string.Empty;
            this.PRINCIPAL_PROC = string.Empty;
            this.PROCEDURE_1 = string.Empty;
            this.PROCEDURE_2 = string.Empty;
            this.PROCEDURE_3 = string.Empty;
            this.PROCEDURE_4 = string.Empty;
            this.PROCEDURE_5 = string.Empty;
            this.PROCEDURE_6 = string.Empty;
            this.PROCEDURE_7 = string.Empty;
            this.PROCEDURE_8 = string.Empty;
            this.PROCEDURE_9 = string.Empty;
            this.PROCEDURE_10 = string.Empty;
            this.PROCEDURE_11 = string.Empty;
            this.PROCEDURE_12 = string.Empty;
            this.PROCEDURE_13 = string.Empty;
            this.PROCEDURE_14 = string.Empty;
            this.PROCEDURE_15 = string.Empty;
            this.PROCEDURE_16 = string.Empty;
            this.PROCEDURE_17 = string.Empty;
            this.PROCEDURE_18 = string.Empty;
            this.PROCEDURE_19 = string.Empty;
            this.PROCEDURE_20 = string.Empty;
            this.PROCEDURE_21 = string.Empty;
            this.PROCEDURE_22 = string.Empty;
            this.PROCEDURE_23 = string.Empty;
            this.OTHER_PX_DATE_1 = string.Empty;
            this.OTHER_PX_DATE_2 = string.Empty;
            this.OTHER_PX_DATE_3 = string.Empty;
            this.OTHER_PX_DATE_4 = string.Empty;
            this.OTHER_PX_DATE_5 = string.Empty;
            this.OTHER_PX_DATE_6 = string.Empty;
            this.OTHER_PX_DATE_7 = string.Empty;
            this.OTHER_PX_DATE_8 = string.Empty;
            this.OTHER_PX_DATE_9 = string.Empty;
            this.OTHER_PX_DATE_10 = string.Empty;
            this.OTHER_PX_DATE_11 = string.Empty;
            this.OTHER_PX_DATE_12 = string.Empty;
            this.OTHER_PX_DATE_13 = string.Empty;
            this.OTHER_PX_DATE_14 = string.Empty;
            this.OTHER_PX_DATE_15 = string.Empty;
            this.OTHER_PX_DATE_16 = string.Empty;
            this.OTHER_PX_DATE_17 = string.Empty;
            this.OTHER_PX_DATE_18 = string.Empty;
            this.OTHER_PX_DATE_19 = string.Empty;
            this.OTHER_PX_DATE_20 = string.Empty;
            this.OTHER_PX_DATE_21 = string.Empty;
            this.OTHER_PX_DATE_22 = string.Empty;
            this.OTHER_PX_DATE_23 = string.Empty;
            this.OTHER_PX_DATE_24 = string.Empty;
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
            this.AppendField(this.ID);
            this.AppendField(this.HMO);
            this.AppendField(this.CLIENT_CLAIM_ID);
            this.AppendField(this.PRINCIPAL_PROC);
            this.AppendField(this.PROCEDURE_1);
            this.AppendField(this.PROCEDURE_2);
            this.AppendField(this.PROCEDURE_3);
            this.AppendField(this.PROCEDURE_4);
            this.AppendField(this.PROCEDURE_5);
            this.AppendField(this.PROCEDURE_6);
            this.AppendField(this.PROCEDURE_7);
            this.AppendField(this.PROCEDURE_8);
            this.AppendField(this.PROCEDURE_9);
            this.AppendField(this.PROCEDURE_10);
            this.AppendField(this.PROCEDURE_11);
            this.AppendField(this.PROCEDURE_12);
            this.AppendField(this.PROCEDURE_13);
            this.AppendField(this.PROCEDURE_14);
            this.AppendField(this.PROCEDURE_15);
            this.AppendField(this.PROCEDURE_16);
            this.AppendField(this.PROCEDURE_17);
            this.AppendField(this.PROCEDURE_18);
            this.AppendField(this.PROCEDURE_19);
            this.AppendField(this.PROCEDURE_20);
            this.AppendField(this.PROCEDURE_21);
            this.AppendField(this.PROCEDURE_22);
            this.AppendField(this.PROCEDURE_23);
            this.AppendField(this.OTHER_PX_DATE_1);
            this.AppendField(this.OTHER_PX_DATE_2);
            this.AppendField(this.OTHER_PX_DATE_3);
            this.AppendField(this.OTHER_PX_DATE_4);
            this.AppendField(this.OTHER_PX_DATE_5);
            this.AppendField(this.OTHER_PX_DATE_6);
            this.AppendField(this.OTHER_PX_DATE_7);
            this.AppendField(this.OTHER_PX_DATE_8);
            this.AppendField(this.OTHER_PX_DATE_9);
            this.AppendField(this.OTHER_PX_DATE_10);
            this.AppendField(this.OTHER_PX_DATE_11);
            this.AppendField(this.OTHER_PX_DATE_12);
            this.AppendField(this.OTHER_PX_DATE_13);
            this.AppendField(this.OTHER_PX_DATE_14);
            this.AppendField(this.OTHER_PX_DATE_15);
            this.AppendField(this.OTHER_PX_DATE_16);
            this.AppendField(this.OTHER_PX_DATE_17);
            this.AppendField(this.OTHER_PX_DATE_18);
            this.AppendField(this.OTHER_PX_DATE_19);
            this.AppendField(this.OTHER_PX_DATE_20);
            this.AppendField(this.OTHER_PX_DATE_21);
            this.AppendField(this.OTHER_PX_DATE_22);
            this.AppendField(this.OTHER_PX_DATE_23);
            this.AppendField(this.OTHER_PX_DATE_24);

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
            this.AppendField(@"ID");
            this.AppendField(@"HMO");
            this.AppendField(@"CLIENT_CLAIM_ID");
            this.AppendField(@"PRINCIPAL_PROC");
            this.AppendField(@"PROCEDURE_1");
            this.AppendField(@"PROCEDURE_2");
            this.AppendField(@"PROCEDURE_3");
            this.AppendField(@"PROCEDURE_4");
            this.AppendField(@"PROCEDURE_5");
            this.AppendField(@"PROCEDURE_6");
            this.AppendField(@"PROCEDURE_7");
            this.AppendField(@"PROCEDURE_8");
            this.AppendField(@"PROCEDURE_9");
            this.AppendField(@"PROCEDURE_10");
            this.AppendField(@"PROCEDURE_11");
            this.AppendField(@"PROCEDURE_12");
            this.AppendField(@"PROCEDURE_13");
            this.AppendField(@"PROCEDURE_14");
            this.AppendField(@"PROCEDURE_15");
            this.AppendField(@"PROCEDURE_16");
            this.AppendField(@"PROCEDURE_17");
            this.AppendField(@"PROCEDURE_18");
            this.AppendField(@"PROCEDURE_19");
            this.AppendField(@"PROCEDURE_20");
            this.AppendField(@"PROCEDURE_21");
            this.AppendField(@"PROCEDURE_22");
            this.AppendField(@"PROCEDURE_23");
            this.AppendField(@"OTHER_PX_DATE_1");
            this.AppendField(@"OTHER_PX_DATE_2");
            this.AppendField(@"OTHER_PX_DATE_3");
            this.AppendField(@"OTHER_PX_DATE_4");
            this.AppendField(@"OTHER_PX_DATE_5");
            this.AppendField(@"OTHER_PX_DATE_6");
            this.AppendField(@"OTHER_PX_DATE_7");
            this.AppendField(@"OTHER_PX_DATE_8");
            this.AppendField(@"OTHER_PX_DATE_9");
            this.AppendField(@"OTHER_PX_DATE_10");
            this.AppendField(@"OTHER_PX_DATE_11");
            this.AppendField(@"OTHER_PX_DATE_12");
            this.AppendField(@"OTHER_PX_DATE_13");
            this.AppendField(@"OTHER_PX_DATE_14");
            this.AppendField(@"OTHER_PX_DATE_15");
            this.AppendField(@"OTHER_PX_DATE_16");
            this.AppendField(@"OTHER_PX_DATE_17");
            this.AppendField(@"OTHER_PX_DATE_18");
            this.AppendField(@"OTHER_PX_DATE_19");
            this.AppendField(@"OTHER_PX_DATE_20");
            this.AppendField(@"OTHER_PX_DATE_21");
            this.AppendField(@"OTHER_PX_DATE_22");
            this.AppendField(@"OTHER_PX_DATE_23");
            this.AppendField(@"OTHER_PX_DATE_24");

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
                    this.ID = this.Fields[this.ColIdx].ToString().Trim();
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
                    this.PRINCIPAL_PROC = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_1 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_2 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_3 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_4 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_5 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_6 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_7 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_8 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_9 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_10 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_11 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_12 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_13 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_14 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_15 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_16 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_17 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_18 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_19 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_20 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_21 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_22 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.PROCEDURE_23 = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_1 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_2 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_3 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_4 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_5 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_6 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_7 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_8 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_9 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_10 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_11 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_12 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_13 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_14 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_15 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_16 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_17 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_18 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_19 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_20 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_21 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_22 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_23 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.OTHER_PX_DATE_24 = DateUtilities.CheckDate(this.Fields[this.ColIdx].ToString().Trim(), "M/d/yyyy");
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
