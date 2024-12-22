﻿using System.Collections.Generic;

using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.DashBoard;

public class SurveyDashboardVM
{
    public long SurveyId { get; set; }
    public string? BeneficiaryName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? NidNo { get; set; }
    public Gender Gender { get; set; }
    public double TotalAIGLoanTaken { get; set; }
    public double TotalAIGLoanRepayment { get; set; }
    public double TotalTotalSaving { get; set; }
    public int TotalMeetingParticipations { get; set; }
    public int TotalTrainingParticipations { get; set; }

    public List<AIGBasicInformationVM> AIGBasicInformations { get; set; } = new List<AIGBasicInformationVM>();
}
