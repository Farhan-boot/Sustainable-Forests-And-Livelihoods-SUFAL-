using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary
{
    public class UpazilaVM : BaseModel
    {
        public string Name { get; set; }
        public string NameBn { get; set; }

        public List<DistrictVM>? Districts { get; set; }
        public long DistrictsId { get; set; }
    }
}