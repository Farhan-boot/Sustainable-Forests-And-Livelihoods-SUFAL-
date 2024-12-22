using AutoMapper;
using PTSL.GENERIC.Business;
using PTSL.GENERIC.Business.Businesses;
using PTSL.GENERIC.Business.Businesses.Implementation;
using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services
{
    public class DistrictService : BaseService<DistrictVM, District>, IDistrictService
    {
        public readonly IDistrictBusiness _DistrictBusiness;
        public IMapper _mapper;
        public DistrictService(IDistrictBusiness DistrictBusiness, IMapper mapper) : base(DistrictBusiness)
        {
            _DistrictBusiness = DistrictBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override District CastModelToEntity(DistrictVM model)
        {
            try
            {
                return _mapper.Map<District>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override DistrictVM CastEntityToModel(District entity)
        {
            try
            {
                DistrictVM model = _mapper.Map<DistrictVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<DistrictVM> CastEntityToModel(IQueryable<District> entity)
        {
            try
            {
                //IQueryable<DistrictVM> DistrictList = _mapper.Map<IQueryable<DistrictVM>>(entity).ToList();
                IList<DistrictVM> DistrictList = _mapper.Map<IList<DistrictVM>>(entity).ToList();
                return DistrictList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, IList<DistrictVM> entity, string message)> ListByDivision(long DivisionId)
        {
            (ExecutionState executionState, IList<DistrictVM> entity, string message) returnResponse;

            try
            {
                (ExecutionState executionState, IQueryable<District> entity, string message) response = await _DistrictBusiness.ListByDivision(DivisionId);

                if (response.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (response.executionState, entity: CastEntityToModel(response.entity), response.message);
                }
                else
                {
                    returnResponse = (response.executionState, entity: null, response.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }

            return returnResponse;
        }
    }
}
