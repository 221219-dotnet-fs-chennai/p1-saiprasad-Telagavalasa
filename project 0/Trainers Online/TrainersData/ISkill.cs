using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainersData
{
    public  interface ISkill
    {
        void Display1(int id);

         void AddSkills(int id);
        int  getSkills(int id);

        void Display(int id);
        
        int ModifySkill(int id);
        int DeleteSkill(int id);
        Skill DisplaySkills(Skill s);
    }
}
