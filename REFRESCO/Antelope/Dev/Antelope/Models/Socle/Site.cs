using Antelope.Models.HSE;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.Models.Socle
{
    public class Site
    {

        public Int32 SiteID { get; set; }

        public String Nom { get; set; }

        public String Trigramme { get; set; }

        public String Arouperr { get; set; }

        // Virtual = Lazy Loading
        [JsonIgnore]
        public virtual List<FicheSecurite> FicheSecurites { get; set; }

    }
}