using BLLWHOLEPOS.DTOs;
using BLLWHOLEPOS.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
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
                    Session["user"] = BusinessService.Get(token.BusinessId).BuName;
                    Session["role"] = BusinessService.Get(token.BusinessId).Role;
                    TempData["Msg"] = "Login Successfull";
                     if (Session["role"].Equals("Admin"))
                        {
                            return RedirectToAction("Index", "AdminDashboard");
                        }
                     else if(Session["role"].Equals("Cashier"))
                        {
                            return RedirectToAction("Index", "CashierDashboard");
                        }
                     else 
                        {
                           return View(loginDTO);
                        }
                
                }
                else
                {
                    TempData["Msg"] = "User not found / Uname pass mismatch";
                    return RedirectToAction("Index");
                }
        
        }

       }
}