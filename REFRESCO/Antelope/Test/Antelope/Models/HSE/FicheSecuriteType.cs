using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Antelope.Models.HSE
{
    public class FicheSecuriteType
    {

        public Int32 FicheSecuriteTypeID { get; set; }

        [DisplayName("Nom")]
        public String Nom { get; set; }

        [JsonIgnore]
        public virtual List<FicheSecurite> FicheSecurites { get; set; }

    }
}