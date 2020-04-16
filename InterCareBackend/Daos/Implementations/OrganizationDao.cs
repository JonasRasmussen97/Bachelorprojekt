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

        LocationDao locationDao = new LocationDao();
        LocationManagerDao managerDao = new LocationManagerDao();


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

        // Deletes the whole organization and anything connected to it. This includes location(s), location manager(s) and the organization admin(s). 
        public async void deleteEntireOrganization (String name)
        {
            // Removes organization and it's connection admin in users collection

            var organization = getOrganization(name);

            db.setCollection("users");
            var userFilter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(organization.AdminId));
            db.getCollection().DeleteOne(userFilter);
           

            db.setCollection("locations");
            var locationList = locationDao.getLocationsFromOrganization(name);
            List<LocationManager> managerList;
            for (int i = 0; i < locationList.Count; i++)
            {
                managerList = managerDao.getManagersFromLocations(locationList[i].Name);


                db.setCollection("users");
                // For-loop that deletes all the managers for each location.
                for (int a = 0; a < managerList.Count; a++)
                {
                filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(managerList[i].id));
                db.getCollection().DeleteOne(filter);
                }

                db.setCollection("locations");
                // Deletes the location after the managers have been deleted.
                filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(locationList[i].Id));
                db.getCollection().DeleteOne(filter);
            }
                    




           deleteOrganization(name);

        }

    }
}
