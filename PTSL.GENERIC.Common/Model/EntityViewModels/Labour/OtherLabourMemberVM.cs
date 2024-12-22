using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Labour;

public class OtherLabourMemberVM : BaseModel
{
    public string? FullName { get; set; }
    public Gender Gender { get; set; }
    public string? PhoneNumber { get; set; }
    public string? NID { get; set; }

    public long? EthnicityId { get; set; }
    [SwaggerExclude]
    public EthnicityVM? Ethnicity { get; set; }

    [SwaggerExclude]
    public LabourDatabaseVM? LabourDatabases { get; set; }

    //Add New Field
    public string? MotherName { get; set; }
    public string? FatherName { get; set; }
    public string? SpouseName { get; set; }
}

