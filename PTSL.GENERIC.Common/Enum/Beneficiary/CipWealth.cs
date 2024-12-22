using System.ComponentModel.DataAnnotations;

namespace PTSL.GENERIC.Common.Enum.Beneficiary;

public enum CipWealth
{
    [Display(Name = "Extreme Poor")]
    ExtremePoor = 1,

    [Display(Name = "Poor")]
    Poor = 2,

    [Display(Name = "Middle")]
    Middle = 3,

    [Display(Name = "Rich")]
    Rich = 4,

    [Display(Name = "Ultra Poor")]
    UltraPoor = 5,
}
