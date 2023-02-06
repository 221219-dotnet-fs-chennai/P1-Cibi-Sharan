using Models;
using TrainerEntity;
using TE=TrainerEntity.Entities;

namespace BusinessLogic
{
    public class Logic : ILogic
    {
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
    }
}
