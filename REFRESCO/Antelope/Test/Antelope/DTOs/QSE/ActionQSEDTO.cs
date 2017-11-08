﻿using Antelope.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}