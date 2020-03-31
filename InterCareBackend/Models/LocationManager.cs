using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Models
{
    public class LocationManager : User, IUser
    {


        public LocationManager(string id, string Email, string Password, string FullName, string AccessLevel, string Type) : base(id, Email, Password, FullName, AccessLevel, Type)
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
    }
}
