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
        public  int TrainerIdByEmail(Models.Trainer t)
        {
           
            
                int id = 0;
                var ans = context.Trainers.Where(item => item.Email==t.Email).First();
                if (ans.Email == t.Email)
                {
                    id = ans.TrainerId;
                }
                return id;
            
           
           
        }
    }
    }

