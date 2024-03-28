using EndGame.Models;

namespace EndGame.GamePlay
{
    public class Game
    {
        private List<Player> players { get; } = new List<Player>();

        public Player Login(string email, string password)
        {
            return players.Find(u => u.Email == email && u.ValidatePassword(password));
        }
        public void AddPlayer(string username, string email, string password)
        {
            players.Add(new Player (username, email, password));
        }
    }
}
