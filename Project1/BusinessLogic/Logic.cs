using Models;
using System.Security.Cryptography;
using TrainerEntity;
//using TrainerEntity.Entities;
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
           
            //context.Add(Map.mapusertable(ut));
            //context.SaveChanges();
            return repo.AddUser(Map.mapusertable(ut));
        }
        public TE.Detail AddDetails(string? email,string password, Details details)
        {
            int id = action.GetId(email);
            //var user = _logic.GetUserDetails(email, password);
            var user = GetUserDetails(email, password);
            if (user != null)
            {
                    details.UserID = id;
                    details.Email = email;
                    //var entityDetail = Map.mapdetail(details);
                    repo.AddDetails(Map.mapdetail(details));
                    return Map.mapdetail(details);
                
            }
            return null;
            
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
        //public TE.Education GetFilteredPercentage(double Percentage)
        //{
        //    Models.Education ed = new Models.Education();
            
        //    //Education filteredEdu = 
        //}
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
        public TE.UserTable GetUserDetails(string? email, string password)
        {
            UserTable ed = new UserTable();
            int id = action.GetId(email);
            ed = efrepo.GetUserTable(id);
            // check email and password are correct
            if (ed.Email== email && ed.Password == password)
            {
                return Map.mapusertable(ed);
            }
            return null;
        }
        public TE.UserTable GetDelDetails(string? email)
        {
            UserTable ed = new UserTable();
            int id = action.GetId(email);
            ed = efrepo.GetUserTable(id);
            // check email and password are correct
            if (ed.Email == email)
            {
                return Map.mapusertable(ed);
            }
            return null;
        }
        public List<TE.UserTable> GetAllUsers()
        {
            var tb = context.UserTables.ToList();
            var query = from t in tb
                        select t;
            return query.ToList();
        }
        public List<TE.Education> GetAllEducation()
        {
            var tbedu = context.Educations.ToList();
            var query = from t in tbedu
                        select t;
            return query.ToList();
        }
        public List<TE.Education> GetFilteredUsers(double Percentage)
        {
            var tb = GetAllEducation();
            var query = from t in tb
                        where t.Percentage > Percentage
                        select t;
            return query.ToList();
        }
        public TE.Detail GetDetailDetails(string? Email)
        {
            Details dt = new Details();
            int id = action.GetId(Email);
            dt = efrepo.GetDetails(id);
            return Map.mapdetail(dt);
        }
        public TE.Skill GetSkillsDetails(string? email)
        {
            Skills skill = new Skills();
            int id = action.GetId(email);
            skill= efrepo.GetSkills(id);
            return Map.mapskill(skill);
        }
        //public TE.Skill GetUserSkills(string? email)
        //{
        //    Skills skills = new Skills();
        //    int id = action.GetId(email);
        //    skills = efrepo.GetUserSkills(id);
        //    ed = repo.DeleteUser(ed);
        //    ed =
        //    return Map.mapskill(skills);
        //}
        public void UpdateUserTable(string? email, UserTable t)
        {
            try
            {
                //int id = efrepo.checkID(email);
                int id = efrepo.checkID(email);
                UserTable ut = efrepo.GetUserTable(id);
                if (ut != null) { 
                    if (t.Name != "string" && t.Name != ut.Name)
                    {
                        ut.Name = t.Name;
                    }
                    if (t.Password != "string" && t.Password!= ut.Password)
                    {
                        ut.Password = t.Password;
                    }
                }
                repo.UpdateUser(Map.mapusertable(ut));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
        public void UpdateSkills(string? Email, Skills s)
        {
            try
            {
                int id = efrepo.checkID(Email);
                var skill = efrepo.GetSkills(id);
                if (skill != null)
                {
                    if (skill.SKILL_1 != "string" && skill.SKILL_1 != s.SKILL_1)
                    {
                        skill.SKILL_1 = s.SKILL_1;
                    }
                    if (skill.SKILL_2 != "string" && skill.SKILL_2 != s.SKILL_2)
                    {
                        skill.SKILL_2 = s.SKILL_2;
                    }
                    if (skill.SKILL_3 != "string" && skill.SKILL_3 != s.SKILL_3)
                    {
                        skill.SKILL_3 = s.SKILL_3;
                    }
                }
                repo.UpdateSkills(Map.mapskill(skill));
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public void UpdateEducation(string? Email, Education ed)
        {
            try
            {
                int id = efrepo.checkID(Email);
                var edu = efrepo.GetEducation(id);
                if (edu != null)
                {
                    if (edu.COLLEGE_NAME != "string" && edu.COLLEGE_NAME != ed.COLLEGE_NAME)
                    {
                       edu.COLLEGE_NAME= ed.COLLEGE_NAME;
                    }
                    if (edu.STREAM != "string" && edu.STREAM != ed.STREAM)
                    {
                        edu.STREAM = ed.STREAM;
                    }
                    if (edu.BRANCH != "string" && edu.BRANCH != ed.BRANCH)
                    {
                        edu.BRANCH = ed.BRANCH;
                    }
                    if (edu.PERCENTAGE != 0 && edu.PERCENTAGE != ed.PERCENTAGE)
                    {
                        edu.PERCENTAGE = ed.PERCENTAGE;
                    }
                    if (edu.START_YEAR != 0 && edu.START_YEAR != ed.START_YEAR)
                    {
                        edu.START_YEAR = ed.START_YEAR;
                    }
                    if (edu.END_YEAR != 0 && edu.END_YEAR != ed.END_YEAR)
                    {
                        edu.END_YEAR = ed.END_YEAR;
                    }
                }
                repo.UpdateEducation(Map.mapeducation(edu));
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
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

        public void UpdateExperience(string? Email, Experience exp)
        {
            try
            {
                int id = efrepo.checkID(Email);
                var experience = efrepo.GetExperience(id);
                if (experience != null)
                {
                    if (experience.COMPANY1 != "string" && experience.COMPANY1 != exp.COMPANY1)
                    {
                        experience.COMPANY1 = exp.COMPANY1;
                    }
                    if (experience.COMPANY2 != "string" && experience.COMPANY2 != exp.COMPANY2)
                    {
                        experience.COMPANY2 = exp.COMPANY2;
                    }
                    if (experience.COMPANY3 != "string" && experience.COMPANY2 != exp.COMPANY2)
                    {
                        experience.COMPANY3 = exp.COMPANY2;
                    }
                }
                repo.UpdateExperience(Map.mapexperience(experience));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
