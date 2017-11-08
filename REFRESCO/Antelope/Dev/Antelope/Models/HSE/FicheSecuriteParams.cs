using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

using Antelope.Binders;
using Antelope.Services.HSE.Enums;

using Newtonsoft.Json;

namespace Antelope.Models.HSE
{
    /// <summary>
    /// Paramètres du filtre de la liste des fiches sécurités.
    /// </summary>
    [ModelBinder(typeof(JsonDatatableBinder))]
    [JsonObject(MemberSerialization.OptOut)]
    public class FicheSecuriteParams : JsonDatatable
    {
        /// <summary>
        /// Identifiant unique du site.
        /// </summary>
        public int SiteId { get; set; }

        /// <summary>
        /// Identifiant unique de la zone.
        /// </summary>
        public int ZoneId { get; set; }

        /// <summary>
        /// Identifiant unique du lieu.
        /// </summary>
        public int LieuId { get; set; }

        /// <summary>
        /// Identifiant unique du type.
        /// </summary>
        [JsonProperty("FicheSecuriteTypeId")]
        public int TypeId { get; set; }

        /// <summary>
        /// Identifiant unique du poste de travail.
        /// </summary>
        public int PosteDeTravailId { get; set; }

        /// <summary>
        /// Identifiant unique du service.
        /// </summary>
        public int ServiceId { get; set; }

        /// <summary>
        /// Identifiant unique du risque.
        /// </summary>
        public int RisqueId { get; set; }

        /// <summary>
        /// Identifiant unique du danger.
        /// </summary>
        public int DangerId { get; set; }

        /// <summary>
        /// Identifiant unique de la zone du corps humain.
        /// </summary>
        public int CorpsHumainZoneId { get; set; }

        /// <summary>
        /// Identifiant unique de la plage horaire.
        /// </summary>
        public int PlageHoraireId { get; set; }

        /// <summary>
        /// Fréquence de la criticité.
        /// </summary>
        public int? CotationFrequence { get; set; }

        /// <summary>
        /// Gravité de la criticité.
        /// </summary>
        public int? CotationGravite { get; set; }

        /// <summary>
        /// Criticité = fréquence x gravité.
        /// </summary>
        public int Criticite { get; set; }

        /// <summary>
        /// Niveau de criticité.
        /// </summary>
        public CriticiteNiveauEnum CriticiteNiveau { get; set; }

        /// <summary>
        /// Si nouvelle fiche.
        /// </summary>
        public bool IsNouvelleFiche { get; set; }

        /// <summary>
        /// Si action validé.
        /// </summary>
        public bool IsPlanActionValide { get; set; }

        /// <summary>
        /// Si plan d'action en attente.
        /// </summary>
        public bool IsPlanActionAttente { get; set; }

        /// <summary>
        /// Si plan d'action rejeté.
        /// </summary>
        public bool IsPlanActionRejete { get; set; }

        /// <summary>
        /// Si plan d'action clôturé.
        /// </summary>
        public bool IsPlanActionCloture { get; set; }

        /// <summary>
        /// Si fiche sécurité clôturée.
        /// </summary>
        public bool IsFicheSecuriteCloture { get; set; }

        /// <summary>
        /// Code de la fiche sécurité.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Age de la fiche sécurité.
        /// </summary>
        public string Age { get; set; }

        /// <summary>
        /// Nom de la personne concernée.
        /// </summary>
        public string PersonneConcerneeNom { get; set; }

        /// <summary>
        /// Nom du responsable.
        /// </summary>
        public string ResponsableNom { get; set; }

        /// <summary>
        /// Nom du responsable de l'action.
        /// </summary>
        public string ResponsableNomAction { get; set; }

        /// <summary>
        /// Type de recherche.
        /// </summary>
        [JsonProperty("typeRecherche")]
        public string RechercheType { get; set; }

        /// <summary>
        /// Date de début.
        /// </summary>
        public DateTime? DateEvenementDebut { get; set; }

        /// <summary>
        /// Date de fin.
        /// </summary>
        public DateTime? DateEvenementFin { get; set; }

        /// <summary>
        /// Première date butoire.
        /// </summary>
        public DateTime? DateButoirDebut { get; set; }

        /// <summary>
        /// Dernière date butoire.
        /// </summary>
        public DateTime? DateButoirFin { get; set; }

        /// <summary>
        /// Première date de clôture.
        /// </summary>
        public DateTime? DateClotureDebut { get; set; }

        /// <summary>
        /// Dernière date de clôture.
        /// </summary>
        public DateTime? DateClotureFin { get; set; }

        /// <summary>
        /// Obtient tous les filtres de type boolean.
        /// </summary>
        /// <returns>Liste des filtre boolean.</returns>
        public List<bool> GetBoolFilters()
        {
            return new List<bool> { IsNouvelleFiche, IsPlanActionValide, IsPlanActionAttente, IsPlanActionRejete, IsPlanActionCloture, IsFicheSecuriteCloture };
        }
    }
}