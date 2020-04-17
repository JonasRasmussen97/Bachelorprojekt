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

        [HttpGet("/api/getAllOrganizations")]
        public List<Organization> getAllOrganizations()
        {
            return organizationDao.getAllOrganizations();
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
