namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary
{
    public class ExpenditureTypeVM : BaseModel
    {
        public string Name { get; set; }
        public string NameBn { get; set; }

        public List<AnnualHouseholdExpenditureVM>? AnnualHouseholdExpenditures { get; set; }
    }
}