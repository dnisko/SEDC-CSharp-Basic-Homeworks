namespace Task02.Models
{
    // Create a class Person with the following properties: Id, FirstName, LastName, Age, FavoriteMusicType (Genre enum) and FavoriteSongs.
    internal class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public GenreEnum FavouriteMusicType { get; set; }

        public List<Song> FavouriteSongs { get; set; }

        public Person(int id, string firstName, string lastName, int age, GenreEnum favouriteMusicType, List<Song> favouriteSongs)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            FavouriteMusicType = favouriteMusicType;
            FavouriteSongs = favouriteSongs;
        }
    }
}
