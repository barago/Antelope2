//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Antelope.Domain.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class CorpsHumainZone
    {
        public CorpsHumainZone()
        {
            this.FicheSecurites = new HashSet<FicheSecurite>();
        }
    
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Code { get; set; }
        public int Rang { get; set; }

        [JsonIgnore]
        public virtual ICollection<FicheSecurite> FicheSecurites { get; set; }
    }
}
