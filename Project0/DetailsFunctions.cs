using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainerLibrary;

namespace Project0
{
    public class DetailsFunctions : IMenu, IFileRepo<Details>
    {
        //string connectionstring = File.ReadAllText("../../../connectionString.txt");
        string connectionstring = "Server = tcp:cibi-db-server1.database.windows.net,1433;Initial Catalog = Project1DB; Persist Security Info=False;User ID = cibi; Password=Cb@75372;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30";

        Details detailsobj = new Details();
        public void display() {
            // enter details
            
            //Console.WriteLine("Enter your fullname : ");
            //detailsobj.FullName = Console.ReadLine();
            //Console.WriteLine("Enter your gender : ");
            //detailsobj.Gender = Console.ReadLine();
            //Console.WriteLine("Enter your address : ");
            //detailsobj.Address = Console.ReadLine();
            //Console.WriteLine("Add About Me : ");
            //detailsobj.AboutMe = Console.ReadLine();
            //Console.WriteLine("Enter your Phone Number : ");
            //detailsobj.PhoneNo = Convert.ToInt64(Console.ReadLine());
            //Console.WriteLine("Add your website : ");
            //detailsobj.Website = Console.ReadLine();
            //Console.WriteLine("Enter your Email : ");
            //GetEmail();

            
        }
        public Details display1(Details detailsobj)
        {
            // enter details

            Console.WriteLine("Enter your fullname : ");
            detailsobj.FullName = Console.ReadLine();
            Console.WriteLine("Enter your gender : ");
            detailsobj.Gender = Console.ReadLine();
            Console.WriteLine("Enter your address : ");
            detailsobj.Address = Console.ReadLine();
            Console.WriteLine("Add About Me : ");
            detailsobj.AboutMe = Console.ReadLine();
            Console.WriteLine("Enter your Phone Number : ");
            detailsobj.PhoneNo = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Add your website : ");
            detailsobj.Website = Console.ReadLine();
            //Console.WriteLine("Enter your Email : ");
            //GetEmail();
            return detailsobj;
        }

        public string UserChoice()
        {

            return "string";
        }

        public Details GetEmail(string email) {
            detailsobj.Email = email;
            //detailsobj.UserID= ID;
            return detailsobj;
        }

        public List<Details> GetDetails()
        {
            List<Details> table = new List<Details>();
            return table;
        }

        public void AddDetails(Details Tb, int ID)
        {
            Tb=display1(Tb);
           // Console.WriteLine(Tb.FullName);
            //Console.WriteLine(Tb.Email);
            Console.WriteLine(ID);
            string query = "INSERT INTO Details(UserID, FullName, Gender, Address, AboutMe, Phone_No, Email_ID, Website) VALUES(@userID, @fullName, @gender, @address, @aboutMe, @phone_No, @email, @website)";
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            using SqlCommand sqlCommand = new SqlCommand(query, conn);
            sqlCommand.Parameters.AddWithValue("@userID", ID);
            sqlCommand.Parameters.AddWithValue("@fullName", Tb.FullName);
            sqlCommand.Parameters.AddWithValue("@gender", Tb.Gender);
            sqlCommand.Parameters.AddWithValue("@address", Tb.Address);
            sqlCommand.Parameters.AddWithValue("@aboutMe", Tb.AboutMe);
            sqlCommand.Parameters.AddWithValue("@phone_No", Tb.PhoneNo);
            sqlCommand.Parameters.AddWithValue("@email", Tb.Email);
            sqlCommand.Parameters.AddWithValue("@website", Tb.Website);
            Console.WriteLine("Press Enter to Save the details");
            Console.ReadLine();
            int rows = sqlCommand.ExecuteNonQuery();
            Console.WriteLine(rows + "row(s) added");
            Console.WriteLine("Details Added");
        }

        //public int CheckId(string id)
        //{
        //    // logic to implement
        //    return 0;
        //}
    }
}
