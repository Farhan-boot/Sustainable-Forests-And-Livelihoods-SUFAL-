using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.Beneficiary;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using System;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary
{
    public class HouseholdMemberVM : BaseModel
    {
        public string? FullName { get; set; }
        public string? FullNameBn { get; set; }

        public long RelationWithHeadHouseHoldTypeId { get; set; }

        [SwaggerExclude]
        public RelationWithHeadHouseHoldTypeVM? RelationWithHeadHouseHoldType { get; set; }
        public string? RelationWithHeadHouseHoldTypeTxt { get; set; }

        public Gender Gender { get; set; }

        public string? Age { get; set; }
        public string? AgeBn { get; set; }

        public MaritalStatus MaritalSatus { get; set; }
        public string? MaritalSatusTxt { get; set; }

        public EducationLevel EducationLevel { get; set; }

        public long MainOccupationId { get; set; }

        [SwaggerExclude]
        public OccupationVM? MainOccupation { get; set; }
        public string? MainOccupationTxt { get; set; }
        public long SecondaryOccupationId { get; set; }

        [SwaggerExclude]
        public OccupationVM? SecondaryOccupation { get; set; }
        public string? SecondOccupationTxt { get; set; }

        public List<BFDAssociationHouseholdMembersMapVM>? BFDAssociationHouseholdMembersMap { get; set; }
        public string? BFDAssociationTxt { get; set; }

        public bool HasDisability { get; set; }

        public List<DisabilityTypeHouseholdMembersMapVM>? DisabilityTypeHouseholdMembersMap { get; set; }

        public long SafetyNetTypeId { get; set; }

        [SwaggerExclude]
        public SafetyNetVM? SafetyNetType { get; set; }
        public string? SafetyNetTypeTxt { get; set; }

        public DateTime SubmissionTime { get; set; }

        public string? SubmittedBy { get; set; }
        public string? Notes { get; set; }

        public long SurveyId { get; set; }

        [SwaggerExclude]
        public SurveyVM? Survey { get; set; }
    }
}