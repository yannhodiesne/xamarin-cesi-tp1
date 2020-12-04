namespace AndroidTP1.Models
{
    public class Account
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public Account(string login, string name, string password)
        {
            Login = login;
            Name = name;
            Password = password;
        }
    }
}
