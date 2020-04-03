using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterCareBackend.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace InterCareBackend.Daos.Implementations
{

    public class LocationManagerDao
    {
        // Instantiates the database connection. <<Database, Collection>>
        public Database db;
        // Instantiate filter to enable filtering of results from database.
        FilterDefinition<BsonDocument> filter;

        public LocationManagerDao()
        {
            db = new Database("InterCare", "users");

        }

        public void createManager(string email, string fullName, string password, string accessLevel, string type)
        {
            db.setCollection("users");
            var userDocument = new BsonDocument
            {
                { "Email", email },
                { "Password", password},
                { "FullName", fullName },
                { "AccessLevel", accessLevel },
                { "Type", type },
            };
            db.getCollection().InsertOne(userDocument);
        }


        public LocationManager getLocationManagerByEmail(String email)
        {
            db.setCollection("users");
            filter = Builders<BsonDocument>.Filter.Eq("Email", email);
            if (db.getCollection().Find(filter).FirstOrDefault() != null)
            {
                // Use BsonSerializer to deserialize the BsonDocument. Then we can retrieve all the values.
                var manager = BsonSerializer.Deserialize<BsonDocument>(db.getCollection().Find(filter).FirstOrDefault().ToJson());
                return new LocationManager(manager["_id"].ToString(), manager["Email"].ToString(), manager["Password"].ToString(), manager["FullName"].ToString(), manager["AccessLevel"].ToString(), manager["Type"].ToString());
            }
            else
            {
                return null;
            }
        }


        public void deleteManager(String email)
        {
            db.setCollection("users");
            filter = Builders<BsonDocument>.Filter.Eq("Email", email);
            db.getCollection().DeleteOne(filter);

        }


    }
}
