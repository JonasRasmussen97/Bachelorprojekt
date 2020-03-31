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

    public class ClientDao
    {
        // Instantiates the database connection. <<Database, Collection>>
        public Database db;
        // Instantiate filter to enable filtering of results from database.
        FilterDefinition<BsonDocument> filter;

        IMongoCollection<BsonDocument> collection;


        public ClientDao()
        {
            db = new Database("InterCare", "users");
            collection = db.getCollection();
        }


        public Client getClientByEmail(String email)
        {
            db.setCollection("users");
            filter = Builders<BsonDocument>.Filter.Eq("Email", email);
            if (db.getCollection().Find(filter).FirstOrDefault() != null)
            {
                // Use BsonSerializer to deserialize the BsonDocument. Then we can retrieve all the values.
                var client = BsonSerializer.Deserialize<BsonDocument>(collection.Find(filter).FirstOrDefault().ToJson());
                return new Client(client["_id"].ToString(), client["Email"].ToString(), client["Password"].ToString(), client["Fullname"].ToString(), client["Accesslevel"].ToString(), client["Gender"].ToString(), client["Age"].ToString(), client["Type"].ToString());
            }
            else
            {
                return null;
            }
        }

    }
    }
