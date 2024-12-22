using PTSL.GENERIC.Common.Entity.CommonEntity;
using System;

namespace PTSL.GENERIC.Common.Entity.Beneficiary
{
    public class ManualPhysicalWork : BaseEntity
    {
        public long? ManualIncomeSourceTypeId { get; set; }
        public ManualIncomeSourceType? ManualIncomeSourceType { get; set; }
        public string? ManualIncomeSourceTypeTxt { get; set; }

        public int NoOfMale { get; set; }
        public int NoOfFemale { get; set; }
        public int NoOfActiveMonth { get; set; }
        public int AvgNoPersonActivePerMonth { get; set; }
        public double AvgDailyIncome { get; set; }
        public double TotalPerson { get; set; }
        public double TotalAnnualIncome { get; set; }

        public long SurveyId { get; set; }
        public Survey? Survey { get; set; }

        public void Calculate()
        {
            TotalPerson = (NoOfMale + NoOfFemale) * NoOfActiveMonth * AvgNoPersonActivePerMonth;
            TotalAnnualIncome = Math.Round(AvgDailyIncome * TotalPerson, 2);
        }
    }
}