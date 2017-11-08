using Antelope.Models.HSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Antelope.Models.Socle
{
    public class Personne
    {

        public Int32 PersonneId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Guid Guid { get; set; }

        [JsonIgnore]
        public virtual List<FicheSecurite> FicheSecurites { get; set; }

    }
}