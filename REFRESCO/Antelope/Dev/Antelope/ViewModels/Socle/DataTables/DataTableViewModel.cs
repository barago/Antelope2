using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.ViewModels.Socle.DataTables
{
    public class DataTableViewModel<T>
    {
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        //public int Echo { get;set; }

        public List<T> data { get; set; }
    }
}