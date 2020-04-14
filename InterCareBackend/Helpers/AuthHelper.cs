using InterCareBackend.Models;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Helpers
{
    public class AuthHelper : ControllerBase
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
        public IActionResult authUser(String username, String password)
        {
            var tokenString = new JwtBuilder()
           .WithAlgorithm(new HMACSHA256Algorithm())
           .WithSecret(secret)
           .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds())
           .AddClaim("username", username)
           .AddClaim("password", password)
           .AddClaim("accessLevel", "0")
           .Encode();
            // If the password and username is found in the DB, then generate the JWT.

            if (checkLogin(username, password))
            {
                return Ok(new { token = tokenString });
            }
            else
            {
                return Ok(new { message = "Unable to login!" });
            }

        }


        public Boolean checkLogin(String username, String password)
        {
            System.Diagnostics.Debug.WriteLine(username + " and " + password);

            db.setCollection("users");
            filter = Builders<BsonDocument>.Filter.Eq("Email", username);
            if (db.getCollection().Find(filter).FirstOrDefault() != null)
            {
                // Use BsonSerializer to deserialize the BsonDocument. Then we can retrieve all the values.
                var User = BsonSerializer.Deserialize<BsonDocument>(db.getCollection().Find(filter).FirstOrDefault().ToJson());
                System.Diagnostics.Debug.WriteLine("HEJ");
                if (username == User["Email"].ToString() && password == User["Password"].ToString())
                {

                    return true;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("It is false!");
                    return false;
                }
            }


            return false;
        }
    }
}