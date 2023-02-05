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
              // TrainerId=t.TrainerId,
                Email = t.Email,
                Password=t.Password,
                Name = t.Name,
                Age = t.Age,
                Gender = t.Gender,
                PhoneNumber=t.PhoneNumber,
                City = t.City,
               Zipcode= t.Zipcode

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
                //TrainerId=t.TrainerId,
                Email = t.Email,
                Password = t.Password,
                Name = t.Name,
                Age = t.Age,
                Gender = t.Gender,
                PhoneNumber = t.PhoneNumber,
                City = t.City,
                Zipcode = t.Zipcode

            };
        }
        public static Models.Skill Map(FluentApi.Entities.Skill s)
        {
            return new Models.Skill()
            {
              
                TrainerId= (int)s.TrainerId,
                SkillName = s.SkillName,
                Proficiency = s.Proficiency

            };
        }
        public static FluentApi.Entities.Skill Map(Models.Skill s)
        {
            return new FluentApi.Entities.Skill()
            {
              
                TrainerId= (int)s.TrainerId,
                SkillName = s.SkillName,
                Proficiency = s.Proficiency

            };
        }
        public static IEnumerable<Models.Skill> Map(IEnumerable<FluentApi.Entities.Skill> skills)
        {
            return skills.Select(Map);
        }
        public static Models.Education Map(FluentApi.Entities.Education e)
        {
            return new Models.Education()
            {

                TrainerId = (int)e.TrainerId,
                Institution=e.Institution,
                Degree=e.Degree,

            };
        }
        public static FluentApi.Entities.Education Map(Models.Education e)
        {
            return new FluentApi.Entities.Education()
            {
                TrainerId = (int)e.TrainerId,
                Institution=e.Institution,
                Degree=e.Degree,

            };
        }
        public static IEnumerable<Models.Education> Map(IEnumerable<FluentApi.Entities.Education> educations)
        {
            return educations.Select(Map);
        }
        public static Models.Company Map(FluentApi.Entities.Company c)
        {
            return new Models.Company()
            {

                TrainerId = (int)c.TrainerId,
                CmpName= c.CmpName,
                Role= c.Role,
                Experience= c.Experience,

            };
        }

        public static FluentApi.Entities.Company Map(Models.Company c)
        {
            return new FluentApi.Entities.Company()
            {
                TrainerId = (int)c.TrainerId,
                CmpName= c.CmpName,
                Role= c.Role,
                Experience= c.Experience,

            };
        }
        public static IEnumerable<Models.Company> Map(IEnumerable<FluentApi.Entities.Company> companies)
        {
            return companies.Select(Map);
        }
        public static Models.Availability Map(FluentApi.Entities.Availability a)
        {
            return new Models.Availability()
            {

                TrainerId = (int)a.TrainerId,
               Day= a.Day,
               StartTime= a.StartTime,
               EndTime= a.EndTime,
               HourlyRate= a.HourlyRate,

            };
        }




        public static FluentApi.Entities.Availability Map(Models.Availability a)
        {
            return new FluentApi.Entities.Availability()
            {
                TrainerId = (int)a.TrainerId,
                Day=a.Day,
                StartTime=a.StartTime,
                EndTime=a.EndTime,
                HourlyRate=a.HourlyRate,

            };
        }

        public static IEnumerable<Models.Availability> Map(IEnumerable<FluentApi.Entities.Availability> availabilities)
        {
            return availabilities.Select(Map);
        }


        public static FluentApi.Entities.Availability Map4(Models.Availability a)
        {
            return new FluentApi.Entities.Availability()
            {
                //TrainerId = (int)a.TrainerId,
                Day = a.Day,
                StartTime = a.StartTime,
                EndTime = a.EndTime,
                HourlyRate = a.HourlyRate,

            };
        }





    }
    }

