using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Logic
{
    public  interface IEducationLogic
    {
        IEnumerable<Models.Education> GetEducation(string email);
        void AddEducation(string email, Models.Education e);
        void UpdateEducation(string email, Models.Education e);
        Models.Education DeleteEducation(string email, string eduname);
    }
}
