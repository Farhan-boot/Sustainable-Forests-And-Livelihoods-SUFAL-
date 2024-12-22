using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

public class CumulativeRecoveryRateVM
{
    public string? ForestCircle { get; set; }
    public string? ForestDivision { get; set; }
    public string? ForestRange { get; set; }
    public string? ForestBeat { get; set; }
    public string? ForestFcvVcf { get; set; }
    public bool? ForestFcvVcfIsFcv { get; set; }

    public double DateWiseRecoveredTk { get; set; }
    public double AdvancedRecoveryTk { get; set; }
    public double ExpectedRecoveryTk { get; set; }
    public double CumulativeRecoveryRate { get; set; }
}

