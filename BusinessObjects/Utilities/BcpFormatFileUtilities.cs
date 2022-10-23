using Novus.BulkCopy;

namespace Novus.Payer1060.BusinessObjects.Utilities
{
    public static class BcpFormatFileUtilities
    {
        /// <summary>
        /// Create Format File and returns HeaderString
        /// </summary>
        public static string CreateFormatFileReturnHeaderString(string adHocConnectionString, string fdTableName, string adHocFileName)
        {
            var fmtFile = new BcpFile(adHocConnectionString, fdTableName);
            fmtFile.WriteFile(adHocFileName.Replace(".txt", ".fmt"));
            return fmtFile.GetHeaderString();
        }

        /// <summary>
        /// Create Format file
        /// </summary>
        public static void CreateFormatFile(string adHocConnectionString, string fdTableName, string adhocFileName)
        {
            var fmtFile = new BcpFile(adHocConnectionString, fdTableName);
            fmtFile.WriteFile(adhocFileName.Replace(".txt", ".fmt"));
        }

        public static void CreateRacerFormatFile(string mapperOutputFormatFileName, BcpFileFormats bcpFileFormat)
        {
            var fmtFile = new BcpFile(bcpFileFormat);

            switch (bcpFileFormat)
            {
                case BcpFileFormats.mapperOutputClaimHeaderFile:
                    {
                        var fmtColumns = new BcpColumns();
                        fmtColumns.Add(new BcpColumn(0, FormatFileDataType.Char, 0, 20, "|", "INS_GROUP_NO"));
                        fmtColumns.Add(new BcpColumn(0, FormatFileDataType.Char, 0, 20, "|", "PROVIDER_NO"));
                        fmtColumns.Add(new BcpColumn(0, FormatFileDataType.Char, 0, 20, "|", "PAT_MEMBER_NO"));
                        fmtColumns.Add(new BcpColumn(0, FormatFileDataType.Char, 0, 20, "\r\n", "SUB_MEMBER_NO"));

                        fmtFile.AddColumnsToCollection(fmtColumns, true, true);
                        break;
                    }
                case BcpFileFormats.mapperOutputClaimLineFile:
                case BcpFileFormats.mapperOutputSpecialFieldsFile:
                    {
                        var fmtColumns = new BcpColumns();
                        fmtColumns.Add(new BcpColumn(0, FormatFileDataType.Char, 0, 20, "\r\n", "CLAIM_NO"));

                        fmtFile.AddColumnsToCollection(fmtColumns, true, true);
                        break;
                    }
                case BcpFileFormats.mapperOutputICD9File:
                    {
                        var fmtColumns = new BcpColumns();
                        fmtColumns.Add(new BcpColumn(0, FormatFileDataType.Char, 0, 20, "|", "CLAIM_NO"));
                        fmtColumns.Add(new BcpColumn(0, FormatFileDataType.Char, 0, 20, "\r\n", "LINE_NO"));

                        fmtFile.AddColumnsToCollection(fmtColumns, true, true);
                        break;
                    }
                default:
                    break;
            }

            fmtFile.WriteFile(mapperOutputFormatFileName);
        }
    }
}
