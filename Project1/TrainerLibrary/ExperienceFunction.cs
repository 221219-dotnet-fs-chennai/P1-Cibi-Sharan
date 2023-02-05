using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainerLibrary;

namespace Project0
{
    public class ExperienceFunction : IFileRepo<Experience>
    {
        string connectionstring = "Server = tcp:cibi-db-server1.database.windows.net,1433;Initial Catalog = Project1DB; Persist Security Info=False;User ID = cibi; Password=Cb@75372;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30";

        Experience experienceobj = new Experience();

        public void display()
        {
            Console.WriteLine("Enter Company 1 (within 100 words) : ");
            experienceobj.COMPANY1 = Console.ReadLine();
            Console.WriteLine("Enter Company 2 (within 100 words): ");
            experienceobj.COMPANY2 = Console.ReadLine();
            Console.WriteLine("Enter Company 3 (within 100 words): ");
            experienceobj.COMPANY3 = Console.ReadLine();
            Console.WriteLine("Add About Me : ");
        }

        public Experience display1(Experience experienceobj)
        {
            Console.WriteLine("Enter Company 1 (within 100 words) : ");
            experienceobj.COMPANY1 = Console.ReadLine();
            Console.WriteLine("Enter Company 2 (within 100 words): ");
            experienceobj.COMPANY2 = Console.ReadLine();
            Console.WriteLine("Enter Company 3 (within 100 words): ");
            experienceobj.COMPANY3 = Console.ReadLine();
            Console.WriteLine("Add About Me : ");
            //GetEmail();
            return experienceobj;
        }

        public string UserChoice()
        {

            return "string";
        }

        public List<Experience> GetDetails()
        {
            List<Experience> table = new List<Experience>();
            return table;
        }

        public void AddDetails(Experience Tb, int ID)
        {
            Tb = display1(Tb);
            // Console.WriteLine(Tb.FullName);
            //Console.WriteLine(Tb.Email);
            Console.WriteLine(ID);
            string query = "INSERT INTO Experience(UserID, Company1, Company2, Company3) VALUES(@userID, @company1, @company2, @company3)";
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            using SqlCommand sqlCommand = new SqlCommand(query, conn);
            sqlCommand.Parameters.AddWithValue("@userID", ID);
            sqlCommand.Parameters.AddWithValue("@company1", Tb.COMPANY1);
            sqlCommand.Parameters.AddWithValue("@company2", Tb.COMPANY2);
            sqlCommand.Parameters.AddWithValue("@company3", Tb.COMPANY3);

            int rows = sqlCommand.ExecuteNonQuery();
            Console.WriteLine(rows + "row(s) added");
            Console.WriteLine("Experience details successfully added..");
        }
        public string ExpPrint()
        {
            //Console.Write("UserID : "+detailsobj.UserID);
            //Console.Write("\tFullName : " + detailsobj.FullName);
            //Console.Write("\tGender : " + detailsobj.Gender);
            //Console.Write("\tAddress : "+detailsobj.Address);
            //Console.Write("\tAbout Me : " + detailsobj.AboutMe);
            //Console.Write("\tPhone Number : " + detailsobj.PhoneNo);
            //Console.Write("\tEmail : " + detailsobj.Email);
            //Console.WriteLine("\tWebsite : "+detailsobj.Website);

            Console.WriteLine("Enter '1' : To update Company 1");
            Console.WriteLine("Enter '2' : To update Company 2");
            Console.WriteLine("Enter '3' : To update Company 3");
            Console.WriteLine("Enter '4' : To Go Back");
            string useropt = Console.ReadLine();
            switch (useropt)
            {
                case "1":
                    return "Experience 1";
                case "2":
                    return "Experience 2";
                case "3":
                    return "Experience 3";
                case "4":
                    return "Go Back";
                default:
                    return "Menu";

            }
        }

        public Experience GetExperienceRows(int userid)
        {
            Experience table = new Experience();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();

                string command = $"SELECT * from [Experience] where UserID = '{userid}'";
                using SqlCommand sqlCommand = new SqlCommand(command, conn);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {

                    table.USERID = reader.GetInt32(0);
                    table.COMPANY1 = reader.GetString(1);
                    table.COMPANY2 = reader.GetString(2);
                    table.COMPANY3 = reader.GetString(3);
                }
            }
            //table.ForEach(t =>
            //{
            //    Console.WriteLine($"Values : {t.Id}");
            //});
            //Console.WriteLine(table[0].Name);

            return table;
        }
        public void UpdateExperience(string column_name, string value, int userid)
        {
            // Details table = new Details();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                string command;
                conn.Open();
                if (Int32.TryParse(value, out int op))
                {
                    //Console.WriteLine(op);
                    command = $"update [Experience] set {column_name} = {op} where UserID = '{userid}'";
                }
                else if (Int64.TryParse(value, out long op1))
                {
                    command = $"update [Experience] set {column_name} = {op1} where UserID = '{userid}'";
                }
                else { command = $"update [Experience] set {column_name} = '{value}' where UserID = '{userid}'"; }

                Console.WriteLine("id : " + userid);

                using SqlCommand sqlCommand = new SqlCommand(command, conn);
                int rows = sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Updated Experience Table");
                Console.WriteLine(rows + "row(s) affected");
            }
        }
        public void DisplayExperienceProfile(Experience exp)
        {
            Console.WriteLine("\n *****Experience*****");
            Console.WriteLine("Company 1 : " + exp.COMPANY1);
            Console.WriteLine("Company 2 : " + exp.COMPANY2);
            Console.WriteLine("Company 3 : " + exp.COMPANY3);
        }
    }
}
