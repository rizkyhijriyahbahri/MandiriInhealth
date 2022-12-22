using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MandiriInhealth.Models
{
    public class UserSkillViewModel
    {
        public int UserSkillId { get; set; }
        public string Username { get; set; }
        public int SkillId { get; set; }
        public int SkillLevelId { get; set; }
    }
}