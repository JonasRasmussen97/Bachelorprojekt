using InterCareBackend.Daos.Implementations;
using InterCareBackend.Helpers;
using InterCareBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InterCareBackend.Controllers
{
    public class OrganizationController : ControllerBase
    {

        OrganizationDao organizationDao = new OrganizationDao();

        [HttpPost("/api/createOrganization")]
        public void createOrganization()
        {
            organizationDao.createOrganization("Test Organization", new List<string> { "Odense", "Aarhus" }, "AdminsId");
        }


        [HttpGet("/api/getOrganizationByName")]
        public Organization getOrganizationByName()
        {
            return organizationDao.getOrganization("Test Organization");
        }

        // Used by OrganizationAdmin
        [HttpGet("/api/getOrganizationFromAdminId")]
        public Organization getOrganizationFromAdminId()
        {
            if (Request.Headers["Authorization"].ToString().Contains("Bearer") == true)
            {
                var header = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
                IDictionary<string, object> token = Globals.auth.decodeJWT(header);
                if (token["type"].ToString() == Globals.GlobalOrganizationAdmin)
                {
                    return organizationDao.getOrganizationFromAdminId(token["id"].ToString());
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
        
        // Used by InterCareAdmin
        [HttpGet("/api/getAllOrganizations")]
        public List<Organization> getAllOrganizations()
        {
            if (Request.Headers["Authorization"].ToString().Contains("Bearer") == true)
            {
                var header = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
                IDictionary<string, object> token = Globals.auth.decodeJWT(header);
                if (token["type"].ToString() == Globals.GlobalInterCareAdmin)
                {
                    return organizationDao.getAllOrganizations();
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

        // Used by Client, LocationManager and OrganizationAdmin
        [HttpGet("/api/getAllOrganizationsAsClient")]
        public List<Organization> getAllOrganizationsAsClient()
        {
            if (Request.Headers["Authorization"].ToString().Contains("Bearer") == true)
            {
                var header = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
                IDictionary<string, object> token = Globals.auth.decodeJWT(header);
                if (token["type"].ToString() == Globals.GlobalClient || token["type"].ToString() == Globals.GlobalLocationManager || token["type"].ToString() == Globals.GlobalOrganizationAdmin)
                {
                    return organizationDao.getAllOrganizationsAsClient();
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

        [HttpDelete("api/deleteOrganizationByName")]
        public void deleteOrganizationByName()
        {
            organizationDao.deleteOrganization("Test Organization");
        }

        [HttpDelete("api/deleteEntireOrganization")]
        public void deleteEntireOrganization()
        {
            organizationDao.deleteEntireOrganization("Odense");
        }

    }
}
