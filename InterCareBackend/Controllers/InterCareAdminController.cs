﻿using InterCareBackend.Daos.Implementations;
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
        public string create()
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
        }


        [HttpGet("/api/getInterCareAdminByEmail")]

        public InterCareAdmin getAdminByEmail()
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


        [HttpDelete("/api/deleteInterCareAdminByEmail")]
        public string delete()
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
    }
}
