using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Galerija.Models
{   
    [BsonIgnoreExtraElements]
    public class Mjesta
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string naziv { get; set; }
        
        

    }
}