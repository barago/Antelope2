using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Antelope.Domain.Models
{
    public class Thematique
    {
        public int ThematiqueId { get; set; }
        public string Nom { get; set; }

        [JsonIgnore]
        public virtual ICollection<NonConformite> NonConformites{ get; set; }
        [JsonIgnore]
        public virtual ICollection<DialogueSecurite> DialogueSecurites { get; set; }
        
    }
}
