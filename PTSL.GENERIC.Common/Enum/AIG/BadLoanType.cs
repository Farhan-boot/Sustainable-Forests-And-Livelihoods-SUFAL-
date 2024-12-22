﻿using System.ComponentModel.DataAnnotations;

namespace PTSL.GENERIC.Common.Enum.AIG;

public enum BadLoanType
{
    [Display(Name = "Regular")]
    Regular,

    [Display(Name = "Watchful")]
    UnderObservation,

    [Display(Name = "Substandard")]
    InferiorLoan,

    [Display(Name = "Doubtful")]
    SuspiciousLoan,

    [Display(Name = "Bad Debt")]
    EvilLoan
}

