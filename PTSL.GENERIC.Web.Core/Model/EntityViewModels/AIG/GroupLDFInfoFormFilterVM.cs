namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

public class GroupLDFInfoFormFilterVM : ForestCivilLocationFilter
{
    public long? EthnicityId { get; set; }
    public long? NgoId { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public int? TotalMember { get; set; }
}
