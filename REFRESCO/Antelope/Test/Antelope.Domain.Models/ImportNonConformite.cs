using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antelope.Domain.Models
{
    public class ImportNonConformite
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Attendu { get; set; }
        public string Cause { get; set; }
        public int NonConformiteOrigineId { get; set; }
        public int NonConformiteGraviteId { get; set; }
        public int NonConformiteDomaineId { get; set; }
        public int SiteId { get; set; }
        public string Code { get; set; }
        public DateTime DateCreation { get; set; }
        public int CompteurAnnuelSite { get; set; }

        public virtual ICollection<ImportAction> ImportActions { get; set; }

    }
}
