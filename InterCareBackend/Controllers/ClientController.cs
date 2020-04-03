using InterCareBackend.Daos.Implementations;
using InterCareBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterCareBackend.Controllers
{
    public class ClientController
    {

        ClientDao clientDao = new ClientDao();


        [HttpPost("/api/createClient")]
        public void create()
        {
            clientDao.createClient("Jonar17@student.sdu.dk", "Pass", "Jonas Støve Rasmussen", "0", "Client", "Male", "23");

        }


        [HttpGet("/api/getClientByEmail")]
        public Client get()
        {
            return clientDao.getClientByEmail("Jonar17@student.sdu.dk");
        }


        [HttpDelete("/api/deleteClientByEmail")]
        public void deleteClient()
        {
            clientDao.deleteClient("Jonar17@student.sdu.dk");
        }
    }
}
