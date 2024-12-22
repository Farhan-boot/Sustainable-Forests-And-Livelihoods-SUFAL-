using System;
using System.Collections.Generic;

using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;

namespace PTSL.GENERIC.Common.Entity.AIG;

public class GroupLDFInfoFormVM : BaseModel
{
    // Forest administration
    public long ForestCircleId { get; set; }
    [SwaggerExclude]
    public ForestCircleVM? ForestCircle { get; set; }
    public long ForestDivisionId { get; set; }
    [SwaggerExclude]
    public ForestDivisionVM? ForestDivision { get; set; }
    public long ForestRangeId { get; set; }
    [SwaggerExclude]
    public ForestRangeVM? ForestRange { get; set; }
    public long ForestBeatId { get; set; }
    [SwaggerExclude]
    public ForestBeatVM? ForestBeat { get; set; }
    public long ForestFcvVcfId { get; set; }
    [SwaggerExclude]
    public ForestFcvVcfVM? ForestFcvVcf { get; set; }

    // Civil administration
    public long DivisionId { get; set; }
    [SwaggerExclude]
    public DivisionVM? Division { get; set; }
    public long DistrictId { get; set; }
    [SwaggerExclude]
    public DistrictVM? District { get; set; }
    public long UpazillaId { get; set; }
    [SwaggerExclude]
    public UpazillaVM? Upazilla { get; set; }
    public long? UnionId { get; set; }
    [SwaggerExclude]
    public UnionVM? Union { get; set; }

    public long? NgoId { get; set; }
    [SwaggerExclude]
    public NgoVM? Ngo { get; set; }

    public long SubmittedById { get; set; }
    [SwaggerExclude]
    public UserVM? SubmittedBy { get; set; }
    public DateTime SubmittedDate { get; set; }

    public string? DocumentName { get; set; }
    public string? DocumentNameURL { get; set; }
    public int TotalMember { get; set; }
    
    [SwaggerExclude]
    public List<GroupLDFInfoFormMemberVM>? GroupLDFInfoFormMembers { get; set; }
}
