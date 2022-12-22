using MandiriInhealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MandiriInhealth.Controllers
{
    public class UserSkillController : ApiController
    {
        public IHttpActionResult GetUserSkillByUsername(string username)
        {
            var userSkill = new UserSkillViewModel();

            using (var conn = new MandiriInTestEntities())
            {
                userSkill = conn.UserSkills.Include("username")
                    .Where(s => s.username == username)
                            .Select(s => new UserSkillViewModel()
                            {
                                UserSkillId = s.userSkillId,
                                SkillId = s.skillId,
                                SkillLevelId =  s.skillLevelId
                            }).FirstOrDefault();
            }

            if (userSkill == null)
            {
                return NotFound();
            }

            return Ok(userSkill);
        }
    }
}