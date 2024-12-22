namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary
{
    public class ForestFcvVcfVM : BaseModel
    {
        public string? Name { get; set; }
        public string? NameBn { get; set; }

        public long ForestBeatId { get; set; }
        public ForestBeatVM? ForestBeat { get; set; }
        public DateTime? FormedTime { get; set; }

        public List<SurveyVM>? Surveys { get; set; }
        public bool IsFcv { get; set; }
    }
}