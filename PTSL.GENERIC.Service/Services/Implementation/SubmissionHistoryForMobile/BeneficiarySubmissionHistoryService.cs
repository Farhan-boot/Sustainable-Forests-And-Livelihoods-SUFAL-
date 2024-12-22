using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SubmissionHistoryForMobile;
using PTSL.GENERIC.Common.Entity.SubmissionHistoryForMobile;
using PTSL.GENERIC.Common.Model.EntityViewModels.SubmissionHistoryForMobile;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.SubmissionHistoryForMobile
{
    public class BeneficiarySubmissionHistoryService : BaseService<BeneficiarySubmissionHistoryVM, BeneficiarySubmissionHistory>, IBeneficiarySubmissionHistoryService
    {
        public IMapper _mapper;

        public BeneficiarySubmissionHistoryService(IBeneficiarySubmissionHistoryBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override BeneficiarySubmissionHistory CastModelToEntity(BeneficiarySubmissionHistoryVM model)
        {
            return _mapper.Map<BeneficiarySubmissionHistory>(model);
        }

        public override BeneficiarySubmissionHistoryVM CastEntityToModel(BeneficiarySubmissionHistory entity)
        {
            return _mapper.Map<BeneficiarySubmissionHistoryVM>(entity);
        }

        public override IList<BeneficiarySubmissionHistoryVM> CastEntityToModel(IQueryable<BeneficiarySubmissionHistory> entity)
        {
            return _mapper.Map<IList<BeneficiarySubmissionHistoryVM>>(entity).ToList();
        }
    }
}