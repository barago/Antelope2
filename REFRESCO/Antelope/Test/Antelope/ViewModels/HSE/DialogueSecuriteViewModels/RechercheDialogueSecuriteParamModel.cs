using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.ViewModels.HSE.DialogueSecuriteViewModels
{
    public class RechercheDialogueSecuriteParamModel
    {
        
        //TODO : Certainement à reclassifier en DTO : RechercheNonConformiteDTOModel
        public Int32? SiteId { get; set; }
        public String Atelier { get; set; }

        // public RechercheNonConformiteParamModel rechercheNonConformiteParamModel{ get; set;}

        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
    }
}