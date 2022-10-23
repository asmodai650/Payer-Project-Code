using System;
using System.Globalization;
using Novus.Payer1060.BusinessObjects.Constants;

namespace Novus.Payer1060.BusinessObjects.Utilities
{
    public static class DateUtilities
    {
        public static string CheckDate(string date, string format = null)
        {
            var trimDate = date?.Trim() ?? string.Empty;

            if (trimDate.Length < 8)
            {
                return string.Empty;
            }

            if (DateTime.TryParseExact(trimDate,
                                       new string[] { "M/d/yyyy", "MM/d/yyyy", "M/dd/yyyy", "MM/dd/yyyy", "mm/dd/yyyy",
                                                     "M/d/yyyy h:mm:ss", "MM/d/yyyy h:mm:ss", "M/dd/yyyy h:mm:ss", "MM/dd/yyyy h:mm:ss",
                                                     "yyyyMd", "yyyyMMd", "yyyyMdd", "yyyyMMdd",
                                                     "yyyy-MM-dd HH:mm:ss", "yyyy-MM-dd HH:mm:ss.fff",
                                                     format ?? "yyyy-MM-dd" },
                                       CultureInfo.InvariantCulture,
                                       DateTimeStyles.None,
                                       out DateTime outVal))
            {
                return (outVal <= Constant.minDateSql || outVal >= Constant.maxDateSql) ? string.Empty : outVal.ToString(Constant.OutputDateFormat);
            }
            else
            {
                return string.Empty;
            }
        }

        public static string GetDate(DateTime date)
        {
            if (date >= Constant.maxDateSql || date <= Constant.minDateSql)
            {
                return string.Empty;
            }
            else
            {
                return date.ToString(Constant.OutputDateFormat);
            }
        }

        public static string GetRacerDate(string date, string format = null)
        {
            var trimDate = date?.Trim() ?? string.Empty;

            if (trimDate.Length < 8)
            {
                return string.Empty;
            }

            if (DateTime.TryParseExact(trimDate,
                                       new string[] { "M/d/yyyy", "MM/d/yyyy", "M/dd/yyyy", "MM/dd/yyyy", "mm/dd/yyyy",
                                                     "M/d/yyyy h:mm:ss", "MM/d/yyyy h:mm:ss", "M/dd/yyyy h:mm:ss", "MM/dd/yyyy h:mm:ss",
                                                     "yyyyMd", "yyyyMMd", "yyyyMdd", "yyyyMMdd",
                                                     "yyyy-MM-dd HH:mm:ss", "yyyy-MM-dd HH:mm:ss.fff",
                                                     format ?? "yyyy-MM-dd" },
                                       CultureInfo.InvariantCulture,
                                       DateTimeStyles.None,
                                       out DateTime outVal))
            {
                return (outVal <= Constant.minDateSql || outVal >= Constant.maxDateSql) ? string.Empty : outVal.ToString(Constant.RacerMapperDateFormat);
            }
            else
            {
                return string.Empty;
            }
        }

    }
}
