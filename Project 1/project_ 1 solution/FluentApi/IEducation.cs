using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi
{
    public  interface IEducation<Education>
    {
        List<Education> GetEducation(int id);
        void AddEducation(Entities.Education education);
        void UpdateEducation(Entities.Education education);

        Education DeleteEducation(Entities.Education  education);
    }
}
