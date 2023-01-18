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

            //Console.WriteLine("Enter Skill_1 (within 100 words) : ");
            //skillsobj.SKILL_1 = Console.ReadLine();
            //Console.WriteLine("Enter Skill_2 (within 100 words): ");
            //skillsobj.SKILL_2 = Console.ReadLine();
            //Console.WriteLine("Enter Skill_3 (within 100 words): ");
            //skillsobj.SKILL_3 = Console.ReadLine();
            //Console.WriteLine("Add About Me : ");        
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
