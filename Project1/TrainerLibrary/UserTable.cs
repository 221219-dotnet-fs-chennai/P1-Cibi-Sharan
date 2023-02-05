namespace TrainerLibrary
{
    public class UserTable
    {
        private int id;
        private string name;
        private string email;
        private string password;

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Password { get { return password; } set {  password = value; } }

        public UserTable() { }

        public override string ToString()
        {
            return $"Id - {Id} Name - {Name} Email - {Email} Password - {Password}";
        }
    }
}