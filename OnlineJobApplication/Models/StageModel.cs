using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineJobApplication.Models
{
    public class StageModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? IndexNumber { get; set; }

        public string UserJobApplicationId { get; set; }
    }
}