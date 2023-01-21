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
                                //logic
                                Login loginobj = new Login();
                                SqlRepo sqlobj = new SqlRepo();
                                table = loginobj.EnterDetails(); // row containing fields entered by user
                                List<UserTable> logtb = loginobj.GetDetails(); // all rows from UserTable
                                Console.WriteLine("hello");
                                bool check1 = loginobj.checkValidation(logtb, table.Email, table.Password);
                                //string command = "SELECT UserID, Name, EmailID, Password from [UserTable]";
                                //table.Id = sqlobj.GetID();
                                //string query = "SELECT UserID from UserTable WHERE EmailID = @mail";
                                if (check1)
                                {
                                    
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
                                            Console.WriteLine("Thank you! Visit Again");
                                            Console.WriteLine("Press CTRL+C to exit");
                                            Console.ReadLine();
                                            break;
                                        case "View Details":
                                            //logic
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
                                            break;
                                        case "Update Details":
                                        //logic
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
                                                    }
                                                    //Console.WriteLine(detailsopt);
                                                    //string detailsopt = detailobj1.DetailsPrint();
                                                    break;
                                                case "Skills":
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
                
                                SignUp signupobj = new SignUp();
                                SqlRepo signuprepo = new SqlRepo();
                                table = signupobj.EnterDetails();
                                
                                //Console.WriteLine("Table.Email = ", table.Email);
                                List<UserTable> tb = signupobj.GetDetails();

                                // check validation
                                bool check = signupobj.checkValidation(tb, table.Email, table.Password);
                                if (check)
                                {
                                    Console.WriteLine("Email already exists!");
                                    repeat = true;
                                    break;
                                    //signupobj.EnterDetails();

                                }
                                else { 
                                   // SqlRepo sqlrepo = new SqlRepo();
                                   // To Add Details Table

                                    Console.WriteLine("Hellooo new user"); repeat = false;
                                    Console.WriteLine("Your Email : " + table.Email);
                                    Details detailobj1 = new Details();
                                // operations menu
                                operationmenu:
                                    //ProfileMenu prof = new ProfileMenu();
                                    menu = new SignUpedMenu();
                                    
                                    menu.display();
                                    string menuopt = menu.UserChoice();
                                    Console.WriteLine("Press Enter to Add your details : ");
                                    Console.ReadLine();
                                    Console.Clear();
                                    SqlRepo sqlrepo_obj = new SqlRepo();
                                    sqlrepo_obj.AddDetails(table, 0);
                                    switch (menuopt)
                                    {
                                        case "Exit":
                                            //logic
                                            break;
                                        //case "View Details":
                                        //    break;
                                        case "Add Details":
                                            //logic
                                            DetailsFunctions addobj1 = new DetailsFunctions();
                                            //detailobj1 = addobj1.display1(detailobj1);
                                            detailobj1 = addobj1.GetEmail(table.Email);
                                            int signupID = signuprepo.CheckId(table.Email);
                                            addobj1.AddDetails(detailobj1, signupID);
                                            //addobj1.DetailsPrint();

                                            // To Add Skills Table

                                            Console.WriteLine("\n");
                                            Console.WriteLine("Press Enter to Add Skills Details : ");
                                            Console.ReadLine(); Console.Clear();
                                            Skills skillobj1 = new Skills();

                                            SkillsFunction addskill = new SkillsFunction();
                                            //addskill.display();

                                            int skillId = signuprepo.CheckId(table.Email);
                                            addskill.AddDetails(skillobj1, skillId);

                                            Console.WriteLine("\n");
                                            Console.WriteLine("Press Enter to Add Experience Details : ");
                                            Console.ReadLine(); Console.Clear();
                                            Experience expobj1 = new Experience();
                                            ExperienceFunction addexp = new ExperienceFunction();
                                            //addexp.display();
                                            int ExpId = signuprepo.CheckId(table.Email);
                                            addexp.AddDetails(expobj1, ExpId);

                                            Console.WriteLine("\n");
                                            Console.WriteLine("Press Enter to Add Education Details : ");
                                            Console.ReadLine(); Console.Clear();
                                            Education eduobj1 = new Education();
                                            EducationFunction addedu = new EducationFunction();
                                            //addedu.display();
                                            int EduId = signuprepo.CheckId(table.Email);
                                            addedu.AddDetails(eduobj1, EduId);

                                            break;
                                        //case "Update Details":
                                        //    UpdateFunc:
                                        //    //logic
                                        //    //menu = new Menu();
                                        //    Console.WriteLine("Helloo");
                                        //    updateMenu:
                                        //    menu1.displayTables();
                                        //    string opt = menu1.userChoice();
                                        //    switch(opt)
                                        //    {
                                        //        case "Details":
                                        //            //logic
                                        //            //print rows of Details Table
                                        //            DetailsFunctions detailsobj = new DetailsFunctions();

                                        //            Details d = detailsobj.GetDetailsRows(table.Email);
                                        //            //Console.WriteLine("Sample Name : {0}",detailobj1.FullName);
                                        //            string detailsopt = detailsobj.DetailsPrint(d);
                                        //            switch(detailsopt)
                                        //            {
                                        //                case "Address":
                                        //                    Console.WriteLine("Enter your new Address : ");
                                        //                    string addr = Console.ReadLine();
                                        //                    //detailsobj.UpdateDetails(d, addr);
                                        //                    d.Address = addr;
                                        //                    break;
                                        //                case "About Me":
                                        //                    break;
                                        //                case "Phone Number":
                                        //                    break;
                                        //                case "Website":
                                        //                    break;
                                        //            }
                                        //            //Console.WriteLine(detailsopt);
                                        //            //string detailsopt = detailobj1.DetailsPrint();
                                        //                break;
                                        //            case "Skills":
                                        //                //logic
                                        //                break;
                                        //            case "Experience":
                                        //                //logic
                                        //                break;
                                        //            case "Education":
                                        //                //logic
                                        //                break;
                                        //            case "Menu":
                                        //                goto updateMenu;
                                        //        }

                                        //    break;
                                        //case "Delete Details":
                                        //    //logic 
                                        //    break;
                                        case "Menu":
                                            Console.WriteLine("Enter valid input!");
                                            goto operationmenu;
                                        default:
                                            Console.WriteLine("Page does not exist!");
                                            Console.WriteLine("Please press Valid Input!");
                                            goto operationmenu;
                                           // break;

                                    }
                                    
                                }
                                break;

                            //case "ListAllTrainers":
                            //    //logic
                            //    break;

                            case "Go Back":
                                //logic
                                //Console.WriteLine("Thank you! Press Ctrl+C to exit the program");
                                //Console.ReadLine();
                                 goto startpage;
                                //repeat = true;
                                //break;

                            default:
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
                    
                    
                    case "Find Trainers":
                        // logic 

                        break;
                    case "Exit":
                        //logic
                        break;
                    case "Menu":
                      //goto redirect;
                    default:
                        Console.WriteLine("Page does not exist!");
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
