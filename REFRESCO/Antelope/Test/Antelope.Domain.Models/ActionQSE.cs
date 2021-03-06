//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Antelope.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    
    public partial class ActionQSE
    {
        public int ActionQSEId { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public System.DateTime DateButoireInitiale { get; set; }
        public Nullable<System.DateTime> DateButoireNouvelle { get; set; }
        public int ResponsableId { get; set; }
        public string Avancement { get; set; }
        public short CotationHumain { get; set; }
        public short CotationOrganisationnel { get; set; }
        public short CotationTechnique { get; set; }
        public short CotationEfficacite { get; set; }
        public Nullable<int> VerificateurId { get; set; }
        public string PreuveVerification { get; set; }
        public string CommentaireEfficaciteVerification { get; set; }
        public bool Realise { get; set; }
        public Nullable<System.DateTime> RealiseDate { get; set; }
        public bool Verifie { get; set; }
        public Nullable<System.DateTime> VerifieDate { get; set; }
        public bool Cloture { get; set; }
        public Nullable<System.DateTime> ClotureDate { get; set; }
        public Nullable<int> CauseQSEId { get; set; }
        public Nullable<int> NonConformiteId { get; set; }
        public string CritereEfficaciteVerification { get; set; }


        [JsonIgnore]
        public virtual CauseQSE CauseQS { get; set; }
        public virtual Personne Responsable { get; set; }
        public virtual Personne Verificateur { get; set; }
        [JsonIgnore]
        public virtual NonConformite NonConformite{ get; set; }
    }
}
