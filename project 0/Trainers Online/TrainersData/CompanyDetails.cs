using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace TrainersData
{
    public class CompanyDetails
    {
        private readonly string connectionString;
        public CompanyDetails(string connectionString)
        {
            this.connectionString = connectionString;
        }
        Company c = new Company();
        public void Display3(int id)
        {
            //Console.Clear();
            c.Cmp_ID = id;
            bool repeat = true;
            while (repeat == true)
            {
               // Console.Clear();
               
                Console.WriteLine("Enter 1 to Add Company Details");
                Console.WriteLine("Enter 2 to upadte Company Details");
                Console.WriteLine("Enter 3 to Delete Company Detais");
                Console.WriteLine("Enter 4 to Display Company Details");
                Console.WriteLine("Enter 0 to exit");
                try
                {
                    Console.WriteLine("Enter your choice");
                    int ans = Convert.ToInt32(Console.ReadLine());

                    switch (ans)
                    {
                        case 1:
                            AddCompany(id);
                            //Adding Company details
                            break;
                        case 2:
                            ModifyCompany(id);
                            //modify Company details;
                            break;
                        case 3:
                            DeleteCompany(id);
                            //delete the Company details;
                            break;
                        case 4:
                            Console.WriteLine(DisplayCompany(c).ToString());
                            //display
                            break;
                        case 0:
                            repeat = false;
                            break;




                    }
                }
                catch(Exception ex) { Console.WriteLine(ex.Message); }
            }
        }
        public void AddCompany(int id)
        {
            Console.WriteLine("Enter your current working Company");
            c.Company_Name = Console.ReadLine();
            Console.WriteLine("Enter your working field");
            c.Field = Console.ReadLine();
            Console.WriteLine("Enter your  working experience ");
            c.Experience = (Console.ReadLine());

            using SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();

            string query = $" Insert into Company(Cmp_ID ,Company_Name, Field,Experience) values ({id},'{c.Company_Name}','{c.Field}','{c.Experience}')";
            SqlCommand command = new SqlCommand(query, connect);
            int rows = command.ExecuteNonQuery();
            Console.WriteLine(rows + "row added ");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=Company details added successfuly-=--=-=-=-=-=-=-=-=-=-=-=-=");
            //Console.ReadKey();


        }
        public int getCompany(int id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            // fire the query for Eduction
            string query = $"select * from Company where Cmp_ID='{id}'";
            using SqlCommand command = new SqlCommand(query, con);
            // execute it
            using SqlDataReader reader = command.ExecuteReader();
            try
            {
                // process the output
                while (reader.Read())
                {
                    c.Company_Name = reader.GetString(1);
                    c.Field = reader.GetString(2);
                    c.Experience = reader.GetString(3);
                }
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
            con.Close();
            return id;
        }

        public void Display(int id)
        {
           
            Console.WriteLine("[1] Company_Name- " + c.Company_Name);
            Console.WriteLine("[2] Field - " + c.Field);
            Console.WriteLine("[3] Experience -" + c.Experience);
            Console.WriteLine("[4] Save");
            Console.WriteLine("[5] Go Back");
        }
        public int ModifyCompany(int id)
        {
            bool loop = true;
            id = getCompany(id);
            while (loop)
            {
                Display(id);
                Console.WriteLine("enter a column to update");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter your company name to update");
                        c.Company_Name = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Enter Your working field to update");
                        c.Field = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Enter your working experience to update");
                        c.Experience = Console.ReadLine();
                        break;
                    case 4:
                        SqlConnection connect = new SqlConnection(connectionString);
                        connect.Open();
                        string query = $"Update Company set Company_Name='{c.Company_Name}',Field='{c.Field}',Experience='{c.Experience}' where Cmp_ID={id} ";
                        SqlCommand command = new SqlCommand(query, connect);
                        SqlDataReader reader = command.ExecuteReader();
                        connect.Close();
                        Console.WriteLine("Company details updated successfully");
                        Console.WriteLine("");
                        break;
                    case 5:
                        loop = false;
                        break;
                }




            }
            //Console.ReadKey();
            return id;
        }
        public int DeleteCompany(int id)
        {
            // Console.WriteLine("Enter your email:");
            //s.Email = Console.ReadLine();
            //Console.WriteLine("Are you sure to Delete Company");
            SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();

            string query = $"Delete  from Company where Cmp_ID='{id}'";

            SqlCommand command = new SqlCommand(query, connect);

            int rows = command.ExecuteNonQuery();
            connect.Close();
            Console.WriteLine(id     + "using edu_id Company details deleted successfully");
            Console.WriteLine("");


            // Console.ReadKey();
            return id;
        }
        public Company DisplayCompany(Company c)
        {

            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = $"select * from Company where Cmp_ID='{c.Cmp_ID}'";
            using SqlCommand command = new SqlCommand(query, con);
            // execute it
            using SqlDataReader reader = command.ExecuteReader();
            // process the output
            if (reader.Read())
            {
                c.Company_Name = reader.GetString(1);
                c.Field = reader.GetString(2);
                c.Experience= reader.GetString(3);

            }

           // Console.ReadKey();
            return c;
        }
    }
}




