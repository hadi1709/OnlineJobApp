using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineJobApplication.Models
{
    public class EmailContactModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Message {get; set;}
    }
}