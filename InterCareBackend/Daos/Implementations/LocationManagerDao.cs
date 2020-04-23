using System.Collections.Generic;
using System.Linq;
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


        public List<LocationManager> getManagersFromLocations(string name)
        {
            db.setCollection("locations");

            filter = Builders<BsonDocument>.Filter.Eq("Name", name);
            List<LocationManager> managers = new List<LocationManager>();
            if (db.getCollection().Find(filter).FirstOrDefault() != null)
            {

                // We retrieve the Organization first and the location id's connected to it. We save each id to a list called locationsList.
                var location = BsonSerializer.Deserialize<BsonDocument>(db.getCollection().Find(filter).FirstOrDefault().ToJson());
                List<string> mList = BsonSerializer.Deserialize<List<string>>(location["Managers"].ToJson());


                db.setCollection("users");
                for (int i = 0; i < mList.Count; i++)
                {
                    filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(mList[i]));
                    var managerObj = BsonSerializer.Deserialize<BsonDocument>(db.getCollection().Find(filter).FirstOrDefault().ToJson());
                    managers.Add(new LocationManager(managerObj["_id"].ToString(), managerObj["Email"].ToString(), managerObj["FullName"].ToString(), managerObj["Password"].ToString(), managerObj["AccessLevel"].ToString(), managerObj["Type"].ToString()));
                }
                return managers;
            }
            else
            {
                return null;
            }


        }

        public LocationManager getLocationManagerByEmail(string email)
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


        public void deleteManager(string email)
        {
            db.setCollection("users");
            filter = Builders<BsonDocument>.Filter.Eq("Email", email);
            db.getCollection().DeleteOne(filter);

        }


    }
}
