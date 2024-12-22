using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.AccountManagement;
using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.AccountManagement
{
    public class SourceOfFundService : BaseService<SourceOfFundVM, SourceOfFund>, ISourceOfFundService
    {
        public IMapper _mapper;

        public SourceOfFundService(ISourceOfFundBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override SourceOfFund CastModelToEntity(SourceOfFundVM model)
        {
            return _mapper.Map<SourceOfFund>(model);
        }

        public override SourceOfFundVM CastEntityToModel(SourceOfFund entity)
        {
            return _mapper.Map<SourceOfFundVM>(entity);
        }

        public override IList<SourceOfFundVM> CastEntityToModel(IQueryable<SourceOfFund> entity)
        {
            return _mapper.Map<IList<SourceOfFundVM>>(entity).ToList();
        }
    }
}