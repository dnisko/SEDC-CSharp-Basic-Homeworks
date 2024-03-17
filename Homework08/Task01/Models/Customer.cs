namespace Task01.Models
{
    public class Customer : Card
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Customer(int id, string firstName, string lastName, int pin, decimal balance, long cardNumber)
            : base(pin, balance, cardNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }



        public virtual string GetInfo()
        {
            return $"\nId: {Id}\n" +
                   $"Name: {FirstName} {LastName}\n" + base.GetInfo();
        }

        //private int Pin { get; set; }

    }
}
