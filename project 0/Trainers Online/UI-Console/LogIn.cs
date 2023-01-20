using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using TrainersData;

namespace UI_Console
{
    public class LogIn 
    {
        readonly string connectionString;
        Trainer t=new Trainer();
        public LogIn(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Trainer IsAccountExists()
        {
            reenter:
            Console.WriteLine("Enter your email:");
            t.Email = Console.ReadLine();
            SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();

            string query = $"select Email from Trainers where Email='{t.Email}'";

            SqlCommand command = new SqlCommand(query, connect);
            SqlDataReader reader = command.ExecuteReader(0);
           

            if (reader.Read())
            {
                pass:
                Console.WriteLine("Enter your Password:");
                string Password = Console.ReadLine();
                query = $"select Password from Trainers where Email='{t.Email}'";
                command = new SqlCommand(query, connect);
                reader.Close();
                reader = command.ExecuteReader(0);
                //sqlDataReader.Close();
                if (reader.Read())
                {
                    string verify = reader.GetString(0);
                    if (verify == Password)
                    {
                        Console.WriteLine("--=-=-=-=-=-=-=-==--=-=== Login successfull --=-=-=-=-=-=-=-=-=-=-=-=");
                    }
                    else
                    {
                        Console.WriteLine("Please check your password");
                        reader.Close();
                        goto pass;
                        //sqlDataReader.Close();



                    }
                   
                }
                //sqlDataReader.Close();

            }
            else
            {
                Console.WriteLine("Please enter correct Email");
                goto reenter;
            }
            Console.ReadKey();
            return t;
            
            
            

            




        }
            
            
            

        
        
        
    }
}
