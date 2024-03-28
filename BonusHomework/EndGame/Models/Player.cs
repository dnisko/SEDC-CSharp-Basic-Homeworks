using System.Numerics;

namespace EndGame.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        private string Password { get; }
        public string Email { get; set; }
        public Race RaceEnum { get; set; }
        public Class ClassEnum { get; set; }

        public double Health { get; set; }
        public double Strength { get; set; }
        public double Agility { get; set; }


        public Player(string username, string email, string password)
        {
            UserName = username;
            Password = password;
            Email = email;
        }

        public Player(Race characterEnum, Class classEnum)
        {
            RaceEnum = characterEnum;
            ClassEnum = classEnum;
        }

        public bool ValidatePassword(string password)
        {
            return Password == password;
        }

        /*
        1 ) Dwarf
               Has 100 Health
               Has 6 Strength
               Has 2 Agility
           2 ) Elf
               Has 60 Health
               Has 4 Strength
               Has 6 Agility
           3 )Human
               Has 80 Health
               Has 5 Strength
               Has 4 Agility
        */
        public void BaseStats()//Player player)
        {
            switch (RaceEnum)
            {
                case Race.Dwarf:
                    Health = 100;
                    Strength = 6;
                    Agility = 2;
                    break;
                case Race.Elf:
                    Health = 60;
                    Strength = 4;
                    Agility = 6;
                    break;
                case Race.Human:
                    Health = 80;
                    Strength = 5;
                    Agility = 4;
                    break;
            }
        }
        /*
        1 ) Warrior
               +20 Health
               -1 Agility
           2 ) Rogue
               -20 Health
               +1 Agility
           3 ) Mage
               +20 health
               -1 Strength
        */
        public void ClassStats()//Player player)
        {
            switch (ClassEnum)
            {
                case Class.Warrior:
                    Health += 20;
                    Agility -= 1;
                    break;
                case Class.Rogue:
                    Health -= 20;
                    Agility += 1;
                    break;
                case Class.Mage:
                    Health += 20;
                    Strength -= 1;
                    break;
            }
        }
    }
}
