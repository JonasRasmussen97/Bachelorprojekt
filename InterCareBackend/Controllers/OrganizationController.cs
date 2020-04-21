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
        AuthHelper auth = new AuthHelper();

        [HttpPost("/api/createOrganization")]
        public void createOrganization()
        {
            organizationDao.createOrganization("Amazon", new List<string> { "Odense", "Aarhus" }, "BobId");
        }


        [HttpGet("/api/getOrganizationByName")]
        public Organization getOrganization()
        {
            return organizationDao.getOrganization("Amazon");
        }

        [HttpGet("/api/getOrganizationFromAdminId")]
        public Organization getOrganizationFromAdminId()
        {
            var header = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
            IDictionary<string, object> token = this.auth.decodeJWT(header);
            return organizationDao.getOrganizationFromAdminId(token["id"].ToString());
        }
        

        [HttpGet("/api/getAllOrganizations")]
        public List<Organization> getAllOrganizations()
        {
            return organizationDao.getAllOrganizations();
        }

        [HttpGet("/api/getAllOrganizationsAsClient")]
        public List<Organization> getAllOrganizationsAsClient()
        {
            return organizationDao.getAllOrganizationsAsClient();
        }

        [HttpDelete("api/deleteOrganizationByName")]
        public void deleteOrganization()
        {
            organizationDao.deleteOrganization("TestOrg");
        }

        [HttpDelete("api/deleteEntireOrganization")]
        public void deleteEntireOrganization()
        {
            organizationDao.deleteEntireOrganization("Odense");
        }

    }
}
