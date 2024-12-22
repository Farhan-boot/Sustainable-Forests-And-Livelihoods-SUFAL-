using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary
{
    public class GrossMarginIncomeAndCostStatusVM : BaseModel
    {
        public string? ProductName { get; set; }
        public double LandArea { get; set; }
        public string? MeasurementOfProduct { get; set; }
        public double TotalProductionHousehold { get; set; }
        public double TotalCostOfProduction { get; set; }
        public double TotalConsumption { get; set; }
        public double QuantitySold { get; set; }
        public double TotalValueSold { get; set; }

        public double ValueSoldPerQuantity { get; set; }
        public double ProductionValueSoldPerQuantity { get; set; }
        public double TotalNetIncome { get; set; }

        public long SurveyId { get; set; }

        [SwaggerExclude]
        public SurveyVM? Survey { get; set; }
    }
}