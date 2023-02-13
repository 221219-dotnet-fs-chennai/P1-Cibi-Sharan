using Models;
using TE = TrainerEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic
{
    public interface ILogic
    {
        /*public UserTable SignUpDetails();
        public List<UserTable> GetSignUpUsers();
        public int checkID(string s);
        //public List<UserTable> GetUserTable();
        public Details GetDetails(int id);
        public Skills GetSkills(int id);
        public Experience GetExperience(int id);
        public Education GetEducation(int id);
        public void AddDetails(Details d);*/
        //public List<Skills> GetSkills();
        //public List<Experience> GetExperience();
        //public List<Education> GetEducation();
        //public void AddDetails(T tb, int ID);

        public TE.Detail AddDetails(string? Email, Details details );
        public TE.UserTable AddUserTable(UserTable userTable );
        //public TE.UserTable AddUserTable( UserTable userTable );
        public TE.Skill AddSkills(string? Email, Skills skills);
        public TE.Experience AddExperience(string? Email, Experience exp);
        public TE.Education AddEducation(string? Email, Education ed);
        public TE.Education GetEducationDetails(string? Email);
        //public TE.Education GetFilteredPercentage(double Percentage);
        public TE.Experience GetExperienceDetails(string? Email);
        public TE.UserTable GetUserDetails(string? Email);
        public TE.Detail GetDetailDetails(string? Email);
        public TE.Skill GetSkillsDetails(string? Email);
        public void UpdateDetails(string? Email, Details d);
        public void UpdateUserTable(string? Email, UserTable userTable);
        public void UpdateSkills(string? Email, Skills skills);
        public void UpdateEducation(string? Email, Education ed);
        public void DeleteTrainer(TE.UserTable t);
        public void UpdateExperience(string? email, Experience exp);
        public List<TE.UserTable> GetAllUsers();
        public List<TE.Education> GetFilteredUsers(double Percentage);
    }
}
