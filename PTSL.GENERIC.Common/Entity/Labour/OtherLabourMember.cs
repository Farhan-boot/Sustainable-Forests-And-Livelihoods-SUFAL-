using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.Labour
{
    public class OtherLabourMember : BaseEntity
    {
        public string? FullName { get; set; }
        public Gender Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? NID { get; set; }

        public long? EthnicityId { get; set; }
        public Ethnicity? Ethnicity { get; set; }

        public LabourDatabase? LabourDatabases { get; set; }

        //Add New Field
        public string? MotherName { get; set; }
        public string? FatherName { get; set; }
        public string? SpouseName { get; set; }

    }
}
