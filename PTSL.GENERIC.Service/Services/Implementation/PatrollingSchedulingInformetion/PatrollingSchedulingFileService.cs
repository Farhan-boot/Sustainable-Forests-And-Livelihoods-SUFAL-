using AutoMapper;
using PTSL.GENERIC.Business.Businesses.Interface.Capacity;
using PTSL.GENERIC.Business.Businesses.Interface.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Common.Model.EntityViewModels.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Service.Services.Interface.Capacity;
using PTSL.GENERIC.Service.Services.Interface.PatrollingSchedulingInformetion;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.Implementation.PatrollingSchedulingInformetion
{
    public class PatrollingSchedulingFileService : BaseService<PatrollingSchedulingFileVM, PatrollingSchedulingFile>, IPatrollingSchedulingFileService
    {
        public IMapper _mapper;

        public PatrollingSchedulingFileService(IPatrollingSchedulingFileBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override PatrollingSchedulingFile CastModelToEntity(PatrollingSchedulingFileVM model)
        {
            try
            {
                return _mapper.Map<PatrollingSchedulingFile>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override PatrollingSchedulingFileVM CastEntityToModel(PatrollingSchedulingFile entity)
        {
            try
            {
                var model = _mapper.Map<PatrollingSchedulingFileVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override IList<PatrollingSchedulingFileVM> CastEntityToModel(IQueryable<PatrollingSchedulingFile> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<PatrollingSchedulingFileVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
