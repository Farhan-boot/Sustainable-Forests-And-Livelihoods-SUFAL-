namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Cutting;

public class LotWiseSellingInformationVM : BaseModel
{
    public long CuttingPlantationId { get; set; }
    public CuttingPlantationVM? CuttingPlantation { get; set; }

    public string LotNumber { get; set; } = string.Empty;
    public DateTime CuttingOrderDate { get; set; }
    public string? TenderNotificationInformation { get; set; } = string.Empty;
    public string ContractorName { get; set; } = string.Empty;
    public string? ContractorMobileNumber { get; set; } = string.Empty;
    public string? ContractorNID { get; set; } = string.Empty;
    public string? ContractorAddress { get; set; }

    public int LotWiseTimber { get; set; }
    public long? LotWiseTimberUnitId { get; set; }
    public PlantationUnitVM? LotWiseTimberUnit { get; set; }

    public int LotWisePole { get; set; }
    public long? LotWisePoleUnitId { get; set; }
    public PlantationUnitVM? LotWisePoleUnit { get; set; }

    public int LotWiseFuelWood { get; set; }
    public long? LotWiseFuelWoodUnitId { get; set; }
    public PlantationUnitVM? LotWiseFuelWoodUnit { get; set; }

    public double SaleValueOfLot { get; set; }
    public double SaleValueOfVatPercentage { get; set; }
    public double SaleValueOfTaxPercentage { get; set; }
    public double TotalSaleValue { get; set; }
    public double TotalVatAndTax { get; set; }
    public double TotalVat { get; set; }
    public double TotalTax { get; set; }
}
