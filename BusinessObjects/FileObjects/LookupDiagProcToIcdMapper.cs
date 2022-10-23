using System.Text;
using System.Linq;
using System.Collections.Generic;
using Novus.Toolbox;
using Novus.Payer1060.BusinessObjects.Constants;

namespace Novus.Payer1060.BusinessObjects.FileObjects
{
    public class LookupDiagProcToIcdMapper
    {
        #region CLASS_VARIABLES

        private readonly StringBuilder stringBuilder = new StringBuilder();
        #endregion CLASS_VARIABLES

        #region CONSTRUCTORS

        /// <summary>
        /// Initializes a new instance of the <see cref="LookupDiagProcToIcdMapper" /> class.
        /// </summary>
        public LookupDiagProcToIcdMapper()
        {
            this.Clear();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LookupDiagProcToIcdMapper" /> class.
        /// </summary>
        /// <param name="racerLoadJobReadOnlyProperties">The instance of RacerLoadJobReadOnlyProperties for this file load.</param>
        public LookupDiagProcToIcdMapper(RacerLoadJobReadOnlyProperties racerLoadJobReadOnlyProperties)
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

        public string PROJECT_ID { get; set;}

        public string FEED_ID { get; set; }

        public string CLAIM_NO { get; set; }

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

        public string ADMITTING_DIAGNOSIS_CODE { get; set; }

        public string CLAIM_ICD_VERSION_INDICATOR { get; set; }
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

                if (this.Fields.Length < 53 || this.Fields[0].ToString().ToLower().Contains("project")) //Header row
                {
                    this.IsValid = false;
                    return;
                }
                this.ColIdx = -1;

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
                    this.CLAIM_NO = this.Fields[this.ColIdx].ToString().Trim();
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
                    this.ADMITTING_DIAGNOSIS_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_ICD_VERSION_INDICATOR = this.Fields[this.ColIdx].ToString().Trim();
                }
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
            this.CLAIM_NO = string.Empty;
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
            this.ADMITTING_DIAGNOSIS_CODE = string.Empty;
            this.CLAIM_ICD_VERSION_INDICATOR = string.Empty;
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

            this.AppendField(this.PROJECT_ID);
            this.AppendField(this.FEED_ID);
            this.AppendField(this.CLAIM_NO);
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
            this.AppendField(this.ADMITTING_DIAGNOSIS_CODE);
            this.AppendLastField(this.CLAIM_ICD_VERSION_INDICATOR);

            return this.stringBuilder.ToString();
        }

        /// <summary>
        /// Outputs the header column names in order they occur in the database table.
        /// </summary>
        /// <returns>The concatenated line of header values.</returns>
        public string EmitHeaderLine(bool includeLookupFields)
        {
            this.stringBuilder.Length = 0;

            this.AppendField(@"PROJECT_ID");
            this.AppendField(@"FEED_ID");
            this.AppendField(@"CLAIM_NO");
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
            this.AppendField(@"ADMITTING_DIAGNOSIS_CODE");
            this.AppendLastField(@"CLAIM_ICD_VERSION_INDICATOR");

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
                    this.PROJECT_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.FEED_ID = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_NO = this.Fields[this.ColIdx].ToString().Trim();
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
                    this.ADMITTING_DIAGNOSIS_CODE = this.Fields[this.ColIdx].ToString().Trim();
                }

                if (++this.ColIdx < this.Fields.Length)
                {
                    this.CLAIM_ICD_VERSION_INDICATOR = this.Fields[this.ColIdx].ToString().Trim();
                }                
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
        /// Returns array of all ICD diagnosis codes in the correct order for racer processing.
        /// </summary>
        public string[] GetDiagnosisCodes()
        {
            var a = new List<string>()
            {
                this.PRINCIPAL_DIAG
                ,this.DIAGNOSIS_1
                ,this.DIAGNOSIS_2
                ,this.DIAGNOSIS_3
                ,this.DIAGNOSIS_4
                ,this.DIAGNOSIS_5
                ,this.DIAGNOSIS_6
                ,this.DIAGNOSIS_7
                ,this.DIAGNOSIS_8
                ,this.DIAGNOSIS_9
                ,this.DIAGNOSIS_10
                ,this.DIAGNOSIS_11
                ,this.DIAGNOSIS_12
                ,this.DIAGNOSIS_13
                ,this.DIAGNOSIS_14
                ,this.DIAGNOSIS_15
                ,this.DIAGNOSIS_16
                ,this.DIAGNOSIS_17
                ,this.DIAGNOSIS_18
                ,this.DIAGNOSIS_19
                ,this.DIAGNOSIS_20
                ,this.DIAGNOSIS_21
                ,this.DIAGNOSIS_22
                ,this.DIAGNOSIS_23
                ,this.ADMITTING_DIAGNOSIS_CODE
                }.Distinct().Where(s => !string.IsNullOrEmpty(s)).ToArray();
            ///};

            ///if (!a.Any(d => d == this.ADMITTING_DIAGNOSIS_CODE))
            ///{
            ///    a.Add(this.ADMITTING_DIAGNOSIS_CODE);
            ///}

            return a.ToArray();
        }

        /// <summary>
        /// Returns array of all ICD procedure codes in the correct order for racer processing.
        /// </summary>
        public string[] GetProcedureCodes()
        {
            return new[]
            {
                this.PRINCIPAL_PROC
                ,this.PROCEDURE_1
                ,this.PROCEDURE_2
                ,this.PROCEDURE_3
                ,this.PROCEDURE_4
                ,this.PROCEDURE_5
                ,this.PROCEDURE_6
                ,this.PROCEDURE_7
                ,this.PROCEDURE_8
                ,this.PROCEDURE_9
                ,this.PROCEDURE_10
                ,this.PROCEDURE_11
                ,this.PROCEDURE_12
                ,this.PROCEDURE_13
                ,this.PROCEDURE_14
                ,this.PROCEDURE_15
                ,this.PROCEDURE_16
                ,this.PROCEDURE_17
                ,this.PROCEDURE_18
                ,this.PROCEDURE_19
                ,this.PROCEDURE_20
                ,this.PROCEDURE_21
                ,this.PROCEDURE_22
                ,this.PROCEDURE_23
            }.Distinct().Where(s => !string.IsNullOrEmpty(s)).ToArray();
            ///}; 
        }
        #endregion METHODS
    }
}
