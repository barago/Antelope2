using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Antelope.Models.HSE;

namespace Antelope.Models.Socle
{
    public class Service
    {
        public Int32 ServiceID { get; set; }

        public Int32 SiteId { get; set; }

        [JsonIgnore]
        public virtual Site Site { get; set; }

        public Int32 ServiceTypeId { get; set; }

        public virtual ServiceType ServiceType { get; set; }

    }
}