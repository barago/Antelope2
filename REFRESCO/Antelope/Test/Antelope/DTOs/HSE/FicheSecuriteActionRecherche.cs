using Antelope.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.DTOs.HSE
{
    public class FicheSecuriteActionRecherche
    {
        public FicheSecurite FicheSecurite {get; set;}
        public ActionQSE ActionQSE { get; set; }
        public CauseQSE CauseQSE { get; set; }


    }
}