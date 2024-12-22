using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Common;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

public class BeneficiaryFilterVM
{
    public Gender? Gender { get; set; }
    public string? PhoneNumber { get; set; }
    public string? NID { get; set; }
    public long? EthnicityId { get; set; }
    public long? NgoId { get; set; }
    public bool GetPendingAlso { get; set; }
    public string? BeneficiaryName { get; set; }
    public string? FcvVcfName { get; set; }

    public ForestCivilLocationVM? ForestCivilLocation { get; set; } = new ForestCivilLocationVM();

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