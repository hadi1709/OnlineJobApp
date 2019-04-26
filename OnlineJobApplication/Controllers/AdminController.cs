using OnlineJobApplication.Models;
using OnlineJobApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineJobApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult JobList()
        {
            string status = TempData["Status"] != null ? TempData["Status"].ToString() : "";
            int statusCode = TempData["StatusCode"] != null ? Convert.ToInt32(TempData["StatusCode"].ToString()) : 0;

            return View();
        }

        [HttpGet]
        public ActionResult NewJobOffer()
        {
            string status = TempData["Status"] != null ? TempData["Status"].ToString() : "";
            int statusCode = TempData["StatusCode"] != null ? Convert.ToInt32(TempData["StatusCode"].ToString()) : 0;

            StatusModel jobStatus = new StatusModel()
            {
                Code = statusCode,
                Description = status
            };

            NewJobOfferViewModel viewModel = new NewJobOfferViewModel()
            {
                CareerList = CommonHelper.GetCareeerAreaList(),
                JobStatus = jobStatus
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewJobOffer(NewJobOfferViewModel viewModel)
        {
            StatusModel statusJobOffer = new StatusModel();
            try
            {
                using (db_1526890_onlinejobEntities db = new db_1526890_onlinejobEntities())
                {
                    Job objJob = new Job()
                    {
                        Title = viewModel.JobModel.Title,
                        Description = viewModel.JobModel.Description,
                        DateOpened = viewModel.JobModel.DateOpened,
                        DateClosed = viewModel.JobModel.DateClosed,
                        CareerAreasId = viewModel.JobModel.CareerAreasId,
                        Qualification = viewModel.JobModel.Qualification,
                        IsDeleted = false
                    };

                    db.Jobs.Add(objJob);
                    db.SaveChanges();
                }

                statusJobOffer.Code = CommonHelper.StatusOk;
                statusJobOffer.Description = "Successfully added " + viewModel.JobModel.Title;

                TempData["Status"] = statusJobOffer.Description;
                TempData["StatusCode"] = statusJobOffer.Code;
                return RedirectToAction("NewJobOffer");

            }
            catch (Exception e)
            {
                statusJobOffer.Code = CommonHelper.StatusError;
                statusJobOffer.Description = e.ToString() + "Please contact admin.";

                return Redirect("NewJobOffer");
            }

        }
    }
}