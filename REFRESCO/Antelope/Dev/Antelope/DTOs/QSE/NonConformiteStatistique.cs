using Antelope.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.DTOs.QSE
{
    public class NonConformiteStatistique
    {
        public Int32 Id { get; set; }
        public DateTime DateEvnmt { get; set; }
        public String Site { get; set; }
        public Int32 TimeStamp { get; set; }
        public String FicheSecuriteType { get; set; }
        public Int32? SiteId { get; set; }
        public Int32? NonConformiteOrigineId { get; set; }
        public Int32? NonConformiteDomaineId { get; set; }
        public Int32? NonConformiteGraviteId { get; set; }
        public Personne Responsable { get; set; }
        public Int32 FicheSecurtiteTypeID { get; set; }
        public String Code { get; set; }
        //public Boolean WorkFlowASEValidee { get; set; }
        //public Boolean WorkFlowFicheSecuriteCloturee { get; set; }
        //public Boolean WorkFlowCloturee { get; set; }


        public virtual ICollection<ActionQSE> ActionQSEs { get; set; }
    }
}