using InterCareBackend.Helpers;
using JWT.Algorithms;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;

namespace InterCareBackend.Controllers
{
    public class AuthController : ControllerBase
    {

        AuthHelper auth = new AuthHelper();

        [HttpPost("/api/login")]
        public IActionResult login()
        {
            var tokenString = auth.checkLogin(Request.Form["email"], Request.Form["password"]);
            return tokenString;
        }

       
        [HttpGet("/api/test")]
        public string testJWT()
        {

            return auth.getBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .Decode(Request.Headers["Authorization"]);
        }

        // This method is used to validate that a user has access to a given site in frontend. It returns the type of the logged in user based on his/her JWT.
        [HttpGet("/api/getUserType")]
        public string getUserType()
        {
            var header = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
            IDictionary<string, object> token = this.auth.decodeJWT(header);
            try
            {
                return token["type"].ToString();
            } catch(KeyNotFoundException)
            {
                return "Unable to get type. Please try again later";
            } catch(NullReferenceException)
            {
                return null;
            }
        }

    }
}
