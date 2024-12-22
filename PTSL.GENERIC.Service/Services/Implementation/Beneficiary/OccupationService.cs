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
    public class OccupationService : BaseService<OccupationVM, Occupation>, IOccupationService
    {
        public IMapper _mapper;

        public OccupationService(IOccupationBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override Occupation CastModelToEntity(OccupationVM model)
        {
            try
            {
                return _mapper.Map<Occupation>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override OccupationVM CastEntityToModel(Occupation entity)
        {
            try
            {
                var model = _mapper.Map<OccupationVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<OccupationVM> CastEntityToModel(IQueryable<Occupation> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<OccupationVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
