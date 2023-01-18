using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project0
{
    internal class FindTrainerMenu : IMenu
    {
        public void display()
        {
            Console.WriteLine("Enter '1' : Login");
            Console.WriteLine("Enter '2' : SignUp");
            //Console.WriteLine("Enter '3' : ListAllTrainers");
            Console.WriteLine("Enter '0' : Exit");
        }

        public string UserChoice()
        {
            string UserInput = Console.ReadLine();
            switch(UserInput)
            {
                case "1":
                    //SignUp signupObj = new SignUp();

                    return "Login";
                case "2":
                    return "SignUp";
                case "3":
                    return "ListAllTrainers";
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "Menu";
            }
        }
    }
}
