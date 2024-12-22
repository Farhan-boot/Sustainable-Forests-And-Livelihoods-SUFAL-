using System;

using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;

public class LotWiseSellingInformation : BaseEntity
{
    public long CuttingPlantationId { get; set; }
    public CuttingPlantation? CuttingPlantation { get; set; }

    public string LotNumber { get; set; } = string.Empty;
    public DateTime CuttingOrderDate { get; set; }
    public string? TenderNotificationInformation { get; set; }
    public string ContractorName { get; set; } = string.Empty;
    public string? ContractorMobileNumber { get; set; } = string.Empty;
    public string? ContractorNID { get; set; } = string.Empty;
    public string? ContractorAddress { get; set; }

    public int LotWiseTimber { get; set; }
    public long? LotWiseTimberUnitId { get; set; }
    public PlantationUnit? LotWiseTimberUnit { get; set; }

    public int LotWisePole { get; set; }
    public long? LotWisePoleUnitId { get; set; }
    public PlantationUnit? LotWisePoleUnit { get; set; }

    public int LotWiseFuelWood { get; set; }
    public long? LotWiseFuelWoodUnitId { get; set; }
    public PlantationUnit? LotWiseFuelWoodUnit { get; set; }

    public double SaleValueOfLot { get; set; }
    public double SaleValueOfVatPercentage { get; set; }
    public double SaleValueOfTaxPercentage { get; set; }
    public double TotalSaleValue => SaleValueOfLot + (SaleValueOfLot * (SaleValueOfVatPercentage / 100)) + (SaleValueOfLot * (SaleValueOfTaxPercentage / 100));
    public double TotalVatAndTax => (SaleValueOfLot * (SaleValueOfVatPercentage / 100)) + (SaleValueOfLot * (SaleValueOfTaxPercentage / 100));
    public double TotalVat => (SaleValueOfLot * (SaleValueOfVatPercentage / 100));
    public double TotalTax => (SaleValueOfLot * (SaleValueOfTaxPercentage / 100));

    public List<Realization>? Realizations { get; set; }
}
