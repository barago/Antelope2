using Antelope.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.DTOs.HSE
{
    public class FicheSecuriteStatistique
    {
        public Int32 Id { get; set; }
        public DateTime DateEvnmt { get; set; }
        public String Site { get; set; }
        public Int32 TimeStamp { get; set; }
        public String FicheSecuriteType { get; set; }
        public Int32? ZoneId { get; set; }
        public Int32? SiteId { get; set; }
        public Int32? ServiceId { get; set; }
        public Personne Responsable { get; set; }
        public Int32 FicheSecurtiteTypeID { get; set; }
        public Boolean WorkFlowASEValidee { get; set; }
        public Boolean WorkFlowFicheSecuriteCloturee { get; set; }
        public Boolean WorkFlowCloturee { get; set; }

        public string Service { get; set; }
        public string Danger { get; set; }
        public int DangerId { get; set; }
        public int CorpsHumainZoneId { get; set; }
        public string CorpsHumainZoneCode { get; set; }
        public string CorpsHumainZone { get; set; }
        public virtual ICollection<CauseQSE> CauseQSEs { get; set; }
    }
}

