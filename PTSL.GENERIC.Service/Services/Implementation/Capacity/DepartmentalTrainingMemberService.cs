using AutoMapper;
using PTSL.GENERIC.Business.Businesses.Interface.Capacity;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Service.Services.Interface.Capacity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.Implementation.Capacity
{
    public class DepartmentalTrainingMemberService : BaseService<DepartmentalTrainingMemberVM, DepartmentalTrainingMember>, IDepartmentalTrainingMemberService
    {
        public IMapper _mapper;

        public DepartmentalTrainingMemberService(IDepartmentalTrainingMemberBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override DepartmentalTrainingMember CastModelToEntity(DepartmentalTrainingMemberVM model)
        {
            try
            {
                return _mapper.Map<DepartmentalTrainingMember>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override DepartmentalTrainingMemberVM CastEntityToModel(DepartmentalTrainingMember entity)
        {
            try
            {
                var model = _mapper.Map<DepartmentalTrainingMemberVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override IList<DepartmentalTrainingMemberVM> CastEntityToModel(IQueryable<DepartmentalTrainingMember> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<DepartmentalTrainingMemberVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
