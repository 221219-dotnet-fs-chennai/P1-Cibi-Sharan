﻿global using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel.Design;
using TrainerLibrary;
using System.Diagnostics;
using System.Reflection;

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
            UserTable table = new UserTable();
            //while (repeat)
                switch (user_opt)
                {
                    case "Register as Trainer":
                // logic
                    redirect:
                    menu = new FindTrainerMenu();
                        menu.display();
                        string user_opt1 = menu.UserChoice();
                    while (repeat)
                    {
                        switch (user_opt1)
                        {
                            case "Login":
                                Log.Logger.Information("In Login page..");
                                //logic
                                Login loginobj = new Login();
                                SqlRepo sqlobj = new SqlRepo();
                                table = loginobj.EnterDetails(); // row containing fields entered by user
                                List<UserTable> logtb = loginobj.GetDetails(); // all rows from UserTable
                                //Console.WriteLine("hello");
                                bool check1 = loginobj.checkValidation(logtb, table.Email, table.Password);
                                //string command = "SELECT UserID, Name, EmailID, Password from [UserTable]";
                                //table.Id = sqlobj.GetID();
                                //string query = "SELECT UserID from UserTable WHERE EmailID = @mail";
                                if (check1)
                                {
                                    Log.Logger.Information("Login Successful..");
                                    Console.WriteLine("Welcome {0}", table.Name);
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
                                            SqlRepo sqlrepo1 = new SqlRepo();
                                            int id = sqlrepo1.CheckId(table.Email);
                                            DetailsFunctions detailsview = new DetailsFunctions();
                                            Details dv = detailsview.GetDetailsRows(id);
                                            detailsview.DisplayDetailsProfile(dv);
                                            SkillsFunction skillsview = new SkillsFunction();
                                            Skills sv = skillsview.GetSkillsRows(id);
                                            skillsview.DisplaySkillsProfile(sv);
                                            ExperienceFunction expview = new ExperienceFunction();
                                            Experience exv = expview.GetExperienceRows(id);
                                            expview.DisplayExperienceProfile(exv);
                                            EducationFunction eduview = new EducationFunction();
                                            Education edv = eduview.GetEducationRows(id);
                                            eduview.DisplayEducationProfile(edv);

                                            // go back
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
                                                SqlRepo signuprepo1 = new SqlRepo();
                                                switch (useropt)
                                                {

                                                    case "Details":
                                                        Log.Logger.Information("Adding details..");
                                                        Details detailobj1 = new Details();

                                                        //List<UserTable> logtb = loginobj.GetDetails(); // all rows from UserTable
                                                        //                                               //Console.WriteLine("hello");
                                                        //bool check1 = loginobj.checkValidation(logtb, table.Email, table.Password);

                                                        DetailsFunctions addobj1 = new DetailsFunctions();
                                                        //detailobj1 = addobj1.display1(detailobj1);
                                                        detailobj1 = addobj1.GetEmail(table.Email);
                                                        int signupID = signuprepo1.CheckId(table.Email);
                                                        addobj1.AddDetails(detailobj1, signupID);
                                                        break;

                                                    case "Skills":
                                                        Log.Logger.Information("Adding skills..");
                                                        Console.WriteLine("\n");
                                                        Console.WriteLine("Press Enter to Add Skills Details : ");
                                                        Console.ReadLine(); Console.Clear();
                                                        Skills skillobj1 = new Skills();

                                                        SkillsFunction addskill = new SkillsFunction();
                                                        //addskill.display();

                                                        int skillId = signuprepo1.CheckId(table.Email);
                                                        addskill.AddDetails(skillobj1, skillId);
                                                        break;

                                                    case "Experience":
                                                        Log.Logger.Information("Adding Experience..");
                                                        Console.WriteLine("\n");
                                                        Console.WriteLine("Press Enter to Add Experience Details : ");
                                                        Console.ReadLine(); Console.Clear();
                                                        Experience expobj1 = new Experience();
                                                        ExperienceFunction addexp = new ExperienceFunction();
                                                        //addexp.display();
                                                        int ExpId = signuprepo1.CheckId(table.Email);
                                                        addexp.AddDetails(expobj1, ExpId);
                                                        break;

                                                    case "Education":
                                                        Log.Logger.Information("Adding education..");
                                                        Console.WriteLine("\n");
                                                        Console.WriteLine("Press Enter to Add Education Details : ");
                                                        Console.ReadLine(); Console.Clear();
                                                        Education eduobj1 = new Education();
                                                        EducationFunction addedu = new EducationFunction();
                                                        //addedu.display();
                                                        int EduId = signuprepo1.CheckId(table.Email);
                                                        addedu.AddDetails(eduobj1, EduId);
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
                                        case "Update Details":
                                            //logic\
                                            Log.Logger.Information("In Update Details..");
                                        UpdateFunc:
                                            //logic
                                            //menu = new Menu();
                                            Console.WriteLine("Helloo");
                                            SqlRepo sqlrepo = new SqlRepo();
                                        updateMenu:
                                            menu1.displayTables();
                                            string opt = menu1.userChoice();
                                            switch (opt)
                                            {
                                                case "Details":
                                                    //logic
                                                    //print rows of Details Table
                                                    Log.Logger.Information("In update details table..");
                                                    DetailsFunctions detailsobj = new DetailsFunctions();
                                                    id = sqlrepo.CheckId(table.Email);

                                                    Details d = detailsobj.GetDetailsRows(id);
                                                    
                                                    
                                                    //Console.WriteLine("Sample Name : {0}",detailobj1.FullName);
                                                    string detailsopt = detailsobj.DetailsPrint(d);
                                                    switch (detailsopt)
                                                    {
                                                        case "Address":

                                                            Console.WriteLine("Enter your new Address : ");
                                                            string addr = Console.ReadLine();
                                                            string store_col1 = "Address";
                                                            //Console.WriteLine(d.Email + "\n" + addr + "\n" + table.Email);
                                                            detailsobj.UpdateDetails(store_col1, addr, id);
                                                            //detailsobj.UpdateDetails(d, addr);
                                                            //Console.WriteLine("Sample : " + d.Address);
                                                            //d.Address = addr;
                                                            //Console.WriteLine("After Sample : "+ d.Address);
                                                            break;
                                                        case "About Me":
                                                            Console.WriteLine("Enter your new About Me : ");
                                                            string abt_me = Console.ReadLine();
                                                            string store_col2 = "AboutMe";
                                                            //Console.WriteLine(d.Email + "\n" + addr + "\n" + table.Email);
                                                            detailsobj.UpdateDetails(store_col2, abt_me, id);
                                                            break;
                                                        case "Phone Number":
                                                            Console.WriteLine("Enter your new Phone Number : ");
                                                            string phn_no = Console.ReadLine();
                                                            string store_col3 = "Phone_No";
                                                            //Console.WriteLine(d.Email + "\n" + addr + "\n" + table.Email);
                                                            detailsobj.UpdateDetails(store_col3, phn_no, id);
                                                            break;
                                                        case "Website":
                                                            Console.WriteLine("Enter your new Website : ");
                                                            string website = Console.ReadLine();
                                                            string store_col4 = "Website";
                                                            //Console.WriteLine(d.Email + "\n" + addr + "\n" + table.Email);
                                                            detailsobj.UpdateDetails(store_col4, website, id);
                                                            break;
                                                        case "Go Back":
                                                            //logic
                                                            goto updateMenu;
                                                            //break;
                                                    }
                                                    //Console.WriteLine(detailsopt);
                                                    //string detailsopt = detailobj1.DetailsPrint();
                                                    break;
                                                case "Skills":
                                                    Log.Logger.Information("In update skills table..");
                                                    repeat = true;
                                                    while (repeat) { 
                                                    //logic
                                                    SkillsFunction skillsobj = new SkillsFunction();

                                                    //Skills s = skillsobj.GetSkillsRows(table.Id);
                                                   // SqlRepo sqlrepo = new SqlRepo();
                                                    id = sqlrepo.CheckId(table.Email);
                                                    Skills s = skillsobj.GetSkillsRows(id);
                                                    //Console.WriteLine("Sample Name : {0}",detailobj1.FullName);
                                                    string skillsopt = skillsobj.SkillsPrint();
                                                        switch (skillsopt)
                                                        {
                                                            case "Skill 1":
                                                                //logic 
                                                                Console.WriteLine("Enter your new Skill 1: ");
                                                                string skill1 = Console.ReadLine();
                                                                string store_col1 = "Skill_1";
                                                                //Console.WriteLine(d.Email + "\n" + addr + "\n" + table.Email);
                                                                skillsobj.UpdateSkills(store_col1, skill1, id);
                                                                repeat = false;
                                                                //skillsopt = skillsobj.SkillsPrint();
                                                                
                                                                break;

                                                            case "Skill 2":
                                                                //logic
                                                                Console.WriteLine("Enter your new Skill 2: ");
                                                                string skill2 = Console.ReadLine();
                                                                string store_col2 = "Skill_1";
                                                                //Console.WriteLine(d.Email + "\n" + addr + "\n" + table.Email);
                                                                skillsobj.UpdateSkills(store_col2, skill2, id);

                                                                break;
                                                            case "Skill 3":
                                                                //logic
                                                                Console.WriteLine("Enter your new Skill 3: ");
                                                                string skill3 = Console.ReadLine();
                                                                string store_col3 = "Skill_1";
                                                                //Console.WriteLine(d.Email + "\n" + addr + "\n" + table.Email);
                                                                skillsobj.UpdateSkills(store_col3, skill3, id);
                                                                break;
                                                            case "Go Back":
                                                                //logic
                                                                goto updateMenu;
                                                                //break;
                                                            default:
                                                                //logic 
                                                                Console.WriteLine("Enter a valid response..");
                                                                Console.WriteLine("Press Enter to continue");
                                                                Console.ReadLine();
                                                               // repeat = false;
                                                                // skillsopt = skillsobj.SkillsPrint();
                                                                break;
                                                        }
                                                    }
                                                    break;
                                                case "Experience":
                                                    //logic
                                                    Log.Logger.Information("In update experience..");
                                                    repeat = true;
                                                    while (repeat)
                                                    {
                                                        //logic
                                                        ExperienceFunction expobj = new ExperienceFunction();

                                                        //Skills s = skillsobj.GetSkillsRows(table.Id);
                                                        // SqlRepo sqlrepo = new SqlRepo();
                                                        id = sqlrepo.CheckId(table.Email);
                                                        Experience e = expobj.GetExperienceRows(id);
                                                        //Console.WriteLine("Sample Name : {0}",detailobj1.FullName);
                                                        string expopt = expobj.ExpPrint();
                                                        switch (expopt)
                                                        {
                                                            case "Experience 1":
                                                                //logic 
                                                                Console.WriteLine("Enter your new Company 1: ");
                                                                string comp1 = Console.ReadLine();
                                                                string store_col1 = "Company1";
                                                                //Console.WriteLine(d.Email + "\n" + addr + "\n" + table.Email);
                                                                expobj.UpdateExperience(store_col1, comp1, id);
                                                                //repeat = false;
                                                                //skillsopt = skillsobj.SkillsPrint();

                                                                break;

                                                            case "Experience 2":
                                                                //logic
                                                                Console.WriteLine("Enter your new Company 2: ");
                                                                string comp2 = Console.ReadLine();
                                                                string store_col2 = "Company2";
                                                                //Console.WriteLine(d.Email + "\n" + addr + "\n" + table.Email);
                                                                expobj.UpdateExperience(store_col2, comp2, id);

                                                                break;
                                                            case "Experience 3":
                                                                //logic
                                                                Console.WriteLine("Enter your new Company 3: ");
                                                                string comp3 = Console.ReadLine();
                                                                string store_col3 = "Company3";
                                                                //Console.WriteLine(d.Email + "\n" + addr + "\n" + table.Email);
                                                                expobj.UpdateExperience(store_col3, comp3, id);
                                                                break;
                                                            case "Go Back":
                                                                //logic
                                                                goto updateMenu;
                                                            //break;
                                                            default:
                                                                //logic 
                                                                Console.WriteLine("Enter a valid response..");
                                                                Console.WriteLine("Press Enter to continue");
                                                                Console.ReadLine();
                                                                 repeat = false;
                                                                // skillsopt = skillsobj.SkillsPrint();
                                                                break;
                                                        }
                                                    }
                                                    break;
                                                case "Education":
                                                    //logic
                                                    Log.Logger.Information("In update education..");
                                                    repeat = true;
                                                    while (repeat)
                                                    {
                                                        //logic
                                                        EducationFunction eduobj = new EducationFunction();

                                                        //Skills s = skillsobj.GetSkillsRows(table.Id);
                                                        // SqlRepo sqlrepo = new SqlRepo();
                                                        id = sqlrepo.CheckId(table.Email);
                                                        Education e = eduobj.GetEducationRows(id);
                                                        //Console.WriteLine("Sample Name : {0}",detailobj1.FullName);
                                                        string eduopt = eduobj.EduPrint();
                                                        switch (eduopt)
                                                        {
                                                            case "Register Number":
                                                                //logic
                                                                Console.WriteLine("Enter your new Register Number: ");
                                                                string reg_no = Console.ReadLine();
                                                                string store_col7 = "Register_No";
                                                                //Console.WriteLine(d.Email + "\n" + addr + "\n" + table.Email);
                                                                eduobj.UpdateEducation(store_col7, reg_no, id);
                                                                break;
                                                            case "College Name":
                                                                //logic 
                                                                Console.WriteLine("Enter your College Name: ");
                                                                string college = Console.ReadLine();
                                                                string store_col1 = "College_Name";
                                                                //Console.WriteLine(d.Email + "\n" + addr + "\n" + table.Email);
                                                                eduobj.UpdateEducation(store_col1, college, id);
                                                                //repeat = false;
                                                                //skillsopt = skillsobj.SkillsPrint();

                                                                break;

                                                            case "Stream":
                                                                //logic
                                                                Console.WriteLine("Enter your Stream: ");
                                                                string stream = Console.ReadLine();
                                                                string store_col2 = "Stream";
                                                                //Console.WriteLine(d.Email + "\n" + addr + "\n" + table.Email);
                                                                eduobj.UpdateEducation(store_col2, stream, id);

                                                                break;
                                                            case "Branch":
                                                                //logic
                                                                Console.WriteLine("Enter your Branch: ");
                                                                string branch = Console.ReadLine();
                                                                string store_col3 = "Branch";
                                                                //Console.WriteLine(d.Email + "\n" + addr + "\n" + table.Email);
                                                                eduobj.UpdateEducation(store_col3, branch, id);
                                                                break;
                                                            case "Percentage":
                                                                //logic
                                                                Console.WriteLine("Enter your Percentage: ");
                                                                string perc = Console.ReadLine();
                                                                string store_col4 = "Percentage";
                                                                //Console.WriteLine(d.Email + "\n" + addr + "\n" + table.Email);
                                                                eduobj.UpdateEducation(store_col4, perc, id);
                                                                break;
                                                            case "Start Year":
                                                                //logic
                                                                Console.WriteLine("Enter your Start Year: ");
                                                                string sy = Console.ReadLine();
                                                                string store_col5 = "StartYear";
                                                                //Console.WriteLine(d.Email + "\n" + addr + "\n" + table.Email);
                                                                eduobj.UpdateEducation(store_col5, sy, id);
                                                                break;
                                                            case "End Year":
                                                                //logic
                                                                Console.WriteLine("Enter your End Year: ");
                                                                string ey = Console.ReadLine();
                                                                string store_col6 = "EndYear";
                                                                //Console.WriteLine(d.Email + "\n" + addr + "\n" + table.Email);
                                                                eduobj.UpdateEducation(store_col6, ey, id);
                                                                break;

                                                            case "Go Back":
                                                                //logic
                                                                goto updateMenu;
                                                            //break;
                                                            default:
                                                                //logic 
                                                                Console.WriteLine("Enter a valid response..");
                                                                Console.WriteLine("Press Enter to continue");
                                                                Console.ReadLine();
                                                                repeat = false;
                                                                // skillsopt = skillsobj.SkillsPrint();
                                                                break;
                                                        }
                                                    }
                                                    break;
                                                //break;
                                               

                                                case "Menu":
                                                    goto updateMenu;
                                                case "Go Back":
                                                    //logic
                                                    goto redirected;
                                                   // break;
                                            }

                                            break;
                                            //break;
                                        case "Delete Details":
                                            Log.Logger.Information("In delete details..");
                                            Console.WriteLine("Are you sure you want to delete the details? [Y] or [N]");
                                            char ip = Convert.ToChar(Console.ReadLine());
                                            if (ip == 'Y')
                                            {
                                                SqlRepo sqldel = new SqlRepo();
                                                id = sqldel.CheckId(table.Email);
                                                sqldel.DelDetails(id);
                                            }
                                            else
                                            {
                                                goto redirect;
                                            }
                                            //logic
                                            break;
                                        case "Menu":
                                            goto redirected;
                                        default:
                                            Console.WriteLine("Enter valid input : ");
                                            goto redirected;
                                    }
                                }
                                else
                                {
                                    Log.Logger.Information("Login Incorrect..");
                                    Console.WriteLine("Login incorrect");
                                    Console.WriteLine("Go Signup");
                                    Console.WriteLine("Press Enter to go back : ");
                                    Console.ReadLine();
                                    Console.Clear();    
                                    repeat = false;
                                    goto redirect;
                                    //break;
                                }
                                //repeat = false;
                                //try
                                //{
                                //    Console.Clear();
                                //    Console.WriteLine("Enter your personal details : ");
                                //    Details detailobj = new Details();
                                //    DetailsFunctions addobj = new DetailsFunctions();
                                //    detailobj = addobj.GetEmail(table.Email);
                                //    int ID = sqlobj.CheckId(table.Email);
                                //    Console.WriteLine("id : " + ID);
                                //    addobj.AddDetails(detailobj, ID);
                                //}
                                //catch (Exception ex) { Console.WriteLine("Already added details.."); Console.WriteLine(ex.Message); }

                               
                                break;

                            case "SignUp":
                                Log.Logger.Information("In Signup..");
                                SignUp signupobj = new SignUp();
                                SqlRepo signuprepo = new SqlRepo();
                               
                                table = signupobj.EnterDetails();

                                    //Console.WriteLine("Table.Email = ", table.Email);
                                List<UserTable> tb = signupobj.GetDetails();
                                // check validation
                                bool check = signupobj.checkValidation(tb, table.Email, table.Password);
                                
                                if (check)
                                {
                                    Log.Logger.Information("Email already exists..");
                                    Console.WriteLine("Email already exists!");
                                    repeat = true;
                                    break;
                                    //signupobj.EnterDetails();

                                }
                                else {

                                    // SqlRepo sqlrepo = new SqlRepo();
                                    // To Add Details Table
                                    SqlRepo sqlrepo_obj = new SqlRepo();
                                    //exception handling for email 
                                    try
                                    {
                                        
                                        sqlrepo_obj.AddDetails(table, 0);
                                        
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("Email already exists!");
                                        // Console.WriteLine(e.Message);
                                        repeat = true;
                                        break;
                                    }
                                    Details detailobj1 = new Details();
                                    Log.Logger.Information("New user..");
                                    Console.WriteLine("Hellooo new user"); repeat = false;
                                    Console.WriteLine("Your Email : " + table.Email);
                                   
                                // operations menu
                                operationmenu:
                                    //ProfileMenu prof = new ProfileMenu();
                                    menu = new SignUpedMenu();
                                    
                                    menu.display();
                                    string menuopt = menu.UserChoice();
                                    Console.WriteLine("Press Enter to Add your details : ");
                                    Console.ReadLine();
                                    Console.Clear();
                                    
                                    switch (menuopt)
                                    {
                                        
                                        case "Exit":
                                            //logic
                                            Log.Logger.Information("User entered exit..");
                                            break;
                                        //case "View Details":
                                        //    break;
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
                                                        //List<UserTable> logtb = loginobj.GetDetails(); // all rows from UserTable
                                                        //                                               //Console.WriteLine("hello");
                                                        //bool check1 = loginobj.checkValidation(logtb, table.Email, table.Password);

                                                        DetailsFunctions addobj1 = new DetailsFunctions();
                                                        //detailobj1 = addobj1.display1(detailobj1);
                                                        detailobj1 = addobj1.GetEmail(table.Email);
                                                        int signupID = signuprepo.CheckId(table.Email);
                                                        addobj1.AddDetails(detailobj1, signupID);
                                                        break;

                                                    case "Skills":
                                                        Log.Logger.Information("Adding skills..");
                                                        Console.WriteLine("\n");
                                                        Console.WriteLine("Press Enter to Add Skills Details : ");
                                                        Console.ReadLine(); Console.Clear();
                                                        Skills skillobj1 = new Skills();

                                                        SkillsFunction addskill = new SkillsFunction();
                                                        //addskill.display();

                                                        int skillId = signuprepo.CheckId(table.Email);
                                                        addskill.AddDetails(skillobj1, skillId);
                                                        break;

                                                    case "Experience":
                                                        Log.Logger.Information("Adding Experience..");
                                                        Console.WriteLine("\n");
                                                        Console.WriteLine("Press Enter to Add Experience Details : ");
                                                        Console.ReadLine(); Console.Clear();
                                                        Experience expobj1 = new Experience();
                                                        ExperienceFunction addexp = new ExperienceFunction();
                                                        //addexp.display();
                                                        int ExpId = signuprepo.CheckId(table.Email);
                                                        addexp.AddDetails(expobj1, ExpId);
                                                        break;

                                                    case "Education":
                                                        Log.Logger.Information("Adding education..");
                                                        Console.WriteLine("\n");
                                                        Console.WriteLine("Press Enter to Add Education Details : ");
                                                        Console.ReadLine(); Console.Clear();
                                                        Education eduobj1 = new Education();
                                                        EducationFunction addedu = new EducationFunction();
                                                        //addedu.display();
                                                        int EduId = signuprepo.CheckId(table.Email);
                                                        addedu.AddDetails(eduobj1, EduId);
                                                        break;

                                                    case "Go Back":
                                                        Log.Logger.Information("User entered Go Back..");
                                                        //Console.WriteLine("Enter valid input!");
                                                        goto redirect;

                                                    default:
                                                        Console.WriteLine("Page does not exist!");
                                                        Console.WriteLine("Please press Valid Input!");
                                                        goto operationmenu;

                                                }
                                            }
                                  
                                        
                                           break;

                                    }
                                    
                                }
                                break;

                            //case "ListAllTrainers":
                            //    //logic
                            //    break;

                            case "Go Back":
                                Log.Logger.Information("User entered go back..");
                                //logic
                                //Console.WriteLine("Thank you! Press Ctrl+C to exit the program");
                                //Console.ReadLine();
                                goto startpage;
                                //repeat = true;
                                //break;

                            default:
                                Log.Logger.Information("User entered invalid response..");
                                Console.WriteLine("Please input a valid response");
                                Console.WriteLine("Please press Enter to continue");
                                Console.ReadLine();
                                break;

                        }
                    }
                        //List<UserTable> list = new List<UserTable>();
                        //GetTrainers trainers = new GetTrainers();
                        //list = trainers.GetDetails();
                        //foreach (UserTable user in list)
                        //{
                        //    Console.WriteLine(user.ToString());
                        //}
                        break;
                    
                    
                    case "Display Trainers":
                    // logic 
                    Log.Logger.Information("Displaying Trainers..");
                    SqlRepo repo = new SqlRepo();
                    List<Details> detailList = new List<Details>();
                    detailList = repo.GetDetails1();
                    //List<Skills> skillList = new List<Skills>();
                    //skillList = repo.GetSkills();
                    //List<Experience> expList = new List<Experience>();
                    //expList = repo.GetExperience();
                    //int i = 1;
                    Console.WriteLine("****PROFILE****");
                    detailList.ForEach(d =>
                    {
                        
                        Console.Write(" {0} {1} {2} {3} ", d.FullName, d.Email, d.PhoneNo, d.Website);
                        Console.WriteLine("\n");
                    });
                    Console.WriteLine("Press Enter to Go Back");
                    Console.ReadLine();
                    Console.Clear();
                    goto startpage;
                    //Console.WriteLine("Name : "+detailList.ful);
                        //break;
                    case "Exit":
                        //logic
                        break;
                    case "Menu":
                      //goto redirect;
                    default:
                        Console.WriteLine("Page does not exist!");
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                    goto startpage;
                      //  break;
                }
            }
        }
    }
