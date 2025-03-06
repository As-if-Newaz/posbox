using BLLWHOLEPOS.DTOs;
using BLLWHOLEPOS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace POSBOX.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View(new LoginDTO());
        }

        [HttpPost]
        public ActionResult Index(LoginDTO loginDTO)
        {
          
                var token = AuthService.Authentication(loginDTO.BuName, loginDTO.Password);
                if (token != null)
                {
                    Session["token"] = token;
                    var busName = BusinessService.Get(token.BusinessId).BuName;
                    Session["user"] = busName;
                    TempData["Msg"] = "Login Successfull";
                    return RedirectToAction("Index", "AdminDashboard");
                }
                else
                {
                    TempData["Msg"] = "User not found / Uname pass mismatch";
                    return RedirectToAction("Index");
                }
        
        }

       }
}