using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;

namespace PTSL.GENERIC.Common.Model.CustomModel
{
    public class PaginationResutl<T>
    {
        public int? iTotalRecords { get; set; }
        public int? iTotalDisplayRecords { get; set; }
        public IList<T> aaData { get; set; } = new List<T>();
    }
}
