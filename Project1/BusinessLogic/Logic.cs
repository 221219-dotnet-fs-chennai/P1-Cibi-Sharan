using Models;
using System.Security.Cryptography;
using TrainerEntity;
using TE=TrainerEntity.Entities;

namespace BusinessLogic
{
    public class Logic : ILogic
    {
        EF_Repo efrepo = new EF_Repo();
        LogicActions action = new LogicActions();
        TE.Project1DbContext context = new TE.Project1DbContext();
        Repo repo = new Repo();
        //public Logic(TE.Project1DbContext context)
        //{
        //    repo = new Repo(context);
        //}

        Mapper Map = new Mapper();
        public TE.UserTable AddUserTable(Models.UserTable ut)
        {
            //var entityUserTable = Map.mapusertable(ut);
            repo.AddUser(Map.mapusertable(ut));
            //context.Add(Map.mapusertable(ut));
            //context.SaveChanges();
            return Map.mapusertable(ut);
        }
        public TE.Detail AddDetails(string? email, Details details)
        {
            int id = action.GetId(email);
            details.UserID = id;
            details.Email = email;
            //var entityDetail = Map.mapdetail(details);
            repo.AddDetails(Map.mapdetail(details));
            return Map.mapdetail(details);
        }
        

        public TE.Skill AddSkills(string? email, Skills skills)
        {
            int id = action.GetId(email);
            skills.USERID = id;
            //details.Email = email;
            //var entityDetail = Map.mapdetail(details);
            repo.AddSkill(Map.mapskill(skills));
            return Map.mapskill(skills);
        }
        public TE.Experience AddExperience(string? email, Experience exp)
        {
            int id = action.GetId(email);
            exp.USERID = id;
            //details.Email = email;
            //var entityDetail = Map.mapdetail(details);
            repo.AddExperience(Map.mapexperience(exp));
            return Map.mapexperience(exp);
        }
        public TE.Education AddEducation(string? email, Education ed)
        {
            int id = action.GetId(email);
            ed.USERID = id;
            //details.Email = email;
            //var entityDetail = Map.mapdetail(details);
            repo.AddEducation(Map.mapeducation(ed));
            return Map.mapeducation(ed);
        }
        public TE.Education GetEducationDetails(string? email)
        {
            Education ed = new Education();
            int id = action.GetId(email);
            ed = efrepo.GetEducation(id);
            //ed.USERID = id;
            //details.Email = email;
            //var entityDetail = Map.mapdetail(details);
            //repo.GetEducation(Map.mapeducation(ed));
            return Map.mapeducation(ed);
        }
        public TE.Experience GetExperienceDetails(string? email)
        {
            Experience exp = new Experience();
            int id = action.GetId(email);
            exp = efrepo.GetExperience(id);
            //ed.USERID = id;
            //details.Email = email;
            //var entityDetail = Map.mapdetail(details);
            //repo.GetEducation(Map.mapeducation(ed));
            return Map.mapexperience(exp);
        }
        public TE.UserTable GetUserDetails(string? email)
        {
            UserTable ed = new UserTable();
            int id = action.GetId(email);
            ed = efrepo.GetUserTable(id);
            //ed = repo.DeleteUser(ed);
            //ed = 
            return Map.mapusertable(ed);
        }
        public void UpdateDetails(string? email, Details d)
        {
            try
            {
                int id = efrepo.checkID(email);
                Details detail = efrepo.GetDetails(id);
                if (detail != null)
                {
                    if (d.FullName != "string" && d.FullName != detail.FullName) {
                        detail.FullName = d.FullName;
                    }
                    if (d.Gender != "string" && d.Gender != detail.Gender)
                    {
                        detail.Gender = d.Gender;
                    }
                    if (d.Address != "string" && d.Address != detail.Address)
                    {
                        detail.Address = d.Address;
                    }
                    if (d.AboutMe != "string" && d.AboutMe != detail.AboutMe)
                    {
                        detail.AboutMe = d.AboutMe;
                    }
                    if (d.PhoneNo != "string" && d.PhoneNo != detail.PhoneNo)
                    {
                        detail.PhoneNo = d.PhoneNo;
                    }
                    if (d.Website != "string" && d.Website != detail.Website)
                    {
                        detail.Website = d.Website;
                    }
                }
                repo.UpdateDetails(Map.mapdetail(detail));
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
        }
        public void DeleteTrainer(TE.UserTable t)
        {
            try
            {
                repo.DeleteUser(t);
                Console.WriteLine("Deleted user : "+t.Name);
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
