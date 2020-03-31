using EO.Internal;
using InterCareBackend.Daos.Interfaces;
using InterCareBackend.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Sitecore.FakeDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Daos.Implementations
{
    public class OrganizationDao : IOrganizationDao
    {
        // Instantiates the database connection. <<Database, Collection>>
        public Database db;
        // Instantiate filter to enable filtering of results from database.
        FilterDefinition<BsonDocument> filter;

        IMongoCollection<BsonDocument> collection;


        public OrganizationDao()
        {
            db = new Database("InterCare", "organizations");
            collection = db.getCollection();
        }


        public void createOrganization(string name, List<String> locations, string adminId)
        {
            db.setCollection("organizations");
            var doc = new BsonDocument
            {
                {"Name", name },
                {"Locations", new BsonArray(locations)},
                {"AdminId", adminId }
            };

            db.getCollection().InsertOne(doc);
        }

        public Organization getOrganization(String name)
        {
            // Query searches for any record with the name parameter being the entered name.
            db.setCollection("organizations");

            filter = Builders<BsonDocument>.Filter.Eq("Name", name);

            if (db.getCollection().Find(filter).FirstOrDefault() != null)
            {
                // Use BsonSerializer to deserialize the BsonDocument. Then we can retrieve all the values.
                var organization = BsonSerializer.Deserialize<BsonDocument>(db.getCollection().Find(filter).FirstOrDefault().ToJson());

                List<string> locations = BsonSerializer.Deserialize<List<string>>(organization["Locations"].ToJson());


                return new Organization(organization["_id"].ToString(), organization["Name"].ToString(), locations, organization["AdminId"].ToString());


            }
            else
            {
                return null;
            }
        }

    }
}
