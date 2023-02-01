using System;
using Bussiness_Logic;
using FluentApi.Entities;
using Models;
using UI_Console;

public static class Program
{
    public static void Main(string[] args)
    {
        ILogic l = new Logic();
        // var t=l.DisplayTrainer();
        //foreach(var i in t)
        //{
        //    Console.WriteLine(i);
        //}
        //Menu m=new Menu();
        TrainerOp to=new TrainerOp();
        Signup signup= new Signup();
        Login login=new Login();
        Models.Trainer t = new Models.Trainer();
        EFRepo ef = new EFRepo();
        ILogic L = new Logic();
        bool repeat = true;
        while (repeat)
        {
            //Console.Clear();
            Console.WriteLine("  ");
            Console.WriteLine("==-=-=-=-=-=-=-=-=-=-=-=-=-Welcome To Find Trainer Online=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("Enter 1 to Sign_Up");
            Console.WriteLine("Enter 2 to Sign_In");
            Console.WriteLine("Enter 3 to Exit   ");
            Console.WriteLine(" ");
            
            

                Console.Write("Enter Your Choice : ");
                int ans = Convert.ToInt32(Console.ReadLine());



                switch (ans)
                {
                    case 1:
                        // Log.Logger.Information("----User Able to create Account----");
                        signup.NewAddTrainer();
                        //U.Display();
                        break;
                    case 2:
                        t=login.IsAccountExists();
                        to.removeTrainer(t);
                   

                        //m.UserChoice(t);
                        //Log.Logger.Information("----User trying to login into application----");
                        //t = L.IsAccountExists();
                        //M.UserChoice(t);
                        break;
                    case 3:
                       // l.RemoveTrainerByName(t.Name);
                        //U.AddDetails(t);
                        break;


                }
            }
           


        }
    }
