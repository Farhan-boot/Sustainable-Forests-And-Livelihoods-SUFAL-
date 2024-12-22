using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup
{
    public class DistrictVM : BaseModel
    {
        public List<SocialForestryTraining.SocialForestryTrainingVM>? SocialForestryTrainings { get; set; }
        //public string Name { get; set; }
        //public string NameBn { get; set; }
        //public long DivisionId { get; set; }
        //[SwaggerExclude]
        //public DivisionVM DivisionDTO { get; set; }
        public string? Name { get; set; }
        public string? NameBn { get; set; }

        public long DivisionId { get; set; }
        [SwaggerExclude]
        public Division? Division { get; set; }
    }
}
