namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.BeneficiarySavingsAccount;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

public class WithdrawAmountInformationVM : BaseModel
{
    // WithdrawAmountInformation
    public long? SavingsAccountId { get; set; }
    public SavingsAccountVM? SavingsAccounts { get; set; }
    public DateTime? WithdrawDate { get; set; }
    public Double? WithdrawAmount { get; set; }
    public string? Remark { get; set; }
    //New Added 
    public long? DfoStatusId { get; set; }
    public string? DfoRemark { get; set; }
    public string? DocumentFileUrl { get; set; }
}