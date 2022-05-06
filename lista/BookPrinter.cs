namespace lista
{
    internal class BookPrinter : IBookPrinter
    {
        public void Print(Book book)
        {
            if (book == null)
            {
                Console.WriteLine("There is no such a book");
            }
            else { Console.WriteLine($"{book.Id} : {book.Title} : {book.Autor} : {book.RealeaseYear}"); }
        }

        public void Print(List<Book> books)
        {
            foreach(Book book in books)
            {
                Print(book);
            }
        }

        public void Print(string? bookTitle)
        {
            Print(bookTitle);
        }
    }
}
