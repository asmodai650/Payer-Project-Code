using System;
using System.Text;
using Novus.Toolbox;
using Novus.Payer1060.BusinessObjects.Constants;
using Novus.Payer1060.BusinessObjects.FileObjects;

namespace Novus.Payer1060.BusinessObjects.RacerMappers
{
    /// <summary>
    /// For this project, all claim lines of a claim have identical ICD values; so we only need to read one line per claim.
    /// </summary>
    public static class IcdMapper
    {
        private static readonly FO_BcpPlusICD9 icd = new FO_BcpPlusICD9();

        private const string newLine = "\r\n";
        private static readonly char[] newLineChars = newLine.ToCharArray();

        public static string EmitIcdHeader()
        {
            return icd.EmitHeaderLine();
        }

        /// <summary>
        /// Gets Admitting diag code from claim header file if available
        /// Creates a line for each diagnosis and procedure code in the Diag and Proc files.
        /// Returns a tuple with 2 strings: [string for the mapperOutputIcd9 file, string for the lookupInputIcd9 file]</returns>
        /// </summary>
        public static Tuple<string, string> EmitRacerIcdLines(LookupDiagProcToIcdMapper lookupFile)
        {
            icd.Clear();

            icd.PROJECT_ID = lookupFile.PROJECT_ID;
            icd.FEED_ID = lookupFile.FEED_ID;
            icd.CLAIM_NO = lookupFile.CLAIM_NO;
            icd.DATE_CREATED = DateTime.Now.ToString(Constant.RacerMapperDateFormat);
            icd.USERNAME = Constant.LoadingUserName;

            ///build strings for mapperOutput and lookupInput file
            var mapperBuilder = new StringBuilder();
            var lookupBuilder = new StringBuilder();

            ///add diag codes to stringbuilders
            var diags = lookupFile.GetDiagnosisCodes();
            for (int i = 0; i < diags.Length; i++)
            {
                var diag = diags[i];
                mapperBuilder.AppendNewLine(GetDiagLine(diag, i, lookupFile.CLAIM_ICD_VERSION_INDICATOR, diag == lookupFile.ADMITTING_DIAGNOSIS_CODE));
                lookupBuilder.AppendNewLine($"{lookupFile.CLAIM_NO}|{diag}");
            }

            ///add proc codes to stringbuilders
            var procs = lookupFile.GetProcedureCodes();
            for (int i = 0; i < procs.Length; i++)
            {
                var proc = procs[i];
                mapperBuilder.AppendNewLine(GetProcLine(proc, i, lookupFile.CLAIM_ICD_VERSION_INDICATOR));
                lookupBuilder.AppendNewLine($"{lookupFile.CLAIM_NO}|{proc}");
            }

            return Tuple.Create(mapperBuilder.GetStringFromStringBuilder(), lookupBuilder.GetStringFromStringBuilder());
        }

        /// <summary>
        /// Removes trailing new line characters and ensures that the output is not null.
        /// </summary>
        private static string GetStringFromStringBuilder(this StringBuilder stringBuilder)
        {
            return (stringBuilder.ToString() ?? string.Empty).TrimEnd(newLineChars);
        }

        /// <summary>
        /// Appends the string value + specific new line character(s).
        /// </summary>
        private static void AppendNewLine(this StringBuilder stringBuilder, string value)
        {
            stringBuilder.Append(value + newLine);
        }

        private static string GetDiagLine(string code, int order, string version, bool isAdmitting)
        {
            icd.ICD9_CODE = code;
            icd.ICD9_TYPE = version == "9" ? "DIAG" : "DIAG10"; ///defaults to icd10
            icd.ADMITTING_CODE = isAdmitting ? "1" : "0";
            icd.PRINCIPAL_CODE = order == 0 ? "1" : "0";
            icd.ORDER_IN_CLAIM = order.ToString();

            return icd.ToString();
        }

        private static string GetProcLine(string code, int order, string version)
        {
            icd.ICD9_CODE = code;
            icd.ICD9_TYPE = version == "9" ? "PROC" : "PROC10"; ///defaults to icd10
            icd.ADMITTING_CODE = "0";
            icd.PRINCIPAL_CODE = order == 0 ? "1" : "0";
            icd.ORDER_IN_CLAIM = order.ToString();

            return icd.ToString();
        }
    }
}
