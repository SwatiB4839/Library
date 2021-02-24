using LibraryWebApp.Database;
using LibraryWebApp.DTO;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Service
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _book;

        public BookService(ILibraryDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _book = database.GetCollection<Book>(settings.BookCollectionName);
            

        }

        public List<BookDTO> GetAllAsync()
        {
            var book = _book.Aggregate()
                     .Lookup("Author", "Author", "_id", "AuthorList")
                      .As<BookDTO>()
                     .ToList();
            return book.FindAll(s => true).ToList();
        }

        public async Task<Book> GetByIdAsync(string id)
        {
            return await _book.Find<Book>(s => s.Id == id).FirstOrDefaultAsync();
         
           
        }

        public async Task<Book> CreateAsync(Book book)
        {
            await _book.InsertOneAsync(book);
            return book;
        }

        public async Task UpdateAsync(string id, Book book)
        {
            await _book.ReplaceOneAsync(s => s.Id == id, book);
        }

        public async Task DeleteAsync(string id)
        {
            await _book.DeleteOneAsync(s => s.Id == id);
        }
    }
}

