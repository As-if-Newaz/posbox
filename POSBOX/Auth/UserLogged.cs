using BLLWHOLEPOS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POSBOX.Auth
{
    public class UserLogged : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)

        {

            if (httpContext.Session["token"] != null && httpContext.Session["role"].Equals("Cashier"))
            {
                return true;
            }

            return false;
        }
    }
}