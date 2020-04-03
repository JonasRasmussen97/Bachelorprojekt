using InterCareBackend.Daos.Implementations;
using InterCareBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterCareBackend.Controllers
{
    public class ManagerController
    {

        LocationManagerDao managerDao = new LocationManagerDao();


        [HttpPost("/api/createLocationManager")]
        public void create()
        {
            managerDao.createManager("Jonar17@student.sdu.dk", "Pass", "Jonas Støve Rasmussen", "0", "Manager");
        }


        [HttpGet("/api/getLocationManagerByEmail")]

        public LocationManager getManagerByEmail()
        {
            return managerDao.getLocationManagerByEmail("Jonar17@student.sdu.dk");
        }


        [HttpDelete("/api/deleteLocationManagerByEmail")]
        public void delete()
        {
            managerDao.deleteManager("Jonar17@student.sdu.dk");
        }

    }
}
