using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Helper;

public static class FcvVcfHelper
{
    public static int? GetFcvVcfType(List<ForestFcvVcfVM>? list, long? fcvVcfId)
    {
        var isFcV = list?.Find(x => x.Id == fcvVcfId)?.IsFcv;

        if (isFcV == false) return (int)FcvVcfType.VCF;
        if (isFcV == true) return (int)FcvVcfType.FCV;
        return null;
    }
}
