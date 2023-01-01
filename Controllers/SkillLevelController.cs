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

        public SkillLevel CreateSkillLevel(SkillLevel skillLevelModel)
        {
            try
            {
                using (var conn = new MandiriInTestEntities())
                {
                    conn.SkillLevel.Add(skillLevelModel);
                    conn.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return skillLevelModel;
        }

        public SkillLevel UpdateSkill(int skillLevelID)
        {
            try
            {
                using (var conn = new MandiriInTestEntities())
                {
                    var data = conn.SkillLevel.Where(x => x.skillLevelId == skillLevelID).SingleOrDefault();
                    return data;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public SkillLevel DeleteSkill(int skillLevelID) //buat delete biasanya pake row status biar softdelete aja, tapi di soal tablenya ga ada row status
        {
            try
            {
                using (var conn = new MandiriInTestEntities())
                {

                    var data = conn.SkillLevel.FirstOrDefault(x => x.skillLevelId == skillLevelID);
                    if (data != null)
                    {
                        conn.SkillLevel.Remove(data);
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
