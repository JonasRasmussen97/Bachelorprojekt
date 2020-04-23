using System;
using System.Linq;
using InterCareBackend.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace InterCareBackend.Daos.Implementations
{

    public class ClientDao
    {
        // Instantiates the database connection. <<Database, Collection>>
        public Database db;
        // Instantiate filter to enable filtering of results from database.
        FilterDefinition<BsonDocument> filter;

        public ClientDao()
        {
            db = new Database("InterCare", "users");

        }

        public void createClient(string email, string password, string fullName, string accessLevel, string type, string gender, string age)
        {
            db.setCollection("users");
            var userDocument = new BsonDocument
            {
                { "Email", email },
                { "Password", password},
                { "FullName", fullName },
                { "AccessLevel", accessLevel },
                { "Type", type },
                { "Gender", gender },
                { "Age", age }
            };
            db.getCollection().InsertOne(userDocument);
        }


        public Client getClientByEmail(string email)
        {
            db.setCollection("users");
            filter = Builders<BsonDocument>.Filter.Eq("Email", email);
            if (db.getCollection().Find(filter).FirstOrDefault() != null)
            {
                // Use BsonSerializer to deserialize the BsonDocument. Then we can retrieve all the values.
                var client = BsonSerializer.Deserialize<BsonDocument>(db.getCollection().Find(filter).FirstOrDefault().ToJson());
                return new Client(client["_id"].ToString(), client["Email"].ToString(), client["FullName"].ToString(), client["Password"].ToString(), client["AccessLevel"].ToString(), client["Type"].ToString(), client["Gender"].ToString(), client["Age"].ToString());
            }
            else
            {
                return null;
            }
        }


        public void deleteClient(string email)
        {
            db.setCollection("users");
            filter = Builders<BsonDocument>.Filter.Eq("Email", email);
            db.getCollection().DeleteOne(filter);

        }


    }
}
