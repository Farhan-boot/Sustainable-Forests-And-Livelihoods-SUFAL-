using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.InternalLoan;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.InternalLoan;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.InternalLoan
{
    public class InternalLoanInformationFileBusiness : BaseBusiness<InternalLoanInformationFile>, IInternalLoanInformationFileBusiness
    {
        private readonly GENERICReadOnlyCtx _readOnlyCtx;
        private readonly GENERICWriteOnlyCtx _writeOnlyCtx;
        public InternalLoanInformationFileBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyCtx, GENERICWriteOnlyCtx writeOnlyCtx)
            : base(unitOfWork)
        {
            _readOnlyCtx = readOnlyCtx;
            _writeOnlyCtx = writeOnlyCtx;
        }

    }
}