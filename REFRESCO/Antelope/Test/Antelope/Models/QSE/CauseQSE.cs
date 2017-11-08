using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Antelope.Models.HSE;


namespace Antelope.Models.QSE
{
    public class CauseQSE
    {

        public Int32 CauseQSEId { get; set; }

        public string Description { get; set; }

        [DisplayName("Fiche Sécurité")]
        public Int32 FicheSecuriteId { get; set; }

        [JsonIgnore]
        public virtual FicheSecurite FicheSecurite { get; set; }

        // Virtual = Lazy Loading
        public virtual List<ActionQSE> Actions { get; set; }


    }
}