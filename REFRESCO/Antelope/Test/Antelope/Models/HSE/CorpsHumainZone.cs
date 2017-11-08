using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.Models.HSE
{
    public class CorpsHumainZone
    {
        public Int32 Id { get; set; }

        public string Nom { get; set; }
        public string Code { get; set; }

        // Virtual = Lazy Loading
        [JsonIgnore]
        public virtual List<FicheSecurite> FicheSecurites { get; set; }
    }
}