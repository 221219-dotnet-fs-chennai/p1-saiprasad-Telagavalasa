/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentApi.Entities;

namespace UI_Console
{
    public class Menu
    {
        private static Project1Context context = new Project1Context();
        public string UserChoice(Trainer t)
        {
           


            while (true)
            {
                Console.Clear();

                Console.WriteLine("[1] to view Trainer Details");
                Console.WriteLine("[2] to View Skills Details");
                Console.WriteLine("[3]  to View Education Details");
                Console.WriteLine("[4 ] to view Comapany Details");
                Console.WriteLine("[5] to view Trainer Avaialabiity");
                Console.WriteLine("[6] to view Entire Trainer Profile");
                Console.WriteLine("[0] Exit");


                Console.WriteLine("Enter your choice :");
                int userInput = Convert.ToInt32(Console.ReadLine());

                //Switch cases are just useful if you are doing a bunch of comparison
                switch (userInput)
                {
                    case 0:
                        break;

                    case 1:
                        // Log.Logger.Information("----User able to view Trainer details----");
                        // T.Display(t);
                        break;

                    case 2:
                        break;
                        //Log.Logger.Information("----User able to view Skill details----");
                }

            }
        }
    }
}*/
