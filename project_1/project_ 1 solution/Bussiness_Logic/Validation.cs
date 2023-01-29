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
        public static bool CheckTrainerExists(Models.Trainers t)
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
       // public static int GetTrainerIdByEmail(string email)
        //{
        //    try
        //    {
        //        int id = 0;
        //        var t = context.TrainerDetails.Where(item => item.Email == email).First();
        //        if (t.Email == email)
        //        {
        //            id = t.Trainerid;
        //        }
        //        return id;
        //    }
        //    catch (InvalidOperationException e)
        //    {
        //        Console.WriteLine("");
        //    }
        //    return 0;
        //}
    }
    }

