using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using TrainersData;

namespace UI_Console
{
     public class  Menu
    {
        private readonly string connectionString;


        public Menu(string connectionString)
        {
            this.connectionString = connectionString;
        }
        
        MoreTrainerDetails T = new MoreTrainerDetails(File.ReadAllText(@"..\..\..\connectionString.txt"));
        SkillDetails S = new SkillDetails(File.ReadAllText(@"..\..\..\connectionString.txt"));
        EducationDetails E = new EducationDetails(File.ReadAllText(@"..\..\..\connectionString.txt"));
        AvailabilityDetails A = new AvailabilityDetails(File.ReadAllText(@"..\..\..\connectionString.txt"));
        CompanyDetails C = new CompanyDetails(File.ReadAllText(@"..\..\..\connectionString.txt"));
        Skill s=new Skill();
        Education e=new Education();
        Company c = new Company();
        Availability a = new Availability();
        //Trainer t= new Trainer;
         int id;
        


        public  string UserChoice(Trainer t)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = $"select User_Id from Trainers where Email ='{t.Email}'";
            SqlCommand command = new SqlCommand(query, con);
            using SqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                 id =reader.GetInt32(0);
            }
            bool repeat = true;
            while (true) {
                Console.Clear();

                Console.WriteLine("[1] to view Trainer Details");
                Console.WriteLine("[2] to View Skills Details");
                Console.WriteLine("[3]  to View Education Details");
                Console.WriteLine("[4 ] to view Comapany Details");
                Console.WriteLine("[5] to view Trainer Avaialabiity");
                Console.WriteLine("[6] to view Entire Trainer Profile");
                Console.WriteLine("[0] Exit");
                try
                {
                    Console.WriteLine("Enter your choice :");
                    int userInput = Convert.ToInt32(Console.ReadLine());

                    //Switch cases are just useful if you are doing a bunch of comparison
                    switch (userInput)
                    {
                        case 0:
                            repeat = false;
                            return "Program";

                        case 1:
                            Log.Logger.Information("----User able to view Trainer details----");
                            T.Display(t);
                            break;

                        case 2:
                            Log.Logger.Information("----User able to view Skill details----");
                            S.Display1(id);
                            break;
                        case 3:
                            Log.Logger.Information("----User able to view Company details----");
                            E.Display2(id);

                            break;
                        case 4:
                            Log.Logger.Information("----User able to view Education details----");
                            C.Display3(id);
                            break;
                        case 5:
                            Log.Logger.Information("----User able to view Availability details----");
                            A.Display4(id);
                            break;
                        case 6:
                            Console.WriteLine("");
                            Console.WriteLine("----------------- Trainer Details :-----------------------");
                            Console.WriteLine(T.DisplayTrainerData(t).ToString());
                            Console.WriteLine("");
                            Console.WriteLine("----------------Skills :------------------------------------");
                            s.Skill_ID = id;
                            Console.WriteLine((S.DisplaySkills(s)).ToString());
                            Console.WriteLine();
                            Console.WriteLine("");
                            Console.WriteLine("----------------- Company :----------------------------------");
                            c.Cmp_ID = id;
                            Console.WriteLine(C.DisplayCompany(c).ToString());
                            Console.WriteLine("");
                            Console.WriteLine("-------------------Education:----------------------------------");
                            e.Edu_ID = id;
                            Console.WriteLine(E.DisplayEducation(e).ToString());
                            Console.WriteLine("");
                            Console.WriteLine("------------------- Avaliability:----------------------------------");
                            a.Ava_ID = id;
                            Console.WriteLine(A.DisplayAvailability(a).ToString());
                            Console.WriteLine("");
                            Console.WriteLine("==-=-=-=-=-=-=-=-=More Functionality Are Going To Add Please do Visit Again [THANK YOU]=--=-=-=-=-=-=-=-=-=-=-=-=-");
                            Console.ReadKey();
                            break;


                    }
                }
                  catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
