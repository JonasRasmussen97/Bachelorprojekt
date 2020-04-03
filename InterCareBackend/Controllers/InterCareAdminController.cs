using InterCareBackend.Daos.Implementations;
using InterCareBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterCareBackend.Controllers
{
    public class InterCareAdminController
    {

        InterCareAdminDao interCareAdminDao = new InterCareAdminDao();
        

        [HttpPost("/api/createInterCareAdmin")]
        public void create()
        {
            interCareAdminDao.createInterCareAdmin("Jonar17@student.sdu.dk", "Pass", "Jonas Støve Rasmussen", "0", "InterCareAdmin");
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
