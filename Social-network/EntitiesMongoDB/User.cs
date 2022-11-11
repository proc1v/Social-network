using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Social_network.DAL.EntetiesMongoDB

{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [BsonElement("first_name")]
        public string FirstName { get; set; }
        [BsonElement("last_name")]
        public string LastName { get; set; }
        [BsonElement("username")]
        public string UserName { get; set; }
        [BsonElement("password")]
        public string Password { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("birth_date")]
        public DateTime BirthDate { get; set; }
        [BsonElement("interests")]
        public List<string> Interests { get; set; }
        [BsonElement("follows")]
        public List<string> Follows { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {UserName}";
        }
    }
}
