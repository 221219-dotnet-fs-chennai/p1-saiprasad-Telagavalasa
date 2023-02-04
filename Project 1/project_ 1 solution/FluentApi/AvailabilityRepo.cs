using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace FluentApi.Entities
{
    public class AvailabilityRepo : IAvailability<Availability>
    {
        Project1Context context=new Project1Context();
        public void AddAvailability(Availability avail)
        {
            context.Availabilities.Add(avail);

            context.SaveChanges();
        }

        public Availability DeleteAvailabilty(Availability avail)
        {
            context.Availabilities.Remove(avail);

            context.SaveChanges();
            return avail;
        }

        public List<Availability> GetAvailability(int id)
        {
           return context.Availabilities.Where(a => a.TrainerId== id).ToList();
        }

        public void UpdateAvailability(Availability avail)
        {
            context.Availabilities.Update(avail);

            context.SaveChanges();
        }
    }
}
