using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.ApprovalLog;
using PTSL.GENERIC.Common.Entity.ApprovalLog;
using PTSL.GENERIC.Common.Model.EntityViewModels.ApprovalLog;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.ApprovalLog
{
    public class ApprovalLogForCfmService : BaseService<ApprovalLogForCfmVM, ApprovalLogForCfm>, IApprovalLogForCfmService
    {
        public IMapper _mapper;

        public ApprovalLogForCfmService(IApprovalLogForCfmBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override ApprovalLogForCfm CastModelToEntity(ApprovalLogForCfmVM model)
        {
            return _mapper.Map<ApprovalLogForCfm>(model);
        }

        public override ApprovalLogForCfmVM CastEntityToModel(ApprovalLogForCfm entity)
        {
            return _mapper.Map<ApprovalLogForCfmVM>(entity);
        }

        public override IList<ApprovalLogForCfmVM> CastEntityToModel(IQueryable<ApprovalLogForCfm> entity)
        {
            return _mapper.Map<IList<ApprovalLogForCfmVM>>(entity).ToList();
        }
    }
}