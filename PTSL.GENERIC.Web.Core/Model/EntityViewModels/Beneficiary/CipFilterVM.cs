using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

public class CipFilterVM : ForestCivilLocationFilter
{
    public Gender? Gender { get; set; }
    public CipWealth? CipWealth { get; set; }
    public string? NID { get; set; }
    public long? EthnicityId { get; set; }

    public bool HasGender => Gender.HasValue;
    public bool HasCipWealth => CipWealth.HasValue;
    public bool HasNID => string.IsNullOrEmpty(NID) == false;
    public bool HasEthnicityId => EthnicityId.HasValue && EthnicityId.Value > 0;

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
