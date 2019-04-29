using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineJobApplication.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string IcNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string CountryId { get; set; }

        public string Country { get; set; }       

        [Required]
        public int ReligionId { get; set; }

        public string Religion { get; set; }      

        public string CurrentStage { get; set; }
    }
}