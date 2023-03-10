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
        Project1Context context;
        public FilterRepo(Project1Context _context) 
        {
            context = _context;

        }

        

        public List<Trainer> GetTrainersByDay(string specifiedDay, List<Trainer> trainers, List<Availability> availabilities)
        {
            
            var query = from trainer in trainers
                        join availability in availabilities on trainer.TrainerId equals availability.TrainerId
                        where availability.Day == specifiedDay
                        select trainer; return query.ToList();
        }

        public List<Trainer> GetTrainersByExperience(int experience, List<Trainer> trainers, List<Company> companies)
        {
            var query = from trainer in trainers
                        join Company in companies on trainer.TrainerId equals Company.TrainerId
                        where Company.Experience >= experience
                        select trainer; return query.ToList();

        }

        public List<Trainer> GetTrainersByHourlyRate(string HourlyRate1, string HourlyRate2, List<Trainer> trainers, List<Availability> availabilities)
        {
            var query = from trainer in trainers
                        join availability in availabilities on trainer.TrainerId equals availability.TrainerId
                        where availability.HourlyRate == HourlyRate1 || availability.HourlyRate == HourlyRate2
                        select trainer; return query.ToList();

        }

        public List<Trainer> GetTrainersBySkillName(string skillName, List<Trainer> trainers, List<Skill> skills)
        {
           var query= from trainer in trainers
                      join Skill in skills on trainer.TrainerId equals Skill.TrainerId
                      where Skill.SkillName == skillName
                      select trainer; return query.ToList();
        }
    }
}
