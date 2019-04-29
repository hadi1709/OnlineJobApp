using Microsoft.AspNet.Identity;
using OnlineJobApplication.App_Data;
using OnlineJobApplication.Models;
using OnlineJobApplication.ViewModels.Career;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineJobApplication.Controllers
{
    public class CareerController : Controller
    {
        // GET: Career
        public ActionResult Index()
        {
            try
            {
                ViewModels.Career.IndexViewModel viewModel = new ViewModels.Career.IndexViewModel()
                {
                    JobList = CommonHelper.GetJobListbyDate()
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw;
            }                      
        }

        [HttpGet]
        public ActionResult JobDetails (int id)
        {
            string status = TempData["Status"] != null ? TempData["Status"].ToString() : "";
            int statusCode = TempData["StatusCode"] != null ? Convert.ToInt32(TempData["StatusCode"].ToString()) : 0;

            StatusModel jobStatus = new StatusModel()
            {
                Code = statusCode,
                Description = status
            };

            try
            {
                JobDetailsViewModel viewModel = new JobDetailsViewModel()
                {
                    JobModel = CommonHelper.GetJobById(id),
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
        [JobseekerAuthorize(Roles = "Jobseeker")]
        public ActionResult Apply(JobDetailsViewModel viewModel)
        {
            StatusModel jobStatus = new StatusModel();
            try
            {
                var userId = CommonHelper.GetUserByAspId(User.Identity.GetUserId());
                var currentDateTime = DateTime.Now;
                var jobGuid = Guid.NewGuid().ToString();

                using (db_1526890_onlinejobEntities db = new db_1526890_onlinejobEntities())
                {
                    var jobApplied = (from jobApplication in db.UserJobApplications
                                      where jobApplication.JobId == viewModel.JobModel.Id && jobApplication.UserId == userId
                                      select jobApplication).FirstOrDefault();

                    if (jobApplied != null)
                    {
                        jobStatus.Code = CommonHelper.StatusError;
                        jobStatus.Description = "You have already applied this job!";

                        TempData["Status"] = jobStatus.Description;
                        TempData["StatusCode"] = jobStatus.Code;

                        return RedirectToAction("JobDetails", new { id = viewModel.JobModel.Id });
                    }

                    UserJobApplication userJobApplicaitonObj = new UserJobApplication()
                    {
                        Id = jobGuid,
                        JobId = viewModel.JobModel.Id,
                        UserId = userId,
                        Date = currentDateTime
                    };

                    db.UserJobApplications.Add(userJobApplicaitonObj);
                    db.SaveChanges();

                    UserJobApplicationStage userJobApplicationStage = new UserJobApplicationStage()
                    {
                        UserJobApplicationId = jobGuid,
                        StageId = 1,
                        Date = currentDateTime
                    };

                    db.UserJobApplicationStages.Add(userJobApplicationStage);
                    db.SaveChanges();

                    jobStatus.Code = CommonHelper.StatusOk;
                    jobStatus.Description = "Thank You for applying. Your details have been submitted for reviewal.";

                    TempData["Status"] = jobStatus.Description;
                    TempData["StatusCode"] = jobStatus.Code;

                    return RedirectToAction("JobDetails", new { id = viewModel.JobModel.Id });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}