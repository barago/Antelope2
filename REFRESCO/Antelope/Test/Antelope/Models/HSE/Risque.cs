using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Antelope.Models.HSE;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Antelope.Models.HSE
{
    public class Risque
    {
        public Int32 RisqueId { get; set; }

        public string Nom { get; set; }

        [DisplayName("Type de risque")]
        public Int32? RisqueTypeId { get; set; }

        [ForeignKey("RisqueTypeId")]
        public virtual RisqueType RisqueType { get; set; }

        [JsonIgnore]
        public virtual List<FicheSecurite> FicheSecurites { get; set; }

    }
}