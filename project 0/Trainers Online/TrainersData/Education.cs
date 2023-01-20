using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainersData
{
    public class Education
    {
        public int Edu_ID { get; set; }
        public string Degree { get; set; }
        public string Institution { get; set; }



        public override string ToString()
        {
            return $" Degree::{Degree}\nClgName::{Institution}\n";
        }
    }
  
}
