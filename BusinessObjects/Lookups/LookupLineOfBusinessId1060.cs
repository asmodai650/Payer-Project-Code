namespace Novus.Payer1060.BusinessObjects.Lookups
{
    public static class LookupLineOfBusinessId1060
    {
        /// <summary>
        /// Return LINE_OF_BUSINESS_ID given FdOptumCareHcpClaim.CLIENT_LOB_CODE.
        /// </summary>
        public static string LobLookup(string clientLobCode)
        {
            if (string.IsNullOrEmpty(clientLobCode))
                return "0";

            switch (clientLobCode.ToUpper())
            {
                case "COMMERCIAL":
                case "POINT OF SERVICE":
                    return "1";
                case "MEDI-CAL":
                    return "6";
                case "SENIOR":
                    return "8";
                default:
                    return "0";                         
            }
        }
    }
}
