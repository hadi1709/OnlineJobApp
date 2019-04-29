using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineJobApplication.Models
{
    public class JobModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateOpened { get; set; }

        public DateTime DateClosed { get; set; }

        public string DateOpenedString { get; set; }

        public string DateClosedString { get; set; }

        public int CareerAreasId { get; set; }

        public string CareerAreas { get; set; }

        public string Qualification { get; set; }

        public string CurrentStage { get; set; }

    }
}