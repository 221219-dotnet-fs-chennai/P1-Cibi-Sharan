using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainerLibrary;

namespace Project0
{
    public class ExperienceFunction : IMenu, IFileRepo<Experience>
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
            //Tb = display1(Tb);
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
    }
}
