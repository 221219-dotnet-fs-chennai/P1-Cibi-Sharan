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
                                    //foreach (UserTable t in logtb)
                                    //{
                                    //    Console.WriteLine(t.ToString());
                                    //}
                                    Console.WriteLine("Welcome {0}", table.Name);
                                    repeat = false;
                                    
                                }
                                else
                                {
                                    Console.WriteLine("Login incorrect");
                                    Console.WriteLine("Go Signup");
                                    Console.WriteLine("Press Enter to go back : ");
                                    Console.ReadLine();
                                    Console.Clear();    
                                    //repeat = false;
                                    goto redirect;
                                    //break;
                                }
                                repeat = false;
                                try
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter your personal details : ");
                                    Details detailobj = new Details();
                                    DetailsFunctions addobj = new DetailsFunctions();
                                    detailobj = addobj.GetEmail(table.Email);
                                    int ID = sqlobj.CheckId(table.Email);
                                    Console.WriteLine("id : " + ID);
                                    addobj.AddDetails(detailobj, ID);
                                }
                                catch (Exception ex) { Console.WriteLine("Already added details.."); Console.WriteLine(ex.Message); }
                               
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
                                    // operations menu
                                    operationmenu:
                                    menu = new OperationsMenu();
                                    menu.display();
                                    string menuopt = menu.UserChoice();
                                    switch(menuopt)
                                    {
                                        case "Exit":
                                            //logic
                                            break;
                                        case "Add Details":
                                            //logic
                                            Console.WriteLine("Press Enter to Add your details : ");
                                            Console.ReadLine();
                                            Console.Clear();
                                            SqlRepo sqlrepo_obj = new SqlRepo();
                                            sqlrepo_obj.AddDetails(table, 0);
                                            Details detailobj1 = new Details();
                                            DetailsFunctions addobj1 = new DetailsFunctions();
                                            //detailobj1 = addobj1.display1(detailobj1);
                                            detailobj1 = addobj1.GetEmail(table.Email);
                                            int signupID = signuprepo.CheckId(table.Email);
                                            addobj1.AddDetails(detailobj1, signupID);

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
                                        case "Update Details":
                                            //logic
                                            break;
                                        case "Delete Details":
                                            //logic 
                                            break;
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
