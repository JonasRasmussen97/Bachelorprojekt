using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Models
{
    public class OrganizationAdmin : User, IUser
    {
        
        
        public OrganizationAdmin(string id, string Email, string Password, string FullName, string AccessLevel, string Type) : base(id, Email, Password, FullName, AccessLevel, Type)
        {

        }
        public OrganizationAdmin(string Email, string Password, string FullName, string AccessLevel, string Type) : base(id, Email, Password, FullName, AccessLevel, Type)
        {

        }


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
