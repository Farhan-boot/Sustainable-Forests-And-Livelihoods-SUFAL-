using PTSL.GENERIC.Web.Core.Model.EntityViewModels.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Cutting;

public class CuttingPlantationVM : BaseModel
{
    public long NewRaisedPlantationId { get; set; }
    public NewRaisedPlantationVM? NewRaisedPlantation { get; set; }

    // Marking Information
    public int TotalTreeMarked { get; set; }
    public double MarkingCost { get; set; }
    public string StandingTreeMarkingListUrl { get; set; } = string.Empty;

    public int MarkedTimber { get; set; }
    public long? MarkedTimberUnitId { get; set; }
    public PlantationUnitVM? MarkedTimberUnit { get; set; }

    public int MarkedPole { get; set; }
    public long? MarkedPoleUnitId { get; set; }
    public PlantationUnitVM? MarkedPoleUnit { get; set; }

    public int MarkedFuelWood { get; set; }
    public long? MarkedFuelWoodUnitId { get; set; }
    public PlantationUnitVM? MarkedFuelWoodUnit { get; set; }
    // Marking Information

    // Information of cutting plantation
    public long FinancialYearId { get; set; }
    public FinancialYearVM? FinancialYear { get; set; }
    public int RotationNo { get; set; }
    public string RotationNoDisplay { get; set; } = string.Empty;
    public int TotalNumberOfLots { get; set; }
    //add new field start
    public int? NumberOfSoldLots { get; set; }
    public int? RemainingNumberOfLots { get; set; }
    //add new field end
    public int ProducedTimber { get; set; }
    public long? ProducedTimberUnitId { get; set; }
    public PlantationUnitVM? ProducedTimberUnit { get; set; }

    public int ProducedPole { get; set; }
    public long? ProducedPoleUnitId { get; set; }
    public PlantationUnitVM? ProducedPoleUnit { get; set; }

    public int ProducedFuelWood { get; set; }
    public long? ProducedFuelWoodUnitId { get; set; }
    public PlantationUnitVM? ProducedFuelWoodUnit { get; set; }
    // Information of cutting plantation

    public List<LotWiseSellingInformationVM>? LotWiseSellingInformation { get; set; }
    public List<ShareDistributionVM>? ShareDistributions { get; set; }

    public List<RealizationVM>? Realizations { get; set; }
}
