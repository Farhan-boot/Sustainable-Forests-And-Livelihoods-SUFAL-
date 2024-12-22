using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Labour;

public class OtherLabourMemberVM : BaseModel
{
    public string? FullName { get; set; }
    public Gender Gender { get; set; }
    public string? PhoneNumber { get; set; }
    public string? NID { get; set; }

    public long? EthnicityId { get; set; }
    public EthnicityVM? Ethnicity { get; set; }
    public LabourDatabaseVM? LabourDatabases { get; set; }

    //Add New Field
    public string? MotherName { get; set; }
    public string? FatherName { get; set; }
    public string? SpouseName { get; set; }
}

