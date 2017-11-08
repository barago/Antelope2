using Antelope.Models.Socle;
using Antelope.Models.QSE;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Antelope.Models.HSE
{
    public class FicheSecurite
    {

        public Int32 FicheSecuriteID { get; set; }

        [DisplayName("Code")]
        public String Code { get; set; }

        [DisplayName("Type")]
        public String Type { get; set; }

        [DisplayName("Âge")]
        public String Age { get; set; }

        //[DisplayName("Poste")]
        //public String PosteDeTravail {get; set;}

        [DisplayName("Poste de travail")]
        public Int32? PosteDeTravailId { get; set; }

        [JsonIgnore]
        public virtual PosteDeTravail PosteDeTravail { get; set; }

        [DisplayName("Service")]
        public Int32? ServiceId { get; set; }

        [JsonIgnore]
        public virtual Service Service { get; set; }

        //[DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yy}")]
        [Required]
        [DisplayName("Date créa.")]
        public DateTime DateCreation { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yy}", ApplyFormatInEditMode = true)]
        [Required]
        [DisplayName("Date évnmt.")]
        public DateTime DateEvenement { get; set; }
      
        //[DisplayName("Heure évnmt.")]
        //[DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:hh:mm}")]
        //public DateTime HeureEvenement { get; set; }

        [DisplayName("Pers. concern.")]
        public String PersonnesConcernees { get; set; }

        [Required(ErrorMessage = "{0} est un champ obligatoire")]
        [DisplayName("Description")] 
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }

        [DisplayName("Action immédiate 1")] 
        [DataType(DataType.MultilineText)]
        public String ActionImmediate1 { get; set; }

        [DisplayName("Action immédiate 2")] 
        [DataType(DataType.MultilineText)]
        public String ActionImmediate2 { get; set; }

        [DisplayName("Témoins")]
        public String Temoins { get; set; }

        [DisplayName("Fréquence d'exposition")]
        [DefaultValue(0)]
        public short CotationFrequence { get; set; }
        [DisplayName("Gravité")]
        [DefaultValue(0)]
        public short CotationGravite { get; set; }

        //[DisplayName("Risque")]
        //public String Risque { get; set; }

        [DisplayName("Type")]
        public Int32 FicheSecuriteTypeId { get; set;}

        [JsonIgnore] 
        public virtual FicheSecuriteType FicheSecuriteType {get; set;}

        [DisplayName("Risque")]
        public Int32 RisqueId { get; set; }

        [JsonIgnore]
        public virtual Risque Risque { get; set; }

        [DisplayName("Danger")]
        public Int32 DangerId { get; set; }

        [JsonIgnore]
        public virtual Danger Danger { get; set; }

        [DisplayName("Zone du corps")]
        public Int32 CorpsHumainZoneId { get; set; }

        [JsonIgnore]
        public virtual CorpsHumainZone CorpsHumainZone { get; set; }

        [DisplayName("Plage Horaire")]
        public Int32? PlageHoraireId { get; set; }

        [JsonIgnore]
        public virtual PlageHoraire PlageHoraire { get; set; }

         [DisplayName("Site")]
        public Int32 SiteId { get; set; }

        [JsonIgnore]
        public virtual Site Site { get; set; }

        [DisplayName("Zone")]
        public Int32? ZoneId { get; set; }

        [JsonIgnore]
        public virtual Zone Zone { get; set; }

        [DisplayName("Lieu")]
        public Int32? LieuId { get; set; }

        [JsonIgnore]
        public virtual Lieu Lieu { get; set; }

        //public virtual List<ActionSecurite> ActionSecurites{ get; set; }

        [DisplayName("Enquête réaliseé")]
        public Boolean EnqueteRealisee { get; set; }

        [DisplayName("Date enquête")]
        public Nullable<DateTime> EnqueteDate { get; set; }

        [DisplayName("Protagoniste enquête ")]
        public String EnqueteProtagoniste { get; set; }

        [DisplayName("Membre CHSCT")]
        public String CHSCTMembre { get; set; }

        [DisplayName("Personne Concernée")]
        public Int32? PersonneConcerneeId { get; set; }

        [ForeignKey("PersonneConcerneeId")]
        public virtual Personne PersonneConcernee { get; set; }

        [DisplayName("Responsable")]
        public Int32? ResponsableId { get; set; }

        [ForeignKey("ResponsableId")]
        public virtual Personne Responsable { get; set; }

        // Virtual = Lazy Loading
        public virtual List<CauseQSE> Causes { get; set; }

        //Etats de la fiche (Workflow)
        public Boolean WorkFlowDiffusee { get; set; }
        public Boolean WorkFlowAttenteASEValidation { get; set; }
        public Boolean WorkFlowASEValidee { get; set; }
        public Boolean WorkFlowASERejetee { get; set; }
        public Boolean WorkFlowCloturee { get; set; }

    }
}