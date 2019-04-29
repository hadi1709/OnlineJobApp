using Microsoft.AspNet.Identity;
using OnlineJobApplication.ViewModels.JobSeeker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineJobApplication.Controllers
{
    public class JobSeekerController : Controller
    {
        // GET: JobSeeker
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult JobStatus()
        {
            var userId = User.Identity.GetUserId();

            JobStatusViewModel viewModel = new JobStatusViewModel()
            {
                JobList = CommonHelper.GetJobListByUserId(userId)
            };

            return this.View(viewModel);
        }
    }
}