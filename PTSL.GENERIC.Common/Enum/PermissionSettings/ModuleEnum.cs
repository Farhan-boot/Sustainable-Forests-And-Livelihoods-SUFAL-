using System.ComponentModel.DataAnnotations;

namespace PTSL.GENERIC.Common.Enum.PermissionSettings;

public enum ModuleEnum
{
    [Display(Name = "Committee Management")]
    CommitteeManagement = 1,
    [Display(Name = "Cip Team")]
    CipTeam = 2
}