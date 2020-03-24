using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Models
{
    public class LocationManager : IUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string AccessLevel { get; set; }


        public LocationManager(String Email, String Password, String FullName, String AccessLevel)
        {
            this.Email = Email;
            this.Password = Password;
            this.FullName = FullName;
            this.AccessLevel = AccessLevel;
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
