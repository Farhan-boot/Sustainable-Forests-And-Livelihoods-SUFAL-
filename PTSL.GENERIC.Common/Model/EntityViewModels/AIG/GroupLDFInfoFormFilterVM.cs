using System;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.AIG;

public class GroupLDFInfoFormFilterVM : ForestCivilLocationFilter
{
    public long? EthnicityId { get; set; }
    public long? NgoId { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public int? TotalMember { get; set; }

    public bool HasEthnicityId => EthnicityId.HasValue && EthnicityId.Value > 0;
    public bool HasNgoId => NgoId.HasValue && NgoId.Value > 0;
    public bool HasFromDate => FromDate.HasValue;
    public bool HasToDate => ToDate.HasValue;
    public bool HasTotalMember => TotalMember.HasValue && TotalMember.Value > 0;
}
