using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness_Logic;
using FluentApi.Entities;
using Models;

namespace UI_Console
{
    public class Signup
    {
        //Project1Context context = new Project1Context();
        // private static FluentApi.Entities.Trainer trainer = new();
        // private static ILogic l = new Logic();
        // Trainer t = new Trainer();
        //EFRepo ef = new EFRepo();
        Models.Trainer t = new Models.Trainer();
        ILogic l = new Logic();

        public Models.Trainer NewAddTrainer()
        {
            //Trainers t = new Trainers();
            Console.WriteLine("\n==========Welcome===========\n");
            Console.WriteLine("Enter your Email : ");
             t.Email = Console.ReadLine();
            Console.WriteLine("Enter your Password : ");
            t.Password = Console.ReadLine();
            Console.WriteLine("Enter your Name : ");
            t.Name = Console.ReadLine();
            l.AddTrainerSignup(t);

            return t;
        }
    }
}
