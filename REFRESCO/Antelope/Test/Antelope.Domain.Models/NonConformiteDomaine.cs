using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antelope.Domain.Models
{
    public class NonConformiteDomaine
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        [JsonIgnore]
        public virtual ICollection<NonConformite> NonConformites { get; set; }
    }
}
