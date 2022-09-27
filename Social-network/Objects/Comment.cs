using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Social_network.Objects
{
    public class Comment
    {
        [BsonElement("username")]
        public string UserName { get; set; }
        [BsonElement("text")]
        public string CommentText { get; set; }
        [BsonElement("date")]
        public DateTime CreationDate { get; set; }
        public override string ToString()
        {
            return $"\nusername: {UserName}   date: {CreationDate.ToShortDateString()}\n\n{CommentText}";
        }
    }
}
