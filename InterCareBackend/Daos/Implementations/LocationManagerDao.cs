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


        public Client getManagerByEmail(String email)
        {
            db.setCollection("users");
            filter = Builders<BsonDocument>.Filter.Eq("Email", email);
            if (db.getCollection().Find(filter).FirstOrDefault() != null)
            {
                // Use BsonSerializer to deserialize the BsonDocument. Then we can retrieve all the values.
                var client = BsonSerializer.Deserialize<BsonDocument>(db.getCollection().Find(filter).FirstOrDefault().ToJson());
                return new Client(client["_id"].ToString(), client["Email"].ToString(), client["Password"].ToString(), client["Fullname"].ToString(), client["Accesslevel"].ToString(), client["Gender"].ToString(), client["Age"].ToString(), client["Type"].ToString());
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

        public void createManager(string email, string fullName, string password, string accessLevel, string gender, string age)
        {
            db.setCollection("users");
            var userDocument = new BsonDocument
            {
                { "Email", email },
                { "FullName", fullName },
                { "Password", password},
                { "AccessLevel", accessLevel },
                { "Gender", gender },
                { "Age", age }
            };
            db.getCollection().InsertOne(userDocument);
        }




    }
    }
