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

        [HttpPost("/api/createInterCareAdmin")]
        public string createInterCareAdmin()
        {
            if (Request.Headers["Authorization"].ToString().Contains("Bearer") == true)
            {
                var header = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
                IDictionary<string, object> token = Globals.auth.decodeJWT(header);
                if (token["type"].ToString() == Globals.GlobalInterCareAdmin)
                {
                    interCareAdminDao.createInterCareAdmin("InterCareAdmin@test.dk", "Pass", "Brian Løkke", "0", Globals.GlobalInterCareAdmin);
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


        [HttpGet("/api/getInterCareAdminByEmail")]

        public InterCareAdmin getAdminByEmail()
        {
            if (Request.Headers["Authorization"].ToString().Contains("Bearer") == true)
            {
                var header = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
                IDictionary<string, object> token = Globals.auth.decodeJWT(header);

                if (token["type"].ToString() == Globals.GlobalInterCareAdmin)
                {
                    return interCareAdminDao.getInterCareAdminByEmail("InterCareAdmin@test.dk");
                }
                else
                {
                    return null;
                }
            }
            return null;
        }


        [HttpDelete("/api/deleteInterCareAdminByEmail")]
        public string deleteInterCareAdminByEmail()
        {
            if (Request.Headers["Authorization"].ToString().Contains("Bearer") == true)
            {
                var header = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
                IDictionary<string, object> token = Globals.auth.decodeJWT(header);
                if (token["type"].ToString() == Globals.GlobalInterCareAdmin)
                {
                    interCareAdminDao.deleteInterCareAdmin("InterCareAdmin@test.dk");
                    return Globals.GlobalValidType;
                }
                else
                {
                    return Globals.GlobalInvalidType;
                }
            }
            return Globals.GlobalInvalidType;
        }
    }
}
