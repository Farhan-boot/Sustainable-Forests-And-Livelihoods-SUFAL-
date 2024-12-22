using System;

using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;

public class Realization : BaseEntity
{
    public long CuttingPlantationId { get; set; }
    public CuttingPlantation? CuttingPlantation { get; set; }

    public long LotWiseSellingInformationId { get; set; }
    public LotWiseSellingInformation? LotWiseSellingInformation { get; set; }

    public double SaleValueOfLot { get; set; }
    public double SaleValueOfVatPercentage { get; set; }
    public double SaleValueOfTaxPercentage { get; set; }
    public double TotalSaleValue { get; set; }

    public DateTime RealizedDate { get; set; }
}
