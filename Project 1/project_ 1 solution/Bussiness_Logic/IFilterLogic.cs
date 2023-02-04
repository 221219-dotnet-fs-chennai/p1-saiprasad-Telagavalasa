using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Logic
{
    public interface IFilterLogic
    {
        // public List<Models.Trainer> GetTrainersByDay(string specifiedDay, List<Models.Trainer> trainers, List<Models.Availability> availabilities);
        IEnumerable<Models.Trainer> GetTrainersByDay(string specifiedDay);
        IEnumerable<Models.Trainer> GetTrainersByHourlyRate(string HourlyRate1 ,string HourlyRate2);
    }
}
