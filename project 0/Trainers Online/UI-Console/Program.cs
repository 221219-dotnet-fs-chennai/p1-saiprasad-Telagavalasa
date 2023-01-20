global using Serilog;
using System.ComponentModel.DataAnnotations;
using TrainersData;

namespace UI_Console
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Initialize the logger
            Log.Logger = new LoggerConfiguration()
              .WriteTo.File(@"..\..\..\Logs\logs.txt")
              .CreateLogger();

            Log.Logger.Information("----Program starts----");


            SignUp s = new SignUp(File.ReadAllText(@"..\..\..\connectionString.txt"));
            LogIn L = new LogIn(File.ReadAllText(@"..\..\..\connectionString.txt"));
            MoreTrainerDetails U = new MoreTrainerDetails(File.ReadAllText(@"..\..\..\connectionString.txt"));
            Menu M = new Menu(File.ReadAllText(@"..\..\..\connectionString.txt"));
            //string conStr = File.ReadAllText("../../../connectionString.txt");
           // Modify M = new Modify(File.ReadAllText(@"..\..\..\connectionString.txt"));

            //IRepo repo = new Modify(conStr);
            Trainer t = new Trainer();
            bool repeat = true;
            while (repeat)
            {
                Console.Clear();
                Console.WriteLine("  ");
                Console.WriteLine("==-=-=-=-=-=-=-=-=-=-=-=-=-Welcome To Find Trainer Online=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("Enter 1 to Sign_Up");
                Console.WriteLine("Enter 2 to Sign_In");
                Console.WriteLine("Enter 3 to Exit   ");
                Console.WriteLine(" ");
                try
                {

                    Console.Write("Enter Your Choice : ");
                    int ans = Convert.ToInt32(Console.ReadLine());



                    switch (ans)
                    {
                        case 1:
                            Log.Logger.Information("----User Able to create Account----");
                            s.NewAddTrainer();
                            //U.Display();
                            break;
                        case 2:
                            Log.Logger.Information("----User trying to login into application----");
                            t = L.IsAccountExists();
                            M.UserChoice(t);
                            break;
                        case 3:
                            repeat = false;
                            //U.AddDetails(t);
                            break;


                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Log.Logger.Information("----Program Ends----");
            }
         }   
           // Log.Logger.Information("----Program Ends----");


     }

 }









                
           



            

           
         

        
    
