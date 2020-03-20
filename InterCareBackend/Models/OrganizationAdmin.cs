using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Models
{
    public class OrganizationAdmin : IUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public int AccessLevel { get; set; }

        public void Login()
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public Boolean createLocation(String name, String address, String postalCode, String country, ArrayList images, Dictionary<String, LocationManager> managers) 
        {
            return true;
        }

        public void editLocation(Location location)
        {

        }

        public Boolean removeLocation(Location location)
        {
            return true;
        }



    }
}
