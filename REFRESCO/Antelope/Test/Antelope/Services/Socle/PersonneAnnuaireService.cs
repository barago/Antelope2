using Antelope.DTOs.Socle;
using Antelope.Infrastructure.EntityFramework;
using Antelope.Domain.Models;
using Antelope.Repositories.HSE;
using Antelope.Repositories.Socle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.Services.Socle
{
    public class PersonneAnnuaireService
    {

        public FicheSecuriteRepository _ficheSecuriteRepository { get; set; }
        public PersonneRepository _personneRepository { get; set; }
        public ActiveDirectoryUtilisateurRepository _activeDirectoryUtilisateurRepository { get; set; }
        //private AntelopeEntities db = new AntelopeEntities();

        public PersonneAnnuaireService()
        {
            _ficheSecuriteRepository = new FicheSecuriteRepository();
            _personneRepository = new PersonneRepository();
            _activeDirectoryUtilisateurRepository = new ActiveDirectoryUtilisateurRepository();
        }

        public PersonneAnnuaireService(AntelopeEntities db)
        {
            _ficheSecuriteRepository = new FicheSecuriteRepository();
            _personneRepository = new PersonneRepository(db);
            _activeDirectoryUtilisateurRepository = new ActiveDirectoryUtilisateurRepository();
        }

        //Permet grâce : à l'Id d'une Personne, de retourner celle-ci, 
        //Si l'ID n'est pas présent, on va la chercher dans l'Annuaire Applicatif (Table Personne) par son Nom/Prenom
        //Si la Personne n'est pas trouvée, on va la chercher sans l'Annuaire AD et la créer dans les Personnes
        //Si elle n'est pas trouvée non plus dans l'AD, on va la créer dans les Personnes, sans Guid.
        public Personne GetPersonneFromAllAnnuaireOrCreate(String Nom, String Prenom, Int32? PersonneId, AntelopeEntities db)
        {

            Personne personne;
            ActiveDirectoryUtilisateurDTO ResponsableActiveDirectoryUtilisateurDTO;

            if (PersonneId == null || PersonneId ==0 )
            {
                personne = _personneRepository.GetPersonneByNomPrenom(Nom, Prenom);
                if (personne == null)
                {
                    ResponsableActiveDirectoryUtilisateurDTO = _activeDirectoryUtilisateurRepository.GetActiveDirectoryUtilisateurByNomPrenom(Nom, Prenom);

                    if (ResponsableActiveDirectoryUtilisateurDTO == null)
                    {
                        personne = new Personne()
                        {
                            Nom = Nom,
                            Prenom = Prenom
                        };
                    }
                    else
                    {
                        personne = new Personne()
                        {
                            Nom = ResponsableActiveDirectoryUtilisateurDTO.Nom,
                            Prenom = ResponsableActiveDirectoryUtilisateurDTO.Prenom,
                            Guid = ResponsableActiveDirectoryUtilisateurDTO.Guid
                        };
                    }
                }
            }
            else
            {
                personne = db.Personnes.FirstOrDefault(p => p.PersonneId == PersonneId);
            }

            return personne;

        }

    }
}