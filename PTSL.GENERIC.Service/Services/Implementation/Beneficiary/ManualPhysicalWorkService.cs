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
    public class ManualPhysicalWorkService : BaseService<ManualPhysicalWorkVM, ManualPhysicalWork>, IManualPhysicalWorkService
    {
        public IMapper _mapper;

        public ManualPhysicalWorkService(IManualPhysicalWorkBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override ManualPhysicalWork CastModelToEntity(ManualPhysicalWorkVM model)
        {
            try
            {
                return _mapper.Map<ManualPhysicalWork>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override ManualPhysicalWorkVM CastEntityToModel(ManualPhysicalWork entity)
        {
            try
            {
                var model = _mapper.Map<ManualPhysicalWorkVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<ManualPhysicalWorkVM> CastEntityToModel(IQueryable<ManualPhysicalWork> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<ManualPhysicalWorkVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
