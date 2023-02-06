
using FluentApi;
using FluentApi.Entities;
using Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Bussiness_Logic
{
    public  class SkillLogic:ISkillLogic
    {
         Project1Context context;
        Validation v;
        ISkill<FluentApi.Entities.Skill> repo;
        public SkillLogic(ISkill<FluentApi.Entities.Skill> _repo,Project1Context _context,Validation _v)
        {
            repo = _repo;
            context= _context;
            v = _v;
        }

        public IEnumerable<Models.Skill> GetSkills(string email)
        {
            int id = v.TrainerIdByEmail(email);
            return Mapper.Map(repo.GetSkills(id));
          
        }

        public void AddSkills(string email, Models.Skill s)
        {
            


            s.TrainerId = v.TrainerIdByEmail(email);

            repo.AddSkills(Mapper.Map(s));

        }

        public void UpdateSkill(string email, Models.Skill s)
        {
            s.TrainerId = v.TrainerIdByEmail(email);
            var skill = context.Skills.Where(item => item.TrainerId == s.TrainerId).First();
            if(skill != null)
            {
                skill.SkillName = s.SkillName;
                skill.Proficiency= s.Proficiency;
                repo.UpdateSkills(skill);
            }

        }

        public Models.Skill DeleteSkill(string email, string skillname)
        {
           
            var deletedskill = v.getskillname(v.TrainerIdByEmail(email), skillname);
            return Mapper.Map( repo.DeleteSkills((deletedskill)));
        }
    }
}
