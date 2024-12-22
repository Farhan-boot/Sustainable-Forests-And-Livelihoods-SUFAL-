namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary
{
    public class BusinessVM : BaseModel
    {
        public long? BusinessIncomeSourceTypeId { get; set; }
        public BusinessIncomeSourceTypeVM? BusinessIncomeSourceType { get; set; }
        public string? BusinessIncomeSourceTypeTxt { get; set; }

        public double BusinessGrossValueOfSales { get; set; }
        public double BusinessTotalCashCosts { get; set; }
        public double TotalNetIncome { get; set; }

        public long SurveyId { get; set; }
        public SurveyVM? Survey { get; set; }
    }
}
