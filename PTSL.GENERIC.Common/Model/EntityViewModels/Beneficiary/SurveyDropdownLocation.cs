using System.Collections.Generic;
using System.Linq;

using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;

public class SurveyDropdownLocation
{
    public IEnumerable<ForestCircleDropdown> ForestLocations { get; set; } = Enumerable.Empty<ForestCircleDropdown>();
    public IEnumerable<DivisionDropdown> CivilLocations { get; set; } = Enumerable.Empty<DivisionDropdown>();
}

// Forest
public class ForestCircleDropdown : DropdownLongVM
{
    public IEnumerable<ForestDivisionDropdown> ForestDivisions { get; set; } = Enumerable.Empty<ForestDivisionDropdown>();
}
public class ForestDivisionDropdown : DropdownLongVM
{
    public long ForestCircleId { get; set; }
    public IEnumerable<ForestRangeDropdown> ForestRanges { get; set; } = Enumerable.Empty<ForestRangeDropdown>();
}
public class ForestRangeDropdown : DropdownLongVM
{
    public long ForestDivisionId { get; set; }
    public IEnumerable<ForestBeatDropdown> ForestBeats { get; set; } = Enumerable.Empty<ForestBeatDropdown>();
}
public class ForestBeatDropdown : DropdownLongVM
{
    public long ForestRangeId { get; set; }
    public IEnumerable<ForestFcvVcfDropdown> ForestForestFcvVcfs { get; set; } = Enumerable.Empty<ForestFcvVcfDropdown>();
}
public class ForestFcvVcfDropdown : DropdownLongVM
{
    public long ForestBeatId { get; set; }
}

// Civil
public class DivisionDropdown : DropdownLongVM
{
    public IEnumerable<DistrictDropdown> Districts { get; set; } = Enumerable.Empty<DistrictDropdown>();
}
public class DistrictDropdown : DropdownLongVM
{
    public long DivisionId { get; set; }
    public IEnumerable<UpazillaDropdown> Upazillas { get; set; } = Enumerable.Empty<UpazillaDropdown>();
}
public class UpazillaDropdown : DropdownLongVM
{
    public long DistrictId { get; set; }
    public IEnumerable<UnionDropdown> Unions { get; set; } = Enumerable.Empty<UnionDropdown>();
}
public class UnionDropdown : DropdownLongVM
{
    public long UpazillaId { get; set; }
}

