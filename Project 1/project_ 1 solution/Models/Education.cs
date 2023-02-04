using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class Education
    {
        public int EduId { get; set; }

        public int? TrainerId { get; set; }

        public string? Institution { get; set; }

        public string? Degree { get; set; }


        public  override  string ToString()
        {
            return $"Institution:{Institution}\n Degree:{Degree}";
        }
    }
}
