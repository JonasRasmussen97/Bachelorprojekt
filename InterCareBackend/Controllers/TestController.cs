using InterCareBackend.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Controllers
{
    [ApiController]
    public class TestController : ControllerBase
    {
        Database db = new Database("InterCare", "users");
        
       

        [HttpGet("/api/")]
        public String Get()
        {
            return db.getUserByName("Jonas").FullName;
        }
    }
}
