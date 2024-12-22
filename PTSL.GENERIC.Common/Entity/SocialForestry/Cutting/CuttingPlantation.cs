using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;

namespace PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;

public class CuttingPlantation : BaseEntity
{
    public long NewRaisedPlantationId { get; set; }
    public NewRaisedPlantation? NewRaisedPlantation { get; set; }

    // Marking Information
    public int TotalTreeMarked { get; set; }
    public double MarkingCost { get; set; }
    public string StandingTreeMarkingListUrl { get; set; } = string.Empty;

    public int MarkedTimber { get; set; }
    public long? MarkedTimberUnitId { get; set; }
    public PlantationUnit? MarkedTimberUnit { get; set; }

    public int MarkedPole { get; set; }
    public long? MarkedPoleUnitId { get; set; }
    public PlantationUnit? MarkedPoleUnit { get; set; }

    public int MarkedFuelWood { get; set; }
    public long? MarkedFuelWoodUnitId { get; set; }
    public PlantationUnit? MarkedFuelWoodUnit { get; set; }
    // Marking Information

    // Information of cutting plantation
    public long FinancialYearId { get; set; }
    public FinancialYear? FinancialYear { get; set; }
    public int RotationNo { get; set; }
    public int TotalNumberOfLots { get; set; }
    //add new field start
    public int? NumberOfSoldLots { get; set; }
    public int? RemainingNumberOfLots { get; set; }
    //add new field end

    public int ProducedTimber { get; set; }
    public long? ProducedTimberUnitId { get; set; }
    public PlantationUnit? ProducedTimberUnit { get; set; }

    public int ProducedPole { get; set; }
    public long? ProducedPoleUnitId { get; set; }
    public PlantationUnit? ProducedPoleUnit { get; set; }

    public int ProducedFuelWood { get; set; }
    public long? ProducedFuelWoodUnitId { get; set; }
    public PlantationUnit? ProducedFuelWoodUnit { get; set; }
    // Information of cutting plantation

    public List<LotWiseSellingInformation>? LotWiseSellingInformation { get; set; }
    public List<Realization>? Realizations { get; set; }
    public List<ShareDistribution>? ShareDistributions { get; set; }
}
