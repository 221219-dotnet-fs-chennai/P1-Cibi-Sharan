
using TrainerEntity.Entities;
namespace TrainerEntity
{
    public interface IRepo
    {
       
        public void AddDetails(Detail d);
        public void AddUser(UserTable t);

        public IEnumerable<UserTable> GetUsers();

    }
}
