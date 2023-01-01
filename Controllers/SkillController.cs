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

        public Skill CreateUSkill(Skill skillModel)
        {
            try
            {
                using (var conn = new MandiriInTestEntities())
                {
                    conn.Skill.Add(skillModel);
                    conn.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return skillModel;
        }

        public Skill UpdateSkill(int skillID)
        {
            try
            {
                using (var conn = new MandiriInTestEntities())
                {
                    var data = conn.Skill.Where(x => x.skillId == skillID).SingleOrDefault();
                    return data;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Skill DeleteSkill(int skillID) //buat delete biasanya pake row status biar softdelete aja, tapi di soal tablenya ga ada row status
        {
            try
            {
                using (var conn = new MandiriInTestEntities())
                {

                    var data = conn.Skill.FirstOrDefault(x => x.skillId == skillID);
                    if (data != null)
                    {
                        conn.Skill.Remove(data);
                        conn.SaveChanges();

                    }
                    return data;
                }
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
