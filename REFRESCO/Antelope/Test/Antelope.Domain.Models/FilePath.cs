using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antelope.Domain.Models
{
    public class FilePath
    {
        public int FilePathId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public Nullable<int> NonConformiteId { get; set; }
        public Nullable<int> FicheSecuriteId { get; set; }
        public bool Show { get; set; }

        [JsonIgnore]
        public virtual NonConformite NonConformite { get; set; }
        [JsonIgnore]
        public virtual FicheSecurite FicheSecurite { get; set; }
    }
}
