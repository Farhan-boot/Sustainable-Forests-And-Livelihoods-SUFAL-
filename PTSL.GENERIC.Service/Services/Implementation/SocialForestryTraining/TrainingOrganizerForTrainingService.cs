using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SocialForestryTraining;
using PTSL.GENERIC.Common.Entity.SocialForestryTraining;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestryTraining;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.SocialForestryTraining
{
    public class TrainingOrganizerForTrainingService : BaseService<TrainingOrganizerForTrainingVM, TrainingOrganizerForTraining>, ITrainingOrganizerForTrainingService
    {
        public IMapper _mapper;

        public TrainingOrganizerForTrainingService(ITrainingOrganizerForTrainingBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override TrainingOrganizerForTraining CastModelToEntity(TrainingOrganizerForTrainingVM model)
        {
            return _mapper.Map<TrainingOrganizerForTraining>(model);
        }

        public override TrainingOrganizerForTrainingVM CastEntityToModel(TrainingOrganizerForTraining entity)
        {
            return _mapper.Map<TrainingOrganizerForTrainingVM>(entity);
        }

        public override IList<TrainingOrganizerForTrainingVM> CastEntityToModel(IQueryable<TrainingOrganizerForTraining> entity)
        {
            return _mapper.Map<IList<TrainingOrganizerForTrainingVM>>(entity).ToList();
        }
    }
}