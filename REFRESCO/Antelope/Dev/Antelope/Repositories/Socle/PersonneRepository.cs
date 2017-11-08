using Antelope.Infrastructure.EntityFramework;
using Antelope.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MMLib.Extensions;

namespace Antelope.Repositories.Socle
{
    public class PersonneRepository
    {

        public AntelopeEntities _db { get; set; }

        public PersonneRepository()
            : this(new AntelopeEntities())
        {

        }

        public PersonneRepository(AntelopeEntities db)
        {
            _db = db;
        }

        public Personne GetPersonneByNomPrenom(string Nom, string Prenom)
        {
            var queryPersonne = from p in _db.Personnes
                                where p.Nom == Nom
                                && p.Prenom == Prenom
                                select p;
            Personne personne = queryPersonne.FirstOrDefault();
            return personne;
        }




    }
}