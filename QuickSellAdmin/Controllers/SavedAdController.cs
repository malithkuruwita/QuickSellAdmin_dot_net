using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Core.Metadata.Edm;
using QuickSellAdmin.Models;


namespace QuickSellAdmin.Controllers
{
    public class SavedAdController : Controller
    {
        

        // GET: SavedAd
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

                using (QuickSellData db = new QuickSellData()) {
                List<savedAdd> savedata = db.savedAdds.ToList<savedAdd>();
                return Json(new { data = savedata }, JsonRequestBehavior.AllowGet);
                }


            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {
            var username = Session["username"] as String;
            var password = Session["password"] as String;
            if (username != null && password != null)
            {


                if (id ==0)
                return View(new savedAdd());
                else
                {
                    using(QuickSellData db = new QuickSellData())
                    {
                        return View(db.savedAdds.Where(x => x.Id == id).FirstOrDefault<savedAdd>());
                    }
                }


            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(savedAdd sav)
        {
            var username = Session["username"] as String;
            var password = Session["password"] as String;
            if (username != null && password != null)
            {

                using (QuickSellData db = new QuickSellData())
                {
                if(sav.Id == 0)
                {
                    db.savedAdds.Add(sav);
                    db.SaveChanges();

                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var ad = db.savedAdds.AsNoTracking().Where(x => x.Id == sav.Id).FirstOrDefault();
                    int dg = ad.AddID;


                    

                    
                    using (QuickSellData db1 = new QuickSellData()) {
                        sav.AddID = dg;
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
                savedAdd sav = db.savedAdds.Where(x => x.Id == id).FirstOrDefault<savedAdd>();
                db.savedAdds.Remove(sav);
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