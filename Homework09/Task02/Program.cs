using Task02.Models;

namespace Task02
{
    internal class Program
    {
        #region Task2

        /*
         Task 2
           Create a class Song with the following properties: Title, Length and, Genre.
            Genre is enum with - Rock, Hip_Hop, Techno and Classical
            Create a class Person with the following properties: Id, FirstName, LastName, Age, FavoriteMusicType (Genre enum) and FavoriteSongs.
            FavoriteSongs is a list of Songs
            Create a method called GetFavSongs(): That will print out all the titles of their favorite songs or write a message that this person hates music
        if there are no favorite songs in their list.
         */

        #endregion
        static void Main(string[] args)
        {
            Song s1 = new Song("Another brick in the wall", 5, GenreEnum.Rock);
            Song s2 = new Song("Thunderstruck", 3, GenreEnum.Rock);
            Song s3 = new Song("Never gonna give you up", 5, GenreEnum.Techno);
            Song s4 = new Song("Straight outta compound", 5, GenreEnum.Hip_Hop);

            Person p1 = new Person(1, "Bob", "Bobsky", 105, GenreEnum.Rock, new List<Song>{s1, s2});
            Person p2 = new Person(2, "Jane", "Janesky", 23, GenreEnum.Rock, new List<Song>{s3, s4});
            Person p3 = new Person(3, "Emin", "Braced", 30, GenreEnum.Rock, new List<Song>{});
            Person p4 = new Person(4, "Dino", "Nik", 35, GenreEnum.Rock, new List<Song>{s1, s2});

            Console.WriteLine(GetFavSongs(p1));
            Console.WriteLine(GetFavSongs(p2));
            Console.WriteLine(GetFavSongs(p3));
            Console.WriteLine(GetFavSongs(p4));
        }

        public static string GetFavSongs(Person person)
        {
            if (person.FavouriteSongs.Count ==0)
            {
                return $"The {person.FirstName} hates music";
            }

            string result = "";
            foreach (var song in person.FavouriteSongs)
            {
                result += $"{song.Title}, ";
            }

            return $"{person.FirstName}'s favourite songs are: {result}";
        }
    }
}
