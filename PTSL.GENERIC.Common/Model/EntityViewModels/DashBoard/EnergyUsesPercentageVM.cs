namespace PTSL.GENERIC.Common.Model.EntityViewModels.DashBoard
{
    public class EnergyUsesPercentageVM
    {
        public long EnergyTypeId { get; set; }
        public string? EnergyTypeName { get; set; }
        public double Percentage { get; set; }
    }
}