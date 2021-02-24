using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp
{
    public class Book

    {
      
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Poster { get; set; }

        public string Title { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Author { get; set; }

        public string Price { get; set; }
        public string Rating { get; set; }


    }
}
