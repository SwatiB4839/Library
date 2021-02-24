using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.DTO
{
    public class AuthorDTO
    {
        public AuthorDTO()
        {
            Books = new List<Book>();
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Biography { get; set; }

        public string Photograph { get; set; }

        public string Email { get; set; }

        public List<Book> Books { get; set; }
    }
}
