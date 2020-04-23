using InterCareBackend.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Linq;

namespace InterCareBackend.Daos.Implementations
{
    public class InterCareAdminDao
    {

        // Instantiates the database connection. <<Database, Collection>>
        public Database db;

        public ClientDao clientDao;

        // Instantiate filter to enable filtering of results from database.
        FilterDefinition<BsonDocument> filter;

        public InterCareAdminDao()
        {
            db = new Database("InterCare", "users");
            clientDao = new ClientDao();

        }


        public void createInterCareAdmin(string email, string password, string fullName, string accessLevel, string type)
        {
            db.setCollection("users");
            var doc = new BsonDocument
            {
                { "Email", email },
                { "Password", password},
                { "FullName", fullName },
                { "AccessLevel", accessLevel },
                { "Type", type }
            };

            db.getCollection().InsertOne(doc);
        }


        public InterCareAdmin getInterCareAdminByEmail(string email)
        {
            db.setCollection("users");
            filter = Builders<BsonDocument>.Filter.Eq("Email", email);
            if (db.getCollection().Find(filter).FirstOrDefault() != null)
            {
                // Use BsonSerializer to deserialize the BsonDocument. Then we can retrieve all the values.
                var admin = BsonSerializer.Deserialize<BsonDocument>(db.getCollection().Find(filter).FirstOrDefault().ToJson());
                return new InterCareAdmin(admin["_id"].ToString(), admin["Email"].ToString(), admin["Password"].ToString(), admin["FullName"].ToString(), admin["AccessLevel"].ToString(), admin["Type"].ToString());
            }
            else
            {
                return null;
            }
        }


        public void deleteInterCareAdmin(string email)
        {
            db.setCollection("users");
            filter = Builders<BsonDocument>.Filter.Eq("Email", email);
            db.getCollection().DeleteOne(filter);

        }


    }
}
