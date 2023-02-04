using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentApi.Entities;

namespace FluentApi
{
    public  interface IFilter<Trainer>
    {
      
        public List<Entities.Trainer> GetTrainersByDay(string specifiedDay, List<Entities.Trainer> trainers, List<Entities.Availability> availabilities);
        public List<Entities.Trainer> GetTrainersByHourlyRate(string HourlyRate1,string HourlyRate2, List<Entities.Trainer> trainers, List<Entities.Availability> availabilities);

    }
}
