namespace lista
{
    internal class ProgramInterface : IProgramInterface
    {
        public void PrintMenu()
        {
            Console.WriteLine("Choose option:");
            Console.WriteLine("1 - to print all books");
            Console.WriteLine("2 - to search by title");
            Console.WriteLine("3 - to search by id");
            Console.WriteLine("4 - to add book");
            Console.WriteLine("5 - to delete book");
            Console.WriteLine("6 - to update list");
            Console.WriteLine("7 - exit");
        }
        IBookPrinter bookPrinter = new BookPrinter();
        IBookReader bookReader = new BookReader();
        IDbBookService dbBookService = new DbBookService();
        public void Menu()
        {
            dbBookService.ReadBooksDb();
            try
            {
                int x = int.Parse(Console.ReadLine());
                switch (x)
                {
                    case 1:
                        {
                            List<Book> books = dbBookService.GetAll();
                            bookPrinter.Print(books);
                            break;
                        }
                    case 2:
                        {
                            List<Book> books = dbBookService.Get(bookReader.ReadTitle());
                            bookPrinter.Print(books);
                            break;
                        }
                    case 3:
                        {
                            Book book = dbBookService.GetById(bookReader.ReadId());
                            bookPrinter.Print(book);
                            break;
                        }
                    case 4:
                        {
                            dbBookService.Add();
                            break;
                        }
                    case 5:
                        {
                            int id = bookReader.ReadId();
                            dbBookService.Delete(id);
                            dbBookService.DeleteInDb(id);
                            break;
                        }
                    case 6:
                        {
                            int id = bookReader.ReadId();
                            dbBookService.Update(id);
                            break;
                        }
                    case 7:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            }
            catch 
            {
                Console.Clear();
                PrintMenu();
                Menu(); 
            }
        }

        public void ContinueWork()
        {
            Console.WriteLine("Continue?");
            Console.WriteLine("y/n?");
            string x = Console.ReadLine();
            if (x == "y")
            {
                Console.Clear();
                PrintMenu();
                Menu();
                ContinueWork();
            }
            else if (x == "n")
            {
                Console.WriteLine("Press any key to exit");
            }
            else 
            {
                ContinueWork();
            }

        }
    }
}
