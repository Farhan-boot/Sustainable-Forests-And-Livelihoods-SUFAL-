using System.Collections.Generic;
using System.Threading.Tasks;
using System;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.SubmissionHistoryForMobile;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.SubmissionHistoryForMobile;
using PTSL.GENERIC.DAL.UnitOfWork;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Common.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PTSL.GENERIC.Common.Model.EntityViewModels.SubmissionHistoryForMobile;

namespace PTSL.GENERIC.Business.Businesses.Implementation.SubmissionHistoryForMobile
{
    public class BeneficiarySubmissionHistoryBusiness : BaseBusiness<BeneficiarySubmissionHistory>, IBeneficiarySubmissionHistoryBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        private readonly GENERICReadOnlyCtx _readOnlyContext;
        private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

        public BeneficiarySubmissionHistoryBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyContext, GENERICWriteOnlyCtx writeOnlyCtx)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _readOnlyContext = readOnlyContext;
            _writeOnlyCtx = writeOnlyCtx;
        }

        public async Task<(ExecutionState executionState, bool entity, string message)> UploadFiles(
         BeneficiarySubmissionHistoryVM entity,
         string beneficiarySubmissionHistoryFileUrl
        )
        {
            try
            {

                var obj = new BeneficiarySubmissionHistory
                {
                    Id = entity.Id,
                    SurveyId = entity.SurveyId,
                    AIGBasicInformationId = entity.AIGBasicInformationId,
                    InternalLoanInformationId = entity.InternalLoanInformationId,
                    SavingsAccountId = entity.SavingsAccountId,
                    FileUrl = beneficiarySubmissionHistoryFileUrl
                };


                entity.FileUrl = beneficiarySubmissionHistoryFileUrl;

                   await _writeOnlyCtx.Set<BeneficiarySubmissionHistory>()
                    .AddAsync(obj);
                await _writeOnlyCtx.SaveChangesAsync();


                return (ExecutionState.Success, true, "File Upload Successfully!");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Success, false, "Unexpected error occurred");
            }
        }










    }
}