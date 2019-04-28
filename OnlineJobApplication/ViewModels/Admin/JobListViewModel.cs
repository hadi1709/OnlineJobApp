using OnlineJobApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineJobApplication.ViewModels.Admin
{
    public class JobListViewModel
    {
        public List<JobModel> JobList { get; set; } 

        public StatusModel JobStatus { get; set; }
    }
}