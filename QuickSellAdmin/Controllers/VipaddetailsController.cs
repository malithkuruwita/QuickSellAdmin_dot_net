using QuickSellAdmin.ListModels;
using QuickSellAdmin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickSellAdmin.Controllers
{
    public class VipaddetailsController : Controller
    {
        // GET: Vipaddetails
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
                var vipdetails = db.vipDetails.Select(x => new { x.Id,x.EndDate,x.Status, x.Title, x.AddPlaced, x.Price, x.Location, x.Contact1, x.Contact2, x.MainCategory, x.SubCategory, x.Brand, x.ModelYear, x.Model, x.EngineCapacity, x.Mileage, x.Condition, x.Negotiable, x.UserID }).ToList();

                List<vipdate> details = new List<vipdate>();
                foreach(var item in vipdetails)
                {
                    details.Add(new vipdate {
                        AddPlaced = item.AddPlaced.ToShortDateString(),
                        EndDate = item.EndDate.ToShortDateString(),
                        Status = item.Status,
                        Id = item.Id,
                        Title =item.Title,
                        Price = item.Price,
                        Contact1 = item.Contact1,
                        Contact2 = item.Contact2,
                        Location = item.Location,
                        MainCategory = item.MainCategory,
                        SubCategory = item.SubCategory,
                        Brand = item.Brand,
                        ModelYear = item.ModelYear,
                        Model = item.Model,
                        EngineCapacity = item.EngineCapacity,
                        Mileage = item.Mileage,
                        Condition = item.Condition,
                        Negotiable = item.Negotiable,
                        UserID = item.UserID

                    
                    });
                }

                return Json(new { data = details }, JsonRequestBehavior.AllowGet);
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
                return View(new vipDetail());
                else
                {
                    using (QuickSellData db = new QuickSellData())
                    {
                        return View(db.vipDetails.Where(x => x.Id == id).FirstOrDefault<vipDetail>());
                    }
                }


            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(vipDetail sav)
        {

            var username = Session["username"] as String;
            var password = Session["password"] as String;
            if (username != null && password != null)
            {

                using (QuickSellData db = new QuickSellData())
                {
                if (sav.Id == 0)
                {
                    db.vipDetails.Add(sav);
                    db.SaveChanges();

                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var ad = db.vipDetails.AsNoTracking().Where(x => x.Id == sav.Id).FirstOrDefault();


                    using (QuickSellData db1 = new QuickSellData())
                    {
                        sav.Img1 = ad.Img1;
                        sav.Img2 = ad.Img2;
                        sav.Img3 = ad.Img3;
                        sav.Img4 = ad.Img4;
                        sav.Img4 = ad.Img5;
                        
                        sav.AddPlaced = ad.AddPlaced;
                        sav.Condition = ad.Condition;
                        sav.Location = ad.Location;
                        sav.MainCategory = ad.MainCategory;
                        sav.SubCategory = ad.SubCategory;
                        sav.UserID = ad.UserID;
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
                vipDetail sav = db.vipDetails.Where(x => x.Id == id).FirstOrDefault<vipDetail>();
                db.vipDetails.Remove(sav);
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