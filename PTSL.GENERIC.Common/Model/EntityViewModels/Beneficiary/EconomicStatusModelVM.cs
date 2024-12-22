using PTSL.GENERIC.Common.Entity.Beneficiary;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary
{
	public class EconomicStatusModelVM
	{
		public List<LandOccupancyVM>? LandOccupancies { get; set; }
		public List<LiveStockVM>? LiveStocks { get; set; }
		public List<AssetVM>? Assets { get; set; }
		public List<ImmovableAssetVM>? ImmovableAssets { get; set; }
		public List<EnergyUseVM>? EnergyUses { get; set; }
	}

	public class EconomicStatusModel
	{
		public List<LandOccupancy>? LandOccupancies { get; set; }
		public List<LiveStock>? LiveStocks { get; set; }
		public List<Asset>? Assets { get; set; }
		public List<ImmovableAsset>? ImmovableAssets { get; set; }
		public List<EnergyUse>? EnergyUses { get; set; }
	}
}
