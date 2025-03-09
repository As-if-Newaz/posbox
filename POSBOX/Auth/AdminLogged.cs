using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POSBOX.Auth
{
    public class AdminLogged : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)

        {
            
            if (httpContext.Session["token"] != null && httpContext.Session["role"].Equals("Admin"))
            {
                return true;
            }

            return false;
        }
    }
}