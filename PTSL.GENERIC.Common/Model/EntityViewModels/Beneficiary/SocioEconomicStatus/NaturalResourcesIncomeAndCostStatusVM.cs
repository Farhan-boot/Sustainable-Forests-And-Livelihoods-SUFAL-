using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary
{
    public class NaturalResourcesIncomeAndCostStatusVM : BaseModel
    {
        public long? NaturalIncomeSourceTypeId { get; set; }

        [SwaggerExclude]
        public NaturalIncomeSourceTypeVM? NaturalIncomeSourceType { get; set; }

        public int NoOfMale { get; set; }
        public int NoOfFemale { get; set; }
        public int NoOfActiveMonth { get; set; }
        public double AvgNoPersonActivePerMonth { get; set; }
        public double TotalManDaysForCollection { get; set; }
        public string? Unit { get; set; }
        public double TotalProduced { get; set; }
        public double TotalConsumption { get; set; }
        public double QuantitySold { get; set; }
        public double ValueProduceSold { get; set; }
        public double CostOfActivity { get; set; }
        public double ValueSoldPerActivity { get; set; }
        public double ProducedValueSoldActivity { get; set; }
        public double ActivityPerValueSold { get; set; }
        public double TotalNetIncome { get; set; }

        public long SurveyId { get; set; }

        [SwaggerExclude]
        public SurveyVM? Survey { get; set; }
    }
}