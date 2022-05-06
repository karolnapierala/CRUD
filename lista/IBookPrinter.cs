namespace lista
{
    internal interface IBookPrinter
    {
        void Print(List<Book> books);
        void Print(Book book);
        void Print(string? bookTitle);
    }
}
