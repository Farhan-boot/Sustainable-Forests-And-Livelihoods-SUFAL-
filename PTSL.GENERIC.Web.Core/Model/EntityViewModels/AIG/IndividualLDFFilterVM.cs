using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.AIG;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

public class IndividualLDFFilterVM : ForestCivilLocationFilter
{
    public IndividualLDFInfoStatus? IndividualLDFInfoStatus { get; set; }
    public Gender? Gender { get; set; }
    public string? PhoneNumber { get; set; }
    public string? NID { get; set; }
    public long? EthnicityId { get; set; }
    public long? NgoId { get; set; }

    public bool HasIndividualLDFInfoStatus => IndividualLDFInfoStatus.HasValue;
    public bool HasGender => Gender.HasValue;
    public bool HasPhoneNumber => string.IsNullOrEmpty(PhoneNumber) == false;
    public bool HasNID => string.IsNullOrEmpty(NID) == false;
    public bool HasEthnicityId => EthnicityId.HasValue && EthnicityId.Value > 0;
    public bool HasNgoId => NgoId.HasValue && NgoId.Value > 0;

    //Pagination
    public string sEcho { get; set; }
    public string sSearch { get; set; }
    public int? iDisplayLength { get; set; }
    public int? iDisplayStart { get; set; }
    public int iColumns { get; set; }
    public int iSortCol_0 { get; set; }
    public string sSortDir_0 { get; set; }
    public int iSortingCols { get; set; }
    public string sColumns { get; set; }
}
