using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Antelope.Models.HSE;
using Newtonsoft.Json;

namespace Antelope.Models.Socle
{
    public class PlageHoraire
    {

        public Int32 PlageHoraireID { get; set; }

        public string Nom { get; set; }

        // Virtual = Lazy Loading
        [JsonIgnore]
        public virtual List<FicheSecurite> FicheSecurites { get; set; }
    }
}