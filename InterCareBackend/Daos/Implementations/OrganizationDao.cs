using InterCareBackend.Daos.Interfaces;
using InterCareBackend.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InterCareBackend.Daos.Implementations
{
    public class OrganizationDao : IOrganizationDao
    {
        // Instantiates the database connection. <<Database, Collection>>
        public Database db;
        // Instantiate filter to enable filtering of results from database.
        FilterDefinition<BsonDocument> filter;


        public OrganizationDao()
        {
            db = new Database("InterCare", "organizations");
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


        public void deleteOrganization(String name)
        {
            // Removes organization
            db.setCollection("organizations");
            filter = Builders<BsonDocument>.Filter.Eq("Name", name);
            db.getCollection().DeleteOne(filter);

            // Removes related organization admin
            

        }

        public void deleteOrganizationAndAdmin (String name)
        {
            // Removes organization and it's connection admin in users collection

            var organization = getOrganization(name);
     
            var userFilter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(organization.AdminId));
            db.setCollection("users");
            db.getCollection().DeleteOne(userFilter);

            var orgFilter = Builders<BsonDocument>.Filter.Eq("Name", name);
            db.setCollection("organizations");
            db.getCollection().DeleteOne(orgFilter);


        }

    }
}
