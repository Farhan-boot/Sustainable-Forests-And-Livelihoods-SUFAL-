using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.AIG
{
    public class RepaymentLDFFileBusiness : BaseBusiness<RepaymentLDFFile>, IRepaymentLDFFileBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        private readonly GENERICReadOnlyCtx _readOnlyContext;
        public RepaymentLDFFileBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyContext)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _readOnlyContext = readOnlyContext;
        }

        public async Task<(ExecutionState executionState, List<RepaymentLDFFile> entity, string message)> GetRepaymentLDFFileByRepaymentId(long repaymentId)
        {
            try
            {
                IQueryable<RepaymentLDFFile> query = _readOnlyContext.Set<RepaymentLDFFile>();
                query = query.Where(x=>x.RepaymentLDFId == repaymentId);

                return (ExecutionState.Retrieved, query.ToList(), "Data returned successfully.");
            }
            catch (Exception)
            {
                return (ExecutionState.Failure, new List<RepaymentLDFFile>()!, "Unexpected error occurred.");
            }
        }

    }
}