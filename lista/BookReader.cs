namespace lista
{
    internal class BookReader : IBookReader
    {
        public string ReadAutor()
        {
            string autor = Console.ReadLine();
            return autor;
        }

        public int ReadId()
        {
            try
            {
                int id = int.Parse(Console.ReadLine());
                return id;
            }
            catch
            {
                Console.WriteLine("Try again.");
                return ReadId();
            }

        }

        public int ReadReleaseYear()
        {
            int ReleaseYear = int.Parse(Console.ReadLine());
            return ReleaseYear;
        }

        public string ReadTitle()
        {
            string Title = Console.ReadLine();
            return Title;
        }
    }
}
