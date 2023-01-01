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
                                SkillLevelId = s.skillLevelId
                            }).FirstOrDefault();
            }

            if (userSkill == null)
            {
                return NotFound();
            }

            return Ok(userSkill);
        }

        public UserSkills CreateUserSkill(UserSkills userSkillModel)
        {
            try
            {
                using (var conn = new MandiriInTestEntities())
                {
                    conn.UserSkills.Add(userSkillModel);
                    conn.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return userSkillModel;
        }

        public UserSkills UpdateUserSkill(int userSkillID)
        {
            try
            {
                using (var conn = new MandiriInTestEntities())
                {
                    var data = conn.UserSkills.Where(x => x.userSkillId == userSkillID).SingleOrDefault();
                    return data;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public UserSkills DeleteUserSkill(int userSkillID)
        {
            try
            {
                using (var conn = new MandiriInTestEntities())
                {

                    var data = conn.UserSkills.FirstOrDefault(x => x.userSkillId == userSkillID);
                    if (data != null)
                    {
                        conn.UserSkills.Remove(data);
                        conn.SaveChanges();

                    }
                    return data;
                }
            }
            catch (Exception)
            {

                throw;
            }


        } //buat delete biasanya pake row status biar softdelete aja, tapi di soal tablenya ga ada row status

    }

}