using Antelope.Domain.Models;
using Antelope.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.ViewModels.HSE.DialogueSecuriteViewModels
{
    public class DialogueSecuriteViewModel
    {
        private AntelopeEntities db = new AntelopeEntities();

        public DialogueSecurite DialogueSecurite;
        public List<Site> AllSite;
        public List<Zone> AllZone;
        public List<Lieu> AllLieu;
        public List<Thematique> AllThematique;
        public List<ServiceType> AllServiceType;


        public DialogueSecuriteViewModel(DialogueSecurite dialogueSecurite)
        {
            this.DialogueSecurite = dialogueSecurite; 
            this.AllSite = db.Sites.ToList();
            this.AllZone = new List<Zone>();
            this.AllLieu = new List<Lieu>();
            this.AllThematique = db.Thematiques.ToList();
            this.AllServiceType = db.ServiceTypes.ToList();
        }

        public DialogueSecuriteViewModel(DialogueSecurite dialogueSecurite, List<Zone>AllZone, List<Lieu>AllLieu )
        {
            this.DialogueSecurite = dialogueSecurite;
            this.AllSite = db.Sites.ToList();
            this.AllZone = AllZone;
            this.AllLieu = AllLieu;
            this.AllThematique = db.Thematiques.ToList();
            this.AllServiceType = db.ServiceTypes.ToList();
        }

    }
}