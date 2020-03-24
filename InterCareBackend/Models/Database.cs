using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
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

            // Filter out the ID since it breaks JSON conversion, due to the nature of mongoDB (objectID).
            ProjectionDefinition<BsonDocument> projectionRemoveId = Builders<BsonDocument>.Projection.Exclude("_id");
            // Make a JObject from the JSON returned by MongoDB.
            JObject jUser = JObject.Parse(collection.Find(filter).Project(projectionRemoveId).FirstOrDefault().ToJson());

                
            return new User((string) jUser["Name"], (string) jUser["Password"], (string) jUser["FullName"], (string) jUser["AccessLevel"]);
        }

        public User getUserByEmail(String email)
        {

            // Query searches for any record with the email parameter being the entered email.
            filter = Builders<BsonDocument>.Filter.Eq("Email", email);

            // Filter out the ID since it breaks JSON conversion, due to the nature of mongoDB (objectID).
            ProjectionDefinition<BsonDocument> projectionRemoveId = Builders<BsonDocument>.Projection.Exclude("_id");
            // Make a JObject from the JSON returned by MongoDB.
            JObject jUser = JObject.Parse(collection.Find(filter).Project(projectionRemoveId).FirstOrDefault().ToJson());

            return new User((string)jUser["Name"], (string)jUser["Password"], (string)jUser["FullName"], (string)jUser["AccessLevel"]);
        }

        public Boolean checkLogin(String username, String password)
        {
            // Query searches for any record with the email parameter being the entered email(username).
            filter = Builders<BsonDocument>.Filter.Eq("Email", username);

            // Filter out the ID since it breaks JSON conversion, due to the nature of mongoDB (objectID).
            ProjectionDefinition<BsonDocument> projectionRemoveId = Builders<BsonDocument>.Projection.Exclude("_id");

            if (collection.Find(filter).Project(projectionRemoveId).FirstOrDefault() != null)
            {
                // Make a JObject from the JSON returned by MongoDB.
                JObject jUser = JObject.Parse(collection.Find(filter).Project(projectionRemoveId).FirstOrDefault().ToJson());
            // Checks if the entered username and password fits the user from the database.
            if (username == (string)jUser["Email"] && password == (string)jUser["Password"])
            {
                return true;
            }
            else
            {
                //   System.Diagnostics.Debug.WriteLine(Email + " : " + username + " - " +  password + " : " + Password);
                return false;
            }
        }
            return false;
        }


   

}


}
