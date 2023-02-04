using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace FluentApi.Entities
{
    public class FilterRepo : IFilter<Trainer>
    {
        Project1Context context = new Project1Context();
        AvailabilityRepo er=new AvailabilityRepo();

        

        public List<Trainer> GetTrainersByDay(string specifiedDay, List<Trainer> trainers, List<Availability> availabilities)
        {
            
            var query = from trainer in trainers
                        join availability in availabilities on trainer.TrainerId equals availability.TrainerId
                        where availability.Day == specifiedDay
                        select trainer; return query.ToList();
        }

        public List<Trainer> GetTrainersByHourlyRate(string HourlyRate1, string HourlyRate2, List<Trainer> trainers, List<Availability> availabilities)
        {
            var query = from trainer in trainers
                        join availability in availabilities on trainer.TrainerId equals availability.TrainerId
                        where availability.HourlyRate == HourlyRate1 || availability.HourlyRate == HourlyRate2
                        select trainer; return query.ToList();

        }
    }
}
