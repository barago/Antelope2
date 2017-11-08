using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antelope.Domain.Models
{
    public class ImportAction
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public System.DateTime DateButoireInitiale { get; set; }
        public Nullable<System.DateTime> DateButoireNouvelle { get; set; }
        public string ResponsableNom { get; set; }
        public string ResponsablePrenom { get; set; }
        public string Avancement { get; set; }
        public String VerificateurNom { get; set; }
        public String VerificateurPrenom { get; set; }
        public string PreuveVerification { get; set; }
        public string CommentaireEfficaciteVerification { get; set; }
        public Nullable<System.DateTime> RealiseDate { get; set; }
        public Nullable<System.DateTime> VerifieDate { get; set; }
        public int NonConformiteId { get; set; }
        public string CritereEfficaciteVerification { get; set; }

        [JsonIgnore]
        public virtual ImportNonConformite ImportNonConformite { get; set; }


    }
}
