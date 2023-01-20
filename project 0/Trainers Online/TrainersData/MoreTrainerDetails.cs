using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using TrainersData;

namespace UI_Console
{


    public class MoreTrainerDetails : ITrainer
    {
        private readonly string connectionString;


        public MoreTrainerDetails(string connectionString)
        {
            this.connectionString = connectionString;
        }
        

        public void Display(Trainer t)
        {




            Console.Clear();
            bool repeat = true;
            while (repeat == true)
            {
               //Console.Clear();
                Console.WriteLine("Enter 1 to add more details of trainer");
                Console.WriteLine("Enter 2 to update Trainer details");
                Console.WriteLine("Enter 3 to Delete Trainer");
                Console.WriteLine("Enter 4 to Display Trainer");
                Console.WriteLine("Enter 0 to exit");
                Console.WriteLine("Enter your choice");
                int ans = Convert.ToInt32(Console.ReadLine());




                switch (ans)
                {
                    case 1:
                        AddDetails(t);
                        //repeat = false;
                        break;
                    case 2:
                        ModifyData(t);
                        //updatedetails;
                        break;
                    case 3:
                        DeleteTrainer(t);
                        //delete;
                        break;
                    case 4:
                        Console.WriteLine("      ");
                        Console.WriteLine("----------------- Trainer Details :----------");
                        Console.WriteLine(DisplayTrainerData(t).ToString());
                        Console.WriteLine("");
                        //display
                        break;
                    case 0:
                        repeat = false;
                        break;





                }
            }
        }
        public Trainer AddDetails(Trainer t)
        {
            Console.WriteLine("Enter your Name:");
            t.Name = Console.ReadLine();
            Console.WriteLine("Enter your Age:");
            t.Age = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("Enter your Gender:");
            t.Gender = Console.ReadLine();
            Console.WriteLine("Enter your PhoneNumber:");
            t.Phone_Number = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter your City:");
            t.City = Console.ReadLine();
            Console.WriteLine("Enter your zipcode:");
            t.zipcode = Console.ReadLine();

            using SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();
            //Console.WriteLine($"Update Trainers set Name='{U.Name}', Age='{U.Age}',Gender='{U.Gender}',Phone_Number='{U.Phone_Number}',City='{U.City}',zipcode='{U.zipcode}' where Email='{t.Email}'");

            string query = $"Update Trainers set Name='{t.Name}', Age='{t.Age}',Gender='{t.Gender}',Phone_Number='{t.Phone_Number}',City='{t.City}',zipcode='{t.zipcode}' where Email='{t.Email}'";

            SqlCommand command = new SqlCommand(query, connect);
            //SqlDataReader reader = command.ExecuteReader(0);


            int rows = command.ExecuteNonQuery();

            Console.WriteLine(rows + "row(s) added");
            Console.WriteLine("==-=-=-=-=-=-=-=-=-=Details Added Successfully-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            connect.Close();
            //Console.ReadKey();
            return t;



        }
        public Trainer getData(Trainer t)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            // fire the query

            // for trainer
            string query = $"select * from Trainers where Email='{t.Email}'";
            using SqlCommand command = new SqlCommand(query, con);
            // execute it
            using SqlDataReader reader = command.ExecuteReader();
            // process the output
            while (reader.Read())
            {

                t.User_ID = reader.GetInt32(0);
                t.Email = reader.GetString(1);
                t.Password = reader.GetString(2);
                t.Name = reader.GetString(3);
                t.Age = reader.GetByte(4);
                t.Gender = reader.GetString(5);
                t.Phone_Number = reader.GetInt64(6);
                t.City = reader.GetString(7);
                t.zipcode = reader.GetString(8);

            }
            con.Close();
            return t;
        }




        public void Display2(Trainer t)
        {

            Console.WriteLine("[1] Paswword - " + t.Password);
            Console.WriteLine("[2] Name - " + t.Name);
            Console.WriteLine("[3] Age - " + t.Age);
            Console.WriteLine("[4] gender - " + t.Gender);
            Console.WriteLine("[5] Phone_Number  - " + t.Phone_Number);
            Console.WriteLine("[6] city - " + t.City);
            Console.WriteLine("[7] Zipcode - " + t.zipcode);
            Console.WriteLine("[8] Save");
            Console.WriteLine("[9] Go Back");
        }

        public Trainer ModifyData(Trainer t)
        {
            bool loop = true;
            t = getData(t);
            while (loop)
            {



                // t =getData(t);
                Display2(t);
                Console.WriteLine("enter a column to update");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter your  password to change");
                        t.Password = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Enter your Name to change ");
                        t.Name = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Enter your Age to change ");
                        t.Age = Convert.ToByte(Console.ReadLine());
                        break;
                    case 4:
                        Console.WriteLine("Enter your gender to change ");
                        t.Gender = Console.ReadLine();
                        break;
                    case 5:
                        Console.WriteLine("Enter your Phone_Number to change ");
                        t.Phone_Number = Convert.ToInt64(Console.ReadLine());
                        break;
                    case 6:
                        Console.WriteLine("Enter your City to change ");
                        t.City = Console.ReadLine();
                        break;
                    case 7:
                        Console.WriteLine("Enter your zipcode to chnage");
                        t.zipcode = Console.ReadLine();
                        break;
                    case 8:
                        SqlConnection connect = new SqlConnection(connectionString);
                        connect.Open();

                        string query = $" Update Trainers set  Password='{t.Password}',Name='{t.Name}', Age='{t.Age}',Gender='{t.Gender}',Phone_Number='{t.Phone_Number}',City='{t.City}',zipcode='{t.zipcode}' where Email='{t.Email}'";

                        SqlCommand command = new SqlCommand(query, connect);
                        SqlDataReader reader = command.ExecuteReader(0);
                        connect.Close();
                        Console.WriteLine("-=-=-=-=-=-=-=-=- Trainer Details Updated-=-=-=-=-=-=-=-=-=-=-=-");
                        break;
                    case 9:
                        loop = false;
                        break;





                }
            }
           // Console.ReadKey();
            return t;
        }



        public Trainer DeleteTrainer(Trainer t)
        {



           // Console.WriteLine("Enter your email:");
           // t.Email = Console.ReadLine();
            SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();

            string query = $"Delete  from Trainers where Email='{t.Email}'";

            SqlCommand command = new SqlCommand(query, connect);

            int rows = command.ExecuteNonQuery();
            connect.Close();
            Console.WriteLine("-=-==-=-=-=-=-=Trainer deleted successfully-=-=-=-=--=-=-=-=-=-");
            Console.WriteLine("");


           // Console.ReadKey();
            return t;

        }


        public Trainer DisplayTrainerData(Trainer t)
        {
            //Console.WriteLine("Enter mail to display trainer data");
            //t.Email = Console.ReadLine();
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string? query = $"select * from Trainers where Email='{t.Email}'";
            using SqlCommand command = new SqlCommand(query, con);
            // execute it
            using SqlDataReader reader = command.ExecuteReader();
            // process the output
            if (reader.Read())
            {

                t.User_ID = reader.GetInt32(0);
                t.Email = reader.GetString(1);
                t.Password = reader.GetString(2);
                t.Name = reader.GetString(3);
                t.Age = reader.GetByte(4);
                t.Gender = reader.GetString(5);
                t.Phone_Number = reader.GetInt64(6);
                t.City = reader.GetString(7);
                t.zipcode = reader.GetString(8);
            }
           // Console.ReadKey();
            return t;
            
        }

    }
}

