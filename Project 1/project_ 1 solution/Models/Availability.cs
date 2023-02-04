using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class Availability
    {
        public int AvaId { get; set; }

        public int? TrainerId { get; set; }

        public string? Day { get; set; }

        public string? StartTime { get; set; }

        public string? EndTime { get; set; }

        public string? HourlyRate { get; set; }
        public override string ToString()
        {
            return $"Day:{Day}\nStartTime:{StartTime}\nEndTime:{EndTime}\nHourlyRate:{HourlyRate}";
        }
    }
}
