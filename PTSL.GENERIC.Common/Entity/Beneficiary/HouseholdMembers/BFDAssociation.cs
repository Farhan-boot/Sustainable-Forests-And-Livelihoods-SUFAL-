using PTSL.GENERIC.Common.Entity.CommonEntity;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Entity.Beneficiary
{
    public class BFDAssociation : BaseEntity
    {
        public string? Name { get; set; }
        public string? NameBn { get; set; }

        public List<BFDAssociationHouseholdMembersMap>? BFDAssociationHouseholdMembers { get; set; }
    }
}