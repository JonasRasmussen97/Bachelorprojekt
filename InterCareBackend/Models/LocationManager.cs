using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Models
{
    public class LocationManager : User, IUser
    {

        public string OrganizationId { get; set; }
        public string LocationId { get; set; }
  

        public LocationManager(string id, string Email, string Password, string FullName, string AccessLevel, string organizationId, string locationId, string Type) : base(id, Email, Password, FullName, AccessLevel, Type)
        {

            this.OrganizationId = organizationId;
            this.LocationId = locationId;
        }

        public void Login()
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
