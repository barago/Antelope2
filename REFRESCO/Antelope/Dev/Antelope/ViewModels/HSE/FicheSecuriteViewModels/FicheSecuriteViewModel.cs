using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Antelope.Domain.Models;
using Antelope.Infrastructure.EntityFramework;


namespace Antelope.ViewModels.HSE.FicheSecuriteViewModels
{

    public class FicheSecuriteViewModel
    {

        private AntelopeEntities db = new AntelopeEntities();

        public FicheSecurite FicheSecurite;
        public List<Zone> AllZone;
        public List<Lieu> AllLieu;
        public List<Site> AllSite;
        public List<Service> AllService;
        public List<PosteDeTravail> AllPosteDeTravail;
        public List<FicheSecuriteType> AllFicheSecuriteType;
        public List<Danger> AllDanger;
        public List<PlageHoraire> AllPlageHoraire;
        public List<CorpsHumainZone> AllCorpsHumainZone;
        public List<RisqueType> AllRisqueType;
        public List<Risque> AllRisque;
        public String FicheSecuriteDate;
        public String FicheSecuriteHeure;

        public FicheSecuriteViewModel()
        {

            this.FicheSecurite = new FicheSecurite();
            this.AllZone = new List<Zone>();
            this.AllLieu = new List<Lieu>();
            this.AllSite = db.Sites.ToList(); // new List<Site>();
            this.AllFicheSecuriteType = db.FicheSecuriteTypes.ToList();
            this.AllDanger = db.Dangers.ToList();
            this.AllPlageHoraire = db.PlageHoraires.ToList();
            this.AllRisqueType = db.RisqueTypes.ToList();
            this.AllRisque = db.Risques.ToList();
        }

        public FicheSecuriteViewModel(
            FicheSecurite ficheSecurite, List<Zone> AllZone, List<Lieu> AllLieu, List<Service> AllService, List<PosteDeTravail> AllPosteDeTravail
            )
        {
            this.FicheSecurite = ficheSecurite;
            this.AllZone = AllZone;
            this.AllLieu = AllLieu;
            this.AllService = AllService;
            this.AllPosteDeTravail = AllPosteDeTravail;
            this.AllSite = db.Sites.ToList(); // new List<Site>();
            this.AllFicheSecuriteType = db.FicheSecuriteTypes.ToList();
            this.AllDanger = db.Dangers.ToList();
            this.AllPlageHoraire = db.PlageHoraires.ToList();
            this.AllCorpsHumainZone = db.CorpsHumainZones.ToList();
            this.AllRisqueType = db.RisqueTypes.ToList();
            this.AllRisque = db.Risques.ToList();
            this.FicheSecuriteDate = this.FicheSecurite.DateEvenement.Date.ToString("dd/MM/yyyy");
            this.FicheSecuriteHeure = this.FicheSecurite.DateEvenement.Date.ToString("HH:mm");

        }

    }
}