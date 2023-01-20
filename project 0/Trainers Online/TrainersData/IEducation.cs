using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainersData
{
    public interface IEducation
    {
        void Display2(int id);

        void AddEducation(int id);
        int getEducation(int id);

        void Display(int id);

        int ModifyEducation(int id);
        int DeleteEducation(int id);
        Education DisplayEducation(Education e);
    }

}
