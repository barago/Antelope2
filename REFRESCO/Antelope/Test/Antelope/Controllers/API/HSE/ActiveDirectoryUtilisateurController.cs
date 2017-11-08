using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Antelope.Domain.Models;
using Antelope.ViewModels.Socle.ActiveDirectory;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using Antelope.Infrastructure.EntityFramework;

namespace Antelope.Controllers.API.HSE
{
    public class ActiveDirectoryUtilisateurController : ApiController
    {
        private AntelopeEntities db = new AntelopeEntities();



        public HttpResponseMessage GetActiveDirectoryUtilisateurByNomPrenom(int id, string param1, string param2)  // [FromUri] ActiveDirectoryUtilisateurViewModel activeDirectoryUtilisateurViewModel
        {

            List<ActiveDirectoryUtilisateurViewModel> allActiveDirectoryViewModel = new List<ActiveDirectoryUtilisateurViewModel>();
            List<Guid> AllGuid = new List<Guid>();
            List<Personne> AllPersonne = new List<Personne>();

            var context = new PrincipalContext(ContextType.Domain, "refresco.local"); //"refresco.local" > Pas obligatoire ?
            //define a "query-by-example" principal - here, we search for a UserPrincipal 
            //and with the first name (GivenName) and a last name (Surname) 
            UserPrincipal qbeUser = new UserPrincipal(context);

            if(param2 != "undefined"){
                qbeUser.GivenName = "*" + param2 + "*";
            }
            if (param1 != "undefined")
            {
                qbeUser.Surname = "*" + param1 + "*";
            }

            // create your principal searcher passing in the QBE principal    
            PrincipalSearcher srch = new PrincipalSearcher(qbeUser);


            // find all matches
            foreach (var result in srch.FindAll())
            {
                DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                System.Diagnostics.Debug.WriteLine("First Name: " + de.Properties["givenName"].Value + " " + "Last Name : " + de.Properties["sn"].Value);

                allActiveDirectoryViewModel.Add(
                    new ActiveDirectoryUtilisateurViewModel
                    {
                        Nom = (string)de.Properties["sn"].Value,
                        Prenom = (string)de.Properties["givenName"].Value,
                        Guid = (Guid)result.Guid,
                        IsAnnuaireAD = true,
                        IsAnnuaireApplication = false
                    }
                );

                AllGuid.Add((Guid)result.Guid);
            }


            var queryPersonne = from p in db.Personnes
                                where AllGuid.Contains(p.Guid)
                                || ((param1 == "undefined" || p.Nom.Contains(param1))
                                && (param2 == "undefined" || p.Prenom.Contains(param2)))
                                select p;

            //var queryPersonne = from p in db.Personnes
            //                    where  p.Nom.Contains(param1)
            //                    select p;

            AllPersonne = queryPersonne.ToList();

            foreach (ActiveDirectoryUtilisateurViewModel activeDirectoryViewModel in allActiveDirectoryViewModel)
            {
                //Itération déscendante afin de pouvoir couper la branche sur laquelle on est (remove de la Personne)
                for (int i = AllPersonne.Count - 1; i >= 0; --i)
                {
                    if (AllPersonne[i].Guid == activeDirectoryViewModel.Guid)
                    {
                        activeDirectoryViewModel.PersonneId = AllPersonne[i].PersonneId;
                        activeDirectoryViewModel.IsAnnuaireApplication = true;
                        AllPersonne.RemoveAt(i);
                    }
                }
            }

            foreach (Personne personne in AllPersonne)
            {
                allActiveDirectoryViewModel.Add(new ActiveDirectoryUtilisateurViewModel()
                {
                    PersonneId = personne.PersonneId,
                    Nom = personne.Nom,
                    Prenom = personne.Prenom,
                    Guid = personne.Guid,
                    IsAnnuaireAD = false,
                    IsAnnuaireApplication = true
                });
            }

            //if(param2 != "undefined"){
            //    queryPersonne.Where(p => AllGuid.Contains(p.Guid) ||
                    
            //        (param2 != "undefined") ? p.Nom.Contains(param2):true);
            //};

            //         from i in dc.SomeTable
            //  where (a == "" || i.A.Contains(a))
            //    && (b == "" || i.B.Contains(b))
            //    && (c == "" || i.C.Contains(c))
            //  select i;

            //...and if you want to switch from 'and' to 'or' between the different predicates, just change it to:

            //var results =
            //  from i in dc.SomeTable
            //  where (a == "" || i.A.Contains(a))
            //    || (b == "" || i.B.Contains(b))
            //    || (c == "" || i.C.Contains(c))
            //  select i;







            //POUR TEST LOCAL SANS Active Directory, NE PAS EFFACER MERCI
            //allActiveDirectoryViewModel.Add(
            //    new ActiveDirectoryUtilisateurViewModel
            //    {
            //        Nom = "Boyer",
            //        Prenom = "Julien",
            //        Guid = new Guid()
            //    }
            //);


            return Request.CreateResponse(HttpStatusCode.OK, allActiveDirectoryViewModel);
        }

    }
}