using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Enum.Beneficiary;

namespace PTSL.GENERIC.Common.Entity.Beneficiary
{
    public class ExistingSkill : BaseEntity
    {
        public string? SkillName { get; set; }

        public SkillLevel? SkillLevelEnum { get; set; }

        public string? Remarks { get; set; }

        public long SurveyId { get; set; }
        public Survey? Survey { get; set; }
    }
}