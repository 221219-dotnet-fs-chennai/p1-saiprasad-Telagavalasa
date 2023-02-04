using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Skill
    {
        public int SkillId { get; set; }

        public int? TrainerId { get; set; }

        public string? SkillName { get; set; }

        public string? Proficiency { get; set; }


        public override string ToString()
        {
            return $"SkillName:{SkillName}\n Proficiency:{Proficiency}";
        }
    }
}
