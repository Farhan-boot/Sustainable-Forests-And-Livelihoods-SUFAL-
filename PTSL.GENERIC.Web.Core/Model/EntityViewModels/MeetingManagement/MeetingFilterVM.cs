namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.MeetingManagement;

public class MeetingFilterVM : ForestCivilLocationFilter
{
    public long? NgoId { get; set; }
    public DateTime? MeetingDate { get; set; }
    public long? MeetingTypeId { get; set; }

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

