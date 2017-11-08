using Antelope.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.DTOs.QSE
{
    public class NonConformiteActionRecherche
    {
        public NonConformite NonConformite{ get; set; }
        public ActionQSE ActionQSE { get; set; }
    }
}