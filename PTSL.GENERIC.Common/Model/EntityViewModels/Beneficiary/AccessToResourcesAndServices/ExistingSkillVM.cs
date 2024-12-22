using PTSL.GENERIC.Common.Enum.Beneficiary;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary
{
    public class ExistingSkillVM : BaseModel
    {
        public string? SkillName { get; set; }

        public SkillLevel? SkillLevelEnum { get; set; }
        public string? SkillLevelEnumString { get; set; }

        public string? Remarks { get; set; }

        public long SurveyId { get; set; }

        [SwaggerExclude]
        public SurveyVM? Survey { get; set; }
    }
}