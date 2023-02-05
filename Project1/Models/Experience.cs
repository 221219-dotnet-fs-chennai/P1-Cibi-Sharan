using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Experience
    {
        private int UserID;
        private string Company1;
        private string Company2;
        private string Company3;

        public int USERID { get { return UserID; } set { UserID = value; } }
        public string COMPANY1 { get { return Company1; } set { Company1 = value; } }
        public string COMPANY2 { get { return Company2; } set { Company2 = value; } }
        public string COMPANY3 { get { return Company3; } set { Company3 = value; } }
    }
}
