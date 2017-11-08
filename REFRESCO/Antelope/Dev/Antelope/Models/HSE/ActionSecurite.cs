using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.Models.HSE
{
    public class ActionSecurite
    {

        public Int32 ActionSecuriteId { get; set; }

        public Int32 FicheSecuriteId { get; set; }

        [JsonIgnore]
        public virtual FicheSecurite FicheSecurite { get; set; }

        public String Code {get; set;}
        public String Description {get; set;}
        public String FaitPar { get; set; }

    }
}