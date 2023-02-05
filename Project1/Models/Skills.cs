using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Skills
    {
        private int UserID;
        private string Skill_1;
        private string Skill_2;
        private string Skill_3;

        public int USERID { get { return UserID; } set { UserID = value; } }

        public string SKILL_1 { get { return Skill_1; } set { Skill_1 = value; } }

        public string SKILL_2 { get { return Skill_2; } set { Skill_2 = value; } }

        public string SKILL_3 { get { return Skill_3; } set { Skill_3 = value; } }
    }
}
