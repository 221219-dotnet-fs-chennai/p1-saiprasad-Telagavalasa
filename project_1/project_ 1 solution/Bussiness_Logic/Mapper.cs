using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentApi;
using FluentApi.Entities;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Bussiness_Logic
{
    public class Mapper
    {
         private static Project1Context context=new Project1Context();
        public static Models.Trainers Map(FluentApi.Entities.Trainer t)
        {
            return new Models.Trainers()
            {

                Email = t.Email,
                Name = t.Name,
                Age = (int)t.Age,
                Gender = t.Gender,
                Phone_Number=t.PhoneNumber,
                City = t.City,
               zipcode= t.Zipcode

            };
        }

        public static IEnumerable<Models.Trainers> Map(IEnumerable<FluentApi.Entities.Trainer> trainers)
        {
            return trainers.Select(Map);
        }
        public static FluentApi.Entities.Trainer MapTrainerSignup(Models.Trainers t)
        {
            return new FluentApi.Entities.Trainer()
            {
                Email = t.Email,
                Password = t.Password,
                Name =t.Name
            };

        }
        public static FluentApi.Entities.Trainer MapAddTrainer(Models.Trainers t)
        {
            return new FluentApi.Entities.Trainer()
            {

               
                Age = (byte?)t.Age,
                Gender=t.Gender,
                PhoneNumber=t.Phone_Number,
                City=t.City,
                Zipcode=t.zipcode
            };

        }
    }
}
