using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FluentApi.Entities
{
    public  class SkillRepo:ISkill<Skill>
    {
        Project1Context context;
        public SkillRepo(Project1Context  _context)
        {
            context = _context;
        }

        public void AddSkills( Entities.Skill s)
        {
            context.Skills.Add(s);
         
            context.SaveChanges();
        }

        public Skill DeleteSkills(Skill skill)
        {
            context.Skills.Remove(skill);
            context.SaveChanges();
            return skill;
        }

        public void UpdateSkills(Entities.Skill skill)
        {
            context.Skills.Update(skill);
            context.SaveChanges();
        }

        List<Skill> ISkill<Skill>.GetSkills(int id)
        {
            return context.Skills.Where(s => s.TrainerId == id).ToList();
        }

    }
}

   

