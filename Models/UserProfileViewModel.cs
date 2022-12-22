using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MandiriInhealth.Models
{
    public class UserProfileViewModel
    {
        public string Username { get; set; }
        public string Address { get; set; }
        public DateTime BoD { get; set; }
        public string Email { get; set; }
    }
}