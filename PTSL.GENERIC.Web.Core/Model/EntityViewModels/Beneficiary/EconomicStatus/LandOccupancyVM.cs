using PTSL.GENERIC.Web.Core.Helper.Enum.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary
{
    public class LandOccupancyVM : BaseModel
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

        public DateTime SubmissionTime { get; set; } = DateTime.Now;
        public string? Notes { get; set; }

        public long SurveyId { get; set; }
        public SurveyVM? Survey { get; set; }
    }
}
