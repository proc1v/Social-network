using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using Social_network.Objects;
using MongoDB.Bson;

namespace Social_network.Repositories
{
    public class UsersRepository
    {
        private IMongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<User> _usersCollection;

        public UsersRepository(string connectionString)
        {
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase("social-network");
            _usersCollection = _database.GetCollection<User>("users");
        }
        public void InsertUser(User user)
        {
            _usersCollection.InsertOne(user);
        }
        public List<User> GetAllUsers()
        {
            return _usersCollection.Find(new BsonDocument()).ToList();
        }

        public List<User> GetUsersByField(string fieldName, string fieldValue)
        {
            var filter = Builders<User>.Filter.Eq(fieldName, fieldValue);
            var result = _usersCollection.Find(filter).ToList();

            return result;
        }

        public List<User> GetUsers(int startingFrom, int count)
        {
            var result = _usersCollection.Find(new BsonDocument())
                                               .Skip(startingFrom)
                                               .Limit(count)
                                               .ToList();

            return result;
        }
        public bool UpdateUser(ObjectId id, string udateFieldName, string updateFieldValue)
        {
            var filter = Builders<User>.Filter.Eq("_id", id);
            var update = Builders<User>.Update.Set(udateFieldName, updateFieldValue);

            var result = _usersCollection.UpdateOne(filter, update);

            return result.ModifiedCount != 0;
        }
    }
}
