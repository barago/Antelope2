//using System;
//using System.Collections.Generic;
//using System.DirectoryServices.AccountManagement;
//using System.Linq;
//using System.Web;

//namespace Antelope.Services.Socle
//{
//    public class ActiveDirectoryService
//    {


//        // Cette méthode résoud un bug Microsoft (
//        //https://connect.microsoft.com/VisualStudio/feedback/details/748790/userprincipal-current-throws-invalidcastexception
//        //)
//        // Sous IIS : UserPrincipal.Current >> Renvoit un Groupe et non pas l'Utilisateur ... Donc on va chercher l'utilisateur dans l'AD par son Login
//        // A faire en début de session, puis le déclarer en session ? (A voir)
//        //          DEJA TESTE : 
//        //          UserPrincipal user = System.Security.Principal.WindowsIdentity.GetCurrent();
//        //          UserPrincipal user = HttpContext.Current.User;
//        public UserPrincipal GetActiveDirectoryUser(string userName)
//        {
//            using (var ctx = new PrincipalContext(ContextType.Domain))
//            using (var user = new UserPrincipal(ctx) { SamAccountName = userName })
//            using (var searcher = new PrincipalSearcher(user))
//            {
//                return searcher.FindOne() as UserPrincipal;
//            }
//        }


//    }
//}