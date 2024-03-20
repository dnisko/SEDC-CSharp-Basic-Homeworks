namespace Task02.Models
{
    //Create a class Song with the following properties: Title, Length and, Genre.
    internal class Song
    {
        public string Title { get; set; }
        public int Length { get; set; }
        public GenreEnum Genre { get; set; }

        public Song(string title, int length, GenreEnum genre)
        {
            Title = title;
            Length = length;
            Genre = genre;
        }
    }
}
