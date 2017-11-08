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
    
    public partial class ServiceType
    {
        public ServiceType()
        {
            this.Services = new HashSet<Service>();
        }
    
        public int ServiceTypeId { get; set; }
        public string Nom { get; set; }
        public Nullable<int> Rang { get; set; }

        [JsonIgnore]
        public virtual ICollection<Service> Services { get; set; }
        [JsonIgnore]
        public virtual ICollection<NonConformite> NonConformites { get; set; }
        [JsonIgnore]
        public virtual ICollection<NonConformiteOrigine> NonConformiteOrigines { get; set; }
        [JsonIgnore]
        public virtual ICollection<DialogueSecurite> DialogueSecurites { get; set; }
        [JsonIgnore]
        public virtual ICollection<DialogueSecurite> DialogueSecurites1 { get; set; }
        [JsonIgnore]
        public virtual ICollection<DialogueSecurite> DialogueSecurites2 { get; set; }
        [JsonIgnore]
        public virtual ICollection<DialogueSecurite> DialogueSecurites3 { get; set; }
        [JsonIgnore]
        public virtual ICollection<DialogueSecurite> DialogueSecurites4 { get; set; }
        [JsonIgnore]
        public virtual ICollection<DialogueSecurite> DialogueSecurites5 { get; set; }
    }
}