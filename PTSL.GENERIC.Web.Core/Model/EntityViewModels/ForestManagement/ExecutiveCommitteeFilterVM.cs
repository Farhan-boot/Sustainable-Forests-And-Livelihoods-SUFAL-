using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;

public class ExecutiveCommitteeFilterVM : ForestCivilLocationFilter
{
    //Extra Filter
    public Gender? Gender { get; set; }
    public string? PhoneNumber { get; set; }
    public string? NID { get; set; }
    public long? EthnicityId { get; set; }
    public long? NgoId { get; set; }
    public long MeetingTypeId { get; set; }

    //Extra for User role
    public long? UserRoleId { get; set; }

    //Server Site Pagination
    public string? sEcho { get; set; }
    public string? sSearch { get; set; }
    public int? iDisplayLength { get; set; }
    public int? iDisplayStart { get; set; }
    public int? iColumns { get; set; }
    public int? iSortingCols { get; set; }
    public string? sColumns { get; set; }
    public int? iSortCol_0 { get; set; }
    public string? sSortDir_0 { get; set; }
    public string? sSearch_0 { get; set; }
    public string? sSearch_1 { get; set; }
    public string? sSearch_2 { get; set; }
    public string? sSearch_3 { get; set; }
    public string? sSearch_4 { get; set; }
    public string? sSearch_5 { get; set; }
    public string? sSearch_6 { get; set; }
    public string? sSearch_7 { get; set; }
}
