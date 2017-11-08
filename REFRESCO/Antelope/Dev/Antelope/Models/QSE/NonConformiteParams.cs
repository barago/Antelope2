using System;
using System.Web.Http.ModelBinding;

using Antelope.Binders;

using Newtonsoft.Json;

namespace Antelope.Models.QSE
{
    /// <summary>
    /// Paramètres du filtre de la liste des non conformités.
    /// </summary>
    [ModelBinder(typeof(JsonDatatableBinder))]
    [JsonObject(MemberSerialization.OptOut)]
    public class NonConformiteParams : JsonDatatable
    {
        /// <summary>
        /// Identifiant unique du site.
        /// </summary>
        public int SiteId { get; set; }

        /// <summary>
        /// Identifiant unique de type de service.
        /// </summary>
        public int ServiceTypeId { get; set; }

        /// <summary>
        /// Identifiant unique de l'origine de la non conformité.
        /// </summary>
        public int NonConformiteOrigineId { get; set; }

        /// <summary>
        /// Identifiant unique du domaine de la non conformité.
        /// </summary>
        public int NonConformiteDomaineId { get; set; }

        /// <summary>
        /// Identifiant unique de la gravité de la non conformité.
        /// </summary>
        public int NonConformiteGraviteId { get; set; }

        /// <summary>
        /// Nom du responsable de la non conformité.
        /// </summary>
        public string ResponsableNom { get; set; }

              /// <summary>
        /// Date butoir de début de la non conformité.
        /// </summary>
        public DateTime? DateButoirDebut { get; set; }

        /// <summary>
        /// Date butoir de fin de la non conformité.
        /// </summary>
        public DateTime? DateButoirFin { get; set; }

        /// <summary>
        /// Détermine si la non conformité est en cours.
        /// </summary>
        public bool IsNCEnCours { get; set; }

        /// <summary>
        /// Détermine si la non conformité est clôturée.
        /// </summary>
        public bool IsNCCloture { get; set; }

        /// <summary>
        /// Code de la non conformité.
        /// </summary>
        public string NonConformiteCode { get; set; }

        /// <summary>
        /// Détermine si on affiche les non conformité archivés.
        /// </summary>
        public bool ShowArchived { get; set; }
    }
}