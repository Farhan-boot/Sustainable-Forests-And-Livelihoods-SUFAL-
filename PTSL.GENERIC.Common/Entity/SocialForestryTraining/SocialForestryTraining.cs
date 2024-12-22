using System;
using System.Collections.Generic;

using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;

namespace PTSL.GENERIC.Common.Entity.SocialForestryTraining;

public class SocialForestryTraining : BaseEntity
{
    public long? ForestCircleId { get; set; }
    public ForestCircle? ForestCircle { get; set; }
    public long? ForestDivisionId { get; set; }
    public ForestDivision? ForestDivision { get; set; }
    public long? ForestRangeId { get; set; }
    public ForestRange? ForestRange { get; set; }
    public long? ForestBeatId { get; set; }
    public ForestBeat? ForestBeat { get; set; }
    public long? DivisionId { get; set; }
    public Division? Division { get; set; }
    public long? DistrictId { get; set; }
    public District? District { get; set; }
    public long? UpazillaId { get; set; }
    public Upazilla? Upazilla { get; set; }
    public long? UnionId { get; set; }
    public Union? Union { get; set; }


    public string? TrainingTitle { get; set; }
    public string? TrainingTitleBn { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? TrainingDuration { get; set; } = string.Empty;
    public string? TrainerName { get; set; }
    public string? Location { get; set; }
    public string? LocationBn { get; set; }

    //ddl
    public long? FinancialYearForTrainingId { get; set; }
    public FinancialYearForTraining? FinancialYearForTraining { get; set; }
    //ddl
    public long? EventTypeForTrainingId { get; set; }
    public EventTypeForTraining? EventTypeForTraining { get; set; }
    //ddl
    public long? TrainingOrganizerForTrainingId { get; set; }
    public TrainingOrganizerForTraining? TrainingOrganizerForTraining { get; set; }
    //ddl
    public long? TrainerDesignationForTrainingId { get; set; }
    public TrainerDesignationForTraining? TrainerDesignationForTraining { get; set; }

    //extra
    public int TotalMembers { get; set; }
    public int TotalMale { get; set; }
    public int TotalFemale { get; set; }

    public string? TrainerAddress { get; set; }

    public List<SocialForestryTrainingParticipentsMap>? SocialForestryTrainingParticipentsMaps { get; set; }
    public List<SocialForestryTrainingFile>? SocialForestryTrainingFiles { get; set; }
}

