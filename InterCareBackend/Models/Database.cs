using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Models
{
    public class Database
    {
        String DatabaseName;
        String CollectionName; 
        MongoClient dbClient;
        IMongoDatabase database;
        IMongoCollection<BsonDocument> collection;
        FilterDefinition<BsonDocument> filter;
   

    public Database(String DatabaseName, String CollectionName)
        {
            this.DatabaseName = DatabaseName;
            this.CollectionName = CollectionName;

            dbClient = new MongoClient("mongodb+srv://InterCare:Jonas@intercarebachelor-lctyd.azure.mongodb.net/test?retryWrites=true&w=majority");
            database = dbClient.GetDatabase(DatabaseName);
            collection = database.GetCollection<BsonDocument>(CollectionName);
        }

        public User getUserByName(String name)
        {
            // Query searches for any record with
            filter = Builders<BsonDocument>.Filter.Eq("Name", name);
            collection.Find(filter).FirstOrDefault().ToString();
            ProjectionDefinition<BsonDocument>  projectionName = Builders<BsonDocument>.Projection.Include("Name").Exclude("_id");
            ProjectionDefinition<BsonDocument> projectionPassword = Builders<BsonDocument>.Projection.Include("Password").Exclude("_id");
            ProjectionDefinition<BsonDocument> projectionEmail = Builders<BsonDocument>.Projection.Include("Email").Exclude("_id");
            ProjectionDefinition <BsonDocument> projectionAccessLevel = Builders<BsonDocument>.Projection.Include("AccessLevel").Exclude("_id");
            ProjectionDefinition<BsonDocument> projectionFullName = Builders<BsonDocument>.Projection.Include("FullName").Exclude("_id");



            String Name = collection.Find(filter).Project(projectionName).FirstOrDefault().ToString();
            String Password = collection.Find(filter).Project(projectionPassword).FirstOrDefault().ToString();
            String Email = collection.Find(filter).Project(projectionEmail).FirstOrDefault().ToString();
            String AccessLevel = collection.Find(filter).Project(projectionAccessLevel).FirstOrDefault().ToString();
            String FullName = collection.Find(filter).Project(projectionFullName).FirstOrDefault().ToString();
            return new User(Name, Password, FullName, AccessLevel);
        }


   

}


}
