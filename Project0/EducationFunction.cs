using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainerLibrary;

namespace Project0
{
    internal class EducationFunction : IMenu, IFileRepo<Education>
    {
        string connectionstring = "Server = tcp:cibi-db-server1.database.windows.net,1433;Initial Catalog = Project1DB; Persist Security Info=False;User ID = cibi; Password=Cb@75372;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30";

        Education eduobj = new Education();
        public void display()
        {
            Console.WriteLine("Enter Register Number (within 100 words) : ");
            eduobj.REGISTER_NO = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter College Name (within 100 words): ");
            eduobj.COLLEGE_NAME = Console.ReadLine();
            Console.WriteLine("Enter Stream (within 100 words): ");
            eduobj.STREAM = Console.ReadLine();
            Console.WriteLine("Enter Branch (within 100 words): ");
            eduobj.BRANCH = Console.ReadLine();
            Console.WriteLine("Enter Percentage (within 100 words): ");
            eduobj.PERCENTAGE = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Start Year (within 100 words): ");
            eduobj.START_YEAR = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter End Year (within 100 words): ");
            eduobj.END_YEAR = Convert.ToInt32(Console.ReadLine());
        }

        public Education display1(Education eduobj)
        {
            Console.WriteLine("Enter Register Number (within 100 words) : ");
            eduobj.REGISTER_NO = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter College Name (within 100 words): ");
            eduobj.COLLEGE_NAME = Console.ReadLine();
            Console.WriteLine("Enter Stream (within 100 words): ");
            eduobj.STREAM = Console.ReadLine();         
            Console.WriteLine("Enter Branch (within 100 words): ");
            eduobj.BRANCH = Console.ReadLine();
            Console.WriteLine("Enter Percentage (within 100 words): ");
            eduobj.PERCENTAGE = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Start Year (within 100 words): ");
            eduobj.START_YEAR = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter End Year (within 100 words): ");
            eduobj.END_YEAR = Convert.ToInt32(Console.ReadLine());
            //GetEmail();
            return eduobj;
        }

        public string UserChoice()
        {

            return "string";
        }

        public List<Education> GetDetails()
        {
            List<Education> table = new List<Education>();
            return table;
        }
        public void AddDetails(Education Tb, int ID)
        {
            //Tb = display1(Tb);
            // Console.WriteLine(Tb.FullName);
            //Console.WriteLine(Tb.Email);
            Console.WriteLine(ID);
            string query = "INSERT INTO Education(Register_No, UserID, College_Name, Stream, Branch, Percentage, StartYear, EndYear)" +
                " VALUES(@Register_No, @userID, @College_Name, @Stream, @Branch, @Percentage, @StartYear, @EndYear)";
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            using SqlCommand sqlCommand = new SqlCommand(query, conn);
            sqlCommand.Parameters.AddWithValue("@Register_No", Tb.REGISTER_NO);
            sqlCommand.Parameters.AddWithValue("@userID", ID);
            sqlCommand.Parameters.AddWithValue("@College_Name", Tb.COLLEGE_NAME);
            sqlCommand.Parameters.AddWithValue("@Stream", Tb.STREAM);
            sqlCommand.Parameters.AddWithValue("@Branch", Tb.BRANCH);
            sqlCommand.Parameters.AddWithValue("@Percentage", Tb.PERCENTAGE);
            sqlCommand.Parameters.AddWithValue("@StartYear", Tb.START_YEAR);
            sqlCommand.Parameters.AddWithValue("@EndYear", Tb.END_YEAR);

            int rows = sqlCommand.ExecuteNonQuery();
            Console.WriteLine(rows + "row(s) added");
            Console.WriteLine("Education details successfully added..");
        }
    }
}
