using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Models
{
    public class InterCareAdmin : IUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string AccessLevel { get; set; }
        public string Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Login()
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public Boolean removeOrganization(Organization organization)
        {
            return true;
        }

        public Boolean removeLocation(Location location)
        {
            return true;
        }

        public Boolean removeUser(IUser user)
        {
            return true;
        }

    }
}
