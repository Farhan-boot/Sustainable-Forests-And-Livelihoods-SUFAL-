namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

public class LiveStockTypeVM : BaseModel
{
    public string Name { get; set; }
    public string NameBn { get; set; }

    public List<LiveStockVM>? LiveStocks { get; set; }
}