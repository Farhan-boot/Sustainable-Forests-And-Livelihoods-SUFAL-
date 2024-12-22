using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PTSL.GENERIC.Business.Businesses.Interface.Labour;
using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.Labour;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Service.Services.Interface.Labour;

namespace PTSL.GENERIC.Service.Services.Implementation.Labour
{
    public class LabourDatabaseService : BaseService<LabourDatabaseVM, LabourDatabase>, ILabourDatabaseService
    {
        private readonly ILabourDatabaseBusiness _business;
        public IMapper _mapper;

        public LabourDatabaseService(ILabourDatabaseBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override LabourDatabaseVM CastEntityToModel(LabourDatabase entity)
        {
            try
            {
                var model = _mapper.Map<LabourDatabaseVM>(entity);
                return model;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public override IList<LabourDatabaseVM> CastEntityToModel(IQueryable<LabourDatabase> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<LabourDatabaseVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override LabourDatabase CastModelToEntity(LabourDatabaseVM model)
        {
            try
            {
                return _mapper.Map<LabourDatabase>(model);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public List<LabourDatabaseVM> CastEntityListToModel(List<LabourDatabase> entity)
        {
            return _mapper.Map<List<LabourDatabaseVM>>(entity);
        }

        public async Task<(ExecutionState executionState, PaginationResutl<LabourDatabaseVM> entity, string message)> GetByFilter(LabourDatabaseFilterVM filter)
        {
            var result = await _business.GetByFilter(filter);

            if (result.entity is not null)
            {
                //return (result.executionState, CastEntityListToModel(result.entity), result.message);
                return (result.executionState, _mapper.Map<PaginationResutl<LabourDatabaseVM>>(result.entity), result.message);
            }

            return (result.executionState, new PaginationResutl<LabourDatabaseVM>(), result.message);
        }

    }
}
