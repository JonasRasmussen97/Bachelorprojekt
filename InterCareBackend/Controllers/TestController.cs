
using InterCareBackend.Helpers;
using InterCareBackend.Models;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Core;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Controllers
{

    [ApiController]
    public class TestController : ControllerBase
    {
        Database db = new Database("InterCare", "locations");
        AuthHelper auth = new AuthHelper();
        
 
        [HttpGet("/api/")]
        public String Get()
        {
            db.setCollection("users");
            return db.getUserByEmail("Test@email.com").FullName;
        }

        [HttpPost("/api/login")]
       public IActionResult login()
        {
            var tokenString = auth.authUser(Request.Form["username"], Request.Form["password"]);
            return Ok(new { token = tokenString });
        }

        [HttpPost("/api/createLocation")]
            public void createLocation()
        {
            db.setCollection("locations");
            db.createLocation(Request.Form["name"], Request.Form["address"], Request.Form["postalcode"], Request.Form["country"], Request.Form["manager"]);
        }

    }
}
