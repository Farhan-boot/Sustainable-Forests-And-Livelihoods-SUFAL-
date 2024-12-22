using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary
{
    public class ForestCircleVM : BaseModel
    {
        public List<SocialForestryTraining.SocialForestryTrainingVM>? SocialForestryTrainings { get; set; }
        public string? Name { get; set; }
        public string? NameBn { get; set; }

        [SwaggerExclude]
        public List<ForestDivisionVM>? ForestDivisions { get; set; }

        [SwaggerExclude]
        public List<SurveyVM>? Surveys { get; set; }
    }
}