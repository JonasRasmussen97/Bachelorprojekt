using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Models
{
    public class User: IUser
    {
        
        public String id;
        public String Email { get; set; }
        public String Password { get; set; }
        public String FullName { get; set;}
        public String AccessLevel { get; set; }
        public String Type { get; set; }
        

        public User(String id, string Email, string Password, String FullName, String AccessLevel, String Type)
        {
            this.id = id;
            this.Email = Email;
            this.Password = Password;
            this.FullName = FullName;
            this.AccessLevel = AccessLevel;
            this.Type = Type;
        }

        public User(string Email, string Password, String FullName, String AccessLevel, String Type)
        {
            this.Email = Email;
            this.Password = Password;
            this.FullName = FullName;
            this.AccessLevel = AccessLevel;
            this.Type = Type;
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
