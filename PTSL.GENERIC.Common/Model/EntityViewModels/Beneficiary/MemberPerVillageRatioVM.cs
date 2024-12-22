using System;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;

public class MemberPerVillageVM
{
    public string? ForestCircle { get; set; }
    public string? ForestDivision { get; set; }
    public string? ForestRange { get; set; }
    public string? ForestBeat { get; set; }
    public string? ForestFcvVcf { get; set; }
    public bool? ForestFcvVcfIsFcv { get; set; }

    public long NoOfTotalFcvMember { get; set; }
    public long NoOfTotalVillage { get; set; }
  
    public long MemberPerVillage
    {
        get
        {
            var result = NoOfTotalFcvMember / NoOfTotalVillage;
            return result <= 0 ? 0 : result;
        }
    }
}

public class MemberPerVillageHelper
{
    public long AIGBasicInformationId { get; set; }
    public long SurveyId { get; set; }

    public long ForestCircleId { get; set; }
    public long ForestDivisionId { get; set; }
    public long ForestRangeId { get; set; }
    public long ForestBeatId { get; set; }
    public long ForestFcvVcfId { get; set; }

    public string? ForestCircle { get; set; }
    public string? ForestDivision { get; set; }
    public string? ForestRange { get; set; }
    public string? ForestBeat { get; set; }
    public string? ForestFcvVcf { get; set; }
    public bool? ForestFcvVcfIsFcv { get; set; }
    public long MemberPerVillage { get; set; }

}
