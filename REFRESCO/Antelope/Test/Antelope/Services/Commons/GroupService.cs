using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Antelope.Services.Commons
{
    public class GroupService
    {


        public static ArrayList GetAllGroupForUser()
        {
            ArrayList groups = new ArrayList();
            foreach (System.Security.Principal.IdentityReference group in
                System.Web.HttpContext.Current.Request.LogonUserIdentity.Groups)
            {
                //groups.Add(group.Translate(typeof
                //    (System.Security.Principal.NTAccount)).ToString());
            }

            return groups;
        }



    }
}