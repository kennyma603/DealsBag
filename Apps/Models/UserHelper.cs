using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Apps.Models
{
    public class UserHelper
    {

        public static Guid GetCachedUserID()
        {
            string UserName = HttpContext.Current.User.Identity.Name;

            if (UserName == "") 
                return Guid.Empty;

            if (HttpRuntime.Cache[UserName] == null)
            {
                HttpRuntime.Cache.Insert(UserName, Membership.GetUser(UserName).ProviderUserKey, null,
                    System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(12));

            }

            Guid UIDguid = new Guid(HttpRuntime.Cache[UserName].ToString());

            return UIDguid;

        }


        public static void RemoveCachedUserID()
        {
            // called when the user is logged out   
            string UserName = HttpContext.Current.User.Identity.Name;
            HttpRuntime.Cache.Remove(UserName);


        }

    }
}