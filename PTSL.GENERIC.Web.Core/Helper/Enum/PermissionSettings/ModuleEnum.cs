using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PTSL.GENERIC.Web.Core.Helper.Enum.PermissionSettings
{
    public enum ModuleEnum
    {
        [Display(Name = "Committee Management")]
        CommitteeManagement = 1,
        [Display(Name = "Cip Team")]
        CipTeam = 2
    }
}