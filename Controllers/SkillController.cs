using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MandiriInhealth.Models;

namespace MandiriInhealth.Controllers
{
    public class SkillController : ApiController
    {
        public IHttpActionResult GetAllSKills()
        {
            IList<SkillViewModel> skillList = null;

            using (var conn = new MandiriInTestEntities())
            {
                skillList = conn.Skill.Include("SkillName")
                            .Select(s => new SkillViewModel()
                            {
                                SkillId = s.skillId,
                                SkillName = s.skillName
                            }).ToList<SkillViewModel>();
            }

            if (skillList.Count == 0)
            {
                return NotFound();
            }

            return Ok(skillList);
        }

        public IHttpActionResult GetSkilById(int skillId)
        {
            var skill = new SkillViewModel();

            using (var conn = new MandiriInTestEntities())
            {
                skill = conn.Skill.Include("SkillName")
                    .Where(s => s.skillId == skillId)
                            .Select(s => new SkillViewModel()
                            {
                                SkillId = s.skillId,
                                SkillName = s.skillName
                            }).FirstOrDefault();
            }

            if (skill == null)
            {
                return NotFound();
            }

            return Ok(skill);
        }
    }
}
