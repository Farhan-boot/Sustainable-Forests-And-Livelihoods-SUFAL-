using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Cutting;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

public class NewRaisedPlantationForFelledOrCutReportVM
{
    public double? PreviousAmount { get; set; }
    public List<NewRaisedPlantationVM>? NewRaisedPlantationList { get; set; } = new List<NewRaisedPlantationVM>();
}

