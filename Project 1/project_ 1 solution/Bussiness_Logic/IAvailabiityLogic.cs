using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Logic
{
    public  interface IAvailabiityLogic
    {
        IEnumerable<Models.Availability> GetAvailability(string email);
        void AddAvailability(string email, Models.Availability a);
        void UpdateAvailability(string email, Models.Availability a);
        Models.Availability DeleteAvaiability(string email, string avaday);
    }
}
