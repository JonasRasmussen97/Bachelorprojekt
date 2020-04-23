using System;
using System.Collections;
using System.Collections.Generic;

namespace InterCareBackend.Models
{
    public class OrganizationAdmin : User, IUser
    {
        
        
        public OrganizationAdmin(string id, string Email, string Password, string FullName, string AccessLevel, string Type) : base(id, Email, Password, FullName, AccessLevel, Type)
        {

        }
        public OrganizationAdmin(string Email, string Password, string FullName, string AccessLevel, string Type) : base(Email, Password, FullName, AccessLevel, Type)
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

        public Boolean createLocation(string name, string address, string postalCode, string country, ArrayList images, Dictionary<string, LocationManager> managers) 
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
