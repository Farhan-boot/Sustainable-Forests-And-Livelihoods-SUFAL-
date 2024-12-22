using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.Beneficiary;
using System;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Entity.Beneficiary
{
    public class HouseholdMember : BaseEntity
    {
        public string? FullName { get; set; }
        public string? FullNameBn { get; set; }

        public long RelationWithHeadHouseHoldTypeId { get; set; }
        public RelationWithHeadHouseHoldType? RelationWithHeadHouseHoldType { get; set; }
        public string? RelationWithHeadHouseHoldTypeTxt { get; set; }

        public Gender Gender { get; set; }

        public string? Age { get; set; }
        public string? AgeBn { get; set; }

        public MaritalStatus MaritalSatus { get; set; }
        public string? MaritalSatusTxt { get; set; }

        public EducationLevel EducationLevel { get; set; }

        public long MainOccupationId { get; set; }
        public Occupation? MainOccupation { get; set; }
        public string? MainOccupationTxt { get; set; }
        public long SecondaryOccupationId { get; set; }
        public Occupation? SecondaryOccupation { get; set; }
        public string? SecondOccupationTxt { get; set; }

        public List<BFDAssociationHouseholdMembersMap>? BFDAssociationHouseholdMembers { get; set; }
        public string? BFDAssociationTxt { get; set; }

        public bool HasDisability { get; set; }

        public List<DisabilityTypeHouseholdMembersMap>? DisabilityTypeHouseholdMembers { get; set; }

        public long SafetyNetTypeId { get; set; }
        public SafetyNet? SafetyNetType { get; set; }
        public string? SafetyNetTypeTxt { get; set; }

        public DateTime SubmissionTime { get; set; }

        public string? SubmittedBy { get; set; }
        public string? Notes { get; set; }

        public long SurveyId { get; set; }
        public Survey? Survey { get; set; }
    }
}