using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi
{
    public  interface ISkill<Skill>
    {
        List<Skill> GetSkills(int id);
        void AddSkills(Entities.Skill skill);
        void UpdateSkills(Entities.Skill skill);

        Skill DeleteSkills(Entities.Skill skill);

    }
}
