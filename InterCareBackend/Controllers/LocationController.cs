using InterCareBackend.Daos.Implementations;
using InterCareBackend.Helpers;
using InterCareBackend.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;

namespace InterCareBackend.Controllers
{
    public class LocationController : ControllerBase
    {

        LocationDao locationDao = new LocationDao();
        AuthHelper auth = new AuthHelper();


        [HttpPost("/api/createLocation")]
        public void createLocation()
        {
            locationDao.createLocation("Nyborg", "Odensevej 100000", "DK-5000", "Denmark", "images", new List<string> { "Polle", "Heino" });
        }

        // Should get a legit id
        [HttpGet("/api/getLocationById")]
        public Location getOrganization()
        {
            return locationDao.getLocationById("5e79e3e908e5001d3c7e9016");
        }

        
        [HttpGet("/api/getLocationsByOrganizationName")]
        public List<Location> getLocationsFromOrganization()
        {
            return locationDao.getLocationsFromOrganization("Sygehus");
        }

        // Used by LocationManager
        [HttpGet("/api/getLocationFromManagerId")]
        public Location getLocationFromManagerId()
        {
            var header = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
            IDictionary<string, object> token = this.auth.decodeJWT(header);
            return locationDao.getLocationFromManagerId(token["id"].ToString());
        }


        [HttpPut("/api/updateLocation")]
        public void updateLocation()
        {
            locationDao.updateLocation("Nyborg", "Country", "Germany");
        }


        [HttpDelete("api/deleteLocationByName")]
        public void deleteOrganization()
        {
            locationDao.deleteLocationByName("Nyborg");
        }


    }
}
