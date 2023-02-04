using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentApi.Entities;

namespace Bussiness_Logic
{
    public  interface ISkillLogic
    {
        IEnumerable<Models.Skill> GetSkills(string email);


        //id AddSkills( rainer trainer, Skill s);
        void AddSkills(string email, Models.Skill s);
        void UpdateSkill(string email, Models.Skill s);
        Models.Skill DeleteSkill(string email,string skillname);
    }
}
