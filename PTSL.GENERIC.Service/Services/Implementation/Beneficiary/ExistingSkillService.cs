using AutoMapper;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.Beneficiary
{
    public class ExistingSkillService : BaseService<ExistingSkillVM, ExistingSkill>, IExistingSkillService
    {
        public IMapper _mapper;

        public ExistingSkillService(IExistingSkillBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override ExistingSkill CastModelToEntity(ExistingSkillVM model)
        {
            try
            {
                return _mapper.Map<ExistingSkill>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override ExistingSkillVM CastEntityToModel(ExistingSkill entity)
        {
            try
            {
                var model = _mapper.Map<ExistingSkillVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<ExistingSkillVM> CastEntityToModel(IQueryable<ExistingSkill> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<ExistingSkillVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
