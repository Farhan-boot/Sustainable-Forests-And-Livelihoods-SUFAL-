using System;

using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;

public class RealizationVM : BaseModel
{
    public long CuttingPlantationId { get; set; }
    public CuttingPlantationVM? CuttingPlantation { get; set; }

    public long LotWiseSellingInformationId { get; set; }
    public LotWiseSellingInformationVM? LotWiseSellingInformation { get; set; }

    public double SaleValueOfLot { get; set; }
    public double SaleValueOfVatPercentage { get; set; }
    public double SaleValueOfTaxPercentage { get; set; }
    public double TotalSaleValue { get; set; }

    public DateTime RealizedDate { get; set; }
}
