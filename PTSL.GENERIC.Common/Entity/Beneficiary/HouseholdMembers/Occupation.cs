using PTSL.GENERIC.Common.Entity.CommonEntity;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Entity.Beneficiary
{
    public class Occupation : BaseEntity
    {
        public string? Name { get; set; }
        public string? NameBn { get; set; }

        public List<HouseholdMember>? HouseholdMembersMain { get; set; }
        public List<HouseholdMember>? HouseholdMembersSecondary { get; set; }
    }
}