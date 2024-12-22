using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.DashBoard;

public class CommitteeMemberCount  : BaseModel
{
    public long TotalFcvVcf { get; set; }
    public double TotalFcvVcfMaleFemale { get; set; }
    public double TotalFcvVcfMaleInPercentage { get; set; }
    public double TotalFcvVcfFemaleInPercentage { get; set; }

    public long TotalExecutiveMember { get; set; }
    public double TotalExecutiveMemberMaleInPercentage { get; set; }
    public double TotalExecutiveMemberFemaleInPercentage { get; set; }

    public long TotalSubExecutiveMember { get; set; }
    public double TotalSubExecutiveMemberMaleInPercentage { get; set; }
    public double TotalSubExecutiveMemberFemaleInPercentage { get; set; }

    public long TotalCoOrdinationMember { get; set; }
    public double TotalCoOrdinationMemberMaleInPercentage { get; set; }
    public double TotalCoOrdinationMemberFemaleInPercentage { get; set; }
}

