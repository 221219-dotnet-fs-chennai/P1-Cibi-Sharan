using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project0
{
    internal class Menu : IMenu
    {
        public void display()
        {
            Console.WriteLine("Find Your Trainer..");
            Console.WriteLine("Enter '0' : Exit");
            Console.WriteLine("Enter '1' : Register as a Trainer");
            Console.WriteLine("Enter '2' : Find Trainers");
        }
        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            //Switch cases are just useful if you are doing a bunch of comparison
            switch (userInput)
            {
                case "0":
                    return "Exit";
                case "1":
                    return "Register as Trainer"; 
                case "2":
                    return "Find Trainers";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "Menu";
            }
        }
    }
}
