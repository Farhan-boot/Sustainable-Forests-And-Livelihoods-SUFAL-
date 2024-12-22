using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;

namespace PTSL.GENERIC.Common.Model.CustomModel
{
    public class JqueryDatatableParamVM
    {
        public string sEcho { get; set; }
        public string sSearch { get; set; }
        public int? iDisplayLength { get; set; }
        public int? iDisplayStart { get; set; }
        public int iColumns { get; set; }
        public int iSortCol_0 { get; set; }
        public string sSortDir_0 { get; set; }
        public int iSortingCols { get; set; }
        public string sColumns { get; set; }
    }
}
