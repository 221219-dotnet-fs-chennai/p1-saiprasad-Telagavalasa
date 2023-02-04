using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class Company
    {
        public int CmpId { get; set; }

        public int? TrainerId { get; set; }

        public string? CmpName { get; set; }

        public string? Role { get; set; }

        public int? Experience { get; set; }

        public override string ToString()
        {
            return $"CmpName:{CmpId}\nRole:{Role}\nExperience:{Experience}";
        }
    }
}
