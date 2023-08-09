using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace reservation_new.Models
{
    public class GuestResponse
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please enter your mobile phone")]
        public string phone { get; set; }

        [Required(ErrorMessage = "Please verify whether you will attend!")]
        public bool WillAttend { get; set; }
    }
}
