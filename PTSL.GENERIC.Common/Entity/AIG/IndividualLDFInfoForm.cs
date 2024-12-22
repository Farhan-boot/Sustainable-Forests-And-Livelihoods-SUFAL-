using System;

using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum.AIG;

namespace PTSL.GENERIC.Common.Entity.AIG;

public class IndividualLDFInfoForm : BaseEntity
{
    // Forest administration
    public long ForestCircleId { get; set; }
    public ForestCircle? ForestCircle { get; set; }
    public long ForestDivisionId { get; set; }
    public ForestDivision? ForestDivision { get; set; }
    public long ForestRangeId { get; set; }
    public ForestRange? ForestRange { get; set; }
    public long ForestBeatId { get; set; }
    public ForestBeat? ForestBeat { get; set; }
    public long ForestFcvVcfId { get; set; }
    public ForestFcvVcf? ForestFcvVcf { get; set; }

    // Civil administration
    public long DivisionId { get; set; }
    public Division? Division { get; set; }
    public long DistrictId { get; set; }
    public District? District { get; set; }
    public long UpazillaId { get; set; }
    public Upazilla? Upazilla { get; set; }
    public long? UnionId { get; set; }
    public Union? Union { get; set; }

    public long? NgoId { get; set; }
    public Ngo? Ngo { get; set; }

    public long SurveyId { get; set; }
    public Survey? Survey { get; set; }

    public double RequestedLoanAmount { get; set; }
    public double ApprovedLoanAmount { get; set; }
    public DateTime SubmittedDate { get; set; }

    public IndividualLDFInfoStatus IndividualLDFInfoStatus { get; set; }
    public DateTime? StatusDate { get; set; }
    public string? DocumentInfoURL { get; set; }

    public int LDFCount { get; set; }

    public AIGBasicInformation? AIGBasicInformation { get; set; }

    public List<GroupLDFInfoFormMember>? GroupLDFInfoFormMembers { get; set; }
}
