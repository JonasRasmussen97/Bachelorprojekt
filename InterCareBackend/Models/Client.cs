using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Models
{
    public class Client : IUser
    {
        public String id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string AccessLevel { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }

    

        public Client(string id, string email, string password, string fullName, string accessLevel, string gender, string age)
        {
            this.id = id;
            Email = email;
            Password = password;
            FullName = fullName;
            AccessLevel = accessLevel;
            Gender = gender;
            Age = age;
            // Defines the access level of a client upon instantiation of object. 
            AccessLevel = "0";
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
