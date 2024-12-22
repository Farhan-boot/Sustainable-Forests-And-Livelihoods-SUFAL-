using PTSL.GENERIC.Web.Core.Helper.Enum.ForestManagement;
using PTSL.GENERIC.Web.Core.Helper.Enum.PermissionSettings;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SystemUser;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.PermissionSettings
{
    public class PermissionHeaderSettingsVM : BaseModel
    {
        // Forest administration
        public long? ForestCircleId { get; set; }
        public ForestCircleVM? ForestCircle { get; set; }
        public long? ForestDivisionId { get; set; }
        public ForestDivisionVM? ForestDivision { get; set; }
        public long? ForestRangeId { get; set; }
        public ForestRangeVM? ForestRange { get; set; }
        public long? ForestBeatId { get; set; }
        public ForestBeatVM? ForestBeat { get; set; }
        public long? ForestFcvVcfId { get; set; }
        public ForestFcvVcfVM? ForestFcvVcf { get; set; }

        //Other Info
        public long? UserRoleId { get; set; }
        public UserRoleVM? UserRole { get; set; }
        public long? UserId { get; set; }
        public UserVM? User { get; set; }
        public ModuleEnum? ModuleEnumId { get; set; }
        public List<PermissionRowSettingsVM>? PermissionRowSettings { get; set; }
        public string? PermissionRowSettingsJson { get; set; }


        // Civil administration
        public long DivisionId { get; set; }
        public DivisionVM? Division { get; set; }
        public long DistrictId { get; set; }
        public DistrictVM? District { get; set; }
        public long UpazillaId { get; set; }
        public UpazillaVM? Upazilla { get; set; }
        public long UnionId { get; set; }
        public UnionVM? Union { get; set; }

        //New field Add
        public long? AccesslistId { get; set; }
        public AccesslistVM? Accesslist { get; set; }
    }
}