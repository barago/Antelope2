using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Antelope.Models.Socle
{
    public class PosteDeTravailType
    {

        public Int32 PosteDeTravailTypeId { get; set; }

        public string Nom { get; set; }

        [JsonIgnore]
        public virtual List<PosteDeTravail> PosteDeTravails { get; set; }

    }
}