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
    public class TrainerDesignationForTrainingService : BaseService<TrainerDesignationForTrainingVM, TrainerDesignationForTraining>, ITrainerDesignationForTrainingService
    {
        public IMapper _mapper;

        public TrainerDesignationForTrainingService(ITrainerDesignationForTrainingBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override TrainerDesignationForTraining CastModelToEntity(TrainerDesignationForTrainingVM model)
        {
            return _mapper.Map<TrainerDesignationForTraining>(model);
        }

        public override TrainerDesignationForTrainingVM CastEntityToModel(TrainerDesignationForTraining entity)
        {
            return _mapper.Map<TrainerDesignationForTrainingVM>(entity);
        }

        public override IList<TrainerDesignationForTrainingVM> CastEntityToModel(IQueryable<TrainerDesignationForTraining> entity)
        {
            return _mapper.Map<IList<TrainerDesignationForTrainingVM>>(entity).ToList();
        }
    }
}