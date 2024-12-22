namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary
{
    public class ForestBeatVM : BaseModel
    {
        public string Name { get; set; }
        public string NameBn { get; set; }

        public long ForestRangeId { get; set; }
        public ForestRangeVM? ForestRange { get; set; }

        public List<ForestFcvVcfVM>? ForestFcvVcfs { get; set; }
        public List<SurveyVM>? Surveys { get; set; }
    }
}