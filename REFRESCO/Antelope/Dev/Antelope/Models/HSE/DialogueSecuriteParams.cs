using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

using Antelope.Binders;

using Newtonsoft.Json;

namespace Antelope.Models.HSE
{
    /// <summary>
    /// Paramètres du filtre de la liste des dialogues sécurités.
    /// </summary>
    [ModelBinder(typeof(JsonDatatableBinder))]
    [JsonObject(MemberSerialization.OptOut)]
    public class DialogueSecuriteParams : JsonDatatable
    {
        public int SiteId { get; set; }
        public string Atelier { get; set; }

        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }

    }
}