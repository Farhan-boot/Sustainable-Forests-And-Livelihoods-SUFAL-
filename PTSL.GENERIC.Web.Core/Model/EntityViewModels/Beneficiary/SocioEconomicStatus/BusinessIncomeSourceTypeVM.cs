namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary
{
    public class BusinessIncomeSourceTypeVM : BaseModel
    {
        public string Name { get; set; }
        public string NameBn { get; set; }

        public List<BusinessVM>? Businesses { get; set; }
    }
}