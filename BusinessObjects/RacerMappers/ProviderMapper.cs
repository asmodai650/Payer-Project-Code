using System;
using Novus.Extensions;
using Novus.Toolbox;
using Novus.Payer1060.BusinessObjects.Constants;
using Novus.Payer1060.BusinessObjects.FileObjects;
using Novus.Payer1060.BusinessObjects.Utilities;

namespace Novus.Payer1060.BusinessObjects.RacerMappers
{
    public static class ProviderMapper
    {
        private static readonly FO_Provider provider = new FO_Provider();

        public static string EmitHeaderLine()
        {
            return provider.EmitHeaderLine();
        }

        public static string EmitRacerLine(FdOptumCareHcpProvider foProvider)
        {
            provider.Clear();

            provider.PROJECT_ID = foProvider.PROJECT_ID;
            provider.PROVIDER_NO = foProvider.PROVIDER_NO;
            provider.TAX_ID = foProvider.TAX_ID;
            provider.NAME = foProvider.PROV_NAME.SubstringNovus(0, 50);
            provider.ADDRESS_1 = foProvider.PROVIDER_MAILING_STREET_ADDRESS_1.SubstringNovus(0, 50).ToUpper();
            provider.ADDRESS_2 = foProvider.PROVIDER_MAILING_STREET_ADDRESS_2.SubstringNovus(0, 50).ToUpper();
            provider.ADDRESS_3 = foProvider.PROVIDER_MAILING_STREET_ADDRESS_3.SubstringNovus(0, 50).ToUpper();
            provider.CITY = GetCityFromProvMailCity(foProvider.PROVIDER_MAILING_CITY).ToUpper();
            provider.STATE = GetStateFromProvMailCity(foProvider.PROVIDER_MAILING_CITY).ToUpper();
            provider.ZIP = GetZipFromProvMailCity(foProvider.PROVIDER_MAILING_CITY).ToUpper();
            provider.PHONE = foProvider.PROVIDER_PRACTICE_PHONE.SubstringNovus(0, 13);
            provider.UPIN_NUMBER = foProvider.PROVIDER_NPI;
            provider.DATE_EFFECTIVE = DateUtilities.GetRacerDate(foProvider.PROVIDER_GROUP_AFFILIATION_EFFECTIVE_DATE);
            provider.DATE_EXPIRATION = DateUtilities.GetRacerDate(foProvider.PROVIDER_GROUP_AFFILIATION_TERMINATION_DATE);
            provider.DATE_CREATED = DateTime.Now.ToString(Constant.OutputDateFormat);
            provider.USERNAME = Constant.LoadingUserName;

            return provider.ToString();
        }

        public static string GetCityFromProvMailCity(string provMailCity)
        {
            try
            {
                if (provMailCity.Contains(","))
                {
                    string[] splitCty = provMailCity.Split(',');
                    var city = splitCty[0].Trim();

                    return city;
                }
                else
                {
                    return provMailCity.ToUpper(); ///per CDG return ORIGINAL string if no comma or no two or more spaces together
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string GetStateFromProvMailCity(string provMailCity)
        {
            try
            {
                if (provMailCity.Contains(","))
                {
                    string[] splitSt = provMailCity.Split(',');
                    var state = splitSt[1].Trim().Substring(0, 2);

                    return state;
                }
                else
                {
                    return string.Empty; ///per CDG return EMPTY string if no comma or no two or more spaces together
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string GetZipFromProvMailCity(string provMailCity)
        {
            try
            {
                if (string.IsNullOrEmpty(provMailCity))
                    return string.Empty;

                string checkForZip = provMailCity.Trim().Substring(provMailCity.Length - 10);

                if (checkForZip.Contains("-"))
                {
                    string[] splitZip = checkForZip.Split('-');

                    var splitZipCodeA = splitZip[0].Substring(splitZip[0].Length - 5);
                    bool validZipA = int.TryParse(splitZipCodeA, out int _);

                    var splitExtZipCodeA = splitZip[1].ToString();
                    bool validExtZipA = int.TryParse(splitExtZipCodeA, out int a); 

                    if (validZipA && validExtZipA)
                        return splitZipCodeA.ToString().Trim() + "-" + splitExtZipCodeA.ToString().Trim();

                    if (validZipA || !validExtZipA)
                        return splitZipCodeA.ToString().Trim();
                    else
                        return string.Empty;
                }
                if (!checkForZip.Contains("-"))
                {
                    var zipCode = checkForZip.Substring(checkForZip.Length - 5);
                    bool validZipB = int.TryParse(zipCode, out int _);

                    if (validZipB)
                        return zipCode.ToString().Trim();
                    else
                        return string.Empty;
                }
                else
                    return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
