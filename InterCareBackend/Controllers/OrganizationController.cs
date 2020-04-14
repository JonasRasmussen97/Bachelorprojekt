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


        [HttpDelete("api/deleteOrganizationByName")]
        public void deleteOrganization()
        {
            organizationDao.deleteOrganization("TestOrg");
        }

        [HttpDelete("api/deleteOrganizationAndAdmin")]
        public void deleteOrganizationAndAdmin()
        {
            organizationDao.deleteOrganizationAndAdmin("TestOrg");
        }

    }
}
