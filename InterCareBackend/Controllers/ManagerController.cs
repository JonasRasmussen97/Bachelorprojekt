using InterCareBackend.Daos.Implementations;
using InterCareBackend.Helpers;
using InterCareBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InterCareBackend.Controllers
{
    public class ManagerController : ControllerBase
    {

        LocationManagerDao managerDao = new LocationManagerDao();

        [HttpPost("/api/createLocationManager")]
        public string createLocationManager()
        {
            if (Request.Headers["Authorization"].ToString().Contains("Bearer") == true)
            {
                var header = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
                IDictionary<string, object> token = Globals.auth.decodeJWT(header);
                if (token["type"].ToString() == Globals.GlobalLocationManager)
                {
                    managerDao.createManager("LocationManager@test.dk", "Pass", "Poul Andersen", "0", Globals.GlobalLocationManager);
                    return "Manager has been created!";
                }
                else
                {
                    return Globals.GlobalCreateFailed;
                }
            } else
            {
                return Globals.GlobalCreateFailed;
            } 
           
        }


        [HttpGet("/api/getLocationManagerByEmail")]

        public LocationManager getManagerByEmail()
        {
            if (Request.Headers["Authorization"].ToString().Contains("Bearer") == true)
            {
                var header = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
                IDictionary<string, object> token = Globals.auth.decodeJWT(header);
                if (token["type"].ToString() == Globals.GlobalLocationManager)
                {
                    return managerDao.getLocationManagerByEmail("Test@test.dk");
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


        [HttpDelete("/api/deleteLocationManagerByEmail")]
        public string deleteLocationManagerByEmail()
        {
            if (Request.Headers["Authorization"].ToString().Contains("Bearer") == true)
            {
                var header = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
                IDictionary<string, object> token = Globals.auth.decodeJWT(header);
                if (token["type"].ToString() == Globals.GlobalOrganizationAdmin || token["type"].ToString() == Globals.GlobalInterCareAdmin)
                {
                    managerDao.deleteManager("Test@test.dk");
                    return "Manager has been deleted";
                }
                else
                {
                    return Globals.GlobalDeleteFailed;
                }
            } else
            {
                return Globals.GlobalDeleteFailed;
            }
        }

    }
}
