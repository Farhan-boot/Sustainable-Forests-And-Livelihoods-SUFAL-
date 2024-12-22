namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary
{
    public class ForestRangeVM : BaseModel
    {
        public string Name { get; set; }
        public string NameBn { get; set; }

        public long ForestDivisionId { get; set; }
        public ForestDivisionVM? ForestDivision { get; set; }
        public List<ForestBeatVM>? ForestBeats { get; set; }
        public List<SurveyVM>? Surveys { get; set; }
    }
}