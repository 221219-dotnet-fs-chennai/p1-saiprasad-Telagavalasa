using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using TrainersData;


namespace UI_Console
{
     
    public class SkillDetails : ISkill
    {
        Skill s = new Skill();
        
        private readonly string connectionString;
        public SkillDetails(string connectionString)
        {
            this.connectionString = connectionString;
        }
        
        public void Display1(int id)
        {
            s.Skill_ID = id;
            bool repeat = true;
            while (repeat == true)
            {
               // Console.Clear();
                Console.WriteLine("Enter 1 to Skills");
                Console.WriteLine("Enter 2 to Upadte Skills");
                Console.WriteLine("Enter 3 to Delete skills");
                Console.WriteLine("Enter 4 to Display skills");
                Console.WriteLine("Enter 0 to exit");
                Console.WriteLine("Enter your choice");
                int ans = Convert.ToInt32(Console.ReadLine());

                switch (ans)
                {
                    case 1:
                       
                        AddSkills(id);
                        //Adding skills

                        break;
                    case 2:
                        ModifySkill(id);
                        //modify skills;
                        break;
                    case 3:
                        DeleteSkill(id);

                        //delete;
                        break;
                    case 4:
                        Console.WriteLine(DisplaySkills(s).ToString());
                        //display
                        break;
                    case 0:
                        repeat = false;
                        
                        break;




                }
            }
        }
        public void AddSkills(int id)
        {

            Console.WriteLine("Enter  your Skill_1");
            s.Skill_1 = Console.ReadLine();
            Console.WriteLine("Enter  your Skill_2");
            s.Skill_2 = Console.ReadLine();
            Console.WriteLine("Enter  your Skill_3");
            s.Skill_3 = Console.ReadLine();


            using SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();
            string query = $" Insert into Skill(Skill_ID,Skill_1,Skill_2,Skill_3) values ({id},'{s.Skill_1}','{s.Skill_2}','{s.Skill_3}')";
            SqlCommand command = new SqlCommand(query, connect);
            int rows = command.ExecuteNonQuery();
            Console.WriteLine(rows + "rows added");
            Console.WriteLine("=--=-=-=-=-=-=-==Skills Added Successfully-=-=-=-=-=-=-=-=-=-=");
           // Console.ReadKey();

        }


        public int getSkills(int id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            // fire the query

            // for skills
            string query = $"select * from Skill where Skill_ID='{id}'";
            using SqlCommand command = new SqlCommand(query, con);
            // execute it
            using SqlDataReader reader = command.ExecuteReader();
            // process the output
            while (reader.Read())
            {


                s.Skill_1 = reader.GetString(1);
                s.Skill_2 = reader.GetString(2);
                s.Skill_3 = reader.GetString(3);


            }
            con.Close();
            return id;

        }

        public void Display(int id)
        {

            Console.WriteLine("[1] Skill_1- " + s.Skill_1);
            Console.WriteLine("[2] Skill_2- " + s.Skill_2);
            Console.WriteLine("[3] Skill_3 - " + s.Skill_3);
            Console.WriteLine("[4] Save");
            Console.WriteLine("[5] Go Back");
        }
        public int ModifySkill(int id)
        {
            bool loop = true;
            id = getSkills(id);
            while (loop)
            {
                Display(id);
                Console.WriteLine("enter a column to update");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter your skill_1 to change");
                        s.Skill_1 = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Enter your skill_2 to change");
                        s.Skill_2 = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Enter your skill_1 to change");
                        s.Skill_3 = Console.ReadLine();
                        break;
                    case 4:
                        SqlConnection connect = new SqlConnection(connectionString);
                        connect.Open();

                        string query = $"Update Skill set Skill_1='{s.Skill_1}',Skill_2='{s.Skill_2}',Skill_3='{s.Skill_3}' where Skill_ID={id}";

                        SqlCommand command = new SqlCommand(query, connect);
                        SqlDataReader reader = command.ExecuteReader(0);
                        connect.Close();
                        Console.WriteLine("--==-=-=-=-=-=--=-=Skills Updated=-=-=-=-=-=-=-=-=-=-=-=-=--=");
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
        public int DeleteSkill(int id)
        {
            // Console.WriteLine("Enter your email:");
            //s.Email = Console.ReadLine();
           // Console.WriteLine("Are you sure to Delete Skills");
            SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();

            string query = $"Delete  from skill where Skill_ID='{id}'";

            SqlCommand command = new SqlCommand(query, connect);

            int rows = command.ExecuteNonQuery();
            connect.Close();
            Console.WriteLine("--=-=-=-=-=-=-=-=-=-=-skills deleted successfully-=-=-=-=-=-=-=-=-==-=-=-=-");
            Console.WriteLine("");

            Console.ReadKey();
            return id;

        }

        public Skill   DisplaySkills(Skill s)
        {

           
            //Console.ReadKey();
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = $"select * from Skill where Skill_ID='{s.Skill_ID}'";
            using SqlCommand command = new SqlCommand(query, con);
            // execute it
            using SqlDataReader reader = command.ExecuteReader();
            // process the output
            if (reader.Read())
            { 
               // s = reader;
                //s.Skill_ID = Convert.ToInt32(1);
                s.Skill_1 = reader.GetString(1);
                s.Skill_2 = reader.GetString(2);
                s.Skill_3 = reader.GetString(3);

                //Console.WriteLine("Skill_1" + s.Skill_1);

            }
            //Console.ReadKey();
            return s;
            //Console.ReadKey();
            //Console.WriteLine("Skill_1" +s.Skill_1);
            // Console.WriteLine(id + "using userid in trainer table skills deleted successfully");

           













        }
    }
}
