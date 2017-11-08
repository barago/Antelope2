using Antelope.Models.HSE;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.Models.Socle
{
    public class Lieu
    {

        public Int32 LieuID { get; set; }

        
        public Int32 ZoneId { get; set; }
        [JsonIgnore]
        public virtual Zone Zone{ get; set; }

        public Int32 LieuTypeId { get; set; }
        public virtual LieuType LieuType { get; set; }

        public String Nom { get; set; }

        //[JsonIgnore]
        //public virtual List<FicheSecurite> FicheSecurites { get; set; }

    }
}