using InterCareBackend.Daos.Implementations;
using InterCareBackend.Helpers;
using InterCareBackend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace InterCareBackend.Controllers
{
    public class ClientController : ControllerBase
    {

        ClientDao clientDao = new ClientDao();
        AuthHelper helper = new AuthHelper();


        [HttpPost("/api/createClient")]
        public void create()
        {
            clientDao.createClient("Jonar17@student.sdu.dk", "Pass", "Jonas Støve Rasmussen", "0", "Client", "Male", "23");

        }


        [HttpGet("/api/getClientByEmail")]
        public Client get()
        {
            var header = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
            IDictionary<string, object> token = helper.decodeJWT(header);
           
                return clientDao.getClientByEmail(token["username"].ToString());
        }

      


        [HttpDelete("/api/deleteClientByEmail")]
        public void deleteClient()
        {
            clientDao.deleteClient("Jonar17@student.sdu.dk");
        }
    }
}
