using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.DTOs.Socle
{
    public class ActiveDirectoryUtilisateurDTO
    {
        public Guid Guid { get; set;}
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public String email { get; set; }


        //Numero de téléphone etc...

    }
}