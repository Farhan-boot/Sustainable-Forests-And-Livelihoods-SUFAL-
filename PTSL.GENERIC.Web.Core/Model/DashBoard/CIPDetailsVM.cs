namespace PTSL.GENERIC.Web.Core.Model.DashBoard;

public class CIPDetailsVM
{
    public int TotalCip { get; set; }
    public int TotalMale { get; set; }
    public int TotalFemale { get; set; }
    public int TotalOthersGender { get; set; }

    public double MalePercentage { get; set; }
    public double FemalePercentage { get; set; }
    public double OthersGenderPercentage { get; set; }
}
