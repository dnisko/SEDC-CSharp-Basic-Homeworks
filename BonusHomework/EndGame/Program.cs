using EndGame.GamePlay;
using EndGame.Models;

namespace EndGame
{
    internal class Program
    {
        #region EndGame

        /*
         Bonus Task - not mandatory
           Hero's Journey ⚔
           Part 1: Log in the game 🛡
           
               The users can log in with their email and passwords
               Research how to find a character in a string
               Find a way to keep the emails and passwords
           
                   Proposal: Create an array with two emails and an array with two passwords
           
               Ask the user to enter username and then password
               Validate the inputs
                   Fields must not be empty
                   The email and password must match with the corresponding email and password that were added previously
                   The email filed should be validated by checking if there is @ character and a . character
                   In case the input is wrong give the user an option to try again
                   After 5 tries, close the application
               When the user logs in show a Welcome message
           
           Part2: Create a character 🗡
           
               The user needs to input a name
                   The name must be longer than 1 characters
                   The name must not be longer than 20 characters
               Give the options to the user to choose from 3 races:
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
                   Validate the answer, if it is not a number or a number that is not given as an option, show an error message and give the options again
               After that give the user an option to choose a class:
                   1 ) Warrior
                       +20 Health
                       -1 Agility
                   2 ) Rogue
                       -20 Health
                       +1 Agility
                   3 ) Mage
                       +20 health
                       -1 Strength
                   Validate the answer, if it is not a number or a number that is not given as an option, show an error message and give the options again
               A message for successful creating of the character must be shown
               A review of the character stats must be shown:
                   'name' ( 'race' ) the 'class'
           
                       Ex: Bob ( Dwarf ) the Warrior
           
                   Stats: 'health' HP, 'strength' STR, 'agility' AGI
           
                       Ex: 120 HP, 6 STR, 1 AGI
           
           Part 3: Gameplay 🏹
           
               Research how to get random numbers in C#
               The hero should pass 5 events to win the game
               When an event happens:
                   Description of the event shows
                   The hero has an option to:
                       1 ) Fight - Get a random number from 1 to 10 and if that number is lesser than your Strength then you win the fight with a message showing: You won fight!
                       2 ) Run Away - Get a random number from 1 to 10 and if that number is lesser than your Agility then you run away
                   The user should not be able to enter anything other than 1 or 2
                   Events take health off the character if it fails
                   Different events take different amount of health
                   When the health is subtracted from the character health there must be a check made to see if the character health is below or equal to 0
                   If the character health is equal of below zero, show a YOU LOST message and ask the person if they want to start a new game
                       1 ) Yes - Restarts the game
                       2 ) No - Exits the application
                   If the character has more health, show how much health is left and go to the next event
                   After the last event if the character has more than 0 health, show a YOU WON message and ask the person if they want to start a new game,
                    the same as when you lose options of Yes and No
               Events:
                   Bandits attack you out of nowhere. They seem very dangerous...
                       -20 health
                   You bump in to one of the guards of the nearby village. They attack you without warning...
                       -30 health
                   A Land Shark appears. It starts chasing you down to eat you...
                       -50 health
                   You accidentally step on a rat. His friends are not happy. They attack...
                       -10 health
                   You find a huge rock. It comes alive somehow and tries to smash you...
                       -30 health
           
         */

        #endregion

        static void Main(string[] args)
        {
            Game game = new Game();
            Player currentPlayer;
            game.AddPlayer("bob", "bob@gamer.com", "bob123");
            game.AddPlayer("test", "test@test.com", "test123");
            game.AddPlayer("player1", "player1@gamer.com", "asde");
            game.AddPlayer("player2", "player2@gamer.com", "asde");
            game.AddPlayer("player3", "player3@gamer.com", "asde");
            game.AddPlayer("player4", "player4@gamer.com", "asde");
            game.AddPlayer("player5", "player5@gamer.com", "asde");
            game.AddPlayer("player6", "player6@gamer.com", "asde");
            game.AddPlayer("player7", "player7@gamer.com", "asde");
            game.AddPlayer("player8", "player8@gamer.com", "asde");

            int tries = 0;
            int raceInput, raceClassInput;
            Random randomNumber = new Random();
            int fights = 0;
            string finalInput = "";
            EventResult eventPlayer;
            string email, password;
            while (true)
            {
                Console.WriteLine("Enter email to login:");
                email = Console.ReadLine();
                if (!email.Contains('@') && !email.Contains('.'))
                {
                    Console.WriteLine("Enter valid email.");
                    tries++;
                    continue;
                }
                Console.WriteLine("Enter password:");
                password = Console.ReadLine();
                

                currentPlayer = game.Login(email, password);

                if (currentPlayer != null)
                {
                    Console.WriteLine($"Welcome {currentPlayer.UserName}");
                    break;
                }

                tries++;

                if (tries != 5)
                {
                    Console.WriteLine("Error. Try again\n" +
                                      $"{5 - tries} left");
                }
                else
                {
                    Console.WriteLine("Are you trying to hack me!?\n" +
                                      "bye bye!");
                    Environment.Exit(0);
                    //https://stackoverflow.com/questions/10286056/what-is-the-command-to-exit-a-console-application-in-c
                }
            }


            //Console.WriteLine("Enter username:");
            //string username = Console.ReadLine();
            //Console.WriteLine("Enter password:");
            //string password = Console.ReadLine();
            //Console.WriteLine("Enter email:");
            //string email = Console.ReadLine();

            while (true)
            {
                currentPlayer = game.Login(email, password);
                while (true)
                {
                    Console.WriteLine("Choose race:\n" +
                                      "1. Human\n" +
                                      "2. Elf\n" +
                                      "3. Dwarf\n");
                    if (!int.TryParse(Console.ReadLine(), out raceInput) && raceInput < 0 && raceInput > 3)
                    {
                        Console.WriteLine("Wrong input. Enter numbers from 1 to 3");
                        continue;
                    }
                    break;
                }

                while (true)
                {
                    Console.WriteLine("Choose class:\n" +
                                      "1. Mage\n" +
                                      "2. Rogue\n" +
                                      "3. Warrior\n");
                    if (int.TryParse(Console.ReadLine(), out raceClassInput) && raceClassInput < 0 &&
                        raceClassInput > 3)
                    {
                        Console.WriteLine("Wrong input. Enter numbers from 1 to 3");
                        continue;
                    }

                    break;
                }

                Race race;
                switch (raceInput)
                {
                    case 1:
                        race = Race.Human;
                        break;
                    case 2:
                        race = Race.Elf;
                        break;
                    case 3:
                        race = Race.Dwarf;
                        break;
                    default:
                        race = Race.Human;
                        break;
                }

                Class classRace;
                switch (raceClassInput)
                {
                    case 1:
                        classRace = Class.Mage;
                        break;
                    case 2:
                        classRace = Class.Rogue;
                        break;
                    case 3:
                        classRace = Class.Warrior;
                        break;
                    default:
                        classRace = Class.Warrior;
                        break;
                }

                //Player newPlayer = new Player(email, password);
                currentPlayer.RaceEnum = race;
                currentPlayer.ClassEnum = classRace;
                currentPlayer.BaseStats();
                currentPlayer.ClassStats();
                Console.WriteLine(
                    $"{currentPlayer.UserName} ({currentPlayer.RaceEnum}) the {currentPlayer.ClassEnum}\n" +
                    $"Health: {currentPlayer.Health}\n" +
                    $"Agility: {currentPlayer.Agility}\n" +
                    $"Strength: {currentPlayer.Strength}\n");


                while (currentPlayer.Health > 0 && fights < 5)
                {
                    
                    //Dictionary<string, int> randomEvent = RandomEvent();
                    //randomEvent.FirstOrDefault(x => x.Key)

                    //event is a keyword......
                    eventPlayer = RandomEvent();
                    Console.WriteLine($"{eventPlayer.EventMessage}.\n" +
                                      $"---------------------");
                    Console.WriteLine("What will you do?\n" +
                                      "1. Fight!\n" +
                                      "2. Run, like a girl.\n" +
                                      $"Your current health: {currentPlayer.Health}");
                    if (!int.TryParse(Console.ReadLine(), out int option) && option != 1 && option != 2)
                    {
                        Console.WriteLine("Wrong input. Enter 1 or 2");
                        continue;
                    }
                    /*
                     Description of the event shows
                       The hero has an option to:
                           1 ) Fight - Get a random number from 1 to 10 and if that number is lesser than your Strength then you win the fight with a message showing: You won fight!
                           2 ) Run Away - Get a random number from 1 to 10 and if that number is lesser than your Agility then you run away
                       The user should not be able to enter anything other than 1 or 2
                       Events take health off the character if it fails
                       Different events take different amount of health
                       When the health is subtracted from the character health there must be a check made to see if the character health is below or equal to 0
                       If the character health is equal of below zero, show a YOU LOST message and ask the person if they want to start a new game
                           1 ) Yes - Restarts the game
                           2 ) No - Exits the application
                       If the character has more health, show how much health is left and go to the next event
                       After the last event if the character has more than 0 health, show a YOU WON message and ask the person if they want to start a new game,
                        the same as when you lose options of Yes and No
                     */
                    fights++;
                    
                    if (randomNumber.Next(10) > currentPlayer.Strength)
                    {
                        if (fights == 5)
                        {
                            break;
                        }
                        currentPlayer.Health -= eventPlayer.HealthChange;

                        ConsoleRed();
                        Console.WriteLine("Bad luck, you lost the fight.");
                        Console.WriteLine($"Your current health is {currentPlayer.Health}");

                        if (currentPlayer.Health <= 0)
                        {
                            Console.WriteLine("YOU LOST. Train harder and try again!");
                            break;
                        }

                        ConsoleNormal();
                        
                        continue;
                    }

                    if (fights == 5)
                    {
                        break;
                    }

                    ConsoleGreen();
                    Console.WriteLine("Yey, you've won that fight!!! On to the next one!");
                    ConsoleNormal();
                }

                if (fights == 5)
                {
                    ConsoleGreen();
                    Console.WriteLine("CONGRATULATIONS!!! You've won the game!!!");
                    Console.WriteLine($"Remaining health: {currentPlayer.Health}");
                    ConsoleNormal();

                    while (true)
                    {
                        Console.WriteLine("Would you like to try again?");
                        finalInput = Console.ReadLine().ToLower();

                        if (finalInput == "y")
                        {
                            break;
                        }
                        else if (finalInput == "n")
                        {
                            Console.WriteLine("Bye!");
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Wrong input. Enter 'y' or 'n'");
                        }
                    }

                }

                if (finalInput.ToLower() == "y")
                {
                    fights = 0;
                    continue;
                }

                break;
            }
        }

        //public static Dictionary<string, int> RandomEvent()
        //{
        //    Dictionary<string, int> changes = new Dictionary<string, int>();
        //    string[] events = {
        //        "Bandits attack you out of nowhere. They seem very dangerous... (-20 health)",
        //        "You bump into one of the guards of the nearby village. They attack you without warning... (-30 health)",
        //        "A Land Shark appears. It starts chasing you down to eat you... (-50 health)",
        //        "You accidentally step on a rat. His friends are not happy. They attack... (-10 health)",
        //        "You find a huge rock. It comes alive somehow and tries to smash you... (-30 health)"
        //    };
        //    int[] eventIndex = { 0, 1, 2, 3, 4 };
        //    Random random = new Random();
        //    int rgn = random.Next(events.Length);
        //    changes.Add(events[rgn], rgn);

        //    return changes;
        //}
        public static EventResult RandomEvent()
        {
            string[] events = {
                "Bandits attack you out of nowhere. They seem very dangerous... (-20 health)",
                "You bump into one of the guards of the nearby village. They attack you without warning... (-30 health)",
                "A Land Shark appears. It starts chasing you down to eat you... (-50 health)",
                "You accidentally step on a rat. His friends are not happy. They attack... (-10 health)",
                "You find a huge rock. It comes alive somehow and tries to smash you... (-30 health)"
            };
            double health;
            Random random = new Random();

            int rgn = random.Next(events.Length);
            switch (rgn)
            {
                case 0:
                    health = 20;
                    break;
                case 1:
                    health = 30;
                    break;
                case 2:
                    health = 50;
                    break;
                case 3:
                    health = 10;
                    break;
                case 4:
                    health = 30;
                    break;
                default:
                    health = 0;
                    break;
            }

            return new EventResult { EventMessage = events[rgn], HealthChange = health };
        }

        public static void ConsoleRed()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
        }

        public static void ConsoleGreen()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public static void ConsoleNormal()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

