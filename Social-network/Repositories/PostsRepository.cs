using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using Social_network.Objects;
using MongoDB.Bson;

// this class is deprecated. It is better to use IMongoCollection in Command class to use power of MongoDB quering

namespace Social_network.Repositories
{
    public class PostsRepository
    {
        private IMongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<Post> _postsCollection;

        public PostsRepository(string connectionString)
        {
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase("social-network");
            _postsCollection = _database.GetCollection<Post>("posts");
        }
        public void InsertPost(Post post)
        {
            _postsCollection.InsertOne(post);
        }
        public List<Post> GetAllPosts()
        {
            return _postsCollection.Find(new BsonDocument()).ToList();
        }

        public List<Post> GetPostsByField(string fieldName, string fieldValue)
        {
            var filter = Builders<Post>.Filter.Eq(fieldName, fieldValue);
            var result = _postsCollection.Find(filter).ToList();

            return result;
        }

        public List<Post> GetPosts(int startingFrom, int count)
        {
            var result = _postsCollection.Find(new BsonDocument())
                                               .Skip(startingFrom)
                                               .Limit(count)
                                               .ToList();

            return result;
        }
        public bool UpdatePost(ObjectId id, string udateFieldName, string updateFieldValue)
        {
            var filter = Builders<Post>.Filter.Eq("_id", id);
            var update = Builders<Post>.Update.Set(udateFieldName, updateFieldValue);

            var result = _postsCollection.UpdateOne(filter, update);

            return result.ModifiedCount != 0;
        }
    }
}
