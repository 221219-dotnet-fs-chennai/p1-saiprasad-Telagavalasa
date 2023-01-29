using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness_Logic;
using Models;

namespace UI_Console
{
    public class TrainerOp
    {
        Trainers t = new Trainers();
        ILogic l = new Logic();
        public Trainers AddMoreTrainer( Trainers t)
        {
            //Trainers t = new Trainers();
           // Console.WriteLine("\n==========Welcome===========\n");
            Console.WriteLine("Enter your Age : ");
            t.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your gender: ");
            t.Gender = Console.ReadLine();
            Console.WriteLine("Enter your PhoneNumber : ");
            t.Phone_Number = Console.ReadLine();
            Console.WriteLine("Enter your City : ");
            t.City = Console.ReadLine();
            Console.WriteLine("Enter your Zipcode : ");
            t.zipcode = Console.ReadLine();
            l.AddTrainer(t);
            // l.AddTrainerSignup(t);

            return t;
        }
    }
}
