using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioSite.Models;

namespace PortfolioSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string InsertMsg(tbl_messages msg)
        {
            VsntDbEntities Db = new VsntDbEntities();
            msg.date = DateTime.Now;

            if (msg != null)
            {
                Db.tbl_messages.Add(msg);
                Db.SaveChanges();
                return "Message Sent Successfully";

            }
            else
            {
                return "Error Occured";
            }   
        }

        public ActionResult gotoLogin()
        {
            return RedirectToAction("Login","Login");
        }
    }
}