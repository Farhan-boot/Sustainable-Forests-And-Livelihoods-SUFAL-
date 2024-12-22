namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.BeneficiarySavingsAccount;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

public class SavingsAmountInformationVM : BaseModel
{
    // SavingsAmountInformation
    public long? SavingsAccountId { get; set; }
    public SavingsAccountVM SavingsAccounts { get; set; }
    public DateTime? SavingsDate { get; set; }
    public Double? SavingsAmount { get; set; }
    public string? Remark { get; set; }
    public string? DocumentFileUrl { get; set; }
}