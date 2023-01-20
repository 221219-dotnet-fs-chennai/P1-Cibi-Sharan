using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel.Design;
using TrainerLibrary;

namespace Project0
{
    class Program
    {
        static void Main(string[] args)
        {
           
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
                                            break;
                                        case "View Details":
                                            //logic
                                            break;
                                        case "Update Details":
                                        //logic
                                        UpdateFunc:
                                            //logic
                                            //menu = new Menu();
                                            Console.WriteLine("Helloo");
                                        updateMenu:
                                            menu1.displayTables();
                                            string opt = menu1.userChoice();
                                            switch (opt)
                                            {
                                                case "Details":
                                                    //logic
                                                    //print rows of Details Table
                                                    DetailsFunctions detailsobj = new DetailsFunctions();

                                                    Details d = detailsobj.GetDetailsRows(table.Email);
                                                    SqlRepo sqlrepo = new SqlRepo();
                                                    int id = sqlrepo.CheckId(table.Email);
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
                                                    //logic
                                                    break;
                                                case "Experience":
                                                    //logic
                                                    break;
                                                case "Education":
                                                    //logic
                                                    break;
                                                case "Menu":
                                                    goto updateMenu;
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

                            case "Exit":
                                //logic
                                break;

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
                      goto redirect;
                    default:
                        Console.WriteLine("Page does not exist!");
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
