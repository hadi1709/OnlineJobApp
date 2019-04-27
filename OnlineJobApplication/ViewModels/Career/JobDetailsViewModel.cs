using OnlineJobApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineJobApplication.ViewModels.Career
{
    public class JobDetailsViewModel
    {
        public JobModel JobModel { get; set; }

        public StatusModel JobStatus { get; set; }
    }
}