﻿using System.ComponentModel.DataAnnotations;

namespace PTSL.GENERIC.Common.Enum.Beneficiary;

public enum ProgressGrowthStatus
{
    [Display(Name = "Decreased")] Decreased = 1,
    [Display(Name = "No Growth")] NoGrowth = 2,
    [Display(Name = "Increased")] Increased = 3,
}

