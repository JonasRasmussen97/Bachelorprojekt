using InterCareBackend.Models;
using JWT.Algorithms;
using JWT.Builder;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Helpers
{
    public class AuthHelper
    {
        // The secret that is used to authorize if people are allowed to access endpoints.
        String secret = "mU1ojWk5LvBlr7A94v8iEIfKEk5QIy9s";
        Database db = new Database("InterCare", "users");
        JwtBuilder builder;
        IMongoCollection<BsonDocument> collection;
        FilterDefinition<BsonDocument> filter;

        public AuthHelper()
        {
            builder = new JwtBuilder();

        }

        public JwtBuilder getBuilder()
        {
            return this.builder;
        }




        // Authorizes the user and returns a token if the user is valid.
        public String authUser(String username, String password)
        {
            var token = new JwtBuilder()
           .WithAlgorithm(new HMACSHA256Algorithm())
           .WithSecret(secret)
           .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds())
           .AddClaim("username", username)
           .AddClaim("password", password)
           .AddClaim("accessLevel", "0")
           .Encode();
            // If the password and username is found in the DB, then generate the JWT.
            /*
            if (db.checkLogin(username, password)) {
                return token;
            } else
            {
                return "Unable to login!";
            }
            */
            return token;
        }


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