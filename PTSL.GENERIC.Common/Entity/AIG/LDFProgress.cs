using System;

using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Enum.Beneficiary;

namespace PTSL.GENERIC.Common.Entity.AIG;

public class LDFProgress : BaseEntity
{
    public long AIGBasicInformationId { get; set; }
    public AIGBasicInformation? AIGBasicInformation { get; set; }

    public long RepaymentLDFId { get; set; }
    public RepaymentLDF? RepaymentLDF { get; set; }

    public DateTime RepaymentStartDate { get; set; }
    public DateTime RepaymentEndDate { get; set; }
    public int RepaymentSerial { get; set; }

    public double ProgressAmount { get; set; }
    public double GrowthPercentage { get; set; }
    public ProgressGrowthStatus GrowthStatus
    {
        get
        {
            return GrowthPercentage switch
            {
                0 => ProgressGrowthStatus.NoGrowth,
                > 0 => ProgressGrowthStatus.Increased,
                < 0 => ProgressGrowthStatus.Decreased,
                _ => ProgressGrowthStatus.NoGrowth,
            };
        }
    }

    public string? ProgressResource { get; set; }
}

