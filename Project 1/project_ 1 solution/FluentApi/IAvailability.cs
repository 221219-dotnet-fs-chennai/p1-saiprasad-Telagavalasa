using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentApi.Entities;

namespace FluentApi
{
    public interface IAvailability<Availability>
    {
        List<Availability> GetAvailability(int id);
        void AddAvailability(Entities.Availability avail);
        void UpdateAvailability(Entities.Availability avail);

        Availability DeleteAvailabilty(Entities.Availability avail);
    }
}
