namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

public class ManualIncomeSourceTypeVM : BaseModel
{
    public string Name { get; set; }
    public string NameBn { get; set; }

    public List<ManualPhysicalWorkVM>? ManualPhysicalWorks { get; set; }
}