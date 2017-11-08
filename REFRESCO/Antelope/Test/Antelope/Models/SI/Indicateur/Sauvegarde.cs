using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Antelope.Models.SI.Indicateur
{
    public class Sauvegarde
    {

        public Int32 SauvegardeID { get; set; }

        [DisplayName("Site")]
        public string Site { get; set; }
        [DisplayName("Date")]
        public double Date { get; set; }
        [DisplayName("Volume")]
        public float Volume { get; set; }
        [DisplayName("Taux")]
        public float Taux { get; set; }
        [DisplayName("Durée")]
        public int Duree { get; set; }
    }
}