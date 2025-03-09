using BLLWHOLEPOS.DTOs;
using BLLWHOLEPOS.Services;
using POSBOX.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POSBOX.Controllers
{
    [AdminLogged]
    public class AdminBusinessController : Controller
    {
        // GET: Business
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CreatedBy = Session["user"]?.ToString();
            return View(new BusinessDTO());
        }

        [HttpPost]
        public ActionResult Create(BusinessDTO businessDTO)
        {
            if (ModelState.IsValid)
            {
                if (BusinessService.Create(businessDTO))
                {

                    TempData["CreateMessage"] = "Business created!";
                    return View(businessDTO); 
                }
                else
                {
                    TempData["CreateMessage"] = "Failed to create business.";
                }
            }
            return View(businessDTO);
        }

        [HttpGet]
        public ActionResult Manage()
        {
            var businesses = BusinessService.Get();
            return View(businesses);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var businesses = BusinessService.Get(id);
            return View(businesses);
        }

        [HttpPost]
        public ActionResult Update(BusinessDTO businessDTO)
        {
            if (ModelState.IsValid)
            {
                if (BusinessService.Update(businessDTO))
                {

                    TempData["UpdateMessage"] = "Business Updated!";
                    return View(businessDTO); 
                }
                else
                {
                    TempData["UpdateMessage"] = "Failed to update business.";
                }
            }
            return View(businessDTO);
        }

        [HttpPost]

        public ActionResult Delete(int id)
        {
            if(BusinessService.Delete(id))
            {
                TempData["DelMessage"] = "Record Deleted Successfully!";

                return RedirectToAction("Manage", "AdminBusiness");
            }
            else
            {
                TempData["DelMessage"] = "Record Failed to Delete";

                return RedirectToAction("Manage", "AdminBusiness");
            }

        }



    }
}