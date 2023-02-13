using Microsoft.EntityFrameworkCore;
using TrainerEntity.Entities;

namespace TrainerEntity
{
    public class Repo : IRepo
    {
        private Project1DbContext context = new();
        
        /*public Repo(Project1DbContext _context)
        {
            context = _context;
        }*/
        public Repo() { }
        public void AddDetails(Detail detail)
        {
            context.Add(detail);
            context.SaveChanges();
        }

        public IEnumerable<UserTable> GetUsers()
        {
            return context.UserTables.ToList();
        }
        public void AddUser(UserTable userTable)
        {
            //var td = context.UserTables;
            try
            {
                context.Add(userTable);
                context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        public void AddSkill(Skill skill)
        {
            //var td = context.UserTables;
            try
            {
                context.Add(skill);
                context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        public void AddExperience(Experience exp)
        {
            //var td = context.UserTables;
            try
            {
                context.Add(exp);
                context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        public void AddEducation(Education ed)
        {
            //var td = context.UserTables;
            try
            {
                context.Add(ed);
                context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        public void UpdateDetails(Detail d)
        {
            context.Update(d);
            context.SaveChanges();
        }
        public void UpdateUser(UserTable u)
        { 
            context.Update(u);
            context.SaveChanges();
        }
        public void UpdateSkills(Skill s)
        {
            context.Update(s);
            context.SaveChanges();
        }
        public void UpdateEducation(Education education)
        {
            context.Update(education);
            context.SaveChanges();
        }
        public void UpdateExperience(Experience exp)
        {
            context.Update(exp);
            context.SaveChanges();
        }
        public UserTable DeleteUser(UserTable t)
        {
            context.Remove(t);
            context.SaveChanges();
            return t;
        }

    }
}
