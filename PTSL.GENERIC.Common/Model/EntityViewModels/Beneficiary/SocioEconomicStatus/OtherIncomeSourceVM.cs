using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary
{
    public class OtherIncomeSourceVM : BaseModel
    {
        public long? OtherIncomeSourceTypeId { get; set; }

        [SwaggerExclude]
        public OtherIncomeSourceTypeVM? OtherIncomeSourceType { get; set; }
        public string? OtherIncomeSourceTypeTxt { get; set; }

        public double GrossValueOfSales { get; set; }
        public double TotalCashCosts { get; set; }
        public double TotalNetIncome { get; set; }

        public long SurveyId { get; set; }

        [SwaggerExclude]
        public SurveyVM? Survey { get; set; }
    }
}