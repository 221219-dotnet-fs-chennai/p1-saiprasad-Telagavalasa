using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness_Logic;
using FluentApi.Entities;
using Microsoft.IdentityModel.Tokens;
using Models;

namespace UI_Console
{
    public  class Login
    {
        Models.Trainer t = new Models.Trainer();
        ILogic l = new Logic();
        public Models.Trainer IsAccountExists()
        {
            reenter:
            Console.WriteLine("Enter your email:");
            t.Email = Console.ReadLine();
            Console.WriteLine("Enter your Password");
            t.Password = Console.ReadLine();
            Console.WriteLine("Enter your Name");
            t.Name = Console.ReadLine();
            if (!Validation.CheckTrainerExists(t)) 
            {
                Console.WriteLine("Email and Password does not match, press enter to try again");
                Console.ReadKey();

               
            }
            
            
                Console.WriteLine("Login succesfull");
            return t;
            
        }
    }
}
