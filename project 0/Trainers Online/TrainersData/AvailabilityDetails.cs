using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.Data.SqlClient;

namespace TrainersData
{
    public class AvailabilityDetails:IAvailability
    {
        Availability a = new Availability();

        private readonly string connectionString;
        public AvailabilityDetails(string connectionString)
        {
            this.connectionString = connectionString;
        }
        //Availability a = new Availability();
        public void Display4(int id)
        {
            Console.Clear();
            a.Ava_ID = id;
            bool repeat = true;
            while (repeat == true)
            {
               // Console.Clear();
                Console.WriteLine("Enter 1 to Add Availability Details");
                Console.WriteLine("Enter 2 to upadte Availability Details");
                Console.WriteLine("Enter 3 to Delete Availablity Detais");
                Console.WriteLine("Enter 4 to Display Availability Details");
                Console.WriteLine("Enter 0 to exit");
                Console.WriteLine("Enter your choice");

                int ans = int.Parse(Console.ReadLine());

                switch (ans)
                {
                    case 1:
                        AddAvailability(id);
                        //Adding Avaliability details
                        break;
                    case 2:
                        ModifyAvailabiity(id);
                        //modify Avaliability details;
                        break;
                    case 3:
                        DeleteAvailability(id);
                        //delete the  Avaliability details;
                        break;
                    case 4:
                        Console.WriteLine(DisplayAvailability(a).ToString());
                      
                        //display
                        break;
                    case 0:
                        repeat = false;
                        break;




                }
            }


        }

        public void AddAvailability(int id)
        {
            Console.WriteLine("Enter your available day for teaching");
            a.Day = Console.ReadLine();
            Console.WriteLine("Enter your start_time on that particular day");
            a.StartTime = Console.ReadLine();
            Console.WriteLine("Enter your End_time on that particular day");
            a.EndTime = Console.ReadLine();
            Console.WriteLine("Enter your pay(Hourly Rate) for Teaching");
            a.HourlyRate = Console.ReadLine();

            using SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();

            string query = $" Insert into Availability(Ava_ID,Day,StartTime,EndTime,HourlyRate) values ({id}, '{a.Day}','{a.StartTime}','{a.EndTime}','{a.HourlyRate}')";
            SqlCommand command = new SqlCommand(query, connect);
            int rows = command.ExecuteNonQuery();
            Console.WriteLine(rows + "row added");
            Console.WriteLine("==-=-=-=-=-=-=-=-=-=-=-=-=-=Availability Details Added Successfully=-=-=-=-=-=-=-=-=-=");
            //Console.ReadKey();


        }

        public int getAvailability(int id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            // fire the query for Eduction
            string query = $"select * from Availability where Ava_ID='{id}'";
            using SqlCommand command = new SqlCommand(query, con);
            // execute it
            using SqlDataReader reader = command.ExecuteReader();
            // process the output
            while (reader.Read())
            {
                a.Day = reader.GetString(1);
                a.StartTime = reader.GetString(2);
                a.EndTime = reader.GetString(3);
                a.HourlyRate = reader.GetString(4);
            }
            con.Close();
            return id;
        }
        public void Display(int id)
        {
            
            Console.WriteLine("[1] Day- " + a.Day);
            Console.WriteLine("[2] StartTime - " + a.StartTime);
            Console.WriteLine("[3] EndTime - " + a.EndTime);
            Console.WriteLine("[4] HourlyRate- " + a.HourlyRate);
            Console.WriteLine("[5] Save");
            Console.WriteLine("[6] Go Back");
        }
        public int ModifyAvailabiity(int id)
        {
            bool loop = true;
            id = getAvailability(id);
            while (loop)
            {
                Display(id);
                Console.WriteLine("enter a column to update");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter your Available Day to change");
                        a.Day = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Enter your Available start_time to chnage");
                        a.StartTime = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Enter your Available End_time to change");
                        a.EndTime = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Enter your Hourly price to chnage");
                        a.HourlyRate = Console.ReadLine();
                        break;
                    case 5:
                        SqlConnection connect = new SqlConnection(connectionString);
                        connect.Open();
                        string query = $"update Availability set Day='{a.Day}',StartTime='{a.StartTime}',EndTime='{a.EndTime}',HourlyRate='{a.HourlyRate}' where Ava_ID={id}";
                        SqlCommand command = new SqlCommand(query, connect);
                        SqlDataReader reader = command.ExecuteReader();
                        connect.Close();
                        Console.WriteLine("=-=-=-=-=-=-=-=-=-=Availabiity Details Updated Successfully=-=-=-=-=--=-==");
                        Console.WriteLine("");
                        break;
                    case 6:
                        loop = false;
                        break;




                }
            }
            //Console.ReadKey();
            return id;
        }
        public int DeleteAvailability(int id)
        {
            // Console.WriteLine("Enter your email:");
            //s.Email = Console.ReadLine();
            Console.WriteLine("Are you sure to Delete Skills");

            SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();

            string query = $"Delete  from Availability where Ava_ID='{id}'";

            SqlCommand command = new SqlCommand(query, connect);

            int rows = command.ExecuteNonQuery();
            connect.Close();
            Console.WriteLine("-=-=-=-=-=-=-=-=-Availability details deleted successfully=-=-=-=-=-=-=-=-=-=-=-=--");
            Console.WriteLine("");


            //  Console.ReadKey();
            return id;
        }
        public Availability DisplayAvailability(Availability a)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = $"select * from  Availability where Ava_ID={a.Ava_ID}";
            using SqlCommand command = new SqlCommand(query, con);
            // execute it
            using SqlDataReader reader = command.ExecuteReader();
            // process the output
            if (reader.Read())
            {
                //a.Ava_ID = reader.GetInt32(1);
                a.Day = reader.GetString(1);
                a.StartTime = reader.GetString(2);
                a.EndTime = reader.GetString(3);
                a.HourlyRate = reader.GetString(4);

            }
            //Console.ReadKey();
            return a;

        }

         
      
        
    }
}
