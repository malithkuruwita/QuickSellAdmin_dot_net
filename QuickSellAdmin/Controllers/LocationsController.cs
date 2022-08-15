
using QuickSellAdmin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickSellAdmin.Controllers
{
    public class LocationsController : Controller
    {
        // GET: Locations
        public ActionResult Index()
        {
            var username = Session["username"] as String;
            var password = Session["password"] as String;
            if (username != null && password != null)
            {

                return View();

            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        public ActionResult GetData()
        {
            var username = Session["username"] as String;
            var password = Session["password"] as String;
            if (username != null && password != null)
            {

                using (QuickSellData db = new QuickSellData())
                {
                List<Location> location = db.Locations.ToList<Location>();
                return Json(new { data = location }, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {

            var username = Session["username"] as String;
            var password = Session["password"] as String;
            if (username != null && password != null)
            {

                if (id == 0)
                return View(new Location());
                else
                {
                    using (QuickSellData db = new QuickSellData())
                    {
                        return View(db.Locations.Where(x => x.id == id).FirstOrDefault<Location>());
                    }
                }

            }else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        [HttpPost]
        public ActionResult AddOrEdit(Location sav)
        {

            var username = Session["username"] as String;
            var password = Session["password"] as String;
            if (username != null && password != null)
            {

                using (QuickSellData db = new QuickSellData())
                {
                if (sav.id == 0)
                {
                    db.Locations.Add(sav);
                    db.SaveChanges();

                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    
                    using (QuickSellData db1 = new QuickSellData())
                    {
                        
                        db1.Entry(sav).State = EntityState.Modified;
                        db1.SaveChanges();
                    }
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }

                }

            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {

            var username = Session["username"] as String;
            var password = Session["password"] as String;
            if (username != null && password != null)
            {

                using (QuickSellData db = new QuickSellData())
                {
                Location sav = db.Locations.Where(x => x.id == id).FirstOrDefault<Location>();
                db.Locations.Remove(sav);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
                }


            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }
    }
}