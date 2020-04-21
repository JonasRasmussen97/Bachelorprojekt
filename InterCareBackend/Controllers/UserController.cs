using InterCareBackend.Daos.Implementations;
using InterCareBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InterCareBackend.Controllers
{
    public class UserController
    {

        UserDao userDao = new UserDao();

        [HttpGet("/api/getAllUsers")]
        public List<User> getAllUsers()
        {
            return userDao.getAllUsers();
        }
    }
}
