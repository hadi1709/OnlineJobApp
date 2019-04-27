using OnlineJobApplication.Models;
using OnlineJobApplication.ViewModels;
using System;
using System.Linq;
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

            StatusModel jobStatus = new StatusModel()
            {
                Code = statusCode,
                Description = status
            };

            JobListViewModel viewModel = new JobListViewModel()
            {
                JobList = CommonHelper.GetAllJobList(),
                JobStatus = jobStatus
            };

            return View(viewModel);
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

        [HttpGet]
        public ActionResult EditJobOffer(string id)
        {
            StatusModel statusJobOffer = new StatusModel();
            try
            {
                string status = TempData["Status"] != null ? TempData["Status"].ToString() : "";
                int statusCode = TempData["StatusCode"] != null ? Convert.ToInt32(TempData["StatusCode"].ToString()) : 0;

                StatusModel jobStatus = new StatusModel()
                {
                    Code = statusCode,
                    Description = status
                };

                EditJobOfferViewModel viewModel = new EditJobOfferViewModel()
                {
                    JobModel = CommonHelper.GetJobById(Int32.Parse(id)),
                    CareerList = CommonHelper.GetCareeerAreaList(),
                    JobStatus = jobStatus
                };

                return this.View(viewModel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditJobOffer(EditJobOfferViewModel viewModel)
        {
            StatusModel statusJobOffer = new StatusModel();

            try
            {
                using (db_1526890_onlinejobEntities db = new db_1526890_onlinejobEntities())
                {
                    var queryJob = (from job in db.Jobs
                                    where job.Id == viewModel.JobModel.Id
                                    select job).FirstOrDefault();

                    queryJob.Title = viewModel.JobModel.Title;
                    queryJob.Description = viewModel.JobModel.Description;
                    queryJob.DateOpened = viewModel.JobModel.DateOpened;
                    queryJob.DateClosed = viewModel.JobModel.DateClosed;
                    queryJob.CareerAreasId = viewModel.JobModel.CareerAreasId;
                    queryJob.Qualification = viewModel.JobModel.Qualification;

                    db.SaveChanges();
                }

                statusJobOffer.Code = CommonHelper.StatusOk;
                statusJobOffer.Description = "Successfully edited " + viewModel.JobModel.Title;

                TempData["Status"] = statusJobOffer.Description;
                TempData["StatusCode"] = statusJobOffer.Code;
                return RedirectToAction("JobList");
            }
            catch (Exception e)
            {
                statusJobOffer.Code = CommonHelper.StatusError;
                statusJobOffer.Description = e.ToString() + "Please contact admin.";

                return RedirectToAction("EditJobOffer", viewModel.JobModel.Id);
            }
        }
    }
}
