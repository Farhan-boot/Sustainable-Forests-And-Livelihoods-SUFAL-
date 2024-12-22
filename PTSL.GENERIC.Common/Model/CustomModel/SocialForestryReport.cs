using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;

namespace PTSL.GENERIC.Common.Model.CustomModel
{
    public class SocialForestryReport
    {
        public NurseryInformation NurseryInformation { get; set; }
        public NurseryDistribution NurseryDistribution { get; set; }
        public NurseryRaisedSeedlingInformation NurseryRaisedSeedlingInformation { get; set; }
    }
}
