using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_UI
{
    internal class EducationClass
    {
        public void display(Education edu)
        {
            Console.WriteLine("***USER EDUCATION DETAILS***");
            Console.WriteLine("REGISTER NUMBER : " + edu.REGISTER_NO);
            Console.WriteLine("COLLEGE NAME  : " + edu.COLLEGE_NAME);
            Console.WriteLine("STREAM  : " + edu.STREAM);
            Console.WriteLine("BRANCH : "+edu.BRANCH);
            Console.WriteLine("PERCENTAGE : "+edu.PERCENTAGE);
            Console.WriteLine("START YEAR : "+edu.START_YEAR);
            Console.WriteLine("END YEAR : "+edu.END_YEAR);
        }
        public Education InsertEducation(Education ed, int id)
        {
            Console.WriteLine("Adding Education...");
            ed.USERID = id;
            Console.WriteLine("Enter REGISTER NUMBER : ");
            ed.REGISTER_NO = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter COLLEGE NAME : ");
            ed.COLLEGE_NAME = Console.ReadLine();
            Console.WriteLine("Enter STREAM : ");
            ed.STREAM = Console.ReadLine();
            Console.WriteLine("Enter BRANCH : ");
            ed.BRANCH = Console.ReadLine();
            Console.WriteLine("Enter PERCENTAGE : ");
            ed.PERCENTAGE = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter START YEAR : ");
            ed.START_YEAR = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter END YEAR : ");
            ed.END_YEAR = Convert.ToInt32(Console.ReadLine());
            return ed;
        }
    }
}
