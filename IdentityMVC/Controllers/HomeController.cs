using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
            
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            //return View();

            if (Session["Id"] != null)
            {
                ViewBag.Message = "Your application description page.";
                return View();
            }
            else
            {

                // return RedirectToAction("Login", "Account");
                return Content("<script language='javascript' type='text/javascript'>alert('You must login...');window.location.href ='/Account/Login';</script>");

            }
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            //return View();

            if (Session["Id"] != null)
            {
                ViewBag.Message = "Your contact page.";
                return View();
            }
            else
            {

                // return RedirectToAction("Login", "Account");
                return Content("<script language='javascript' type='text/javascript'>alert('You must login...');window.location.href ='/Account/Login';</script>");

            }

        }
    }
}