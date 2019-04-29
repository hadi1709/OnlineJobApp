using OnlineJobApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineJobApplication.ViewModels.Admin
{
    public class JobDetailsViewModel
    {
        public JobModel JobModel { get; set; }

        public List<UserModel> UserList { get; set; }

        public StageModel CurrentStage { get; set; }

        public List<StageModel> StageList { get; set; }

        public UserModel User { get; set; }

        public StatusModel StatusModel { get; set; }
    }
}