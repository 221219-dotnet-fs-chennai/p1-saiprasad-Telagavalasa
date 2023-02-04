using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentApi.Entities;

namespace Bussiness_Logic
{
    public  class Validation
    {
        private static Project1Context context = new Project1Context();
        public static bool CheckTrainerExists(Models.Trainer t)
        {
            
                var ans = context.Trainers.Where(item => item.Email == t.Email).First();
                if (ans.Email == t.Email && ans.Password == t.Password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
          
            return false;
        }
        public  int TrainerIdByEmail(string email)
        {
           
            
                int id = 0;
                var ans = context.Trainers.Where(item => item.Email==email).First();
                if (ans.Email == email)
                {
                    id = ans.TrainerId;
                }
                return id;
            
           
           
        }
        public int TrainerIdEmail(Models.Trainer t)
        {


            int id = 0;
            var ans = context.Trainers.Where(item => item.Email == t.Email).First();
            if (ans.Email == t.Email)
            {
                id = ans.TrainerId;
            }
            return id;



        }


        public Skill getskillname(int id, string name)
        {
            return context.Skills.Where(s => s.TrainerId == id && s.SkillName == name).First();
        }
        public Education geteducationname(int id, string name)
        {
            return context.Educations.Where(e => e.TrainerId == id && e.Institution == name).First();
        }
        public Company getcompanyname(int id, string name)
        {
            return context.Companies.Where(c => c.TrainerId == id && c.CmpName == name).First();
        }
        public Availability getavailableday(int id, string name)
        {
            return context.Availabilities.Where(a => a.TrainerId == id && a.Day == name).First();
        }

    }
}

