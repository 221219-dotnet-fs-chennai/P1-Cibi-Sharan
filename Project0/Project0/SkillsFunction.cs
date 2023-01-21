using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainerLibrary;

namespace Project0
{
    internal class SkillsFunction : IMenu, IFileRepo<Skills>
    {
        string connectionstring = "Server = tcp:cibi-db-server1.database.windows.net,1433;Initial Catalog = Project1DB; Persist Security Info=False;User ID = cibi; Password=Cb@75372;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30";

        Skills skillsobj = new Skills();
        public void display()
        {
            // enter details

            Console.WriteLine("Enter Skill_1 (within 100 words) : ");
            skillsobj.SKILL_1 = Console.ReadLine();
            Console.WriteLine("Enter Skill_2 (within 100 words): ");
            skillsobj.SKILL_2 = Console.ReadLine();
            Console.WriteLine("Enter Skill_3 (within 100 words): ");
            skillsobj.SKILL_3 = Console.ReadLine();
            Console.WriteLine("Add About Me : ");
        }
        public string SkillsPrint()
        {
            //Console.Write("UserID : "+detailsobj.UserID);
            //Console.Write("\tFullName : " + detailsobj.FullName);
            //Console.Write("\tGender : " + detailsobj.Gender);
            //Console.Write("\tAddress : "+detailsobj.Address);
            //Console.Write("\tAbout Me : " + detailsobj.AboutMe);
            //Console.Write("\tPhone Number : " + detailsobj.PhoneNo);
            //Console.Write("\tEmail : " + detailsobj.Email);
            //Console.WriteLine("\tWebsite : "+detailsobj.Website);

            Console.WriteLine("Enter '1' : To update Skill 1");
            Console.WriteLine("Enter '2' : To update Skill 2");
            Console.WriteLine("Enter '3' : To update Skill 3");
            Console.WriteLine("Enter '4' : To Go Back");
            string useropt = Console.ReadLine();
            switch (useropt)
            {
                case "1":
                    return "Skill 1";
                case "2":
                    return "Skill 2";
                case "3":
                    return "Skill 3";
                case "4":
                    return "Go Back";
                default:
                    return "Menu";

            }
        }
        public void UpdateSkills(string column_name, string value, int userid)
        {
            // Details table = new Details();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                string command;
                conn.Open();
                if (Int32.TryParse(value, out int op))
                {
                    //Console.WriteLine(op);
                    command = $"update [Skills] set {column_name} = {op} where UserID = '{userid}'";
                }
                else if (Int64.TryParse(value, out long op1))
                {
                    command = $"update [Skills] set {column_name} = {op1} where UserID = '{userid}'";
                }
                else { command = $"update [Skills] set {column_name} = '{value}' where UserID = '{userid}'"; }

                Console.WriteLine("id : " + userid);

                using SqlCommand sqlCommand = new SqlCommand(command, conn);
                int rows = sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Updated Skills Table");
                Console.WriteLine(rows + "row(s) affected");
            }
        }
        public Skills GetSkillsRows(int userid)
        {
            Skills table = new Skills();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();

                string command = $"SELECT * from [Skills] where UserID = '{userid}'";
                using SqlCommand sqlCommand = new SqlCommand(command, conn);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {

                    table.USERID = reader.GetInt32(0);
                    table.SKILL_1 = reader.GetString(1);
                    table.SKILL_2 = reader.GetString(2);
                    table.SKILL_3 = reader.GetString(3);
                }
            }
            //table.ForEach(t =>
            //{
            //    Console.WriteLine($"Values : {t.Id}");
            //});
            //Console.WriteLine(table[0].Name);

            return table;
        }
        public Skills display1(Skills skillsobj)
        {
            // enter details

            Console.WriteLine("Enter Skill_1 (within 100 words) : ");
            skillsobj.SKILL_1 = Console.ReadLine();
            Console.WriteLine("Enter Skill_2 (within 100 words): ");
            skillsobj.SKILL_2 = Console.ReadLine();
            Console.WriteLine("Enter Skill_3 (within 100 words): ");
            skillsobj.SKILL_3 = Console.ReadLine();
            Console.WriteLine("Add About Me : ");
            //GetEmail();
            return skillsobj;
        }
        public string UserChoice()
        {

            return "string";
        }

        public List<Skills> GetDetails()
        {
            List<Skills> table = new List<Skills>();
            return table;
        }

        public void AddDetails(Skills Tb, int ID)
        {
            Tb = display1(Tb);
            // Console.WriteLine(Tb.FullName);
            //Console.WriteLine(Tb.Email);
            Console.WriteLine(ID);
            string query = "INSERT INTO Skills(UserID, Skill_1, Skill_2, Skill_3) VALUES(@userID, @skill_1, @skill_2, @skill_3)";
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            using SqlCommand sqlCommand = new SqlCommand(query, conn);
            sqlCommand.Parameters.AddWithValue("@userID", ID);
            sqlCommand.Parameters.AddWithValue("@skill_1", Tb.SKILL_1);
            sqlCommand.Parameters.AddWithValue("@skill_2", Tb.SKILL_2);
            sqlCommand.Parameters.AddWithValue("@skill_3", Tb.SKILL_3);
       
            int rows = sqlCommand.ExecuteNonQuery();
            Console.WriteLine(rows + "row(s) added");
            Console.WriteLine("Skills successfully added..");
        }
    }
}
