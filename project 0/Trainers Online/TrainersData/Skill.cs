using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Azure;

namespace TrainersData
{

    
    public  class Skill
    {
        public int Skill_ID { get; set; }
        public string Skill_1 { get; set; }
       
        public string Skill_2 { get; set; }
        public string Skill_3 { get; set; }

        public override string ToString()
        {
            return $" Skill-1::{Skill_1}\n skill-2::{Skill_2}\n skill-3::{Skill_3} \n";
        }
    }
}
