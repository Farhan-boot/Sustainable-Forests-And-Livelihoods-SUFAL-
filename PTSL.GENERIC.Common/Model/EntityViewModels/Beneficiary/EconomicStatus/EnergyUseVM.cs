using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary
{
    public class EnergyUseVM : BaseModel
    {
        public long EnergyTypeId { get; set; }

        [SwaggerExclude]
        public EnergyTypeVM? EnergyType { get; set; }
        public string? EnergyUseTypeTxt { get; set; }

        public double EnergyUsesMonthly { get; set; }

        public long SurveyId { get; set; }

        [SwaggerExclude]
        public SurveyVM? Survey { get; set; }
    }
}