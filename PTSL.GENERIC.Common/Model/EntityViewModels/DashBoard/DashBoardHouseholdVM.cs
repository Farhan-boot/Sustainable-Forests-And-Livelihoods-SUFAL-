using PTSL.GENERIC.Common.Enum.Beneficiary;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.DashBoard
{
    public class DashboardHouseholdVM
    {
        public int TotalHouseholdMember { get; set; }

        public List<HouseConditionPercentage> HouseConditionPercentages { get; set;} = new List<HouseConditionPercentage>();
    }

    public class HouseConditionPercentage
    {
        public HouseType HouseType { get; set; }
        public string HouseTypeName { get; set; } = string.Empty;
        public double Percentage { get; set; }
    }


    public class DashboardSavingsAmountVM
    {
        public double? TotalSavingsAmount { get; set; }
    }
}