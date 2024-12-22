using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Enum.PermissionSettings;

namespace PTSL.GENERIC.Common.Entity.PermissionSettings
{
    public class PermissionHeaderSettings : BaseEntity
    {
        // -- NOT NEEDED --
        // Forest administration
        public long? ForestCircleId { get; set; }
        public ForestCircle? ForestCircle { get; set; }
        public long? ForestDivisionId { get; set; }
        public ForestDivision? ForestDivision { get; set; }
        public long? ForestRangeId { get; set; }
        public ForestRange? ForestRange { get; set; }
        public long? ForestBeatId { get; set; }
        public ForestBeat? ForestBeat { get; set; }
        public long? ForestFcvVcfId { get; set; }
        public ForestFcvVcf? ForestFcvVcf { get; set; }

        public long? UserRoleId { get; set; }
        public UserRole? UserRole { get; set; }

        public long? UserId { get; set; }
        public User? User { get; set; }

        public ModuleEnum? ModuleEnumId { get; set; }
        // -- NOT NEEDED --

        public List<PermissionRowSettings>? PermissionRowSettings { get; set; }

        public long? AccesslistId { get; set; }
        public Accesslist? Accesslist { get; set; }
    }
}
