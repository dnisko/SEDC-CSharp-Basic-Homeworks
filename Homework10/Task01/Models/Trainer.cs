namespace Task01.Models
{
    public class Trainer : Person
    {
        public string Username { get; set; }
        private string Password { get; set; }

        public Trainer(int id, string firstName, string lastName, string username, string password) : base(id, firstName, lastName)
        {
            Username = username;
            Password = password;
        }

        public bool ValidatePassword(string password)
        {
            return Password == password;
        }
    }
}
