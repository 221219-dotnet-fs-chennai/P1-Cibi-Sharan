using TrainerEntity.Entities;

namespace TrainerEntity
{
    public class UserTableRepo 
    {
        private Project1DbContext context;

        public UserTableRepo(Project1DbContext _context)
        {
            context = _context;
        }
        public void AddUserTable(UserTable table)
        {

        }
        
    }
}
