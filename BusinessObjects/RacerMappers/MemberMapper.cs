using System;
using System.Text.RegularExpressions;
using Novus.Extensions;
using Novus.Toolbox;
using Novus.Payer1060.BusinessObjects.Constants;
using Novus.Payer1060.BusinessObjects.FileObjects;
using Novus.Payer1060.BusinessObjects.Lookups;
using Novus.Payer1060.BusinessObjects.Utilities;

namespace Novus.Payer1060.BusinessObjects.RacerMappers
{
    public static class MemberMapper
    {
        private static readonly FO_Member member = new FO_Member();

        public static string EmitHeaderLine()
        {
            return member.EmitHeaderLine();
        }

        public static string EmitRacerLine(FdOptumCareHcpMem foMember)
        {
            member.Clear();

            member.PROJECT_ID = foMember.PROJECT_ID;
            member.MEMBER_NO = foMember.PAT_MEMBER_NO;
            member.DATE_OF_BIRTH = DateUtilities.GetRacerDate(foMember.PAT_DATE_OF_BIRTH);
            member.GENDER = foMember.SEX.SubstringNovus(0, 1);
            member.SSN = foMember.PAT_SSN.SubstringNovus(0, 9);
            member.FIRST_NAME = foMember.FIRST_NAME.SubstringNovus(0, 25);
            member.LAST_NAME = foMember.LAST_NAME.SubstringNovus(0, 25);
            member.MARITAL_STATUS = foMember.MARITAL_STATUS.SubstringNovus(0, 1);
            member.REL_TO_INS_ID = LookupRelationshipToInsuredId1060.InsIdLookup(foMember.SEX.Trim());
            member.REL_TO_INS_GROUP_ID = Constant.RelInsGroupid;
            member.ADDRESS_1 = foMember.MEMBER_STREET_ADDRESS_1.SubstringNovus(0, 50).ToUpper();
            member.ADDRESS_2 = foMember.MEMBER_STREET_ADDRESS_2.SubstringNovus(0, 50).ToUpper();
            member.CITY = GetCityFromCtySt(foMember.CTY_ST).ToUpper();
            member.STATE = GetStateFromCtySt(foMember.CTY_ST).ToUpper();
            member.ZIP = foMember.MEMBER_ZIP_CODE;
            member.HOME_PHONE = foMember.MEMBER_PHONE_NUMBER.Replace("-", "").SubstringNovus(0, 13);
            member.DATE_EFFECTIVE = DateUtilities.GetRacerDate(foMember.PAT_DATE_EFFECTIVE);
            member.DATE_EXPIRATION = DateUtilities.GetRacerDate(foMember.PAT_DATE_EXPIRATION);
            member.DATE_CREATED = DateTime.Now.ToString(Constant.RacerMapperDateFormat);
            member.USERNAME = Constant.LoadingUserName;

            return member.ToString();
        }

        public static string GetCityFromCtySt(string ctySt)
        {
            try
            {
                if (ctySt.Contains(","))
                {
                    string[] splitCty = ctySt.Split(',');
                    var city = splitCty[0].Trim();

                    return city.Trim().ToUpper();
                }
                else if (ctySt.Contains("  "))
                {
                    string[] splitCty = Regex.Split(ctySt, @"\s{2,}");
                    var city = splitCty[0].Trim();

                    return city.Trim().ToUpper();
                }
                else
                {
                    return ctySt.Trim().ToUpper(); ///per CDG return ORIGINAL string if no comma or no two or more spaces together
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string GetStateFromCtySt(string ctySt)
        {
            try
            {
                if (ctySt.Contains(","))
                {
                    string[] splitSt = ctySt.Split(',');
                    var state = splitSt[1].Trim().Substring(0, 2);

                    return state.Trim().ToUpper();
                }
                else if (ctySt.Contains("  "))
                {
                    string[] splitSt = Regex.Split(ctySt, @"\s{2,}");
                    var state = splitSt[1].Trim().Substring(0, 2);

                    return state.Trim().ToUpper();
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
    }
}
