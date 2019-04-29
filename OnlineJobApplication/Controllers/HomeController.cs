using OnlineJobApplication.App_Data;
using OnlineJobApplication.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineJobApplication.Controllers
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

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactUsViewModel viewModel)
        {
            using (db_1526890_onlinejobEntities db = new db_1526890_onlinejobEntities())
            {
                Email emailObj = new Email()
                {
                    Email1 = viewModel.EmailContact.Email,
                    Message = viewModel.EmailContact.Message
                };

                db.Emails.Add(emailObj);
                db.SaveChanges();
            }

            return RedirectToAction("Contact");
        }
    }
}