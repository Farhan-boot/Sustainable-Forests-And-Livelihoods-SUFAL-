using PTSL.GENERIC.Web.Core.Helper.Enum.AccountManagement;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AccountManagement;

public class AccountFilterVM : ForestCivilLocationFilter
{
    public long? CommitteeTypeId { get; set; }
    public long? CommitteeId { get; set; }
    public string? BankAccountName { get; set; }
    public string? AccountNumber { get; set; }
    public AccountTypeForAccount? AccountType { get; set; }

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
