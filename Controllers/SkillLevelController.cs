using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MandiriInhealth.Models;

namespace MandiriInhealth.Controllers
{
    public class SkillLevelController : ApiController
    {
        public IHttpActionResult GetAllSkillLevel()
        {
            IList<SkillLevelViewModel> skillLevelList = null;

            using (var conn = new MandiriInTestEntities())

                skillLevelList = conn.SkillLevel.Include("SkillLevelName")
                            .Select(s => new SkillLevelViewModel()
                            {
                                SkillLevelId = s.skillLevelId,
                                SkillLevelName = s.skillLevelName
                            }).ToList<SkillLevelViewModel>();
            

            if (skillLevelList.Count == 0)
            {
                return NotFound();
            }

            return Ok(skillLevelList);
        }

        public IHttpActionResult GetSkillLevelById(int skillLevelId)
        {
            var skillLevel = new SkillLevelViewModel();

            using (var conn = new MandiriInTestEntities())
            {
                skillLevel = conn.SkillLevel.Include("SkillLevelName")
                    .Where(s => s.skillLevelId == skillLevelId)
                            .Select(s => new SkillLevelViewModel()
                            {
                                SkillLevelId = s.skillLevelId,
                                SkillLevelName = s.skillLevelName
                            }).FirstOrDefault();
            }

            if (skillLevel == null)
            {
                return NotFound();
            }

            return Ok(skillLevel);
        }
    }
}
