using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Enum.Beneficiary;
using System;

namespace PTSL.GENERIC.Common.Entity.Beneficiary
{
    public class LandOccupancy : BaseEntity
    {
        public LandClassification LandClassificationEnum { get; set; }
        public string? LandClassificationTxt { get; set; }
        public double Homesteads { get; set; }
        public double ProductiveLand { get; set; }
        public double FallowLand { get; set; }
        public double ProductiveWetland { get; set; }
        public double FallowWetland { get; set; }
        public double OthersLand { get; set; }
        public double TotalLand { get; set; }

        public DateTime SubmissionTime { get; set; }
        public string? Notes { get; set; }

        public long SurveyId { get; set; }
        public Survey? Survey { get; set; }

        public void Calculate()
        {
            var total = this.Homesteads + ProductiveLand + FallowLand + ProductiveWetland + FallowWetland + OthersLand;
            this.TotalLand = Math.Round(total, 2);
        }
    }
}