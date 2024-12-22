using PTSL.GENERIC.Common.Enum;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;

public class ExecutiveCommitteeFilterVM : ForestCivilLocationFilter
{
    public Gender? Gender { get; set; }
    public string? PhoneNumber { get; set; }
    public string? NID { get; set; }
    public long? EthnicityId { get; set; }
    public long? NgoId { get; set; }
    public long MeetingTypeId { get; set; }
    public long? GenderId { get; set; }
    public bool HasGender => GenderId.HasValue;

    //Extra User ROle
    public long? UserRoleId { get; set; }
}

