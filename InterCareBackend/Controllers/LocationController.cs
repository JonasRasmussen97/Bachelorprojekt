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


        [HttpPost("/api/createLocation")]
        public void createLocation()
        {
            locationDao.createLocation("Odense", "Testvej 100", "DK-5000", "Denmark", "images", new List<string> { "Manager1", "Manager2" });
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
            return locationDao.getLocationsFromOrganization("Test Organization");
        }

        // Used by LocationManager
        [HttpGet("/api/getLocationFromManagerId")]
        public Location getLocationFromManagerId()
        {
            if (Request.Headers["Authorization"].ToString().Contains("Bearer") == true)
            {
                var header = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
                IDictionary<string, object> token = Globals.auth.decodeJWT(header);
                if (token["type"].ToString() == Globals.GlobalLocationManager)
                {
                    return locationDao.getLocationFromManagerId(token["id"].ToString());
                }
                else
                {
                    return null;
                }
            } else
            {
                return null;
            }
        }


        [HttpPut("/api/updateLocation")]
        public void updateLocation()
        {
            locationDao.updateLocation("Odense", "Country", "Denmark");
        }


        [HttpDelete("api/deleteLocationByName")]
        public void deleteOrganization()
        {
            locationDao.deleteLocationByName("Odense");
        }


    }
}
