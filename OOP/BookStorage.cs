using System;
using System.Collections.Generic;

namespace OOP
{
    internal class BookStorage
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();

            storage.Work();
        }
    }

    class Book
    {
        public Book(string name, string author, int releaseYear)
        {
            Name = name;
            Author = author;
            ReleaseYear = releaseYear;
        }

        public string Name { get; private set; }
        public string Author { get; private set; }
        public int ReleaseYear { get; private set; }
    }

    class Storage
    {
        private const string AddCommand = "add";
        private const string DeleteCommand = "delete";
        private const string ViewAllCommand = "viewAll";
        private const string ViewCommand = "view";
        private const string ExitCommand = "exit";

        private const string SearchByName= "name";
        private const string SearchByAuthor = "author";
        private const string SearchByReleaseYear = "releaseYear";

        private List<Book> _books = new List<Book>();

        public void Work()
        {
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("Хранилище книг");
                Console.Write("\nВы можете:" +
                    $"\n\n{AddCommand} - добавить книгу." +
                    $"\n{DeleteCommand} - удалить книгу." +
                    $"\n{ViewAllCommand} - просмотреть все книги в хранилище." +
                    $"\n{ViewCommand} - просмотреть книги по указанному параметру." +
                    $"\n{ExitCommand} - закончить работу с хранилищем." +
                    "\n\nВаш выбор: ");

                switch (Console.ReadLine())
                {
                    case AddCommand:
                        AddBook();
                        break;

                    case DeleteCommand:
                        DeleteBook();
                        break;

                    case ViewAllCommand:
                        PrintAllBooks();
                        break;

                    case ViewCommand:
                        FindBook();
                        break;

                    case ExitCommand:
                        isWorking = false;
                        break;

                    default:
                        Console.WriteLine("Данная команда неизвестна");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        public void AddBook()
        {
            Book book = CreateBook();

            Console.WriteLine($"\nКнига {book.Name} добавлена.");

            _books.Add(book);
        }

        public void DeleteBook()
        {
            if (_books.Count == 0)
            {
                Console.WriteLine("Хранилище книг пусто.");
            }
            else
            {
                List<Book> books = GetBooksByName();

                foreach (Book book in books)
                {
                    Console.WriteLine($"\nКнига {book.Name} удалена.");
                    _books.Remove(book);
                }
            }
        }

        public void PrintAllBooks()
        {
            if (_books.Count == 0)
            {
                Console.WriteLine("Хранилище книг пусто.");
            }
            else
            {
                PrintBooks(_books);
            }
        }

        public void FindBook()
        {
            if (_books.Count == 0)
            {
                Console.WriteLine("Хранилище книг пусто.");
            }
            else
            {
                List<Book> foundBooks = new List<Book>();
                bool isFound = false;

                Console.Write("\nВы можете совершить поиск:" +
                    $"\n\n{SearchByName} - по названию." +
                    $"\n{SearchByAuthor} - по автору." +
                    $"\n{SearchByReleaseYear} - по году выпуска." +
                    "\n\nВаш выбор: ");

                string searchParametr = Console.ReadLine();

                while (isFound == false)
                {
                    string name = "";
                    string author = "";
                    int releaseYear = 0;

                    switch (searchParametr)
                    {
                        case SearchByName:
                            name = GetName();
                            break;

                        case SearchByAuthor:
                            author = GetAuthor();
                            break;

                        case SearchByReleaseYear:
                            releaseYear = GetReleaseYear();
                            break;

                        default:
                            Console.WriteLine("Данная команда неизвестна");
                            isFound = true;
                            break;
                    }

                    foreach (Book book in _books)
                    {
                        if (book.Name == name || book.Author == author || book.ReleaseYear == releaseYear)
                        {
                            foundBooks.Add(book);
                            isFound = true;
                        }
                    }

                    if (isFound == false)
                    {
                        Console.WriteLine("Такой книги нет в хранилище, попробуйте еще раз.");
                    }
                }

                PrintBooks(foundBooks);
            }
        }

        private void PrintBooks(List<Book> books)
        {
            foreach (Book book in books)
            {
                Console.WriteLine($"Книга - {book.Name} от автора {book.Author}. Год выпуска: {book.ReleaseYear}.");
            }
        }

        private Book CreateBook()
        {
            Console.Write("Напишите название книги: ");
            string name = Console.ReadLine();

            Console.Write("Укажите автора, написавшего книгу: ");
            string author = Console.ReadLine();

            bool isReceived = false;
            int releaseYear;

            do
            {
                Console.Write("Напишите год выпуска книги: ");

                if (Int32.TryParse(Console.ReadLine(), out releaseYear))
                {
                    isReceived = true;
                }
                else
                {
                    Console.WriteLine("Год выпуска книги введен не верно.\n");
                }
            }
            while (isReceived == false);

            Book book = new Book(name, author, releaseYear);

            return book;
        }

        private List<Book> GetBooksByName()
        {
            List<Book> foundBooks = new List<Book>();
            bool isFound = false;

            while (isFound == false)
            {
                string name = GetName();
                foreach (Book book in _books)
                {
                    if (book.Name == name)
                    {
                        foundBooks.Add(book);
                        isFound = true;
                    }
                }

                if (isFound == false)
                {
                    Console.WriteLine("Такой книги нет в хранилище, попробуйте еще раз.");
                }
            }

            return foundBooks;
        }

        private string GetName()
        {
            Console.Write("Напишите название книги: ");
            string name = Console.ReadLine();

            return name;
        }

        private string GetAuthor()
        {
            Console.Write("Напишите автора книги: ");
            string author = Console.ReadLine();

            return author;
        }

        private int GetReleaseYear()
        {
            Console.Write("Напишите год выпуска книги: ");
            Int32.TryParse(Console.ReadLine(), out int releaseYear);

            return releaseYear;
        }
    }
}
