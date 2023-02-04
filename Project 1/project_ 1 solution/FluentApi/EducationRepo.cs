using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentApi.Entities;
using Microsoft.EntityFrameworkCore;
using Models;

namespace FluentApi.Entities
{
    public class EducationRepo : IEducation<Education>
    {
        Project1Context context = new Project1Context();
        public void AddEducation(Entities.Education e)
        {
            context.Educations.Add(e);

            context.SaveChanges();
        }



        public Education DeleteEducation(Education education)
        {
            context.Educations.Remove(education);
            context.SaveChanges();
            return education;
        }

        public List<Education> GetEducation(int id)
        {
            return context.Educations.Where(e => e.TrainerId == id).ToList();
        }

        public void UpdateEducation(Education education)
        {
            context.Educations.Update(education);
            context.SaveChanges();
        }
    }
}
