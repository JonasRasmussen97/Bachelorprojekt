using InterCareBackend.Helpers;
using JWT.Algorithms;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Cors;


namespace InterCareBackend.Controllers
{
    public class AuthController : ControllerBase
    {

        AuthHelper auth = new AuthHelper();

        [HttpPost("/api/login")]
        public IActionResult login()
        {
            var tokenString = auth.authUser(Request.Form["email"], Request.Form["password"]);
            return tokenString;
        }

        [DisableCors]
        [HttpGet("/api/test")]
        public String testJWT()
        {

            return auth.getBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .Decode(Request.Headers["Authorization"]);
        }

    }
}
