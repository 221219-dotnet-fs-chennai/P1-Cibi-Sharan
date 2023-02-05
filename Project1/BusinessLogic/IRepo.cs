using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    internal interface IRepo
    {
        public UserTable SignUpDetails();
        public List<UserTable> GetSignUpUsers();
        public int checkID(string s);
        //public List<UserTable> GetUserTable();
        public Details GetDetails(int id);
        public Skills GetSkills(int id);
        public Experience GetExperience(int id);
        public Education GetEducation(int id);
        public void AddDetails(Details d);
        //public List<Skills> GetSkills();
        //public List<Experience> GetExperience();
        //public List<Education> GetEducation();
        //public void AddDetails(T tb, int ID);
    }
}
