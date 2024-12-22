using PTSL.GENERIC.Common.Entity.CommonEntity;
using System;

namespace PTSL.GENERIC.Common.Entity.Beneficiary
{
    public class GrossMarginIncomeAndCostStatus : BaseEntity
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
        public Survey? Survey { get; set; }

        public void Calculate()
        {
            ValueSoldPerQuantity = Math.Round(TotalValueSold / QuantitySold, 2);
            ProductionValueSoldPerQuantity = TotalProductionHousehold * ValueSoldPerQuantity;
            TotalNetIncome = Math.Round(ProductionValueSoldPerQuantity - TotalCostOfProduction, 2);
        }
    }
}