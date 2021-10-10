using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRestService.Managers
{
    public class BooksManager
    {
        private static int _nextId = 1;
        private static readonly List<Book> Data = new List<Book>()        
        {
            new Book {ISBN13 = "ISBN13" + _nextId++ , Title = "C# is nice", Author = "Morten Myfriend", PageNumber = 159 },
            new Book {ISBN13 = "ISBN13" + _nextId++ , Title = "JavaScript is nice", Author = "Martin Myfriend", PageNumber = 180 },
            new Book {ISBN13 = "ISBN13" + _nextId++ , Title = "ASP.Net is nice", Author = "Mohammed Myfriend", PageNumber = 175 },
            
        };
           
        public List<Book> GetAll()
        {            
            //return new List<Book>(Data);
            return Data;
            // copy constructor
            // Callers should no get a reference to the Data object, but rather get a copy
        }

        public Book GetById(string ISBN)
        {
            return Data.Find(book => book.ISBN13 == ISBN);
        }

        public Book Create(string title, string author, int pageNumber)
        {
            Book newBook = new Book();
            newBook.ISBN13 = "ISBN13" + _nextId++;
            Data.Add(newBook);
            return newBook;
        }

        public Book Delete(string ISBN)
        {
            Book book = Data.Find(book => book.ISBN13 == ISBN);
            if (book == null) 
                return null;
            Data.Remove(book);
            return book;
        }

        public Book Update(Book bookToUpdate)
        {
            Book book = Data.Find(book => book.ISBN13 == bookToUpdate.ISBN13);
            if (book == null) return null;
            book.Title = bookToUpdate.Title;
            book.Author = bookToUpdate.Author;
            book.PageNumber = bookToUpdate.PageNumber;
            return book;
        }
    }
}
