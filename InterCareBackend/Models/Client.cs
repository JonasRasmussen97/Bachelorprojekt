using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Models
{
    public class Client : IUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public int AccessLevel { get; set; }

        Client()
        {
            // Defines the access level of a client upon instantiation of object. 
            AccessLevel = 0;
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
