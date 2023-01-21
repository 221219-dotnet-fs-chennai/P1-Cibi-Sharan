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
                    Console.Clear();
                    return "Menu";
            }
        }

        public void displayTables()
        {
            Console.WriteLine("Enter '1' : To update Details Table");
            Console.WriteLine("Enter '2' : To update Skills Table");
            Console.WriteLine("Enter '3' : To update Experience Table");
            Console.WriteLine("Enter '4' : To update Education Table");
            Console.WriteLine("Enter '5' : To Go Back");
        }

        public void displayAddTables()
        {
            Console.WriteLine("Enter '1' : To add Details Table");
            Console.WriteLine("Enter '2' : To add Skills Table");
            Console.WriteLine("Enter '3' : To add Experience Table");
            Console.WriteLine("Enter '4' : To add Education Table");
            Console.WriteLine("Enter '5' : To Go Back");
        }

        public string userChoice() {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    return "Details";
                case "2":
                    return "Skills";
                case "3":
                    return "Experience";
                case "4":
                    return "Education";
                case "5":
                    return "Go Back";
                default:
                    Console.WriteLine("Enter a valid input");
                    return "Menu";
            }
        }

        
    }
}
