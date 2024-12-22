using PTSL.GENERIC.Common.Entity.CommonEntity;
using System;

namespace PTSL.GENERIC.Common.Entity.Beneficiary
{
    public class NaturalResourcesIncomeAndCostStatus : BaseEntity
    {
        public long? NaturalIncomeSourceTypeId { get; set; }
        public NaturalIncomeSourceType? NaturalIncomeSourceType { get; set; }

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
        public Survey? Survey { get; set; }

        public void Calculate()
        {
            TotalManDaysForCollection = (NoOfMale + NoOfFemale) * NoOfActiveMonth * AvgNoPersonActivePerMonth;
            ValueSoldPerActivity = ValueProduceSold / QuantitySold;
            ProducedValueSoldActivity = TotalProduced * ValueSoldPerActivity;
            ActivityPerValueSold = ProducedValueSoldActivity - CostOfActivity;
            TotalNetIncome = Math.Round(ActivityPerValueSold / TotalManDaysForCollection, 2);
        }
    }
}