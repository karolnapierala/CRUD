namespace lista
{
    internal class Book
    {
        public Book(){}
        public Book(int id, string title, string autor, int realeaseYear)
        {
            Id = id;
            Title = title;
            Autor = autor;
            RealeaseYear = realeaseYear;
        }

        public int Id { get; set; }
        public string Title { get; set; }    
        public string Autor { get; set; }
        public int RealeaseYear { get; set; }
    }
}
