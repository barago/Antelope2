using Antelope.Models.HSE;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.Models.Socle
{
    public class Zone
    {

        public Int32 ZoneID { get; set; }

        public Int32 SiteId { get; set; }

        [JsonIgnore]
        public virtual Site Site { get; set; }

        public Int32 ZoneTypeId { get; set; }

        public virtual ZoneType ZoneType { get; set; }

        [JsonIgnore]
        public virtual List<PosteDeTravail> PosteDeTravails { get; set; }

        //public String Nom { get; set; }

        //[JsonIgnore]
        //public virtual List<FicheSecurite> FicheSecurites { get; set; }

        //public Int32 SiteId { get; set; }

        //[JsonIgnore] 
        //public virtual Site Site { get; set; }
    }
}