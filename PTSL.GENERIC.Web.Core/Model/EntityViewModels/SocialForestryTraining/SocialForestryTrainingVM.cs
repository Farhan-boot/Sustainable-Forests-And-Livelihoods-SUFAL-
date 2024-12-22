using System.ComponentModel.DataAnnotations;

using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryTraining;

public class SocialForestryTrainingVM : BaseModel
{
    public long? ForestCircleId { get; set; }
    public ForestCircleVM? ForestCircle { get; set; }
    public long? ForestDivisionId { get; set; }
    public ForestDivisionVM? ForestDivision { get; set; }
    public long? ForestRangeId { get; set; }
    public ForestRangeVM? ForestRange { get; set; }
    public long? ForestBeatId { get; set; }
    public ForestBeatVM? ForestBeat { get; set; }
    public long? DivisionId { get; set; }
    public DivisionVM? Division { get; set; }
    public long? DistrictId { get; set; }
    public DistrictVM? District { get; set; }
    public long? UpazillaId { get; set; }
    public UpazillaVM? Upazilla { get; set; }
    public long? UnionId { get; set; }
    public UnionVM? Union { get; set; }


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
    public FinancialYearForTrainingVM? FinancialYearForTraining { get; set; }
    //ddl
    public long? EventTypeForTrainingId { get; set; }
    public EventTypeForTrainingVM? EventTypeForTraining { get; set; }
    //ddl
    public long? TrainingOrganizerForTrainingId { get; set; }
    public TrainingOrganizerForTrainingVM? TrainingOrganizerForTraining { get; set; }
    //ddl
    public long? TrainerDesignationForTrainingId { get; set; }
    public TrainerDesignationForTrainingVM? TrainerDesignationForTraining { get; set; }

    //extra
    public int TotalMembers { get; set; }
    public int TotalMale { get; set; }
    public int TotalFemale { get; set; }

    public string? TrainerAddress { get; set; }

    public List<SocialForestryTrainingParticipentsMapVM>? SocialForestryTrainingParticipentsMaps { get; set; }
    public List<SocialForestryTrainingFileVM>? SocialForestryTrainingFiles { get; set; } = new List<SocialForestryTrainingFileVM>();

    [Required]
    public string? SocialForestryTrainingParticipentsMapsJSON { get; set; }
}

