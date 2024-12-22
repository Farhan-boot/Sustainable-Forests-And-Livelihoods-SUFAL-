using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

using System;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary
{
    public class ForestFcvVcfVM : BaseModel
    {
        public string? Name { get; set; }
        public string? NameBn { get; set; }

        public long ForestBeatId { get; set; }

        [SwaggerExclude]
        public ForestBeatVM? ForestBeat { get; set; }
        public DateTime? FormedTime { get; set; }

        [SwaggerExclude]
        public List<SurveyVM>? Surveys { get; set; }
        public bool IsFcv { get; set; }
    }
}