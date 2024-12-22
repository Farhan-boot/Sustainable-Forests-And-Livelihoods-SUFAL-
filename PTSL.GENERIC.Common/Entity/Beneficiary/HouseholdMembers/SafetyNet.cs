using PTSL.GENERIC.Common.Entity.CommonEntity;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Entity.Beneficiary
{
    public class SafetyNet : BaseEntity
    {
        public string? Name { get; set; }
        public string? NameBn { get; set; }

        public List<HouseholdMember>? HouseholdMembers { get; set; }
    }
}