using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

public class SurveyIncidentFilterVM : ForestCivilLocationFilter
{
    public long? SurveyId { get; set; }
    public string? Year { get; set; }
    public Months? MonthNo { get; set; }
    public SurveyIncidentStatus? SurveyIncidentStatus { get; set; }

    public Gender? Gender { get; set; }
    public string? PhoneNumber { get; set; }
    public string? NID { get; set; }
    public long? NgoId { get; set; }

    public bool HasGender => Gender.HasValue;
    public bool HasPhoneNumber => string.IsNullOrEmpty(PhoneNumber) == false;
    public bool HasNID => string.IsNullOrEmpty(NID) == false;
    public bool HasNgoId => NgoId.HasValue && NgoId.Value > 0;
}

