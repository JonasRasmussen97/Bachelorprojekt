
using InterCareBackend.Daos.Implementations;
using InterCareBackend.Helpers;
using InterCareBackend.Models;
using JWT.Algorithms;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using System;

namespace InterCareBackend.Controllers
{

    [ApiController]
    public class TestController : ControllerBase
    {

        /*
        // LOCATION OPERATIONS

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
        */

    }
    
}
