using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Models
{
    public class Database
    {
        String DatabaseName;
        String CollectionName;
        MongoClient dbClient;
        IMongoDatabase database;
        IMongoCollection<BsonDocument> collection;
        FilterDefinition<BsonDocument> filter;


        public Database(String DatabaseName, String CollectionName)
        {
            this.DatabaseName = DatabaseName;
            this.CollectionName = CollectionName;

            dbClient = new MongoClient("mongodb+srv://InterCare:Julian123@intercarebachelor-lctyd.azure.mongodb.net/test?retryWrites=true&w=majority");
            database = dbClient.GetDatabase(DatabaseName);
            collection = database.GetCollection<BsonDocument>(CollectionName);
        }

        public void setCollection(String collectionName)
        {
            this.CollectionName = collectionName;
            collection = database.GetCollection<BsonDocument>(collectionName);
        }


        // USER OPERATIONS

        // DENNE METODE ER DEN NYESTE OG DE ANDRE SKAL OPDATERES TIL OGSÅ AT BRUGE BSONSERIALIZER.
        public User getUserByEmail(String email)
        {
            // Query searches for any record with the email parameter being the entered email.
            setCollection("users");
            filter = Builders<BsonDocument>.Filter.Eq("Email", email);

            if (collection.Find(filter).FirstOrDefault() != null)
            {
                // Use BsonSerializer to deserialize the BsonDocument. Then we can retrieve all the values.
                var user = BsonSerializer.Deserialize<BsonDocument>(collection.Find(filter).FirstOrDefault().ToJson());

                return new User(user["_id"].ToString(), user["Email"].ToString(), user["Password"].ToString(), user["FullName"].ToString(), user["AccessLevel"].ToString());
            }
            else
            {
                return null;
            }
        }

        public void deleteUserByEmail(String email)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("Email", email);
            collection.DeleteOne(filter);
        }



        // CLIENT OPERATIONS
        public void createClient(string email, string fullName, string password, string accessLevel, string gender, string age)
        {
            var userDocument = new BsonDocument
            {
                { "Email", email },
                { "FullName", fullName },
                { "Password", password},
                { "AccessLevel", accessLevel }
            };

            setCollection("users");
            collection.InsertOne(userDocument);

            var userId = userDocument["_id"].ToString();

            var clientDocument = new BsonDocument
            {
                { "userId", userId },
                { "Gender", gender },
                { "Age", age }
            };

            setCollection("clients");
            collection.InsertOne(clientDocument);
        }


        public DnsClient getClientFromUser(String email)
        {

            // Query searches for any record with the email parameter being the entered email.
            setCollection("users");
            var user = getUserByEmail(email);
            setCollection("clients");
            if (user != null)
            {
                filter = Builders<BsonDocument>.Filter.Eq("userId", user.id);
            }
            if (collection.Find(filter).FirstOrDefault() != null)
            {
                var client = BsonSerializer.Deserialize<BsonDocument>(collection.Find(filter).First().ToJson());
                System.Diagnostics.Debug.WriteLine(client.ToString());
                return new DnsClient(client["_id"].ToString(), user.Email, user.Password, user.FullName, user.AccessLevel, client["Gender"].ToString(), client["Age"].ToString());
            }
            else
            {
                return null;
            }
        }

        public void deleteClient(String email)
        {
            var user = getUserByEmail(email);
            var clientFilter = Builders<BsonDocument>.Filter.Eq("userId", user.id);
            setCollection("clients");
            collection.DeleteOne(clientFilter);

            var userFilter = Builders<BsonDocument>.Filter.Eq("Email", email);
            setCollection("users");
            collection.DeleteOne(userFilter);

        }


        // LOCATION OPERATIONS

        public void createLocation(string name, string address, string postalCode, string country, string manager)
        {
            var document = new BsonDocument
            {
            {"Name", name },
            {"Address", address },
            {"PostalCode", postalCode },
            {"Country", country },
            {"Managers", new BsonArray { manager } }

         };

            collection.InsertOne(document);
            System.Diagnostics.Debug.WriteLine(document["_id"].ToString());
        }

        //public Location getLocationFromOrganization(string organizationName)
        //{

        //}

        // Takes the name of the location and the field we want to update, and the value we want to update it with.
        public void updateLocation(String locationName, String updateField, String updateValue)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("Name", locationName);
            var update = Builders<BsonDocument>.Update.Set(updateField, updateValue);
            var result = collection.UpdateOne(filter, update);
        }

        // Also removes the connected location manager because he cannot exist without a location.
        public void deleteLocationByName(String name)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("Name", name);
            collection.DeleteOne(filter);
        }




        // LOCATIONMANAGER OPERATIONS

        
        public void createLocationManager(String email, String organizationName, String LocationName)
        {

        }

        //public LocationManager getLocationManager(String email)
        //{
        //    return new LocationManager();
        //}


        // Removes LocationManager. Used together with the removeLocationByName method.
        public void deleteLocationManagerByName(String name)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("Name", name);
            collection.DeleteOne(filter);
        }



        // ORGANIZATION OPERATIONS

        public void createOrganization(String name)
        {
            var document = new BsonDocument
            {
                {"Name", name },
                {"Locations", BsonNull.Value },
                {"Admin", BsonNull.Value }
            };

            collection.InsertOne(document);
        }

        // SKAL TESTES!!!
        public Organization getOrganization(String name)
        {
            // Query searches for any record with the name parameter being the entered name.
            setCollection("organizations");
            
            filter = Builders<BsonDocument>.Filter.Eq("Name", name);

            if (collection.Find(filter).FirstOrDefault() != null)
            {
                // Use BsonSerializer to deserialize the BsonDocument. Then we can retrieve all the values.
                var organization = BsonSerializer.Deserialize<BsonDocument>(collection.Find(filter).FirstOrDefault().ToJson());

                return new Organization(organization["_id"].ToString(), organization["Name"].ToString(), new Dictionary<string, Location>(), new OrganizationAdmin());
            }
            else
            {
                return null;
            }
        }

        public void updateOrganizationLocations()
        {
        }

        public void deleteOrganizationByName(String name)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("Name", name);
            collection.DeleteOne(filter);
        }


        // LOGIN OPERATIONS
        public Boolean checkLogin(String username, String password)
        {
            // Query searches for any record with the email parameter being the entered email(username).
            filter = Builders<BsonDocument>.Filter.Eq("Email", username);

            // Filter out the ID since it breaks JSON conversion, due to the nature of mongoDB (objectID).
            ProjectionDefinition<BsonDocument> projectionRemoveId = Builders<BsonDocument>.Projection.Exclude("_id");

            if (collection.Find(filter).Project(projectionRemoveId).FirstOrDefault() != null)
            {
                // Make a JObject from the JSON returned by MongoDB.
                JObject jUser = JObject.Parse(collection.Find(filter).Project(projectionRemoveId).FirstOrDefault().ToJson());
                // Checks if the entered username and password fits the user from the database.
                if (username == (string)jUser["Email"] && password == (string)jUser["Password"])
                {
                    return true;
                }
                else
                {
                    //   System.Diagnostics.Debug.WriteLine(Email + " : " + username + " - " +  password + " : " + Password);
                    return false;
                }
            }
            return false;
        }




    }


}
