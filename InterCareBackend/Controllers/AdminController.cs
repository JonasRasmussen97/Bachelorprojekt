using InterCareBackend.Daos.Implementations;
using InterCareBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace InterCareBackend.Controllers
{
    public class AdminController
    {
        OrganizationAdminDao adminDao = new OrganizationAdminDao();
        OrganizationDao organizationDao = new OrganizationDao();


        [HttpPost("/api/createAdminWithOrganization")]
        public void create()
        {
            adminDao.createAdmin("Jonar17@student.sdu.dk", "Jonas Støve Rasmussen", "Pass", "0", "Male", "23", "Admin");
            organizationDao.createOrganization("Jonas's Organization", new List<String> { }, adminDao.getAdminByEmail("Jonar17@student.sdu.dk").id);
        }


        [HttpGet("/api/getAdminByEmail")]

        public OrganizationAdmin getAdminByEmail()
        {
            return adminDao.getAdminByEmail("Jonar17@student.sdu.dk");
        }


        [HttpDelete("/api/deleteAdminByEmail")]
        public void delete()
        {
            adminDao.deleteAdmin("Jonar17@student.sdu.dk");
        }


    }
}
