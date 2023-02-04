using FluentApi;
using FluentApi.Entities;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Bussiness_Logic
{
    public class EducationLogic : IEducationLogic
    {
        private static Project1Context context = new Project1Context();
        Validation v = new Validation();
        IEducation<FluentApi.Entities.Education> repo;
        public EducationLogic()
        {
            repo = new FluentApi.Entities.EducationRepo();
        }




        public void AddEducation(string email, Models.Education e)
        {
            e.TrainerId = v.TrainerIdByEmail(email);

            repo.AddEducation(Mapper.Map(e));
        }

        public Models.Education DeleteEducation(string email, string skillname)
        {
            var deletededucation = v.geteducationname(v.TrainerIdByEmail(email), skillname);
            return Mapper.Map(repo.DeleteEducation((deletededucation)));
        }

        public IEnumerable<Models.Education> GetEducation(string email)
        {
            int id = v.TrainerIdByEmail(email);
            return Mapper.Map(repo.GetEducation(id));
        }

        public void UpdateEducation(string email, Models.Education e)
        {
            e.TrainerId = v.TrainerIdByEmail(email);
            var education = context.Educations.Where(item => item.TrainerId == e.TrainerId).First();
            if (education != null)
            {
                education.Institution = e.Institution;
                education.Degree = e.Degree;
                repo.UpdateEducation(education);
            }
        }

      

        
    }
}
