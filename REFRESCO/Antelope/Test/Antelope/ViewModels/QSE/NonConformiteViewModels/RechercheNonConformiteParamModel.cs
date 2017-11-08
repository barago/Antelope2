using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.ViewModels.QSE.NonConformiteViewModels
{
    public class RechercheNonConformiteParamModel
    {

        //TODO : Certainement à reclassifier en DTO : RechercheNonConformiteDTOModel
        public Int32? SiteId { get; set; }
        public Int32? NonConformiteOrigineId { get; set; }
        public Int32? NonConformiteGraviteId { get; set; }
        public Int32? NonConformiteDomaineId { get; set; }
        public String ResponsableNom { get; set; }
        public String VerificateurNom { get; set; }
        public Boolean IsNCEnCours { get; set; }
        public Boolean IsNCCloture { get; set; }
        public Boolean IsActionEnCours { get; set; }
        public Boolean IsActionRealise { get; set; }
        public Boolean IsActionRetard { get; set; }
        public Boolean IsActionCloture { get; set; }
        public Int32 ServiceTypeId { get; set; }

       // public RechercheNonConformiteParamModel rechercheNonConformiteParamModel{ get; set;}

        public DateTime? DateButoirDebut { get; set; }
        public DateTime? DateButoirFin { get; set; }



    }
}