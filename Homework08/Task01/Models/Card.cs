namespace Task01.Models
{
    public class Card
    {
        public int Pin { get; set; }
        public decimal Balance { get; set; }
        public long CardNumber { get; set; }

        public Card(int pin, decimal balance, long cardNumber)
        {
            Pin = pin;
            Balance = balance;
            CardNumber = cardNumber;
        }

        public virtual string GetInfo()
        {
            return $"Pin: {Pin}\n" +
                   $"Card no.: {CardNumber}";
        }
    }
}
