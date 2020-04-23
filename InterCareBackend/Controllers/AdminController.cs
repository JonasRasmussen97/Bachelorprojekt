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
            if (Request.Headers["Authorization"].ToString().Contains("Bearer") == true)
            {
                var header = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
                IDictionary<string, object> token = Globals.auth.decodeJWT(header);
                if (token["type"].ToString() == Globals.GlobalInterCareAdmin)
                {
                    adminDao.createAdmin("test@test.dk", "Test Jensen", "Pass", "0", Globals.GlobalOrganizationAdmin);
                    organizationDao.createOrganization("Test Organization", new List<string> { }, adminDao.getAdminByEmail("Jonar17@student.sdu.dk").id);
                    return Globals.GlobalValidType;
                }
                else
                {
                    return Globals.GlobalInvalidType;
                }
            } else
            {
                return Globals.GlobalInvalidType;
            }
           
        }


        [HttpGet("/api/getAdminByEmail")]

        public OrganizationAdmin getAdminByEmail()
        {
            if (Request.Headers["Authorization"].ToString().Contains("Bearer") == true)
            {
                var header = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
                IDictionary<string, object> token = Globals.auth.decodeJWT(header);
                if (token["type"].ToString() == Globals.GlobalInterCareAdmin)
                {
                    return adminDao.getAdminByEmail("test@test.dk");
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


        [HttpDelete("/api/deleteAdminByEmail")]
        public string delete()
        {
            if (Request.Headers["Authorization"].ToString().Contains("Bearer") == true)
            {
                var header = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
                IDictionary<string, object> token = Globals.auth.decodeJWT(header);
                if (token["type"].ToString() == Globals.GlobalInterCareAdmin)
                {
                    adminDao.deleteAdmin("test@test.dk");
                    return Globals.GlobalValidType;
                }
                else
                {
                    return Globals.GlobalInvalidType;
                }
            } else
            {
                return Globals.GlobalInvalidType;
            }
        }


    }
}
