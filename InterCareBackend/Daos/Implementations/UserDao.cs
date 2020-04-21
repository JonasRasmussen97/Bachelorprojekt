using InterCareBackend.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Daos.Implementations
{
    public class UserDao
    {

        // Instantiates the database connection. <<Database, Collection>>
        public Database db;
        // Instantiate filter to enable filtering of results from database.
        FilterDefinition<BsonDocument> filter;

        public UserDao()
        {
            db = new Database("InterCare", "users");

        }

        // Used by InterCareAdmin
        public List<User> getAllUsers()
        {
            db.setCollection("users");
            List<User> users = new List<User>();
            if (db.getCollection() != null)
            {
                var documents = db.getCollection().Find(new BsonDocument()).ToList();

                foreach (BsonDocument doc in documents)
                {
                    var userObject = BsonSerializer.Deserialize<BsonDocument>(doc.ToJson());
                    users.Add(new User(userObject["Email"].ToString(), userObject["FullName"].ToString(), userObject["Type"].ToString()));
                }
                return users;
            }
            else
            {
                return null;
            }
        }


    }
}
