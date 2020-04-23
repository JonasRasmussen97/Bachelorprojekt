using InterCareBackend.Daos.Implementations;
using InterCareBackend.Helpers;
using InterCareBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace InterCareBackend.Controllers
{
    public class ClientController : ControllerBase
    {

        ClientDao clientDao = new ClientDao();


        [HttpPost("/api/createClient")]
        public string create()
        {       
                clientDao.createClient("Jonar17@student.sdu.dk", "Pass", "Jonas Støve Rasmussen", "0", Globals.GlobalClient, "Male", "23");
                return Globals.GlobalValidType; 
        }


        [HttpGet("/api/getClientByEmail")]
        public Client get()
        {
            if (Request.Headers["Authorization"].ToString().Contains("Bearer") == true)
            {
                var header = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
                IDictionary<string, object> token = Globals.auth.decodeJWT(header);

                if (token["type"].ToString() == Globals.GlobalClient)
                {
                    return clientDao.getClientByEmail(token["username"].ToString());
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


        [HttpDelete("/api/deleteClientByEmail")]
        public String deleteClient()
        {
            if (Request.Headers["Authorization"].ToString().Contains("Bearer") == true)
            {
                var header = Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
                IDictionary<string, object> token = Globals.auth.decodeJWT(header);
                if (token["type"].ToString() == Globals.GlobalClient)
                {
                    clientDao.deleteClient("Jonar17@student.sdu.dk");
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
