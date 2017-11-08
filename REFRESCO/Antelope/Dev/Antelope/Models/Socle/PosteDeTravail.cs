using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Antelope.Models.HSE;
using Newtonsoft.Json;

namespace Antelope.Models.Socle
{
    public class PosteDeTravail
    {

        public Int32 PosteDeTravailId { get; set; }

       
        public Int32 ZoneId { get; set; }
        [JsonIgnore]
        public virtual Zone Zone { get; set; }

        public Int32 PosteDeTravailTypeId { get; set; }
        public virtual PosteDeTravailType PosteDeTravailType { get; set; }

        //public string Nom { get; set; }

        [JsonIgnore]
        public virtual List<FicheSecurite> FicheSecurites { get; set; }

    }
}