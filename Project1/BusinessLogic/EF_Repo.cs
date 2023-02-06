using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TrainerEntity.Entities;
//using TrainerEntity;
using TrainerET = TrainerEntity.Entities;

namespace BusinessLogic
{
    public class EF_Repo 
    {
        Mapper map = new Mapper();
        Project1DbContext dbobj = new Project1DbContext();
        public Models.UserTable SignUpDetails()
        {
            Models.UserTable table = new Models.UserTable();
            string namepattern = @"[A-Za-z]+";
        gotoname:
            try
            {
                Console.WriteLine("Enter your name : ");
                string namestr = Console.ReadLine();
                var match = Regex.Match(namestr, namepattern, RegexOptions.IgnoreCase);
                if (match.Success)
                    table.Name = namestr;
                else
                {
                    Console.WriteLine("Enter a valid name!");
                    goto gotoname;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Enter valid name");
                goto gotoname;
            }

        gotoemail:
            string emailpattern = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
            try
            {
                Console.WriteLine("Enter your email : ");
                string emailstr = Console.ReadLine();
                var match = Regex.Match(emailstr, emailpattern);
                if (match.Success)
                    table.Email = emailstr;
                else
                {
                    Console.WriteLine("Enter a valid email!");
                    goto gotoemail;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Enter valid email");
                goto gotoemail;
            }
        gotopassword:
            string passwordpattern = @"\w{6,10}";
            try
            {
                Console.WriteLine("Enter your password (6-10 characters long, atleast 1 number) : ");
                string passwordstr = Console.ReadLine();
                var match = Regex.Match(passwordstr, passwordpattern);
                if (match.Success)
                    table.Password = passwordstr;
                else
                {
                    Console.WriteLine("Enter a valid password!");
                    goto gotopassword;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Enter valid password");
                goto gotopassword;
            }
            return table;

        }

        public List<Models.UserTable> GetSignUpUsers()
        {
            //Models.UserTable obj = new Models.UserTable();
            var signup = dbobj.UserTables;
            
            var trainerdet = (from trd in signup
                              select new Models.UserTable()
                              {
                                 Id = trd.UserId,
                                 Name = trd.Name,
                                 Email = trd.EmailId,
                                 Password = trd.Password
                              });
            return trainerdet.ToList(); 
        }
        public int checkID(string email)
        {
            int a=0;
            var signedup = dbobj.UserTables;
            var trainerdet = (from trd in signedup
                              where trd.EmailId == email
                              select new Models.UserTable()
                              {
                                  Id = trd.UserId,
                              });

            foreach (var det in trainerdet)
            {
                a = det.Id;

            }
            return a;
        }
        public Details GetDetails(int id)
        {
            var details = dbobj.Details;
            var userdet = from trd in details
                          where trd.UserId == id
                          select trd;
            var t = dbobj.Details.Where(item => item.UserId == id).First();
            TrainerET.Detail det = new TrainerET.Detail();
            foreach (var d in userdet)
            {
                det = new TrainerET.Detail()
                {
                    UserId= id,
                    FullName = d.FullName,
                    Gender= d.Gender,
                    Address= d.Address,
                    AboutMe= d.AboutMe,
                    PhoneNo= d.PhoneNo,
                    EmailId= d.EmailId,
                    Website= d.Website
                };
            }
            return map.MapDetail(det);
        }
        //public TrainerET.UserTable GetUserTable(int id)
        //{
        //    var allusers = dbobj.UserTables;
        //    var user = from ud in allusers
        //               where ud.UserId == id
        //               select ud;
        //    var t = dbobj.UserTables.Where(item => item.UserId == id).First();
        //    TrainerET.UserTable table = new TrainerET.UserTable();
        //    foreach (var u in user)
        //    {
        //        table = new TrainerET.UserTable()
        //        {
        //            UserId = id,
        //            Name = u.Name,
        //        };
        //    }
        //    return map.mapusertable(table);
        //}

        public Skills GetSkills(int id)
        {
            var skills = dbobj.Skills;
            var userskill = from trd in skills
                          where trd.UserId == id
                          select trd;
            var t = dbobj.Skills.Where(item => item.UserId == id).First();
            TrainerET.Skill skill = new TrainerET.Skill();
            foreach (var d in userskill)
            {
                skill = new TrainerET.Skill()
                {
                    UserId = id,
                   Skill1= d.Skill1,
                   Skill2= d.Skill2,
                   Skill3= d.Skill3,
                };
            }
            return map.MapSkill(skill);
        }
        public Models.Experience GetExperience(int id)
        {
            var experience = dbobj.Experiences;
            var userexp = from trd in experience
                            where trd.UserId == id
                            select trd;
            var t = dbobj.Experiences.Where(item => item.UserId == id).First();
            TrainerET.Experience exp = new TrainerET.Experience();
            foreach (var d in userexp)
            {
                exp = new TrainerET.Experience()
                {
                    UserId = id,
                    Company1= d.Company1,
                    Company2= d.Company2,
                    Company3= d.Company3,
                };
            }
            return map.MapExperience(exp);
        }
        public Models.Education GetEducation(int id)
        {
            var education = dbobj.Educations;
            var usered = from trd in education
                          where trd.UserId == id
                          select trd;
            var t = dbobj.Educations.Where(item => item.UserId == id).First();
            TrainerET.Education edu = new TrainerET.Education();
            foreach (var d in usered)
            {
                edu = new TrainerET.Education()
                {
                    RegisterNo = d.RegisterNo,
                    UserId = id,
                    CollegeName = d.CollegeName,
                    Stream = d.Stream,
                    Branch = d.Branch,
                    Percentage = d.Percentage,
                    StartYear = d.StartYear,
                    EndYear= d.EndYear,
                    
                };
            }
            return map.MapEducation(edu);
        }
        public void AddDetails(Details d)
        {
            dbobj.Details.Add(map.mapdetail(d));
            dbobj.SaveChanges();
            Console.WriteLine("Data added successfully..");
        }
        public void AddSkills(Skills s)
        {
            dbobj.Skills.Add(map.mapskill(s));
            dbobj.SaveChanges();
            Console.WriteLine("Data added successfully..");
        }
        public void AddExperience(Models.Experience e)
        {
            dbobj.Experiences.Add(map.mapexperience(e));
            dbobj.SaveChanges();
            Console.WriteLine("Data added successfully..");
        }
        public void AddEducation(Models.Education ed)
        {
            dbobj.Educations.Add(map.mapeducation(ed));
            dbobj.SaveChanges();
            Console.WriteLine("Data added successfully..");
        }
        public void UpdateDetails(Models.Details d, string col)
        {
            if (col == "Address")
            {
                Console.WriteLine("Enter your new Address : ");
                string newaddr = Console.ReadLine();
                map.mapdetail(d);
                d.Address = newaddr;
                dbobj.SaveChanges();
                Console.WriteLine("Updated address..");
            }
            


        }
    }
  }

