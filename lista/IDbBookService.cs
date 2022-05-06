namespace lista
{
    internal interface IDbBookService
    {
        void ReadBooksDb();
        void Add();
        Book GetById(int id);
        List<Book> Get(string title);
        List<Book> GetAll();
        public void Update(int id);
        void Delete(int id);
        void DeleteInDb(int id);
    }
}
