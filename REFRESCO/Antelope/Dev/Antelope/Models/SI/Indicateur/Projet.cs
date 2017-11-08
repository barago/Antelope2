using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Antelope.Models.SI.Indicateur
{
    public class Projet
    {

        public Int32 ProjetID { get; set; }

        [DisplayName("Nom du projet")]
        public string NomProjet { get; set; }
        [DisplayName("Statut couleur")]
        public int StatutCouleur { get; set; }
        [DisplayName("Statut visage")]
        public int StatutVisage { get; set; }
        [DisplayName("Commentaire")]
        public string Commentaire { get; set; }
        [DisplayName("Prochaine étape")]
        public string ProchaineEtape { get; set; }
        [DisplayName("Date d'ouverture")]
        public string DateOuverture { get; set; }
        [DisplayName("Date de cloture")]
        public string DateCloture { get; set; }
        [DisplayName("Service SI")]
        public string Service { get; set; }

    }
}