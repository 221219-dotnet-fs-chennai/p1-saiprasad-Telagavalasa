using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainersData
{
    public  class Company
    {
        public int Cmp_ID { get; set; }
        public string Company_Name { get; set; }
        public string Field { get; set; }
        public string Experience{ get; set;}

        public override string ToString()
        {
            return $" CompanyName::{Company_Name}\n Working Filed::{Field}\nYearsOfExperience::{Experience}\n";
        }
    }
}
