using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentApi;
using FluentApi.Entities;
using Models;

namespace Bussiness_Logic
{
    public  class FilterLogic : IFilterLogic
    {
        Project1Context context ;
        IFilter<FluentApi.Entities.Trainer> repo;
        public FilterLogic(Project1Context _context ,IFilter<FluentApi.Entities.Trainer> _repo)
        {
            repo = _repo;
            context = _context;
        }

        public IEnumerable<Models.Trainer> GetTrainersByDay(string specifiedDay)
        {
            return Mapper.Map(repo.GetTrainersByDay(specifiedDay,context.Trainers.ToList(), context.Availabilities.ToList()));

        }

        public IEnumerable<Models.Trainer> GetTrainersByExperience(int experience)
        {
            return Mapper.Map(repo.GetTrainersByExperience(experience, context.Trainers.ToList(), context.Companies.ToList()));
        }

        public IEnumerable<Models.Trainer> GetTrainersByHourlyRate( string HourlyRate1, string HourlyRate2)
        {
           return Mapper.Map(repo.GetTrainersByHourlyRate(HourlyRate1,HourlyRate2,context.Trainers.ToList(),context.Availabilities.ToList()));
        }

        public IEnumerable<Models.Trainer> GetTrainersBySkillName(string skillname)
        {
            return Mapper.Map(repo.GetTrainersBySkillName(skillname, context.Trainers.ToList(), context.Skills.ToList()));
        }
    }
}
