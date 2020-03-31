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
    public class LocationDao
    {
        // Instantiates the database connection. <<Database, Collection>>
        public Database db;
        // Instantiate filter to enable filtering of results from database.
        FilterDefinition<BsonDocument> filter;


        public LocationDao()
        {
            db = new Database("InterCare", "locations"); 
        }

        public Location getLocationById(string id)
        {
            db.setCollection("locations");
            filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(id));
            if (db.getCollection().Find(filter).FirstOrDefault() != null)
            {
                // Use BsonSerializer to deserialize the BsonDocument. Then we can retrieve all the values.
                var location = BsonSerializer.Deserialize<BsonDocument>(db.getCollection().Find(filter).FirstOrDefault().ToJson());
                List<string> managersList = BsonSerializer.Deserialize<List<string>>(location["Managers"].ToJson());

                return new Location(location["_id"].ToString(), location["Name"].ToString(), location["Address"].ToString(), location["PostalCode"].ToString(), location["Country"].ToString(), location["Images"].ToString(), managersList);
            }
            else
            {
                return null;
            }
        }

        public void createLocation(string name, string address, string postalCode, string country, string images, List<String> managers)
        {
            db.setCollection("locations");
            var document = new BsonDocument {
            {"Name", name },
            {"Address", address },
            {"PostalCode", postalCode },
            {"Country", country },
            {"Images", images },
            {"Managers", new BsonArray(managers)} 
         };

            db.getCollection().InsertOne(document);
 
        }

        public List<Location> getLocationsFromOrganization(string name)
        {
                db.setCollection("organizations");
                filter = Builders<BsonDocument>.Filter.Eq("Name", name);
                List<Location> locations = new List<Location>();
                if (db.getCollection().Find(filter).FirstOrDefault() != null)
                {
                    // We retrieve the Organization first and the location id's connected to it. We save each id to a list called locationsList.
                    var organization = BsonSerializer.Deserialize<BsonDocument>(db.getCollection().Find(filter).FirstOrDefault().ToJson());
                    List<string> locationsList = BsonSerializer.Deserialize<List<string>>(organization["Locations"].ToJson());


                // For each location id(in locationsList) in the organization, we want to retrieve the location object from the locations collection.
                // We run through a for-loop and get each location object for each id + The manager lists. Then we create the location object and add it to our 'locations' object.
                // The 'locations' object contains all the new location objects that were found on the organization object we entered the name for in the beginning.
                db.setCollection("locations");
                    for (int i = 0; i < locationsList.Count; i++)
                    {
                        filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(locationsList[i]));
                        var locationObj = BsonSerializer.Deserialize<BsonDocument>(db.getCollection().Find(filter).FirstOrDefault().ToJson());
                        List<string> managersList = BsonSerializer.Deserialize<List<string>>(locationObj["Managers"].ToJson());
                    locations.Add(new Location(locationObj["_id"].ToString(), locationObj["Name"].ToString(), locationObj["Address"].ToString(), locationObj["PostalCode"].ToString(), locationObj["Country"].ToString(), locationObj["Images"].ToString(), managersList));
                }
                    return locations;
                }
                else
                {
                    return null;
                } 
        }

        // Takes the name of the location and the field we want to update, and the value we want to update it with.
        public void updateLocation(String locationName, String updateField, String updateValue)
        {
            db.setCollection("locations");
            var filter = Builders<BsonDocument>.Filter.Eq("Name", locationName);
            var update = Builders<BsonDocument>.Update.Set(updateField, updateValue);
            var result = db.getCollection().UpdateOne(filter, update);
        }

        // Also removes the connected location manager because he cannot exist without a location.
        public void deleteLocationByName(String name)
        {
            db.setCollection("locations");
            var filter = Builders<BsonDocument>.Filter.Eq("Name", name);
            db.getCollection().DeleteOne(filter);
        }



    }


}
