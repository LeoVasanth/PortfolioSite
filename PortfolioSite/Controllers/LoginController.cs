using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PortfolioSite.Models;

namespace PortfolioSite.Controllers
{
   
    public class LoginController : Controller
    {
        private VsntDbEntities db = new VsntDbEntities();

        
        public async Task<ActionResult> Index()
        {
            return View();
        }

       
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_user tbl_user = await db.tbl_user.FindAsync(id);
            if (tbl_user == null)
            {
                return HttpNotFound();
            }
            return View(tbl_user);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "username,pwd")] tbl_user tbl_user)
        {
            if (ModelState.IsValid)
            {
                db.tbl_user.Add(tbl_user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tbl_user);
        }

        [HttpPost]
        public async Task<ActionResult> Login(tbl_user user)
        {
            Session["User"] = user.username;

            if (user.username == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_user tbluser = await db.tbl_user.FindAsync(user.username);
            if (tbluser == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (tbluser.pwd == user.pwd)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "username,pwd")] tbl_user tbl_user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tbl_user);
        }

        
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_user tbl_user = await db.tbl_user.FindAsync(id);
            if (tbl_user == null)
            {
                return HttpNotFound();
            }
            return View(tbl_user);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            tbl_user tbl_user = await db.tbl_user.FindAsync(id);
            db.tbl_user.Remove(tbl_user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
