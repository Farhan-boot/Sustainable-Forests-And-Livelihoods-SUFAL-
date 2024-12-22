using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary
{
    public class HouseholdMemberVM : BaseModel
    {
        public string? FullName { get; set; }
        public string? FullNameBn { get; set; }

        public long RelationWithHeadHouseHoldTypeId { get; set; }
        public RelationWithHeadHouseHoldTypeVM? RelationWithHeadHouseHoldType { get; set; }
        public string? RelationWithHeadHouseHoldTypeTxt { get; set; }

        public Gender Gender { get; set; }

        public string? Age { get; set; }
        public string? AgeBn { get; set; }

        public MaritalStatus MaritalSatus { get; set; }
        public string? MaritalSatusTxt { get; set; }

        public EducationLevel EducationLevel { get; set; }

        public long MainOccupationId { get; set; }
        public OccupationVM? MainOccupation { get; set; }
        public string? MainOccupationTxt { get; set; }
        public long SecondaryOccupationId { get; set; }
        public OccupationVM? SecondaryOccupation { get; set; }
        public string? SecondOccupationTxt { get; set; }

        public List<BFDAssociationHouseholdMembersMapVM>? BFDAssociationHouseholdMembersMap { get; set; }
        public string? BFDAssociationTxt { get; set; }

        public bool HasDisability { get; set; }

        public List<DisabilityTypeHouseholdMembersMapVM>? DisabilityTypeHouseholdMembersMap { get; set; }

        public long SafetyNetTypeId { get; set; }
        public SafetyNetVM? SafetyNetType { get; set; }
        public string? SafetyNetTypeTxt { get; set; }

        public DateTime SubmissionTime { get; set; } = DateTime.Now;

        public string? SubmittedBy { get; set; }
        public string? Notes { get; set; }

        public long SurveyId { get; set; }
        public SurveyVM? Survey { get; set; }
    }
}
