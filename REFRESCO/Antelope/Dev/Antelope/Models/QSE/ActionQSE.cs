using Antelope.Models.Socle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Antelope.Models.QSE
{
    public class ActionQSE
    {

        public Int32 ActionQSEId { get; set; }

        //SE
        public string Description { get; set; }

        //SE
        public DateTime DateButoireInitiale { get; set; }
        //SE
        public DateTime? DateButoireNouvelle { get; set; }

        //SE
        [DisplayName("Responsable")]
        public Int32 ResponsableId { get; set; }

        [ForeignKey("ResponsableId")]
        public virtual Personne Responsable { get; set; }

        public string Avancement { get; set; }

        [DisplayName("Cotation Humain")]
        [DefaultValue(0)]
        public short CotationHumain { get; set; }

        [DisplayName("Cotation Organisationnel")]
        [DefaultValue(0)]
        public short CotationOrganisationnel { get; set; }

        [DisplayName("Cotation Technique")]
        [DefaultValue(0)]
        public short CotationTechnique { get; set; }

        [DisplayName("Cotation Efficacité")]
        [DefaultValue(0)]
        public short CotationEfficacite { get; set; }

        [DisplayName("Verificateur")]
        public Int32? VerificateurId { get; set; }

        [ForeignKey("VerificateurId")]
        public virtual Personne Verificateur { get; set; }

        public string PreuveVerification { get; set; }

        public string CommentaireEfficaciteVerification { get; set; }

        public Boolean Realise { get; set; }
        public DateTime? RealiseDate { get; set; }
        public Boolean Verifie { get; set; }
        public DateTime? VerifieDate { get; set; }
        //SE
        public Boolean Cloture { get; set; }
        //SE
        public DateTime? ClotureDate { get; set; }

        [DisplayName("Cause")]
        public Int32 CauseQSEId { get; set; }

        [JsonIgnore]
        public virtual CauseQSE CauseQSE { get; set; }
    }
}