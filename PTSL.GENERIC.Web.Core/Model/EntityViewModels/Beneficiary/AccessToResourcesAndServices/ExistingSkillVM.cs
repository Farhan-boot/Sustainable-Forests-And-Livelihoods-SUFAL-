using PTSL.GENERIC.Web.Core.Helper.Enum.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary
{
    public class ExistingSkillVM : BaseModel
    {
        public string? SkillName { get; set; }

        public SkillLevel? SkillLevelEnum { get; set; }
        public string? SkillLevelEnumString { get; set; }

        public string? Remarks { get; set; }

        public long SurveyId { get; set; }
        public SurveyVM? Survey { get; set; }
    }
}
