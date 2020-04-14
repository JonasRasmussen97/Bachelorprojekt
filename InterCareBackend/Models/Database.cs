using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace InterCareBackend.Models
{
    public class Database
    {
        String DatabaseName;
        String CollectionName;
        MongoClient dbClient;
        IMongoDatabase database;
        IMongoCollection<BsonDocument> collection;


        public Database(String DatabaseName, String CollectionName)
        {
            this.DatabaseName = DatabaseName;
            this.CollectionName = CollectionName;

            dbClient = new MongoClient("mongodb+srv://InterCare:Julian123@intercarebachelor-lctyd.azure.mongodb.net/test?retryWrites=true&w=majority");
            database = dbClient.GetDatabase(DatabaseName);
            collection = database.GetCollection<BsonDocument>(CollectionName);
        }

        public void setCollection(String collectionName)
        {
            this.CollectionName = collectionName;
            collection = database.GetCollection<BsonDocument>(collectionName);
        }

        public IMongoCollection<BsonDocument> getCollection()
        {
            return collection;
        }

    }

}
