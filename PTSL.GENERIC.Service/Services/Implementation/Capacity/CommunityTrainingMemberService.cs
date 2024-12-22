using AutoMapper;
using PTSL.GENERIC.Business.Businesses.Interface.Capacity;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Service.Services.Interface.Capacity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.Implementation.Capacity
{
    public class CommunityTrainingMemberService : BaseService<CommunityTrainingMemberVM, CommunityTrainingMember>, ICommunityTrainingMemberService
    {
        public IMapper _mapper;

        public CommunityTrainingMemberService(ICommunityTrainingMemberBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override CommunityTrainingMember CastModelToEntity(CommunityTrainingMemberVM model)
        {
            try
            {
                return _mapper.Map<CommunityTrainingMember>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override CommunityTrainingMemberVM CastEntityToModel(CommunityTrainingMember entity)
        {
            try
            {
                var model = _mapper.Map<CommunityTrainingMemberVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override IList<CommunityTrainingMemberVM> CastEntityToModel(IQueryable<CommunityTrainingMember> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<CommunityTrainingMemberVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
