using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using TrainersData;


namespace UI_Console
{

    public class SignUp
    {
        
        readonly string connectionString;
        Trainer t =new Trainer();



        public SignUp(string connectionString)
        {
            this.connectionString = connectionString;
        }

      
        public Trainer NewAddTrainer()
        {
            Console.WriteLine("Enter your email:");
            t.Email = Console.ReadLine();
            SqlConnection connect= new SqlConnection(connectionString);
            connect.Open();
            
            string query = $"select Email from Trainers where Email='{t.Email}'";
            
            SqlCommand command= new SqlCommand(query, connect);
            SqlDataReader reader =command.ExecuteReader(0);

            if(reader.Read())
            {
                Console.WriteLine("Email already Exists in Trainers");
                NewAddTrainer();
                return t;
            }
            else
            {
                Console.WriteLine("Enter your User_id");
                t.User_ID =Convert.ToInt32( Console.ReadLine());
                Console.WriteLine("Enter your password");
                t.Password = Console.ReadLine();
                reader.Close();

                query = $"Insert into Trainers (User_ID,Email,Password) values ('{t.User_ID}','{t.Email}','{t.Password}')";


                command =new SqlCommand(query, connect);
                int rows = command.ExecuteNonQuery();
                Console.WriteLine("=-=-=-=-=-==-=-Account Created Successfully-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.ReadKey();
                
                return t;
            }
            
    }
          
        
       
    }
    
}
