
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.SubmissionHistoryForMobile;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.BeneficiarySavingsAccount
{
   public class SavingsAccountVM : BaseModel
    {
        [SwaggerExclude]
        public List<BeneficiarySubmissionHistory>? BeneficiarySubmissionHistorys { get; set; }
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
        public long? FcvId { get; set; }

        // Civil administration
        public long? DivisionId { get; set; }
        [SwaggerExclude]
        public Division? Division { get; set; }
        public long? DistrictId { get; set; }
        [SwaggerExclude]
        public District? District { get; set; }
        public long? UpazillaId { get; set; }
        [SwaggerExclude]
        public Upazilla? Upazilla { get; set; }
        public long? UnionId { get; set; }
        [SwaggerExclude]
        public UnionVM? Union { get; set; }
        public long? NgoId { get; set; }
        [SwaggerExclude]
        public Ngo? Ngos { get; set; }

        //Others
        public long? SurveyId { get; set; }
        [SwaggerExclude]
        public Survey? Survey { get; set; }
        public long? StatusId { get; set; }
        public long? AccountTypeId { get; set; }
        public decimal? AmountLimit { get; set; }


        [SwaggerExclude]
        public List<SavingsAmountInformation>? SavingsAmountInformations { get; set; }
        [SwaggerExclude]
        public List<WithdrawAmountInformation>? WithdrawAmountInformations { get; set; }
    }
}
