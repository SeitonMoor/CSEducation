using System;
using System.Collections.Generic;

namespace OOP
{
    internal class BookStorage
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("Хранилище книг");
                Console.Write("\nВы можете:" +
                    "\n\nadd - добавить книгу." +
                    "\ndelete - удалить книгу." +
                    "\nviewAll - просмотреть все книги в хранилище." +
                    "\nview - просмотреть книги по указанному параметру." +
                    "\nend - закончить работу с хранилищем." +
                    "\n\nВаш выбор: ");

                switch (Console.ReadLine())
                {
                    case "add":
                        storage.Add(new Book("Война и мир", "Толстой", 1865));
                        break;

                    case "delete":
                        storage.Delete(new Book("Война и мир", "Толстой", 1865));
                        break;

                    case "viewAll":
                        storage.Print();
                        break;

                    case "view":
                        storage.Find();
                        break;

                    case "end":
                        isWorking = false;
                        break;

                    default:
                        break;
                }

                Console.Clear();
            }
        }

        class Book
        {
            private string _name;
            private string _author;
            private int _releaseYear;

            public Book(string name, string author, int releaseYear)
            {
                this._name = name;
                this._author = author;
                this._releaseYear = releaseYear;
            }

            public string GetName()
            {
                return _name;
            }

            public string GetAuthor()
            {
                return _author;
            }

            public int GetReleaseYear()
            {
                return _releaseYear;
            }
        }

        class Storage
        {
            private List<Book> _books = new List<Book>();

            public void Add(Book book)
            {
                _books.Add(book);
            }

            public void Delete(Book book)
            {
                _books.Remove(book);
            }

            public void Print(Book book)
            {

            }

            public void Print()
            {
                foreach (Book book in _books)
                {
                    Console.WriteLine($"Книга - {book.GetName()} от автора {book.GetAuthor()}. Год выпуска: {book.GetReleaseYear()}.");
                }
            }

            public void Find()
            {

            }
        }
    }
}
