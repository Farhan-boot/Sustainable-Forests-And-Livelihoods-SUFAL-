using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.AIG
{
    public class RepaymentLDFFileService : BaseService<RepaymentLDFFileVM, RepaymentLDFFile>, IRepaymentLDFFileService
    {
        public IMapper _mapper;
        private readonly IRepaymentLDFFileBusiness _business;

        public RepaymentLDFFileService(IRepaymentLDFFileBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override RepaymentLDFFile CastModelToEntity(RepaymentLDFFileVM model)
        {
            return _mapper.Map<RepaymentLDFFile>(model);
        }

        public override RepaymentLDFFileVM CastEntityToModel(RepaymentLDFFile entity)
        {
            return _mapper.Map<RepaymentLDFFileVM>(entity);
        }

        public override IList<RepaymentLDFFileVM> CastEntityToModel(IQueryable<RepaymentLDFFile> entity)
        {
            return _mapper.Map<IList<RepaymentLDFFileVM>>(entity).ToList();
        }


        public async Task<(ExecutionState executionState, List<RepaymentLDFFileVM> entity, string message)> GetRepaymentLDFFileByRepaymentId(long repaymentId)
        {
            var result = await _business.GetRepaymentLDFFileByRepaymentId(repaymentId);

            if (result.executionState == ExecutionState.Retrieved)
            {
              var listOfvm =  _mapper.Map<List<RepaymentLDFFileVM>>(result.entity) ;

                return (result.executionState, listOfvm, result.message);
            }

            return (result.executionState, null!, result.message);
        }


    }
}