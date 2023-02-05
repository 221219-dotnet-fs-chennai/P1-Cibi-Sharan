global using Serilog;
using System;
//using Project0;
using System.Diagnostics;
using System.Reflection;
using Models;
using TE = TrainerEntity.Entities;
using BusinessLogic;
using TrainerLibrary;
using TrainerEntity.Entities;
using Console_UI;
//using TrainerLibrary;

namespace Project0
{
    class Program
    {

        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                             .WriteTo.File(@"..\..\..\Logs\log.txt", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
                             .CreateLogger();
            Log.Logger.Information("**********************************************************************PROGRAM STARTS***********************************************************************");

        startpage:
            IMenu menu = new Menu();
            Menu menu1 = new Menu();

            menu.display();
            string user_opt = menu.UserChoice();
            bool repeat = true;
            Models.UserTable table = new Models.UserTable();
            Models.Details details = new Models.Details();
            Models.Skills skills = new Models.Skills();
            Models.Experience experience = new Models.Experience();
            Models.Education education = new Models.Education();

            DetailsClass dc = new DetailsClass();
            SkillsClass sc = new SkillsClass();
            ExperienceClass ec = new ExperienceClass();
            EducationClass edc = new EducationClass();
            //while (repeat)
            switch (user_opt)
            {
                case "Register as Trainer":
                // logic
                redirect:
                    menu = new FindTrainerMenu();
                    menu.display();
                    string user_opt1 = menu.UserChoice();
                    Mapper map = new Mapper();
                    while (repeat)
                    {
                        switch (user_opt1)
                        {
                            case "Login":
                                Log.Logger.Information("In Login page..");
                                //logic
                                EF_Repo efobj = new EF_Repo();
                                table = efobj.SignUpDetails();
                                Login loginobj = new Login();
                                //table = loginobj.EnterDetails(); // row containing fields entered by user
                                List<Models.UserTable> logtb = efobj.GetSignUpUsers();// all rows from UserTable
                                //List<Models.UserTable> logtb = map.MapUserTable(efobj.GetSignUpUsers());
                                bool check1 = loginobj.checkValidation(logtb, table.Email, table.Password);
                                if (check1)
                                {
                                    Log.Logger.Information("Login Successful..");
                                    Console.WriteLine("Welcome {0}", table.Name);
                                    int id = efobj.checkID(table.Email);
                                    repeat = false;
                                redirected:
                                    menu = new LoggedInMenu();
                                    menu.display();
                                    string menuopt = menu.UserChoice();
                                    switch (menuopt)
                                    {
                                        case "Exit":
                                            //logic
                                            Log.Logger.Information("User entered exit..");
                                            Console.WriteLine("Thank you! Visit Again");
                                            Console.WriteLine("Press CTRL+C to exit");
                                            Console.ReadLine();
                                            
                                            break;

                                        case "View Details":
                                            //logic
                                            Log.Logger.Information("In View Details");
                                            
                                            details = efobj.GetDetails(id);
                                            
                                            dc.display(details);
                                            
                                            skills = efobj.GetSkills(id);
                                            
                                            sc.display(skills);
                                            
                                            experience = efobj.GetExperience(id);
                                            
                                            ec.display(experience);
                                            
                                            education = efobj.GetEducation(id);
                                          
                                            edc.display(education);
                                            //// go back
                                            Console.WriteLine("\n\nPress Enter to go back");
                                            Console.ReadLine();
                                            Console.Clear();
                                            goto redirected;
                                        //break;

                                        case "Add Details":
                                            Log.Logger.Information("In Add details..");
                                            repeat = true;
                                            while (repeat)
                                            {
                                                //logic
                                                Menu men = new Menu();
                                                men.displayAddTables();
                                                string useropt = men.userChoice();
                                                switch (useropt)
                                                {
                                                    case "Details":
                                                        Log.Logger.Information("Adding details..");
                                                        Models.Details inserted_det = new Models.Details();
                                                        inserted_det = dc.InsertDetails(details, id);
                                                        efobj.AddDetails(inserted_det);
                                                        break;
                                                    case "Skills":
                                                        Log.Logger.Information("Adding skills..");
                                                        Models.Skills inserted_sk = new Models.Skills();
                                                        inserted_sk = sc.InsertSkills(skills, id);
                                                        efobj.AddSkills(inserted_sk);
                                                        break;
                                                    case "Experience":
                                                        Log.Logger.Information("Adding experience..");
                                                        Models.Experience inserted_exp = new Models.Experience();
                                                        inserted_exp = ec.InsertExperience(experience, id);
                                                        efobj.AddExperience(inserted_exp);
                                                        break;
                                                    case "Education":
                                                        Log.Logger.Information("Adding education..");
                                                        Models.Education inserted_ed = new Models.Education();
                                                        inserted_ed = edc.InsertEducation(education, id);
                                                        efobj.AddEducation(inserted_ed);
                                                        break;
                                                    case "Go Back":
                                                        Log.Logger.Information("User entered Go Back..");
                                                        //Console.WriteLine("Enter valid input!");
                                                        goto redirect;

                                                    default:
                                                        Console.WriteLine("Page does not exist!");
                                                        Console.WriteLine("Please press Valid Input!");
                                                        //goto operationmenu;
                                                        break;

                                                }
                                            }


                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("User Not found");
                                    repeat = false;
                                }
                                break;
                        }
                    }
                    break;
            }
        }
    }
}