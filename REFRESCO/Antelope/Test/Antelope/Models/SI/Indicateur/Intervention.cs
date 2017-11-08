using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Antelope.Models.SI.Indicateur
{
    public class Intervention
    {

        public Int32 InterventionID { get; set; }

        [DisplayName("Intervenant")]
        public string Intervenant { get; set; }
        [DisplayName("Date d'intervention")]
        public string DateIntervention { get; set; }
        [DisplayName("Planifié")]
        public Boolean Planifie { get; set; }
        [DisplayName("Demandeur")]
        public string Demandeur { get; set; }
        [DisplayName("Motif")]
        public string Motif { get; set; }
        [DisplayName("Durée d'intervention")]
        public int DureeIntervention { get; set; }
        [DisplayName("Note de frais")]
        public Boolean NoteFrais { get; set; }
        [DisplayName("Prime d'intervention")]
        public float PrimeIntervention { get; set; }
        [DisplayName("Prime dimanche et jour ferié")]
        public float PrimeDimanche { get; set; }
        [DisplayName("Validée")]
        public Boolean Valide { get; set; }

    }
}