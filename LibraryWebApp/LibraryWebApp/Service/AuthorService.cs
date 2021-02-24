using LibraryWebApp.Database;
using LibraryWebApp.DTO;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Service
{
    public class AuthorService
    {
        private readonly IMongoCollection<Author> _author;
        public AuthorService(ILibraryDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _author = database.GetCollection<Author>(settings.AuthorCollectionName);
         
        }
        public List<AuthorDTO> GetAllAsync()
        {
            var author = _author.Aggregate()
                .Lookup("Book", "_id", "Author", "Books")
                .As<AuthorDTO>()
                .ToList();
            return author.FindAll(s => true).ToList();

        }
        public async Task<Author> GetByIdAsync(string id)
        {
            return await _author.Find<Author>(s => s.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Author> CreateAsync(Author author)
        {
            await _author.InsertOneAsync(author);
            return author;
        }
        public async Task UpdateAsync(string id, Author author)
        {
            await _author.ReplaceOneAsync(s => s.Id == id, author);
        }
        public async Task DeleteAsync(string id)
        {
            await _author.DeleteOneAsync(s => s.Id == id);
        }

    }
}

