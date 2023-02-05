using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_UI
{
    internal class ExperienceClass
    {
        public void display(Experience exp)
        {
            Console.WriteLine("***USER EXPERIENCES***");
            Console.WriteLine("Company 1 : "+exp.COMPANY1);
            Console.WriteLine("Company 2 : " + exp.COMPANY2);
            Console.WriteLine("Company 3 : " + exp.COMPANY3);
        }
        public Experience InsertExperience(Experience e, int id)
        {
            Console.WriteLine("Adding Experience...");
            e.USERID = id;
            Console.WriteLine("Enter COMPANY 1 : ");
            e.COMPANY1 = Console.ReadLine();
            Console.WriteLine("Enter COMPANY 2 : ");
            e.COMPANY2 = Console.ReadLine();
            Console.WriteLine("Enter COMPANY 3 : ");
            e.COMPANY3 = Console.ReadLine();
            return e;
        }
    }
}
