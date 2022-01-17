using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Galerija.Models;

namespace Galerija.Models
{   
    [BsonIgnoreExtraElements]
    public class Drzava
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string naziv { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string[] mjesta{get; set;}

    }
}