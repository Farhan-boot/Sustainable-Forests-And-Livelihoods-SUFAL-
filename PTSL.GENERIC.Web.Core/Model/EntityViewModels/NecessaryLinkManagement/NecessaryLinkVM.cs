using PTSL.GENERIC.Web.Core.Helper.Enum.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.NecessaryLinkManagement
{
    public class NecessaryLinkVM : BaseModel
    {
        public string? LinkTitleEn { get; set; }
        public string? LinkTitleBn { get; set; }
        public string? SiteLink { get; set; }
    }
}