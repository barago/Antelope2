using Antelope.Infrastructure.EntityFramework;
using Antelope.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.ViewModels.HSE.DialogueSecuriteViewModels
{
    public class RechercheDialogueSecuriteViewModel
    {

        private AntelopeEntities db = new AntelopeEntities();

        //public NonConformitePaginatedList FicheSecuritePaginatedList;


        public List<Site> AllSite;


        public RechercheDialogueSecuriteParamModel RechercheDialogueSecuriteParamModel;


        public RechercheDialogueSecuriteViewModel(RechercheDialogueSecuriteParamModel rechercheDialogueSecuriteParamModel)
        {
            this.AllSite = db.Sites.ToList();

            this.RechercheDialogueSecuriteParamModel = rechercheDialogueSecuriteParamModel;
        }

    }
}