namespace lista
{
    internal interface IBookService
    {
        void Add(Book book);
        Book GetById(int id);
        List<Book> Get(string title);
        List<Book> GetAll();
        void Update();
        void Delete(int id);
    }
}
