using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentApi.Entities;
using FluentApi;
using Models;

namespace Bussiness_Logic
{
    public  class AvailabilityLogic:IAvailabiityLogic
    {
        private static Project1Context context = new Project1Context();
        Validation v = new Validation();
        IAvailability<FluentApi.Entities.Availability> repo;

        public AvailabilityLogic() {
            repo = new FluentApi.Entities.AvailabilityRepo();

        }

        public void AddAvailability(string email, Models.Availability a)
        {
            a.TrainerId = v.TrainerIdByEmail(email);

            repo.AddAvailability(Mapper.Map(a));
        }

        public Models.Availability DeleteAvaiability(string email, string avaday)
        {
            var deletedavailability = v.getavailableday(v.TrainerIdByEmail(email), avaday);
            return Mapper.Map(repo.DeleteAvailabilty((deletedavailability)));
        }

        public IEnumerable<Models.Availability> GetAvailability(string email)
        {
            int id = v.TrainerIdByEmail(email);
            return Mapper.Map(repo.GetAvailability(id));
        }

        public void UpdateAvailability(string email, Models.Availability a)
        {

            a.TrainerId = v.TrainerIdByEmail(email);
            var avail = context.Availabilities.Where(item => item.TrainerId == a.TrainerId).First();
            if (avail != null)
            {
                avail.Day = a.Day;
                avail.StartTime= a.StartTime;
                avail.EndTime= a.EndTime;
                avail.HourlyRate= a.HourlyRate;

                repo.UpdateAvailability(avail);
            }
        }
    }
}
