using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.DTO
{
    public class BookDTO
    {
        public BookDTO()
        {
            AuthorList = new List<Author>();
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public string Poster { get; set; }

        public string Title { get; set; }

        public string Price { get; set; }

        public string Rating { get; set; }


        [BsonRepresentation(BsonType.ObjectId)]
        public string Author { get; set; }

        public List<Author> AuthorList { get; set; }
    }
}
