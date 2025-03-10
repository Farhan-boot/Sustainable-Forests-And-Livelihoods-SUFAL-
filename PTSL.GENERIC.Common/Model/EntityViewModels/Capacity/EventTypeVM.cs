﻿using PTSL.GENERIC.Common.Model.BaseModels;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Capacity
{
    public class EventTypeVM : BaseModel
    {
        public string? Name { get; set; }
        public string? NameBn { get; set; }
        public bool HasTrainingType { get; set; }

        //public List<CommunityTrainingVM>? CommunityTrainings { get; set; }
    }
}
