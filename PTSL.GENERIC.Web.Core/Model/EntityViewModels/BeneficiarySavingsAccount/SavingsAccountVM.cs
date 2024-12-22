namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.BeneficiarySavingsAccount;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

public class SavingsAccountVM : BaseModel
{
    // Forest administration
    public long? ForestCircleId { get; set; }
    public ForestCircleVM? ForestCircle { get; set; }
    public long? ForestDivisionId { get; set; }
    public ForestDivisionVM? ForestDivision { get; set; }
    public long? ForestRangeId { get; set; }
    public ForestRangeVM? ForestRange { get; set; }
    public long? ForestBeatId { get; set; }
    public ForestBeatVM? ForestBeat { get; set; }
    public long? FcvId { get; set; }

    // Civil administration
    public long? DivisionId { get; set; }
    public DivisionVM? Division { get; set; }
    public long? DistrictId { get; set; }
    public DistrictVM? District { get; set; }
    public long? UpazillaId { get; set; }
    public UpazillaVM? Upazilla { get; set; }
    public long? UnionId { get; set; }
    public UnionVM? Union { get; set; }
    public long? NgoId { get; set; }
    public NgoVM? Ngos { get; set; }

    //Others
    public long? SurveyId { get; set; }
    public SurveyVM? Survey { get; set; }
    public long? StatusId { get; set; }

    public long? AccountTypeId { get; set; }
    public decimal? AmountLimit { get; set; }



    //New
    public List<SavingsAmountInformationVM>? SavingsAmountInformations { get; set; }
    public List<WithdrawAmountInformationVM>? WithdrawAmountInformations { get; set; }


    public long? ForestFcvVcfId { get; set; }




    //DataTable Get List using server site Pagination
    public Double? TotalSavingsAmount { get; set; }
    public Double? TotalWithdrawalAmount { get; set; }
    public Double? TotalAccountBalance { get; set; }

}