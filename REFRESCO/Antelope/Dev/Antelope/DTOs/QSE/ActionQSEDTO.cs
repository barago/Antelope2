using Antelope.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Antelope.DTOs.QSE
{
    public class ActionQSEDTO
    {

        public int ActionQSEId { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public string Avancement { get; set; }
        public string CritereEfficaciteVerification { get; set; }
        public string CommentaireEfficaciteVerification { get; set; }
        public System.DateTime DateButoireInitiale { get; set; }
        public Nullable<System.DateTime> DateButoireNouvelle { get; set; }
        public Nullable<int> NonConformiteId { get; set; }

        public Nullable<System.DateTime> RealiseDate { get; set; }
        public Nullable<System.DateTime> VerifieDate { get; set; }
        public Nullable<System.DateTime> ClotureDate { get; set; }

        public virtual Personne Responsable { get; set; }
        public virtual Personne Verificateur { get; set; }
        public virtual NonConformite NonConformite { get; set; }

        public static Expression<Func<ActionQSEDTO, bool>> EnCours
        {
            get
            {
                return x =>
                   (x.RealiseDate == null && DateTime.Today <= x.DateButoireInitiale && x.DateButoireNouvelle == null) ||
                   (x.RealiseDate == null && DateTime.Today <= x.DateButoireInitiale && DateTime.Today <= x.DateButoireNouvelle);
            }
        }

        public static Expression<Func<ActionQSEDTO, bool>> Realisees
        {
            get
            {
                return x => x.RealiseDate != null && x.VerifieDate == null;
            }
        }
        public static Expression<Func<ActionQSEDTO, bool>> EnRetard
        {
            get
            {
                return x =>
                    (x.RealiseDate == null && x.VerifieDate == null && x.DateButoireNouvelle.HasValue && DateTime.Today > x.DateButoireNouvelle) ||
                    (x.RealiseDate == null && x.VerifieDate == null && DateTime.Today > x.DateButoireInitiale);
            }
        }
        public static Expression<Func<ActionQSEDTO, bool>> Cloturees
        {
            get
            {
                return x => x.RealiseDate != null && x.VerifieDate != null;
            }
        }
    }
}