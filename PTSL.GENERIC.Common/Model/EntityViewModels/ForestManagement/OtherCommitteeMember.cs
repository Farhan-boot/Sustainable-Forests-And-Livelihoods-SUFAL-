using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement
{
    public class OtherCommitteeMemberVM : BaseModel
    {
        public string? FullName { get; set; }
        public string? FatherOrSpouse { get; set; }
        public Gender Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? NID { get; set; }
        public string? Address { get; set; }

        // Forest Administration
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

        public long? EthnicityId { get; set; }
        [SwaggerExclude]
        public EthnicityVM? Ethnicity { get; set; }

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
    }
}
