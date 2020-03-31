
using InterCareBackend.Daos.Implementations;
using InterCareBackend.Helpers;
using InterCareBackend.Models;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;

namespace InterCareBackend.Controllers
{

    [ApiController]
    public class TestController : ControllerBase
    {
        Database db = new Database("InterCare", "locations");
        AuthHelper auth = new AuthHelper();
        ClientDao dao = new ClientDao();
        OrganizationDao organizationDao = new OrganizationDao();
        
        /*
        //LOGIN OPERATIONS
        [HttpPost("/api/login")]
        public IActionResult login()
        {
            var tokenString = auth.authUser(Request.Form["username"], Request.Form["password"]);
            return Ok(new { token = tokenString });
        }
       */
        
        // USER OPERATIONS
        [HttpGet("/api/")]
        public Client Get()
        {
            return dao.getClientByEmail("Jonar17@student.sdu.dk");
        }

        /*
        [HttpDelete("/api/deleteUser")]
        public void deleteUser()
        {
            db.setCollection("users");
            db.deleteUserByEmail(Request.Form["email"]);
        }



        // CLIENT OPERATIONS
        [HttpPut("/api/createClient")]
        public void createClient()
        {
            db.createClient(Request.Form["email"], Request.Form["fullName"], Request.Form["password"], Request.Form["accessLevel"], Request.Form["gender"], Request.Form["age"]);
        }


        [HttpGet("/api/getClientFromUser")]
        public Client getClientFromUser()
        {
            return db.getClientFromUser(Request.Form["Email"]);
        }

        [HttpDelete("/api/deleteClient")]
        public void deleteClient()
        {

            db.deleteClient(Request.Form["email"]);
        }



        // LOCATION OPERATIONS
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
        public void deleteLocation(String name)
        {
            // 1. Remove location 2. Remove location manager from 'location_managers' collection 3. Remove connected user profile from 'users' collection. 
            db.setCollection("locations");
            db.deleteLocationByName(name);
            db.setCollection("location_managers");
            db.deleteLocationManagerByName("");
            db.setCollection("users");
            db.deleteUserByEmail("");
        }


        // LOCATIONMANAGER OPERATIONS




        


        [HttpDelete("api/deleteOrganization")]
        public void deleteOrganization()
        {
            db.setCollection("organizations");
            db.deleteOrganizationByName(Request.Form["name"]);
        }


        //ORGANIZATIONADMIN OPERATIONS
        



    */
    
            // ORGANIZATION OPERATIONS

        [HttpPut("/api/createOrganization")]
        public void createOrganization()
        {
            organizationDao.createOrganization("Apple", new List<string> { "Odense", "Aarhus" }, "BobId");
        }
    }
}
