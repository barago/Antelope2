using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antelope.Domain.Models
{
    public class NonConformite
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description {get; set;}
        public string Attendu { get; set; }
        public string Cause { get; set; }
        public int NonConformiteOrigineId { get; set; }
        public int NonConformiteGraviteId { get; set; }
        public int NonConformiteDomaineId { get; set; }
        public int SiteId { get; set; }
        public string Code { get; set; }
        public DateTime DateCreation { get; set; }
        public int CompteurAnnuelSite { get; set; }
        public int ServiceTypeId { get; set; }

        public virtual ICollection<ActionQSE> ActionQSEs { get; set; }

        [JsonIgnore]
        public virtual ICollection<FilePath> FilePaths { get; set; }

        //[JsonIgnore]
        public virtual NonConformiteOrigine NonConformiteOrigine { get; set; }
        //[JsonIgnore]
        public virtual NonConformiteGravite NonConformiteGravite { get; set; }
        //[JsonIgnore]
        public virtual NonConformiteDomaine NonConformiteDomaine { get; set; }
        [JsonIgnore]
        public virtual ServiceType ServiceType { get; set; }
        //[JsonIgnore]
        public virtual Site Site{ get; set; }
    }
}