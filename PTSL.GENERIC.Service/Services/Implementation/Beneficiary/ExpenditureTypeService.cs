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
    public class ExpenditureTypeService : BaseService<ExpenditureTypeVM, ExpenditureType>, IExpenditureTypeService
    {
        public IMapper _mapper;

        public ExpenditureTypeService(IExpenditureTypeBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override ExpenditureType CastModelToEntity(ExpenditureTypeVM model)
        {
            try
            {
                return _mapper.Map<ExpenditureType>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override ExpenditureTypeVM CastEntityToModel(ExpenditureType entity)
        {
            try
            {
                var model = _mapper.Map<ExpenditureTypeVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<ExpenditureTypeVM> CastEntityToModel(IQueryable<ExpenditureType> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<ExpenditureTypeVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
