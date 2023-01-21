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
            Tb = display1(Tb);
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
        public string EduPrint()
        {
            //Console.Write("UserID : "+detailsobj.UserID);
            //Console.Write("\tFullName : " + detailsobj.FullName);
            //Console.Write("\tGender : " + detailsobj.Gender);
            //Console.Write("\tAddress : "+detailsobj.Address);
            //Console.Write("\tAbout Me : " + detailsobj.AboutMe);
            //Console.Write("\tPhone Number : " + detailsobj.PhoneNo);
            //Console.Write("\tEmail : " + detailsobj.Email);
            //Console.WriteLine("\tWebsite : "+detailsobj.Website);

            Console.WriteLine("Enter '1' : To update College Name");
            Console.WriteLine("Enter '2' : To update Stream");
            Console.WriteLine("Enter '3' : To update Branch");
            Console.WriteLine("Enter '4' : To update Percentage");
            Console.WriteLine("Enter '5' : To update Start Year");
            Console.WriteLine("Enter '6' : To update End Year");
            Console.WriteLine("Enter '7' : To update Register Number");
            Console.WriteLine("Enter 'B' : To Go Back");
            string useropt = Console.ReadLine();
            switch (useropt)
            {
                case "1":
                    return "College Name";
                case "2":
                    return "Stream";
                case "3":
                    return "Branch";
                case "4":
                    return "Percentage";
                case "5":
                    return "Start Year";
                case "6":
                    return "End Year";
                case "7":
                    return "Register Number";
                case "B":
                    return "Go Back";

                default:
                    return "Menu";

            }
        }
        public Education GetEducationRows(int userid)
        {
            Education table = new Education();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();

                string command = $"SELECT * from [Education] where UserID = '{userid}'";
                using SqlCommand sqlCommand = new SqlCommand(command, conn);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {

                    table.USERID = reader.GetInt32(0);
                    table.COLLEGE_NAME = reader.GetString(1);
                    table.STREAM = reader.GetString(2);
                    table.BRANCH = reader.GetString(3);
                    table.PERCENTAGE = reader.GetInt64(4);
                    table.START_YEAR = reader.GetInt32(5);
                    table.END_YEAR = reader.GetInt32(6);
                }
            }
            //table.ForEach(t =>
            //{
            //    Console.WriteLine($"Values : {t.Id}");
            //});
            //Console.WriteLine(table[0].Name);

            return table;
        }
        public void UpdateEducation(string column_name, string value, int userid)
        {
            // Details table = new Details();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                string command;
                conn.Open();
                if (Int32.TryParse(value, out int op))
                {
                    //Console.WriteLine(op);
                    command = $"update [Education] set {column_name} = {op} where UserID = '{userid}'";
                }
                else if (Int64.TryParse(value, out long op1))
                {
                    command = $"update [Education] set {column_name} = {op1} where UserID = '{userid}'";
                }
                else { command = $"update [Education] set {column_name} = '{value}' where UserID = '{userid}'"; }

                Console.WriteLine("id : " + userid);

                using SqlCommand sqlCommand = new SqlCommand(command, conn);
                int rows = sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Updated Education Table");
                Console.WriteLine(rows + "row(s) affected");
            }
        }
        public void DisplayEducationProfile(Education ed)
        {
            Console.WriteLine("\n *****Education*****");
            Console.WriteLine("Register Number : " + ed.REGISTER_NO);
            Console.WriteLine("College Name : " + ed.COLLEGE_NAME);
            Console.WriteLine("Stream : " + ed.STREAM);
            Console.WriteLine("Branch : " + ed.BRANCH);
            Console.WriteLine("Percentage : "+ed.PERCENTAGE);
            Console.WriteLine("Start Year : "+ed.START_YEAR);
            Console.WriteLine("End Year : "+ed.END_YEAR);
        }
    }
}
