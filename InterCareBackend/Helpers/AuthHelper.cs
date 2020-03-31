using InterCareBackend.Models;
using JWT.Algorithms;
using JWT.Builder;
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

        public AuthHelper()
        {
       

        }

        /*

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
      
        }

    }
