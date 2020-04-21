using InterCareBackend.Daos.Implementations;
using InterCareBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InterCareBackend.Controllers
{
    public class OrganizationController
    {

        OrganizationDao organizationDao = new OrganizationDao();


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
            return organizationDao.getOrganizationFromAdminId("5e832fd01c9d440000c2d82e");
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
