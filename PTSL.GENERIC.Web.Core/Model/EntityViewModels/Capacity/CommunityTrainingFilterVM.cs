namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;

public class CommunityTrainingFilterVM : ForestCivilLocationFilter
{
    public long? CommunityTrainingTypeId { get; set; }
    public long? TrainingOrganizerId { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public long? NgoId { get; set; }
    public long? EventTypeId { get; set; }

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
