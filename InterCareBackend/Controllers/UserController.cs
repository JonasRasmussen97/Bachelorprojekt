using InterCareBackend.Daos.Implementations;
using InterCareBackend.Helpers;
using InterCareBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InterCareBackend.Controllers
{
    public class UserController : ControllerBase
    {

        UserDao userDao = new UserDao();

        // Used by InterCareAdmin
        [HttpGet("/api/getAllUsers")]
        public List<User> getAllUsers()
        {

            var header = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
            IDictionary<string, object> token = Globals.auth.decodeJWT(header);

            if (token["type"].ToString() == Globals.GlobalInterCareAdmin)
            {
                return userDao.getAllUsers();
            }
            else
            {
                return null;
            }

        }

    }
}
