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

    public class OrganizationAdminDao
    {
        // Instantiates the database connection. <<Database, Collection>>
        public Database db;
        // Instantiate filter to enable filtering of results from database.
        FilterDefinition<BsonDocument> filter;


        public OrganizationAdminDao()
        {
            db = new Database("InterCare", "users");

        }


        public void createAdmin(string email, string fullName, string password, string accessLevel, string gender, string age, string type)
        {
            db.setCollection("users");
            var userDocument = new BsonDocument
            {
                { "Email", email },
                { "FullName", fullName },
                { "Password", password},
                { "AccessLevel", accessLevel },
                {"Type", type }
            };

            db.getCollection().InsertOne(userDocument);
        }


        public OrganizationAdmin getAdminByEmail(String email)
        {
            db.setCollection("users");
            filter = Builders<BsonDocument>.Filter.Eq("Email", email);
            if (db.getCollection().Find(filter).FirstOrDefault() != null)
            {
                // Use BsonSerializer to deserialize the BsonDocument. Then we can retrieve all the values.
                var admin = BsonSerializer.Deserialize<BsonDocument>(db.getCollection().Find(filter).FirstOrDefault().ToJson());
                return new OrganizationAdmin(admin["_id"].ToString(), admin["Email"].ToString(), admin["Password"].ToString(), admin["FullName"].ToString(), admin["AccessLevel"].ToString(), admin["Type"].ToString());
            }
            else
            {
                return null;
            }
        }


        public void deleteAdmin(String email)
        {
            db.setCollection("users");
            filter = Builders<BsonDocument>.Filter.Eq("Email", email);
            db.getCollection().DeleteOne(filter);

        }


    }
}
