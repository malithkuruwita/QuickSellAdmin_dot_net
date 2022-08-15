using QuickSellAdmin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickSellAdmin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
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

        [HttpGet]
        public ActionResult Login()
        {
           

                return View();

        }

        [HttpPost]
        public ActionResult Login(adminAccount user)
        {
            if (user.Username != null && user.Password !=null) {

                /*using (QuickSellData db = new QuickSellData())
                {
                    var admin = db.adminAccounts.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault();
                    if (admin != null)
                    {
                        Session["username"] = user.Username;
                        Session["password"] = user.Password;

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {

                    }*/

                Session["username"] = user.Username;
                Session["password"] = user.Password;

                return RedirectToAction("Index", "Home");

                //return View();
                //}

            }
            else
            {
                return View();
            }
            
        }

        public ActionResult Logout()
        {
            Session["username"] = null;
            Session["password"] = null;
            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public ActionResult AkaChange()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AkaChange(adminAccount model)
        {

            var username = Session["username"] as String;
            var password = Session["password"] as String;
            if (username != null && password != null)
            {

                using (QuickSellData db = new QuickSellData())
                {

                    var details = db.adminAccounts.AsNoTracking().Where(x => x.FirstName == model.FirstName && x.LastName == model.LastName && x.QuickKey == model.QuickKey).FirstOrDefault();

                    if(details != null)
                    {
                        model.UserID = details.UserID;

                        
                        db.Entry(model).State = EntityState.Modified;
                        db.SaveChanges();



                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        Session["username"] = null;
                        Session["password"] = null;
                        return RedirectToAction("Login", "Home");
                    }

                }

             
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

    }
}