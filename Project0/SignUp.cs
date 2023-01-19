using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TrainerLibrary;

namespace Project0
{
    internal class SignUp
    {
        public UserTable EnterDetails() {
            UserTable table = new UserTable();
            string namepattern = @"^\s?[A-Za-z]+$";
            //string namepattern = @"\s?Cibi";
            gotoname:                   
            try
            {
                Console.WriteLine("Enter your name : ");
                string namestr = Console.ReadLine();
                var match = Regex.Match(namestr, namepattern, RegexOptions.IgnoreCase);
                //if (Regex.IsMatch(namestr, namepattern))
                //{
                //    table.Name = namestr;
                //}
                if (match.Success)
                    table.Name = namestr;
                else
                {
                    Console.WriteLine("Enter a valid name!");
                    goto gotoname;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Enter valid name");
                goto gotoname;
                //Console.WriteLine(ex.Message);
            }

        gotoemail:
            string emailpattern = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
            try
            {
                Console.WriteLine("Enter your email : ");
                string emailstr = Console.ReadLine();
                var match = Regex.Match(emailstr, emailpattern);
                //if (Regex.IsMatch(namestr, namepattern))
                //{
                //    table.Name = namestr;
                //}
                if (match.Success)
                    table.Email = emailstr;
                else
                {
                    Console.WriteLine("Enter a valid email!");
                    goto gotoemail;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Enter valid email");
                goto gotoemail;
                //Console.WriteLine(ex.Message);
            }
        //Console.WriteLine("Enter your Email : ");
        //table.Email = Console.ReadLine();

        gotopassword:
            string passwordpattern = @"\w{6,10}";
            try
            {
                Console.WriteLine("Enter your password (6-10 characters long, atleast 1 number) : ");
                string passwordstr = Console.ReadLine();
                var match = Regex.Match(passwordstr, passwordpattern);
                //if (Regex.IsMatch(namestr, namepattern))
                //{
                //    table.Name = namestr;
                //}
                if (match.Success)
                    table.Password = passwordstr;
                else
                {
                    Console.WriteLine("Enter a valid password!");
                    goto gotopassword;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Enter valid password");
                goto gotopassword;
                //Console.WriteLine(ex.Message);
            }
            //Console.WriteLine("Enter your Password : ");
            //table.Password = Console.ReadLine();
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
