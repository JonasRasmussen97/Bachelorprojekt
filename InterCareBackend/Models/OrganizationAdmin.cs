using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Models
{
    public class OrganizationAdmin : User, IUser
    {
        public String OrganizationId { get; set; }
        
        
        public OrganizationAdmin(string id, string Email, string Password, string FullName, string AccessLevel, string OrganizationId) : base(id, Email, Password, FullName, AccessLevel)
        {
            this.OrganizationId = OrganizationId;

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
