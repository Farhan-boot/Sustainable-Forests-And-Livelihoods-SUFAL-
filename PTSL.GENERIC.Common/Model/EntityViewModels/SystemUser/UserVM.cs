using System.Collections.Generic;

using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;

namespace PTSL.GENERIC.Common.Model
{
    public class UserVM : BaseModel
    {
        [SwaggerExclude]
        public List<BankAccountsInformationVM>? BankAccountsInformations { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? RoleName { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }
        public string? ImageUrl { get; set; }
        public string? UserPhone { get; set; }
        public string? UserGroup { get; set; }
        public bool UserStatus { get; set; }
        public long PmsGroupID { get; set; }
        public long? GroupID { get; set; }
        public virtual UserGroupVM? Group { get; set; }
        public virtual PmsGroupVM? PmsGroup { get; set; }

        // Forest administration
        public long? ForestCircleId { get; set; }
        [SwaggerExclude]
        public ForestCircleVM? ForestCircle { get; set; }
        public long? ForestDivisionId { get; set; }
        [SwaggerExclude]
        public ForestDivisionVM? ForestDivision { get; set; }
        public long? ForestRangeId { get; set; }
        [SwaggerExclude]
        public ForestRangeVM? ForestRange { get; set; }
        public long? ForestBeatId { get; set; }
        [SwaggerExclude]
        public ForestBeatVM? ForestBeat { get; set; }
        public long? ForestFcvVcfId { get; set; }
        [SwaggerExclude]
        public ForestFcvVcfVM? ForestFcvVcf { get; set; }

        // Civil administration
        public long? DivisionId { get; set; }
        [SwaggerExclude]
        public DivisionVM? Division { get; set; }
        public long? DistrictId { get; set; }
        [SwaggerExclude]
        public DistrictVM? District { get; set; }
        public long? UpazillaId { get; set; }
        [SwaggerExclude]
        public UpazillaVM? Upazilla { get; set; }
        public long? UnionId { get; set; }
        [SwaggerExclude]
        public UnionVM? Union { get; set; }

        public long? SurveyId { get; set; }
        [SwaggerExclude]
        public SurveyVM? Survey { get; set; }

        public long? UserRoleId { get; set; }
        [SwaggerExclude]
        public UserRoleVM? UserRole { get; set; }

        public UserType UserType { get; set; }

        public List<RepaymentLDFHistoryVM>? RepaymentLDFHistories { get; set; }

        // Map To Account into User
        public long? AccountsId { get; set; }
        public Account? Accounts { get; set; }
    }

    public class LoginVM
    {
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }
        public bool RememberMe { get; set; }
    }

    public class LoginResultVM
    {
        public long UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }

        public string? Token { get; set; } // Need to be removed
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }

        public string? RoleName { get; set; }
        public long? SurveyId { get; set; }

        // Forest administration
        public long? ForestCircleId { get; set; }
        public long? ForestDivisionId { get; set; }
        public long? ForestRangeId { get; set; }
        public long? ForestBeatId { get; set; }
        public long? ForestFcvVcfId { get; set; }

        // Civil administration
        public long? DivisionId { get; set; }
        public long? DistrictId { get; set; }
        public long? UpazillaId { get; set; }
        public long? UnionId { get; set; }

        public long? UserRoleId { get; set; }
    }
}
