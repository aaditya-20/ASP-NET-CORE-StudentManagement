﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Student.Models
{
    public class Register
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string? Name { get; set; }

        public string? Email { get; set; }
        public string? Password { get; set; }

        public List<StudentDetails>? Friends { get; set; }

    }
}

