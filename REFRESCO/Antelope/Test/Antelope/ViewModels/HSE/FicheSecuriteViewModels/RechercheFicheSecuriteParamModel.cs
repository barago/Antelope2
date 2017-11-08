using Antelope.Services.HSE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.ViewModels.HSE.FicheSecuriteViewModels
{
    public class RechercheFicheSecuriteParamModel
    {
        //TODO : Certainement à reclassifier en DTO : RechercheFicheSecuriteDTOModel
        public Int32? SiteId { get; set; }
        public Int32? ZoneId { get; set; }
        public Int32? LieuId { get; set; }
        public Int32? FicheSecuriteTypeId { get; set; }
        public String Code { get; set; }
        public String Age { get; set; }
        public Int32? PosteDeTravailId { get; set; }
        public Int32? ServiceId { get; set; }
        public DateTime? DateEvenementDebut { get; set; }
        public DateTime? DateEvenementFin { get; set; }
        public String PersonneConcerneeNom { get; set; }
        public String ResponsableNom { get; set; }
        public short? CotationFrequence { get; set; }
        public short? CotationGravite { get; set; }
        public Int32? RisqueId { get; set; }
        public Int32? DangerId { get; set; }
        public Int32? CorpsHumainZoneId { get; set; }
        public Int32? PlageHoraireId { get; set; }
        public Guid? ResponsableGuid { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }
        public Boolean IsNouvelleFiche { get; set; }
        public Boolean IsPlanActionValide { get; set; }
        public Boolean IsPlanActionAttente { get; set; }
        public Boolean IsPlanActionRejete { get; set; }
        public Boolean IsPlanActionCloture { get; set; }
        public Boolean IsFicheSecuriteCloture { get; set; }
        public DateTime? DateButoirDebut { get; set; }
        public DateTime? DateButoirFin { get; set; }
        public DateTime? DateClotureDebut { get; set; }
        public DateTime? DateClotureFin { get; set; }
        public String ResponsableNomAction { get; set; }
        public Int32? Criticite { get; set; }
        public CriticiteNiveauEnum CriticiteNiveau {get; set;} 
    }
}