//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
////using Project0;
////using Project0;

//namespace TrainerLibrary
//{
//    public class DetailsFunctions : IFileRepo<Details>
//    {
//        //string connectionstring = File.ReadAllText("../../../connectionString.txt");
//        string connectionstring = "Server = tcp:cibi-db-server1.database.windows.net,1433;Initial Catalog = Project1DB; Persist Security Info=False;User ID = cibi; Password=Cb@75372;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30";

//        Details detailsobj = new Details();
//        public void display() {
//            // enter details
            
//            //Console.WriteLine("Enter your fullname : ");
//            //detailsobj.FullName = Console.ReadLine();
//            //Console.WriteLine("Enter your gender : ");
//            //detailsobj.Gender = Console.ReadLine();
//            //Console.WriteLine("Enter your address : ");
//            //detailsobj.Address = Console.ReadLine();
//            //Console.WriteLine("Add About Me : ");
//            //detailsobj.AboutMe = Console.ReadLine();
//            //Console.WriteLine("Enter your Phone Number : ");
//            //detailsobj.PhoneNo = Convert.ToInt64(Console.ReadLine());
//            //Console.WriteLine("Add your website : ");
//            //detailsobj.Website = Console.ReadLine();
//            //Console.WriteLine("Enter your Email : ");
//            //GetEmail();

            
//        }
//        public Details display1(Details detailsobj)
//        {
//            // enter details

//            Console.WriteLine("Enter your fullname : ");
//            detailsobj.FullName = Console.ReadLine();
//            Console.WriteLine("Enter your gender : ");
//            detailsobj.Gender = Console.ReadLine();
//            Console.WriteLine("Enter your address : ");
//            detailsobj.Address = Console.ReadLine();
//            Console.WriteLine("Add About Me : ");
//            detailsobj.AboutMe = Console.ReadLine();
//            Console.WriteLine("Enter your Phone Number : ");
//            detailsobj.PhoneNo = (Console.ReadLine());
//            Console.WriteLine("Add your website : ");
//            detailsobj.Website = Console.ReadLine();
//            //Console.WriteLine("Enter your Email : ");
//            //GetEmail();
//            return detailsobj;
//        }

//        public string UserChoice()
//        {

//            return "string";
//        }

//        public Details GetEmail(string email) {
//            detailsobj.Email = email;
//            //detailsobj.UserID= ID;
//            return detailsobj;
//        }

//        public List<Details> GetDetails()
//        {
//            List<Details> table = new List<Details>();
//            return table;
//        }

//        public void AddDetails(Details Tb, int ID)
//        {
//            Tb=display1(Tb);
//           // Console.WriteLine(Tb.FullName);
//            //Console.WriteLine(Tb.Email);
//            Console.WriteLine(ID);
//            string query = "INSERT INTO Details(UserID, FullName, Gender, Address, AboutMe, Phone_No, Email_ID, Website) VALUES(@userID, @fullName, @gender, @address, @aboutMe, @phone_No, @email, @website)";
//            SqlConnection conn = new SqlConnection(connectionstring);
//            conn.Open();
//            using SqlCommand sqlCommand = new SqlCommand(query, conn);
//            sqlCommand.Parameters.AddWithValue("@userID", ID);
//            sqlCommand.Parameters.AddWithValue("@fullName", Tb.FullName);
//            sqlCommand.Parameters.AddWithValue("@gender", Tb.Gender);
//            sqlCommand.Parameters.AddWithValue("@address", Tb.Address);
//            sqlCommand.Parameters.AddWithValue("@aboutMe", Tb.AboutMe);
//            sqlCommand.Parameters.AddWithValue("@phone_No", Tb.PhoneNo);
//            sqlCommand.Parameters.AddWithValue("@email", Tb.Email);
//            sqlCommand.Parameters.AddWithValue("@website", Tb.Website);
//            Console.WriteLine("Press Enter to Save the details");
//            Console.ReadLine();
//            int rows = sqlCommand.ExecuteNonQuery();
//            Console.WriteLine(rows + "row(s) added");
//            Console.WriteLine("Details Added");
//        }
//        public string DetailsPrint(Details detailsobj)
//        {
//            //Console.Write("UserID : "+detailsobj.UserID);
//            //Console.Write("\tFullName : " + detailsobj.FullName);
//            //Console.Write("\tGender : " + detailsobj.Gender);
//            //Console.Write("\tAddress : "+detailsobj.Address);
//            //Console.Write("\tAbout Me : " + detailsobj.AboutMe);
//            //Console.Write("\tPhone Number : " + detailsobj.PhoneNo);
//            //Console.Write("\tEmail : " + detailsobj.Email);
//            //Console.WriteLine("\tWebsite : "+detailsobj.Website);

//            Console.WriteLine("Enter '1' : To update Address");
//            Console.WriteLine("Enter '2' : To update About Me");
//            Console.WriteLine("Enter '3' : To update Phone Number");
//            Console.WriteLine("Enter '4' : To update Website");
//            Console.WriteLine("Enter '5' : To Go Back");

//            string useropt = Console.ReadLine();
//            switch(useropt)
//            {
//                case "1":
//                    return "Address";
//                case "2":
//                    return "About Me";
//                case "3":
//                    return "Phone Number";
//                case "4":
//                    return "Website";
//                case "5":
//                    return "Go Back";
//                default:
//                    return "Menu";

//            }
//        }

//        public void UpdateDetails(string column_name, string value, int userid)
//        {
//           // Details table = new Details();

//            using (SqlConnection conn = new SqlConnection(connectionstring))
//            {
//                string command;
//                conn.Open();
//                if (Int32.TryParse(value, out int op)) {
//                    //Console.WriteLine(op);
//                    command = $"update [Details] set {column_name} = {op} where UserID = '{userid}'";
//                }
//                else if(Int64.TryParse(value, out long op1))
//                {
//                    command = $"update [Details] set {column_name} = {op1} where UserID = '{userid}'";
//                }
//                else { command = $"update [Details] set {column_name} = '{value}' where UserID = '{userid}'"; }

//                Console.WriteLine("id : "+userid);
                
//                using SqlCommand sqlCommand = new SqlCommand(command, conn);
//                int rows = sqlCommand.ExecuteNonQuery();
//                Console.WriteLine("Updated Details Table");
//                Console.WriteLine(rows + "row(s) affected");
//            }
//        }

//        public Details GetDetailsRows(int id)
//        {
//            Details table = new Details();

//            using (SqlConnection conn = new SqlConnection(connectionstring))
//            {
//                conn.Open();

//                string command = $"SELECT * from [Details] where UserID = '{id}'";
//                using SqlCommand sqlCommand = new SqlCommand(command, conn);
//                SqlDataReader reader = sqlCommand.ExecuteReader();
//                while (reader.Read())
//                {

//                    table.UserID = reader.GetInt32(0);
//                    table.FullName = reader.GetString(1);
//                    table.Gender = reader.GetString(2);
//                    table.Address = reader.GetString(3);
//                    table.AboutMe = reader.GetString(4);
//                    table.PhoneNo = reader.GetString(5);
//                    table.Email = reader.GetString(6);
//                    table.Website = reader.GetString(7);
             
//                }
//            } 
//            //table.ForEach(t =>
//            //{
//            //    Console.WriteLine($"Values : {t.Id}");
//            //});
//            //Console.WriteLine(table[0].Name);

//            return table;
//        }
//        public void DisplayDetailsProfile(Details dv)
//        {
//            Console.WriteLine("****PROFILE****");
//            Console.WriteLine("****PERSONAL INFORMATION*****");
//            Console.WriteLine("ID : " + dv.UserID);
//            Console.WriteLine("FullName : " + dv.FullName);
//            Console.WriteLine("Email ID : " + dv.Email);
//            Console.WriteLine("Phone Number : " + dv.PhoneNo);
//            Console.WriteLine("Address : " + dv.Address);
//            Console.WriteLine("About Me : " + dv.AboutMe);
//            Console.WriteLine("Website : "+dv.Website);
//        }

//        //public void DisplayMenu()
//        //{

//        //}
//        //public void displayValues()
//        //{
//        //    Console.WriteLine("User ID : "+detailsobj.UserID);
//        //    Console.WriteLine("Full : " + detailsobj.UserID);
//        //}

//        //public int CheckId(string id)
//        //{
//        //    // logic to implement
//        //    return 0;
//        //}
//    }
//}
