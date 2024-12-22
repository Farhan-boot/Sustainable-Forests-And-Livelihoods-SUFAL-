using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.Beneficiary
{
    public class Business : BaseEntity
    {
        public long? BusinessIncomeSourceTypeId { get; set; }
        public BusinessIncomeSourceType? BusinessIncomeSourceType { get; set; }
        public string? BusinessIncomeSourceTypeTxt { get; set; }

        public double BusinessGrossValueOfSales { get; set; }
        public double BusinessTotalCashCosts { get; set; }
        public double TotalNetIncome { get; set; }

        public long SurveyId { get; set; }
        public Survey? Survey { get; set; }

        public void Calculate()
        {
            TotalNetIncome = BusinessGrossValueOfSales - BusinessTotalCashCosts;
        }
    }
}