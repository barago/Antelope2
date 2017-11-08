using Antelope.DTOs.Socle;
using Antelope.Domain.Models;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web;
using System.DirectoryServices;

using Antelope.Configurations;
using Antelope.Infrastructure.EntityFramework;


namespace Antelope.Repositories.Socle
{
    public class ActiveDirectoryUtilisateurRepository
    {

        public AntelopeEntities _db { get; set; }
        public PrincipalContext _principalContext { get; set; }

        public ActiveDirectoryUtilisateurRepository()
            : this(new AntelopeEntities())
        {

        }

        public ActiveDirectoryUtilisateurRepository(AntelopeEntities db)
        {
            var principalContext = new PrincipalContext(ContextType.Domain, ActiveDirectoryConfig.CurrentConfig.DomainName);
            _db = db;
            _principalContext = principalContext;
        }

        public ActiveDirectoryUtilisateurRepository(AntelopeEntities db, PrincipalContext principalContext)
        {

            _db = db;
            _principalContext = principalContext;
        }

        public ActiveDirectoryUtilisateurDTO GetActiveDirectoryUtilisateurByNomPrenom(String Nom, String Prenom)
        {
            UserPrincipal qbeUser = new UserPrincipal(_principalContext);

            qbeUser.GivenName = Prenom;
            qbeUser.Surname = Nom;

            PrincipalSearcher srch = new PrincipalSearcher(qbeUser);
            Principal principal = srch.FindOne();

            ActiveDirectoryUtilisateurDTO ActiveDirectoryUtilisateurDTO = null;

            if (principal != null)
            {
                var utilisateurAD = principal.GetUnderlyingObject() as DirectoryEntry;


                ActiveDirectoryUtilisateurDTO = new ActiveDirectoryUtilisateurDTO()
                {
                    Guid = (Guid)principal.Guid,
                    Nom = (string)utilisateurAD.Properties["sn"].Value,
                    Prenom = (string)utilisateurAD.Properties["givenName"].Value,
                    email = (string)utilisateurAD.Properties["mail"].Value
                };

            }

            return ActiveDirectoryUtilisateurDTO;
        }


        public string GetCurrentUserEmail()
        {
            UserPrincipal user = GetActiveDirectoryUser(System.Web.HttpContext.Current.User.Identity.Name.Split('\\')[1]);
            DirectoryEntry de = user.GetUnderlyingObject() as DirectoryEntry;
            return (String)de.Properties["mail"].Value;
        }

        public string GetCurrentUserSiteTrigramme()
        {
            UserPrincipal user = GetActiveDirectoryUser(System.Web.HttpContext.Current.User.Identity.Name.Split('\\')[1]);
            DirectoryEntry de = user.GetUnderlyingObject() as DirectoryEntry;

#if DEBUG
            return "RFS";
#endif
            return (String)de.Properties["company"][0];
        }

        public Site GetCurrentUserSite()
        {

            String SiteTrigramme = GetCurrentUserSiteTrigramme();

            var querySiteUser = from s in _db.Sites
                                where s.Trigramme == SiteTrigramme
                                select s;
            return (Site)querySiteUser.FirstOrDefault();

        }


        // Cette méthode résoud un bug Microsoft (
        //https://connect.microsoft.com/VisualStudio/feedback/details/748790/userprincipal-current-throws-invalidcastexception
        //)
        // Sous IIS : UserPrincipal.Current >> Renvoit un Groupe et non pas l'Utilisateur ... Donc on va chercher l'utilisateur dans l'AD par son Login
        // A faire en début de session, puis le déclarer en session ? (A voir)
        //          DEJA TESTE : 
        //          UserPrincipal user = System.Security.Principal.WindowsIdentity.GetCurrent();
        //          UserPrincipal user = HttpContext.Current.User;
        public UserPrincipal GetActiveDirectoryUser(string userName)
        {
            using (var ctx = new PrincipalContext(ContextType.Domain))
            using (var user = new UserPrincipal(ctx) { SamAccountName = userName })
            using (var searcher = new PrincipalSearcher(user))
            {
                return searcher.FindOne() as UserPrincipal;
            }
        }






    }
}