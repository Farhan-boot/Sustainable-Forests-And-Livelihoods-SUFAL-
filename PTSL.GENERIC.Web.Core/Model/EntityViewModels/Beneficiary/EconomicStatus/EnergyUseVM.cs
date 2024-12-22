namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary
{
    public class EnergyUseVM : BaseModel
    {
        public long EnergyTypeId { get; set; }
        public EnergyTypeVM? EnergyType { get; set; }
        public string? EnergyUseTypeTxt { get; set; }

        public double EnergyUsesMonthly { get; set; }

        public long SurveyId { get; set; }
        public SurveyVM? Survey { get; set; }
    }
}
