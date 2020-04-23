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
        AuthHelper auth = new AuthHelper();

        [HttpPost("/api/createLocationManager")]
        public string create()
        {
            var header = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
            IDictionary<string, object> token = this.auth.decodeJWT(header);
            if (token["type"].ToString() == Globals.GlobalLocationManager)
            {
                managerDao.createManager("Jonar17@student.sdu.dk", "Pass", "Jonas Støve Rasmussen", "0", "Manager");
                return "Manager has been created!";
            } else
            {
                return "Unable to create manager.";
            }
        }


        [HttpGet("/api/getLocationManagerByEmail")]

        public LocationManager getManagerByEmail()
        {
            var header = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
            IDictionary<string, object> token = this.auth.decodeJWT(header);
            if (token["type"].ToString() == Globals.GlobalLocationManager)
            {
                return managerDao.getLocationManagerByEmail("Jonar17@student.sdu.dk");
            } else
            {
                return null;
            }
        }


        [HttpDelete("/api/deleteLocationManagerByEmail")]
        public string delete()
        {
            var header = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
            IDictionary<string, object> token = this.auth.decodeJWT(header);
            if (token["type"].ToString() == Globals.GlobalOrganizationAdmin || token["type"].ToString() == Globals.GlobalInterCareAdmin)
            {
                managerDao.deleteManager("Jonar17@student.sdu.dk");
                return "Manager has been deleted";
            } else
            {
                return "Could not delete manager!";
            }
        }

    }
}
