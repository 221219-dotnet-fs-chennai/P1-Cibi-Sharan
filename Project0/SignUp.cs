using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TrainerLibrary;

namespace Project0
{
    internal class SignUp
    {
        public UserTable EnterDetails() {
            UserTable table = new UserTable();
            Console.WriteLine("Enter your name : ");
            table.Name = Console.ReadLine();
            Console.WriteLine("Enter your Email : ");
            table.Email = Console.ReadLine();
            Console.WriteLine("Enter your Password : ");
            table.Password = Console.ReadLine();
            Console.WriteLine("Password : " + table.Password);
            return table;

        }
            // checking if email already exists
         public List<UserTable> GetDetails()
        {
            string connectionstring = "Server = tcp:cibi-db-server1.database.windows.net,1433;Initial Catalog = Project1DB; Persist Security Info=False;User ID = cibi; Password=Cb@75372;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30";
            List<UserTable> retrievetable = new List<UserTable>();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                string query = "SELECT UserID, EmailID, Password from [UserTable]";
                using SqlCommand sqlCommand = new SqlCommand(query, conn);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    retrievetable.Add(new UserTable()
                    {
                        Id = reader.GetInt32(0),
                        Email = reader.GetString(1),
                        Password = reader.GetString(2)
                    });
                }
                //retrievetable.ForEach(x =>
                //{
                //    Console.WriteLine(x.Email);
                //});
            }
            return retrievetable;
        }
        public bool checkValidation(List<UserTable> tb, string Email, string Password)
        {
            bool result = false;
            // logic to check if email already exists
            foreach(UserTable item in tb)
            {
                //Console.WriteLine(item.Email);
                //Console.WriteLine(Email);
                if (item.Email == Email && item.Password == Password)
                { 
                    result = true;
                    break;
                }
                else
                    result = false;
            }
            return result;
        }

    }
}
