﻿using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary
{
    public class ForestDivisionVM : BaseModel
    {
        public List<SocialForestryTraining.SocialForestryTrainingVM>? SocialForestryTrainings { get; set; }
        public string? Name { get; set; }
        public string? NameBn { get; set; }

        public long ForestCircleId { get; set; }

        [SwaggerExclude]
        public ForestCircleVM? ForestCircle { get; set; }

        [SwaggerExclude]
        public List<ForestRangeVM>? ForestRanges { get; set; }

        [SwaggerExclude]
        public List<SurveyVM>? Surveys { get; set; }

        [SwaggerExclude]
        public NgoVM? Ngo { get; set; }
    }
}