using OnlineJobApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineJobApplication.ViewModels
{
    public class NewJobOfferViewModel
    {
        public JobModel JobModel { get; set; }

        public List<CareerAreaModel> CareerList { get; set; }

        public StatusModel JobStatus { get; set; }
    }
}