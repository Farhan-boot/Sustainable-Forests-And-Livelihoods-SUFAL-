using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup
{
    public class UnionVM : BaseModel
    {
        public List<SocialForestryTraining.SocialForestryTrainingVM>? SocialForestryTrainings { get; set; }
        public string? Name { get; set; }
        public string? NameBn { get; set; }

        public long UpazillaId { get; set; }
        [SwaggerExclude]
        public UpazillaVM? Upazilla { get; set; }
    }
}
