using QuickSellAdmin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickSellAdmin.Controllers
{
    public class UseraccountController : Controller
    {
        // GET: Useraccount
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
                List<userAccount> uaccount = db.userAccounts.ToList<userAccount>();
                return Json(new { data = uaccount }, JsonRequestBehavior.AllowGet);
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
                return View(new userAccount());
                else
                {
                    using (QuickSellData db = new QuickSellData())
                    {
                        return View(db.userAccounts.Where(x => x.UserID == id).FirstOrDefault<userAccount>());
                    }
                }

            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(userAccount sav)
        {

            var username = Session["username"] as String;
            var password = Session["password"] as String;
            if (username != null && password != null)
            {

                using (QuickSellData db = new QuickSellData())
                {
                if (sav.UserID == 0)
                {
                    db.userAccounts.Add(sav);
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
                userAccount sav = db.userAccounts.Where(x => x.UserID == id).FirstOrDefault<userAccount>();
                db.userAccounts.Remove(sav);
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