using PTSL.GENERIC.Web.Core.Helper.Enum.AIG;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AccountManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

public class IndividualLDFInfoFormVM : BaseModel
{
    // Forest administration
    public long ForestCircleId { get; set; }
    public ForestCircleVM? ForestCircle { get; set; }
    public long ForestDivisionId { get; set; }
    public ForestDivisionVM? ForestDivision { get; set; }
    public long ForestRangeId { get; set; }
    public ForestRangeVM? ForestRange { get; set; }
    public long ForestBeatId { get; set; }
    public ForestBeatVM? ForestBeat { get; set; }
    public long ForestFcvVcfId { get; set; }
    public ForestFcvVcfVM? ForestFcvVcf { get; set; }

    // Civil administration
    public long DivisionId { get; set; }
    public DivisionVM? Division { get; set; }
    public long DistrictId { get; set; }
    public DistrictVM? District { get; set; }
    public long UpazillaId { get; set; }
    public UpazillaVM? Upazilla { get; set; }
    public long? UnionId { get; set; }
    public UnionVM? Union { get; set; }

    public long? NgoId { get; set; }
    public NgoVM? Ngo { get; set; }

    public long SurveyId { get; set; }
    public SurveyVM? Survey { get; set; }

    public double RequestedLoanAmount { get; set; }
    public double ApprovedLoanAmount { get; set; }
    public DateTime SubmittedDate { get; set; }

    public IndividualLDFInfoStatus IndividualLDFInfoStatus { get; set; }
    public DateTime? StatusDate { get; set; }
    public string? DocumentInfoURL { get; set; }

    public int LDFCount { get; set; }
    public string LDFCountInWord { get; set; } = string.Empty;
}
