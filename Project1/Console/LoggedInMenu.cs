﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project0
{
    internal class LoggedInMenu : IMenu
    {
        public void display()
        {
            Console.WriteLine("-------Select your operations------");
            Console.WriteLine("Enter '0' : Exit");
            Console.WriteLine("Enter '1' : View Details");
            Console.WriteLine("Enter '2' : Update Details");
            Console.WriteLine("Enter '3' : Delete Details");
            Console.WriteLine("Enter '4' : Add Details");

            // Console.WriteLine("Enter '2' : Update Details");
            //Console.WriteLine("Enter '3' : Delete Details");
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
                    return "View Details";
                case "2":
                    return "Update Details";
                case "3":
                    return "Delete Details";
                case "4":
                    return "Add Details";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "Menu";
            }
        }
    }
}
