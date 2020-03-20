using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Models
{
    public class User: IUser
    {
        public String Email { get; set; }
        public String Password { get; set; }
        public String FullName { get; set;}
        public String AccessLevel { get; set; }

        public User(string Email, string Password, String FullName, String AccessLevel)
        {
            this.Email = Email;
            this.Password = Password;
            this.FullName = FullName;
            this.AccessLevel = AccessLevel;
        }
        public void Login()
        {
            // To be implemented.
            throw new NotImplementedException();
        }

        public void Logout()
        {
            // To be implemented.
            throw new NotImplementedException();
        }
    }
}
