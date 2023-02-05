using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_UI
{
    internal class DetailsClass
    {
        public void display(Details d) {
            Console.WriteLine("***DETAILS OF USER***");
            Console.WriteLine("FullName : "+d.FullName);
            Console.WriteLine("Gender : "+d.Gender);
            Console.WriteLine("Address : "+d.Address);
            Console.WriteLine("About Me : "+d.AboutMe);
            Console.WriteLine("Phone No : "+d.PhoneNo);
            Console.WriteLine("Website : "+d.Website);
        }
        public Details InsertDetails(Details d, int id)
        {
                Console.WriteLine("Adding Details..");
                d.UserID = id;
                Console.WriteLine("Enter your full Name : ");
                d.FullName = Console.ReadLine();
                Console.WriteLine("Enter your Gender : ");
                d.Gender = Console.ReadLine();
                Console.WriteLine("Enter your Address : ");
                d.Address = Console.ReadLine();
                Console.WriteLine("Enter your 'About Me' : ");
                d.AboutMe = Console.ReadLine();
                Console.WriteLine("Enter your Phone Number : ");
                d.PhoneNo = Console.ReadLine();
                Console.WriteLine("Enter your Email_ID : ");
                d.Email = Console.ReadLine();
                Console.WriteLine("Enter your Website : ");
                d.Website = Console.ReadLine();
            
            return d;
        }
    }
}
