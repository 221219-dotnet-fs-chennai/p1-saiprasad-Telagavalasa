using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Data.SqlClient;

namespace TrainersData
{
    public class EducationDetails:IEducation
    {
        private readonly string connectionString;

        public EducationDetails(string connectionString)
        {
            this.connectionString = connectionString;
        }
        Education e = new Education();

        public void Display2(int id)
        {
            Console.Clear();
            e.Edu_ID = id;
            bool repeat = true;
            while (repeat == true)
            {
               // Console.Clear() ;
                Console.WriteLine("Enter 1 to Add Education Details");
                Console.WriteLine("Enter 2 to upadte Education Details");
                Console.WriteLine("Enter 3 to Delete Education Detais");
                Console.WriteLine("Enter 4 to Display Education Details");
                Console.WriteLine("Enter 0 to exit");
                Console.WriteLine("Enter your choice");
                int ans = Convert.ToInt32(Console.ReadLine());

                switch (ans)
                {
                    case 1:
                        AddEducation(id);
                        //Adding education details
                        break;
                    case 2:
                        ModifyEducation(id);
                        //modify education details;
                        break;
                    case 3:
                        DeleteEducation(id);
                        //delete the education details;
                        break;
                    case 4:
                        Console.WriteLine(DisplayEducation(e).ToString());
                        //display
                        break;
                    case 0:
                        repeat = false;
                        break;




                }
            }
        }

        public void AddEducation(int id)
        {
            Console.WriteLine("Enter your most recent Degree");
            e.Degree = Console.ReadLine();
            Console.WriteLine("Enter Institution Name");
            e.Institution = Console.ReadLine();

            using SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();

            string query = $" Insert into Education(Edu_ID ,Degree, Institution) values ({id},'{e.Degree}','{e.Institution}')";
            SqlCommand command = new SqlCommand(query, connect);
            int rows = command.ExecuteNonQuery();
            Console.WriteLine(rows + "row added ");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-Education detais added successfully-=-=-=-=-=-=-=-=-=");

            //Console.ReadKey();
        }


        public int getEducation(int id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            // fire the query for Eduction
            string query = $"select * from Education where Edu_ID='{id}'";
            using SqlCommand command = new SqlCommand(query, con);
            // execute it
            using SqlDataReader reader = command.ExecuteReader();
            // process the output
            while (reader.Read())
            {
                //e.Edu_ID = reader.GetInt32(1);
                e.Degree = reader.GetString(1);
                e.Institution = reader.GetString(2);
            }
            con.Close();
            return id;
        }

        public void Display(int id)
        {
            
            Console.WriteLine("[1] Degree- " + e.Degree);
            Console.WriteLine("[2] Institution - " + e.Institution);
            Console.WriteLine("[3] Save");
            Console.WriteLine("[4] Go Back");
        }
        public int ModifyEducation(int id)
        {
            bool loop = true;
            id = getEducation(id);
            while (loop)
            {
                Display(id);
                Console.WriteLine("enter a column to update");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter your recent Degree to change");
                        e.Degree = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Enter Your Institution to change");
                        e.Institution = Console.ReadLine();
                        break;
                    case 3:
                        SqlConnection connect = new SqlConnection(connectionString);
                        connect.Open();
                        string query = $"Update Education set Degree='{e.Degree}',Institution='{e.Institution}' where Edu_ID={id} ";
                        SqlCommand command = new SqlCommand(query, connect);
                        SqlDataReader reader = command.ExecuteReader();
                        connect.Close();
                        Console.WriteLine("=-=-=-=-=-=-=-==-Eduaction details updated successfully=-=-=--=-=-=-=-=-=-=-=--=-=");
                        Console.WriteLine("");
                        break;
                    case 4:
                        loop = false;
                        break;
                }



            }
            //Console.ReadKey();
            return id;
        }
        public int DeleteEducation(int id)
        {
            // Console.WriteLine("Enter your email:");
            //s.Email = Console.ReadLine();
            Console.WriteLine("Are you sure to Delete Skills");
            SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();

            string query = $"Delete  from Education where Edu_ID='{id}'";

            SqlCommand command = new SqlCommand(query, connect);

            int rows = command.ExecuteNonQuery();
            connect.Close();
            Console.WriteLine("-=-=-=-=-=-=-=-=- Education details deleted successfully=-=-=-=-=-=-=-=-=--=-");
            Console.WriteLine("");

            //Console.ReadKey();

            return id;
        }
        public Education DisplayEducation(Education e)
        {

            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = $"select * from Education where Edu_ID='{e.Edu_ID}'";
            using SqlCommand command = new SqlCommand(query, con);
            // execute it
            using SqlDataReader reader = command.ExecuteReader();
            // process the output
            if (reader.Read())
            {
                e.Degree = reader.GetString(1);
                e.Institution = reader.GetString(2);

            }

           // Console.ReadKey();
            return e;
        }
    }
}
