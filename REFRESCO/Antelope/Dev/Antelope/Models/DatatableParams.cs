using System.Collections.Generic;
using System.Web.Http.ModelBinding;

using Antelope.Binders;

using Newtonsoft.Json;

namespace Antelope.Models
{
    /// <summary>
    /// Paramètre d'une datatable.
    /// </summary>
    [ModelBinder(typeof(JsonDatatableBinder))]
    [JsonObject(MemberSerialization.OptOut)]
    public class JsonDatatable
    {
        /// <summary>
        /// Draw.
        /// </summary>
        [JsonProperty("draw")]
        public int Draw { get; set; }

        /// <summary>
        /// Start.
        /// </summary>
        [JsonProperty("start")]
        public int Start { get; set; }

        /// <summary>
        /// Nombre.
        /// </summary>
        [JsonProperty("length")]
        public int Length { get; set; }

        /// <summary>
        /// Paramètre de recherche.
        /// </summary>
        [JsonProperty("search")]
        public JsonDatatableSearch Search { get; set; }

        /// <summary>
        /// Paramètre d'ordonnancement.
        /// </summary>
        [JsonProperty("order")]
        public List<JsonDatableOrder> Order { get; set; }

        /// <summary>
        /// Paramètre des colonnes.
        /// </summary>
        [JsonProperty("columns")]
        public List<JsonDatatableColumn> Columns { get; set; }

        /// <summary>
        /// Détermine si on doit récupérer les paramètres du cookie.
        /// </summary>
        public bool IsRefresh { get; set; }
    }

    /// <summary>
    /// Paramètre de recherche d'une datatable.
    /// </summary>
    public class JsonDatatableSearch
    {
        /// <summary>
        /// Valeur de la recherche.
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }

        /// <summary>
        /// Détermine si interpréter la recherche au format regex.
        /// </summary>
        [JsonProperty("regex")]
        public bool IsRegex { get; set; }
    }

    /// <summary>
    /// Paramètre d'ordonnancement d'une datatable.
    /// </summary>
    public class JsonDatableOrder
    {
        /// <summary>
        /// Colonne d'ordonnancement.
        /// </summary>
        [JsonProperty("column")]
        public int OrderingColumn { get; set; }

        /// <summary>
        /// Asc" ou "desc".
        /// </summary>
        [JsonProperty("dir")]
        public string OrderingDirection { get; set; }
    }

    /// <summary>
    /// Paramètre de colonne de la datatable.
    /// </summary>
    public class JsonDatatableColumn
    {
        /// <summary>
        /// Donnée de la colonne.
        /// </summary>
        [JsonProperty("data")]
        public string Data { get; set; }

        /// <summary>
        /// Nom de la colonne.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Détermine si un filtre est applicable sur la colonne.
        /// </summary>
        [JsonProperty("searchable")]
        public bool Searchable { get; set; }

        /// <summary>
        /// Détermine si la colonne ordonnable.
        /// </summary>
        [JsonProperty("orderable")]
        public bool Orderable { get; set; }

        /// <summary>
        /// Définit la recherche propre à la colonne de la datatable.
        /// </summary>
        [JsonProperty("search")]
        public JsonDatatableSearch Search { get; set; }
    }
}