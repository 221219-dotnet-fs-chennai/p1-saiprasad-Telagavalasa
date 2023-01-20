using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainersData
{
    internal interface IAvailability
    {
        void Display4(int id);

        void AddAvailability(int id);
        int getAvailability(int id);

        void Display(int id);

        int ModifyAvailabiity(int id);
        int DeleteAvailability(int id);
        Availability DisplayAvailability(Availability a);
    }
}
