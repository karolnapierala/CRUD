using MySql.Data.MySqlClient;

namespace lista
{

    internal class DbBookService : IDbBookService
    {
        IBookReader bookReader = new BookReader();
        List<Book> Books = new List<Book>
        {};
        const string con = "SERVER='localhost'; DATABASE='library'; UID='root'; PASSWORD='my-secret-pw'";
        MySqlConnection connect = new MySqlConnection(con);
        public void ReadBooksDb()
        {
            Books.Clear();
            connect.Open();
            string query = "select * from library.books";
            MySqlCommand command = new MySqlCommand(query, connect);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Book book = new Book();
                book.Id = (int)reader["id"];
                book.Title = (string)reader["title"];
                book.Autor = (string)reader["autor"];
                book.RealeaseYear = (int)reader["releaseYear"];
                Books.Add(book);
            }
            reader.Close();
            connect.Close();
        }

        public List<Book> Get(string title)
        {
            List<Book> filteredBooks = Books.Where(x => x.Title.Contains(title) || x.Autor.Contains(title)).ToList();
            return filteredBooks; ;
        }
        public Book? GetById(int id)
        {
                return Books.Where(x => x.Id == id).FirstOrDefault();
        }
        public void Add()
        {
            connect.Open();
            string title = bookReader.ReadTitle();
            string autor = bookReader.ReadAutor();
            int releaseYear = bookReader.ReadReleaseYear();
            string query2 = $"INSERT INTO `books` (`title`, `autor`, `releaseYear`) VALUES ('{title}', '{autor}', '{releaseYear}')";
            MySqlCommand command2 = new MySqlCommand(query2, connect);
            command2.ExecuteNonQuery();
            connect.Close();
        }

        public void Delete(int id)
        {
            var book = Books.Where(x => x.Id == id).FirstOrDefault();
            if (book == null)
            {
                return;
            }
            else
            {
                Books.Remove(book);
            }

        }
        public void DeleteInDb(int id)
        {
            connect.Open();
            string query3 = $"DELETE FROM `books` WHERE `id` = {id}";
            MySqlCommand command3 = new MySqlCommand(query3, connect);
            command3.ExecuteNonQuery();
            connect.Close();
        }

        public List<Book> GetAll()
        {
            return Books;
        }

        public void Update(int id)
        {
            Delete(id);
            DeleteInDb(id);
            Add();
        }

    }  
}
