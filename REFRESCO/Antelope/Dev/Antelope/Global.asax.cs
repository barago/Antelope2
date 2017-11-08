using Antelope.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using System.Web.Security;
using System.Diagnostics;
using Antelope.Services.HSE.Enums;
using Antelope.Infrastructure.EntityFramework;
using Antelope.Models; //TODO : A vérifier >> Pour le TestContext
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;

using Antelope.Binders;

namespace Antelope
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            GlobalConfiguration.Configure(WebApiConfig.Register);

            //Datas Initializer when the base is in a Create/Drop state
            //Database.SetInitializer<AntelopeContext>(new AntelopeContextInitializer());
            Database.SetInitializer(new TestContextInitializer());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Session_Start()
        {

            AntelopeEntities db = new AntelopeEntities();

            //-_-_-_-_-_-Traitements pour HSE-_-_-_-_-_-

            Int16 HSERole = (Int16)HSERoleEnum.Visiteur;
            Int16 CurrentHSERole = (Int16)HSERoleEnum.Visiteur;
            var allADHSERoleMapped = from a in db.ADRoles
                                  where a.RoleType == "HSE"
                                  select a;

            var id = ClaimsPrincipal.Current.Identities.First();

            //Seul contournement trouvé au fait que 
            //Guid guid = (Guid)Membership.GetUser().ProviderUserKey;
            // Ne fonctionne pas (l'utilisateur est authentifié, mais pas loggué, on dirait...)
            // A refactor dans une méthode !!!
            string login = HttpContext.Current.User.Identity.Name;
            string domain = login.Substring(0, login.IndexOf('\\'));
            string userName = login.Substring(login.IndexOf('\\') + 1);
            DirectoryEntry domainEntry = new DirectoryEntry("LDAP://" + domain);
            DirectorySearcher searcher = new DirectorySearcher(domainEntry);
            searcher.Filter = string.Format("(&(objectCategory=person)(objectClass=user)(sAMAccountName={0}))", userName);
            SearchResult searchResult = searcher.FindOne();
            DirectoryEntry entry = searchResult.GetDirectoryEntry();
            Guid objectGuid = entry.Guid;

            System.Security.Principal.WindowsIdentity.GetCurrent();

            Session["CurrentGuid"] = objectGuid;

            foreach (ADRole ADRole in allADHSERoleMapped)
            {

                Debug.WriteLine(ADRole.Name);

                string[] roles = Roles.GetRolesForUser(id.Name);


                if ((Roles.IsUserInRole(ADRole.Name.Replace(@"\\", @"\"))) || (ADRole.Name.Replace(@"\\", @"\") == login))
                {
                    Debug.WriteLine(ADRole.Name);

                    HSERoleEnum RoleToAdd = (HSERoleEnum)Enum.Parse(typeof(HSERoleEnum), ADRole.RoleCode);  //TODO : Renommer RoleCode en APPRoleCode !!! RoleType en APPRoleType

                    if ((Int16)RoleToAdd < (Int16)HSERole)
                    {
                        HSERole = (Int16)RoleToAdd;
                        CurrentHSERole = (Int16)RoleToAdd;
                    }

                }

            }
            
            Session["HSERole"] = HSERole;
            // Dans le futur, l'utilisateur pourra choisir un role inferieur à celui auquel il a droit
            // Il faut donc utiliser CurrentHSERole dans les pages de l'appli.
            //Session["CurrentHSERole"] = Enum.GetName(typeof(HSERoleEnum), CurrentHSERole);
            Session["CurrentHSERole"] = CurrentHSERole;

            //-_-_-_-_-_-Traitements pour QSE-_-_-_-_-_-

            Int16 QSERole = (Int16)HSERoleEnum.Visiteur;
            Int16 CurrentQSERole = (Int16)HSERoleEnum.Visiteur;

            var allADQSERoleMapped = from a in db.ADRoles
                                     where a.RoleType == "QSE"
                                     select a;

            foreach (ADRole ADRole in allADQSERoleMapped)
            {

                Debug.WriteLine(ADRole.Name);

                //var id = ClaimsPrincipal.Current.Identities.First();
                string[] roles = Roles.GetRolesForUser(id.Name);

                if (Roles.IsUserInRole(ADRole.Name.Replace(@"\\", @"\")))
                {
                    Debug.WriteLine(ADRole.Name);

                    HSERoleEnum RoleToAdd = (HSERoleEnum)Enum.Parse(typeof(HSERoleEnum), ADRole.RoleCode);  //TODO : Renommer RoleCode en APPRoleCode !!! RoleType en APPRoleType

                    if ((Int16)RoleToAdd < (Int16)QSERole)
                    {
                        QSERole = (Int16)RoleToAdd;
                        CurrentQSERole = (Int16)RoleToAdd;
                    }

                }

            }

            Session["QSERole"] = QSERole;
            // Voir commentaire pour les rôles HSE
            Session["CurrentQSERole"] = CurrentQSERole;



        }


        void Application_AcquireRequestState()
        {

            //String HSERole = Session["HSERole"] as String;
            //var id = ClaimsPrincipal.Current.Identities.First();
            //Boolean IsInRole = Roles.IsUserInRole(HSERole);

            //id.AddClaim(new Claim(ClaimTypes.GroupSid, HSERole));
            //Boolean IsInRole2 = Roles.IsUserInRole(HSERole);

            //var e = 5;

        }


        void Application_PostAuthenticateRequest()
        {

            if (Request.IsAuthenticated)
            {


                //var HSERole = Session["HSERole"];

                //var id = ClaimsPrincipal.Current.Identities.First();
                //string[] roles = Roles.GetRolesForUser(id.Name);
                //Boolean IsInRole = Roles.IsUserInRole("Tartampion");

                //id.AddClaim(new Claim(ClaimTypes.GroupSid, "Tartampion"));
                //Boolean IsInRole2 = Roles.IsUserInRole("Tartampion");

                //string[] roles2 = Roles.GetRolesForUser(id.Name);
                //int a = 1;

                //var util = User.Identity.Name;
                //User.Identity.   AddClaim(new Claim(ClaimTypes.Role, "Tartampion"));
                //foreach (var role in roles)
                //{
                //Console.WriteLine("Role : " + role);
                //id.Claims.add(new Claim(ClaimTypes.Role, role));
                //int c = 3;
                //var id2 = new ClaimsIdentity();
                //id2.AddClaim(new Claim(ClaimTypes.Role, "YourRole"));
                //ClaimsPrincipal.Current.AddIdentity(id);
                //string[] roles3 = Roles.GetRolesForUser();
                //Roles.AddUserToRole(User.Identity.Name, "AGAGAGAGAGAGAGAGAGAGAG");
                //string[] roles3 = Roles.GetRolesForUser(User.Identity.Name);
                //string[] rolesId = Roles.GetRolesForUser(User.Identity.Name);
                //int d = 4;
                //}
            }
        }
    }
}
