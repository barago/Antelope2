using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Antelope.Models.HSE
{
    public class RisqueType
    {
        public Int32 RisqueTypeId { get; set; }

        public string Nom { get; set; }

        [JsonIgnore]
        public virtual List<Risque> Risques { get; set; }

    }
}