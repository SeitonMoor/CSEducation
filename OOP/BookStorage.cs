using System;
using System.Collections.Generic;

namespace OOP
{
    internal class BookStorage
    {
        /*static void Main(string[] args)
        {
            Storage storage = new Storage();

            storage.Add(new Book("Война и мир", "Толстой", 1865));
            storage.Print();
        }*/

        class Book
        {
            string name;
            string author;
            int releaseYear;

            public Book(string name, string author, int releaseYear)
            {
                this.name = name;
                this.author = author;
                this.releaseYear = releaseYear;
            }

            public string GetName()
            {
                return name;
            }

            public string GetAuthor()
            {
                return author;
            }

            public int GetReleaseYear()
            {
                return releaseYear;
            }
        }

        class Storage
        {
            List<Book> books = new List<Book>();

            public void Add(Book book)
            {
                books.Add(book);
            }

            public void Delete(Book book)
            {
                books.Remove(book);
            }

            public void Print(Book book)
            {

            }

            public void Print()
            {
                foreach (Book book in books)
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
