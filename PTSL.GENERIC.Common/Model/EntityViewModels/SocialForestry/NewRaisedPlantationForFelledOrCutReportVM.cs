using Humanizer;

using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;

public class NewRaisedPlantationForFelledOrCutReportVM
{
    public double? PreviousAmount { get; set; }
    public List<NewRaisedPlantationVM>? NewRaisedPlantationList { get; set; } = new List<NewRaisedPlantationVM>();
}
