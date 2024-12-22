using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.Beneficiary
{
    public class EnergyUse : BaseEntity
    {
        public long EnergyTypeId { get; set; }
        public EnergyType? EnergyType { get; set; }
        public string? EnergyUseTypeTxt { get; set; }

        public double EnergyUsesMonthly { get; set; }

        public long SurveyId { get; set; }
        public Survey? Survey { get; set; }
    }
}