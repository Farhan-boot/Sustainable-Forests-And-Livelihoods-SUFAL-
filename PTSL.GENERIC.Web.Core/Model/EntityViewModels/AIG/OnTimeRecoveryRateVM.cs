using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

public class OnTimeRecoveryRateVM
{
    public string? ForestCircle { get; set; }
    public string? ForestDivision { get; set; }
    public string? ForestRange { get; set; }
    public string? ForestBeat { get; set; }
    public string? ForestFcvVcf { get; set; }
    public bool? ForestFcvVcfIsFcv { get; set; }

    public double SumOfRegularRecoveryDuringThePeriodTk { get; set; }
    public double SumOfRegularRecoverableDuringThePeriodTk { get; set; }
    public double OnTimeRecoveryRate { get; set; }
}

