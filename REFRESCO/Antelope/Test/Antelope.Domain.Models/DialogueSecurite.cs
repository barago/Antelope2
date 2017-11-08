using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antelope.Domain.Models
{
    public class DialogueSecurite
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Contexte {get; set;}
        public string Observation {get; set;}
        public string Reflexion { get; set; }
        public string Action {get; set;}
        public string Atelier {get ;set;}
        public int SiteId { get; set;}
        public int CompteurAnnuelSite { get; set; }
        public string Code { get; set; }
        public int ZoneId { get; set; }
        public int LieuId { get; set; }
        public int ThematiqueId { get; set; }
        public int Dialogueur1Id { get; set; }
        public int? Dialogueur2Id { get; set; }
        public int? Dialogueur3Id { get; set; }
        public int Entretenu1Id { get; set; }
        public int? Entretenu2Id { get; set; }
        public int? Entretenu3Id { get; set; }
        public int ServiceTypeDialogueur1Id { get; set; }
        public int? ServiceTypeDialogueur2Id { get; set; }
        public int? ServiceTypeDialogueur3Id { get; set; }
        public int ServiceTypeEntretenu1Id { get; set; }
        public int? ServiceTypeEntretenu2Id { get; set; }
        public int? ServiceTypeEntretenu3Id { get; set; }

        [JsonIgnore]
        public virtual Site Site { get; set; }
        [JsonIgnore]
        public virtual Zone Zone { get; set; }
        [JsonIgnore]
        public virtual Lieu Lieu { get; set; }
        [JsonIgnore]
        public virtual Thematique Thematique { get; set; }

        public virtual Personne Dialogueur1 { get; set; }

        public virtual Personne Dialogueur2 { get; set; }

        public virtual Personne Dialogueur3 { get; set; }

        public virtual Personne Entretenu1 { get; set; }

        public virtual Personne Entretenu2 { get; set; }

        public virtual Personne Entretenu3 { get; set; }

        public virtual ServiceType ServiceType { get; set; }

        public virtual ServiceType ServiceType1 { get; set; }

        public virtual ServiceType ServiceType2 { get; set; }

        public virtual ServiceType ServiceType3 { get; set; }

        public virtual ServiceType ServiceType4 { get; set; }

        public virtual ServiceType ServiceType5 { get; set; }
    }
}
