using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_UI
{
    internal class SkillsClass
    {
        public void display(Skills s)
        {
            Console.WriteLine("***SKILLS OF USER***");
            Console.WriteLine("SKILL 1 : "+s.SKILL_1);
            Console.WriteLine("SKILL 2 : "+s.SKILL_2);
            Console.WriteLine("SKILL 3 : " + s.SKILL_3);
        }
        public Skills InsertSkills(Skills s, int id)
        {
            Console.WriteLine("Adding Skills...");
            s.USERID= id;
            Console.WriteLine("Enter SKILL 1 : ");
            s.SKILL_1 = Console.ReadLine();
            Console.WriteLine("Enter SKILL 2 : ");
            s.SKILL_2 = Console.ReadLine();
            Console.WriteLine("Enter SKILL 3 : ");
            s.SKILL_3 = Console.ReadLine();
            return s;
        }
    }
}
