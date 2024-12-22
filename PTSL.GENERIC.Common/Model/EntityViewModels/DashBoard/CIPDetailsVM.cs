using System;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.DashBoard;

public class CIPDetailsVM
{
    public int TotalCip { get; set; }
    public int TotalMale { get; set; }
    public int TotalFemale { get; set; }
    public int TotalOthersGender { get; set; }

    private double _malePercentage => Math.Round(((double)TotalMale / TotalCip) * 100);
    private double _femalePercentage => Math.Round(((double)TotalFemale / TotalCip) * 100);
    private double _otherPercentage => Math.Round(((double)TotalOthersGender / TotalCip) * 100);

    public double MalePercentage => double.IsInfinity(_malePercentage) ? 0 : _malePercentage;
    public double FemalePercentage => double.IsInfinity(_femalePercentage) ? 0 : _femalePercentage;
    public double OthersGenderPercentage => double.IsInfinity(_otherPercentage) ? 0 : _otherPercentage;
}
