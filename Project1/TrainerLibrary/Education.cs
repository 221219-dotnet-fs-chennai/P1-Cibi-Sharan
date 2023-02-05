using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainerLibrary
{
    public class Education
    {
        private long Register_No;
        private int UserID;
        private string College_Name;
        private string Stream;
        private string Branch;
        private double Percentage;
        private int StartYear;
        private int EndYear;

        public long REGISTER_NO { get { return Register_No; } set { Register_No = value; } }
        public int USERID { get { return UserID; } set { UserID = value; } }
        public string COLLEGE_NAME { get { return College_Name; } set { College_Name = value; } }
        public string STREAM { get { return Stream; } set { Stream = value; } }
        public string BRANCH { get { return Branch; } set { Branch = value; } }
        public double PERCENTAGE { get { return Percentage; } set { Percentage = value; } }
        public int START_YEAR { get { return StartYear; } set { StartYear = value; } }
        public int END_YEAR { get { return EndYear; } set { EndYear = value; } }
    }
}
