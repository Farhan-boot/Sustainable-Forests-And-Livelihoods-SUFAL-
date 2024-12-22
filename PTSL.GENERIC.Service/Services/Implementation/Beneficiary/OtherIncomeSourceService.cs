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
    public class OtherIncomeSourceService : BaseService<OtherIncomeSourceVM, OtherIncomeSource>, IOtherIncomeSourceService
    {
        public IMapper _mapper;

        public OtherIncomeSourceService(IOtherIncomeSourceBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override OtherIncomeSource CastModelToEntity(OtherIncomeSourceVM model)
        {
            try
            {
                return _mapper.Map<OtherIncomeSource>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override OtherIncomeSourceVM CastEntityToModel(OtherIncomeSource entity)
        {
            try
            {
                var model = _mapper.Map<OtherIncomeSourceVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<OtherIncomeSourceVM> CastEntityToModel(IQueryable<OtherIncomeSource> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<OtherIncomeSourceVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
