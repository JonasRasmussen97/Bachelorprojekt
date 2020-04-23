using InterCareBackend.Daos.Implementations;
using InterCareBackend.Helpers;
using InterCareBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace InterCareBackend.Controllers
{
    public class AdminController : ControllerBase
    {
        OrganizationAdminDao adminDao = new OrganizationAdminDao();
        OrganizationDao organizationDao = new OrganizationDao();


        [HttpPost("/api/createAdminWithOrganization")]
        public string create()
        {
            var header = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
            IDictionary<string, object> token = Globals.auth.decodeJWT(header);
            if(token["type"].ToString() == Globals.GlobalInterCareAdmin)
            {
                adminDao.createAdmin("Jonar17@student.sdu.dk", "Jonas Støve Rasmussen", "Pass", "0", Globals.GlobalOrganizationAdmin);
                organizationDao.createOrganization("Jonas's Organization", new List<string> { }, adminDao.getAdminByEmail("Jonar17@student.sdu.dk").id);
                return Globals.GlobalValidType;
            } else
            {
                return Globals.GlobalInvalidType;
            }
           
        }


        [HttpGet("/api/getAdminByEmail")]

        public OrganizationAdmin getAdminByEmail()
        {
            var header = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
            IDictionary<string, object> token = Globals.auth.decodeJWT(header);
            if (token["type"].ToString() == Globals.GlobalInterCareAdmin)
            {
                return adminDao.getAdminByEmail("Jonar17@student.sdu.dk");
            } else
            {
                return null;
            }
        }


        [HttpDelete("/api/deleteAdminByEmail")]
        public string delete()
        {
            var header = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
            IDictionary<string, object> token = Globals.auth.decodeJWT(header);
            if (token["type"].ToString() == Globals.GlobalInterCareAdmin)
            {
                adminDao.deleteAdmin("Jonar17@student.sdu.dk");
                return Globals.GlobalValidType;
            } else
            {
                return Globals.GlobalInvalidType;
            }
        }


    }
}
