namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary
{
    public class EnergyTypeVM : BaseModel
    {
        public string Name { get; set; }
        public string NameBn { get; set; }

        public List<EnergyUseVM>? EnergyUses { get; set; }
    }
}