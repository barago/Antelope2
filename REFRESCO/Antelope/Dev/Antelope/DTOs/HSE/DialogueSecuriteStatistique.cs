using Antelope.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.DTOs.HSE
{
    public class DialogueSecuriteStatistique
    {
        public Int32 Id { get; set; }
        public DateTime Date { get; set; }
        public String Site { get; set; }
        public Int32? ZoneId { get; set; }
        public Int32? SiteId { get; set; }
        public int Dialogueur1Id { get; set; }
        public int? Dialogueur2Id { get; set; }
        public int? Dialogueur3Id { get; set; }
        public int Entretenu1Id { get; set; }
        public int? Entretenu2Id { get; set; }
        public int? Entretenu3Id { get; set; }
        public Personne Dialogueur1 { get; set; }
        public Personne Dialogueur2 { get; set; }
        public Personne Dialogueur3 { get; set; }
        public Personne Entretenu1 { get; set; }
        public Personne Entretenu2 { get; set; }
        public Personne Entretenu3 { get; set; }
        public Int32 TimeStamp { get; set; }
        public int ThematiqueId { get; set; }
        public int ServiceTypeDialogueur1Id { get; set; }
        public int? ServiceTypeDialogueur2Id { get; set; }
        public int? ServiceTypeDialogueur3Id { get; set; }
        public int ServiceTypeEntretenu1Id { get; set; }
        public int? ServiceTypeEntretenu2Id { get; set; }
        public int? ServiceTypeEntretenu3Id { get; set; }
    }
}

