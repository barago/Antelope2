using Antelope.Domain.Models;
using Antelope.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.ViewModels.QSE.NonConformiteViewModels
{
    public class RechercheNonConformiteViewModel
    {

        private AntelopeEntities db = new AntelopeEntities();

        //public NonConformitePaginatedList FicheSecuritePaginatedList;


        public List<Site> AllSite;
        public List<ServiceType> AllServiceType;
        public List<NonConformiteDomaine> AllNonConformiteDomaine;
        public List<NonConformiteOrigine> AllNonConformiteOrigine;
        public List<NonConformiteGravite> AllNonConformiteGravite;

        public RechercheNonConformiteParamModel RechercheNonConformiteParamModel;


        public RechercheNonConformiteViewModel(RechercheNonConformiteParamModel rechercheNonConformiteParamModel)
        {
            this.AllSite = db.Sites.ToList();
            this.AllServiceType = db.ServiceTypes.Where(w => w.Nom.Equals("Qualité R/D") || w.Nom.Equals("Sécurité/Environnement")).ToList();
            this.AllNonConformiteDomaine = db.NonConformiteDomaines.OrderBy(o => o.Nom).ToList();
            this.AllNonConformiteOrigine = db.NonConformiteOrigines.OrderBy(o => o.Nom).ToList();
            this.AllNonConformiteGravite = db.NonConformiteGravites.ToList();

            this.RechercheNonConformiteParamModel = rechercheNonConformiteParamModel;
        }

    }


}