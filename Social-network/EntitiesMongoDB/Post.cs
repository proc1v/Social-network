using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Social_network.DAL.EntetiesMongoDB
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [BsonElement("username")]
        public string UserName { get; set; }
        [BsonElement("post")]
        public string PostText { get; set; }
        [BsonElement("date")]
        public DateTime CreationDate { get; set; }
        [BsonElement("comments")]
        public List<Comment> Comments { get; set; }
        [BsonElement("likes")]
        public List<string> Likes { get; set; }

        public override string ToString()
        {
            return $"\n\nusername: {UserName}   date: {CreationDate.ToShortDateString()}\n" 
                + $"likes: {Likes.Count}    comments: {Comments.Count}\n\n" + PostText + "\n\n";
        }
    }
}
