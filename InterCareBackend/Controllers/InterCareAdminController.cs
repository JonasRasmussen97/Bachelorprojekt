using InterCareBackend.Daos.Implementations;
using InterCareBackend.Helpers;
using InterCareBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InterCareBackend.Controllers
{
    public class InterCareAdminController : ControllerBase
    {

        InterCareAdminDao interCareAdminDao = new InterCareAdminDao();
        AuthHelper auth = new AuthHelper();

        [HttpPost("/api/createInterCareAdmin")]
        public string create()
        {
            var header = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
            IDictionary<string, object> token = this.auth.decodeJWT(header);
            if (token["type"].ToString() == Globals.GlobalInterCareAdmin)
            {
                interCareAdminDao.createInterCareAdmin("Jonar17@student.sdu.dk", "Pass", "Jonas Støve Rasmussen", "0", Globals.GlobalInterCareAdmin);
                return "Success!";
            } else
            {
                return "You need to be an InterCare";
            }
        }


        [HttpGet("/api/getInterCareAdminByEmail")]

        public InterCareAdmin getAdminByEmail()
        {
            return interCareAdminDao.getInterCareAdminByEmail("Jonar17@student.sdu.dk");
        }


        [HttpDelete("/api/deleteInterCareAdminByEmail")]
        public void delete()
        {
            interCareAdminDao.deleteInterCareAdmin("Jonar17@student.sdu.dk");
        }


    }
}
