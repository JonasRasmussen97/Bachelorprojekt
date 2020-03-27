
using InterCareBackend.Helpers;
using InterCareBackend.Models;
using Microsoft.AspNetCore.Mvc;

using System;

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
            return db.getUserByEmail("BOB@hotmailssssd.dk")
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

        [HttpPut("/api/updateLocation")]
        public void updateLocation()
        {
            db.setCollection("locations");
            db.updateLocation(Request.Form["locationName"], Request.Form["updateField"], Request.Form["updateValue"]);
        }

        [HttpDelete("/api/removeLocation")]
        public void removeLocation(String name)
        {
            // 1. Remove location 2. Remove location manager from 'location_managers' collection 3. Remove connected user profile from 'users' collection. 
            db.setCollection("locations");
            db.removeLocationByName(name);
            db.setCollection("location_managers");
            db.removeLocationManagerByName("");
            db.setCollection("users");
            db.removeUserByEmail("");
        }

        [HttpPut("/api/createClient")]
        public void createClient()
        {
            db.createClient(Request.Form["email"], Request.Form["fullName"], Request.Form["password"], Request.Form["accessLevel"], Request.Form["gender"], Request.Form["age"]);
        }


        [HttpDelete("/api/deleteUser")]
        public void deleteUser()
        {
            db.setCollection("users");
            db.removeUserByEmail(Request.Form["email"]);
        }

        [HttpGet("/api/getClientFromUser")]
        public Client getClientFromUser()
        {
            return db.getClientFromUser(Request.Form["Email"]);
        }

    }
}
