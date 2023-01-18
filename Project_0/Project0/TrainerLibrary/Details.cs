﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainerLibrary
{
    public class Details
    {
        private int userID;
        private string fullName;
        private string gender;
        private string address;
        private string aboutMe;
        private long phone_No;
        private string email;
        private string website;

        public int UserID { get { return userID; } set { userID = value; } }
        public string FullName { get { return fullName; } set { fullName = value; } }
        public string Gender { get { return gender; } set { gender = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string AboutMe { get { return aboutMe; } set { aboutMe = value; } }
        public long PhoneNo { get { return phone_No;} set { phone_No = value; } }
        public string Email { get { return email; }set { email = value; } }
        public string Website { get { return website; }set { website= value; } }
    }
}
