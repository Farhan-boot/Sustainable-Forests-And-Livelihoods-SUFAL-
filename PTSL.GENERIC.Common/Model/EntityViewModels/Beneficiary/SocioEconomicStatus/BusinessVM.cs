using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary
{
    public class BusinessVM : BaseModel
    {
        public long? BusinessIncomeSourceTypeId { get; set; }

        [SwaggerExclude]
        public BusinessIncomeSourceTypeVM? BusinessIncomeSourceType { get; set; }
        public string? BusinessIncomeSourceTypeTxt { get; set; }

        public double BusinessGrossValueOfSales { get; set; }
        public double BusinessTotalCashCosts { get; set; }
        public double TotalNetIncome { get; set; }

        public long SurveyId { get; set; }

        [SwaggerExclude]
        public SurveyVM? Survey { get; set; }
    }
}