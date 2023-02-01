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
        public static Models.Trainer Map(FluentApi.Entities.Trainer t)
        {
            return new Models.Trainer()
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

        public static IEnumerable<Models.Trainer> Map(IEnumerable<FluentApi.Entities.Trainer> trainers)
        {
            return trainers.Select(Map);
        }


        public static FluentApi.Entities.Trainer Map(Models.Trainer t)
        {
            return new FluentApi.Entities.Trainer()
            {

                Email = t.Email,
                Name = t.Name,
                Age = (byte)t.Age,
                Gender = t.Gender,
                PhoneNumber = t.Phone_Number,
                City = t.City,
                Zipcode = t.zipcode

            };
        }
    }
}
