using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.Beneficiary
{
    public class OtherIncomeSource : BaseEntity
    {
        public long? OtherIncomeSourceTypeId { get; set; }
        public OtherIncomeSourceType? OtherIncomeSourceType { get; set; }
        public string? OtherIncomeSourceTypeTxt { get; set; }

        public double GrossValueOfSales { get; set; }
        public double TotalCashCosts { get; set; }

        public double TotalNetIncome { get; set; }

        public long SurveyId { get; set; }
        public Survey? Survey { get; set; }

        public void Calculate()
        {
            TotalNetIncome = GrossValueOfSales - TotalCashCosts;
        }
    }
}