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
    public class SafetyNetService : BaseService<SafetyNetVM, SafetyNet>, ISafetyNetService
    {
        public IMapper _mapper;

        public SafetyNetService(ISafetyNetBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override SafetyNet CastModelToEntity(SafetyNetVM model)
        {
            try
            {
                return _mapper.Map<SafetyNet>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override SafetyNetVM CastEntityToModel(SafetyNet entity)
        {
            try
            {
                var model = _mapper.Map<SafetyNetVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<SafetyNetVM> CastEntityToModel(IQueryable<SafetyNet> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<SafetyNetVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
