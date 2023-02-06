using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainerEntity;

namespace BusinessLogic
{
    public class LogicActions
    {
        IRepo repo = new Repo();
        public int GetId(string? email)
        {
            return (from user in repo.GetUsers()
                   where user.EmailId == email
                   select user.UserId).FirstOrDefault();
        }
    }
}
