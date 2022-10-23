namespace Novus.Payer1060.BusinessObjects.Lookups
{
    public static class LookupRelationshipToInsuredId1060
    {
        /// <summary>
        /// Return REL_TO_INS_ID given FdOptumCareHcpMem.SEX.
        /// </summary>
        public static string InsIdLookup(string relationshipToInsId)
        {
            if (string.IsNullOrEmpty(relationshipToInsId))
                return "13";

            switch (relationshipToInsId.ToUpper())
            {
                case "M":
                    return "11";
                case "F":
                    return "12";
                default:
                    return "13";
            }
        }
    }
}
