using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Project0;

namespace TrainerLibrary
{
    public class SqlRepo : IFileRepo<UserTable>
    
    {
        string connectionstring = "Server = tcp:cibi-db-server1.database.windows.net,1433;Initial Catalog = Project1DB; Persist Security Info=False;User ID = cibi; Password=Cb@75372;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30";
        //string connectionstring = File.ReadAllText("../../../connectionString.txt");
        public List<UserTable> GetDetails()
        {
            List<UserTable> table = new List<UserTable>();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();

                string command = "SELECT UserID, Name, EmailID, Password from [UserTable]";
                using SqlCommand sqlCommand = new SqlCommand(command, conn);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    table.Add(new UserTable()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Email = reader.GetString(2),
                        Password = reader.GetString(3)
                    });
                }
            };
            //table.ForEach(t =>
            //{
            //    Console.WriteLine($"Values : {t.Id}");
            //});
            //Console.WriteLine(table[0].Name);

            return table;
        }

        public List<Details> GetDetails1()
        {
            List<Details> table = new List<Details>();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();

                string command = "SELECT FullName, Email_ID,Phone_No,Website from [Details]";
                using SqlCommand sqlCommand = new SqlCommand(command, conn);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    table.Add(new Details()
                    {
                        FullName = reader.GetString(0),
                        Email = reader.GetString(1),
                        PhoneNo = reader.GetString(2),
                        Website = reader.GetString(3)
                    });
                }
            };
            //table.ForEach(t =>
            //{
            //    Console.WriteLine($"Values : {t.Id}");
            //});
            //Console.WriteLine(table[0].Name);

            return table;
        }

        public List<Skills> GetSkills()
        {
            List<Skills> table = new List<Skills>();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();

                string command = "SELECT Skill_1 from [Skills]";
                using SqlCommand sqlCommand = new SqlCommand(command, conn);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    table.Add(new Skills()
                    {
                        SKILL_1 = reader.GetString(0),
                        //SKILL_2 = reader.GetString(1),
                        //SKILL_3 = reader.GetString(2),
                    });
                }
            };
            //table.ForEach(t =>
            //{
            //    Console.WriteLine($"Values : {t.Id}");
            //});
            //Console.WriteLine(table[0].Name);

            return table;
        }

        public List<Experience> GetExperience()
        {
            List<Experience> table = new List<Experience>();

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();

                string command = "SELECT Company1 from [Experience]";
                using SqlCommand sqlCommand = new SqlCommand(command, conn);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    table.Add(new Experience()
                    {
                        COMPANY1 = reader.GetString(0),
                        //COMPANY2 = reader.GetString(1),
                        //COMPANY3 = reader.GetString(2),
                    });
                }
            };
            //table.ForEach(t =>
            //{
            //    Console.WriteLine($"Values : {t.Id}");
            //});
            //Console.WriteLine(table[0].Name);

            return table;
        }

        //public List<Education> GetEducation()
        //{
        //    List<Education> table = new List<Education>();

        //    using (SqlConnection conn = new SqlConnection(connectionstring))
        //    {
        //        conn.Open();

        //        string command = "SELECT  from [Education]";
        //        using SqlCommand sqlCommand = new SqlCommand(command, conn);
        //        SqlDataReader reader = sqlCommand.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            table.Add(new Education()
        //            {
        //                FullName = reader.GetString(0),
        //                Email = reader.GetString(1),
        //                PhoneNo = reader.GetString(2),
        //                Website = reader.GetString(3)
        //            });
        //        }
        //    };
        //    //table.ForEach(t =>
        //    //{
        //    //    Console.WriteLine($"Values : {t.Id}");
        //    //});
        //    //Console.WriteLine(table[0].Name);

        //    return table;
        //}


        public int CheckId(string email)
        {
            int ID = 0;
            string query = $"select UserID from UserTable where [EmailID] = '{email}'";
            using SqlConnection conn = new(connectionstring);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            ID = Convert.ToInt32(cmd.ExecuteScalar());
            return ID;
        }

        public void DelDetails(int ID)
        {
            string query = $"DELETE FROM Details WHERE UserID = {ID}";
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            using SqlCommand sqlCommand= new SqlCommand(query, conn);
            //sqlCommand.Parameters.AddWithValue("@Name", l.Name);
            //sqlCommand.Parameters.AddWithValue("@EmailID", l.Email);
            //sqlCommand.Parameters.AddWithValue("@Password", l.Password);
            int rows = sqlCommand.ExecuteNonQuery();
            Console.WriteLine(rows + "row(s) deleted");

        }
        public void AddDetails(UserTable l, int ID)
        {
            string query = "INSERT INTO UserTable(Name, EmailID, Password) VALUES(@Name, @EmailID, @Password)";
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            using SqlCommand sqlCommand = new SqlCommand(query, conn);
            sqlCommand.Parameters.AddWithValue("@Name", l.Name);
            sqlCommand.Parameters.AddWithValue("@EmailID", l.Email);
            sqlCommand.Parameters.AddWithValue("@Password", l.Password);
            int rows = sqlCommand.ExecuteNonQuery();
            Console.WriteLine(rows + "row(s) added");

        }


    }
}
