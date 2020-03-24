
using InterCareBackend.Helpers;
using InterCareBackend.Models;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Core;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Controllers
{

    [ApiController]
    public class TestController : ControllerBase
    {
        Database db = new Database("InterCare", "users");
        AuthHelper auth = new AuthHelper();
        

        [Authorize]
        [HttpGet("/api/")]
        public String Get()
        {
            return db.getUserByName("Jonas").FullName;
        }

        [HttpPost("/api/login")]
       public IActionResult login()
        {
            var tokenString = auth.authUser(Request.Form["username"], Request.Form["password"]);
            return Ok(new { token = tokenString });
        }

    }
}
