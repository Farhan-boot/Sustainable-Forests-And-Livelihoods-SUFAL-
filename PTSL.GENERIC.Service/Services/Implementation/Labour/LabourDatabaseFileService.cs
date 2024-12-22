using AutoMapper;
using PTSL.GENERIC.Business.Businesses.Interface.Capacity;
using PTSL.GENERIC.Business.Businesses.Interface.Labour;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Common.Model.EntityViewModels.Labour;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Service.Services.Interface.Capacity;
using PTSL.GENERIC.Service.Services.Interface.Labour;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.Implementation.Capacity
{
    public class LabourDatabaseFileService : BaseService<LabourDatabaseFileVM, LabourDatabaseFile>, ILabourDatabaseFileService
    {
        public IMapper _mapper;

        public LabourDatabaseFileService(ILabourDatabaseFileBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override LabourDatabaseFile CastModelToEntity(LabourDatabaseFileVM model)
        {
            try
            {
                return _mapper.Map<LabourDatabaseFile>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override LabourDatabaseFileVM CastEntityToModel(LabourDatabaseFile entity)
        {
            try
            {
                var model = _mapper.Map<LabourDatabaseFileVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override IList<LabourDatabaseFileVM> CastEntityToModel(IQueryable<LabourDatabaseFile> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<LabourDatabaseFileVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
