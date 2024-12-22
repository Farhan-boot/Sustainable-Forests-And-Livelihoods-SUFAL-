using PTSL.GENERIC.Common.Enum.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels;

namespace PTSL.GENERIC.Common.Entity.Beneficiary;

public class SurveyIncidentFilterVM : ForestCivilLocationFilter
{
    public long? SurveyId { get; set; }
    public string? Year { get; set; }
    public Months? MonthNo { get; set; }
    public SurveyIncidentStatus? SurveyIncidentStatus { get; set; }

    public bool HasSurveyId => SurveyId is not null && SurveyId != default;
    public bool HasYearId => string.IsNullOrWhiteSpace(Year) == false;
    public bool HasMonthNo => MonthNo is not null;
    public bool HasSurveyIncidentStatus => SurveyIncidentStatus is not null;

    public Gender? Gender { get; set; }
    public string? PhoneNumber { get; set; }
    public string? NID { get; set; }
    public long? NgoId { get; set; }

    public bool HasGender => Gender.HasValue;
    public bool HasPhoneNumber => string.IsNullOrEmpty(PhoneNumber) == false;
    public bool HasNID => string.IsNullOrEmpty(NID) == false;
    public bool HasNgoId => NgoId.HasValue && NgoId.Value > 0;
}

