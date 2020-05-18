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

       

        [HttpPost("/api/login")]
        public IActionResult login()
        {
            var tokenString = Globals.auth.checkLogin(Request.Form["email"], Request.Form["password"]);
            return tokenString;
        }

        // This method is used to validate that a user has access to a given site in frontend. It returns the type of the logged in user based on his/her JWT.
        [HttpGet("/api/getUserType")]
        public string getUserType()
        {
            if (Request.Headers["Authorization"].ToString().Contains("Bearer") == true)
            {
                var header = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
                IDictionary<string, object> token = Globals.auth.decodeJWT(header);
                try
                {
                    if (token != null)
                    {
                        return token["type"].ToString();
                    }
                    else {
                        return null;

                    }
                }
                catch (KeyNotFoundException)
            {
                return "Unable to get type. Please try again later";
            }
            catch (NullReferenceException)
            {
                return null;
            }
        } else
            {
                return null;
            }
        }

}
}
