﻿using System;

using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum.Beneficiary;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.AIG;

public class LDFProgressVM : BaseModel
{
    public long AIGBasicInformationId { get; set; }
    public AIGBasicInformationVM? AIGBasicInformation { get; set; }

    public long RepaymentLDFId { get; set; }
    public RepaymentLDFVM? RepaymentLDF { get; set; }

    public DateTime RepaymentStartDate { get; set; }
    public DateTime RepaymentEndDate { get; set; }
    public int RepaymentSerial { get; set; }

    public double ProgressAmount { get; set; }
    public double GrowthPercentage { get; set; }
    public ProgressGrowthStatus GrowthStatus { get; set; }

    public string? ProgressResource { get; set; }
}
