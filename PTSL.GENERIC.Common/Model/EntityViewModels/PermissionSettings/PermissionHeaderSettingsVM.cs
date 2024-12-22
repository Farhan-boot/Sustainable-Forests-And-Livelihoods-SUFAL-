using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.PermissionSettings;
using PTSL.GENERIC.Common.Enum.ForestManagement;
using PTSL.GENERIC.Common.Enum.PermissionSettings;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.PermissionSettings
{
   public class PermissionHeaderSettingsVM : BaseModel
    {
        // Forest administration
        public long? ForestCircleId { get; set; }
        [SwaggerExclude]
        public ForestCircle? ForestCircle { get; set; }
        public long? ForestDivisionId { get; set; }
        [SwaggerExclude]
        public ForestDivision? ForestDivision { get; set; }
        public long? ForestRangeId { get; set; }
        [SwaggerExclude]
        public ForestRange? ForestRange { get; set; }
        public long? ForestBeatId { get; set; }
        [SwaggerExclude]
        public ForestBeat? ForestBeat { get; set; }
        public long? ForestFcvVcfId { get; set; }
        [SwaggerExclude]
        public ForestFcvVcf? ForestFcvVcf { get; set; }

        //Other Info
        public long? UserRoleId { get; set; }
        [SwaggerExclude]
        public UserRole? UserRole { get; set; }
        public long? UserId { get; set; }
        [SwaggerExclude]
        public User? User { get; set; }
        public ModuleEnum? ModuleEnumId { get; set; }
        [SwaggerExclude]
        public List<PermissionRowSettings>? PermissionRowSettings { get; set; }

        //New field Add
        public long? AccesslistId { get; set; }
        [SwaggerExclude]
        public Accesslist? Accesslist { get; set; }

    }
}
