using System.Collections.Generic;

namespace Novus.Payer1060.BusinessObjects.FileObjects
{
    /// <summary>
    /// Claim to member file joins are 1 to many.
    /// <br/>We only want to apply member data to a claim record where the claim.DATE_OF_SERVICE falls between the member.PAT_DATE_EFFECTIVE - member.PAT_DATE_EXPIRATION   
    /// </summary>
    public class LookupDiagToClaim
    {
        public List<LookupDiagToClaimFields> Fields { get; set; }

        public LookupDiagToClaim()
        {
            this.Fields = new List<LookupDiagToClaimFields>();
        }

        public void Set(List<string> propStrings)
        {
            this.Fields.Clear();
            this.Fields.TrimExcess();

            foreach (var propString in propStrings)
            {
                var props = propString.Split('|');
                this.Fields.Add(new LookupDiagToClaimFields(props));
            }
        }
    }

    /// <summary>
    /// This class models the lookupMemberToClaim file that is used to merge member data into the claim file.
    /// </summary>
    public class LookupDiagToClaimFields
    {
        public string CLAIM_NO { get; set; }

        public string PRINCIPAL_DIAG { get; set; }

        public LookupDiagToClaimFields()
        {
            this.Clear();
        }

        public LookupDiagToClaimFields(string[] fields) : this()
        {
            this.LoadFromString(fields);
        }

        public void Clear()
        {
            this.CLAIM_NO = string.Empty;
            this.PRINCIPAL_DIAG = string.Empty;
        }

        private void LoadFromString(string[] fields)
        {
            if (fields.Length == 8)
            {
                int i = -1;

                this.CLAIM_NO = fields[++i];
                this.PRINCIPAL_DIAG = fields[++i];
            }
        }
    }
}
