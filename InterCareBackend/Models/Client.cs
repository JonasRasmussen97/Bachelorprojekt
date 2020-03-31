using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Models
{
    public class Client : User, IUser
    {
        public string Gender { get; set; }
        public string Age { get; set; }


        public Client(string id, string Email, string Password, string FullName, string AccessLevel, string Gender, string Age, string Type) : base(id, Email, Password, FullName, AccessLevel, Type)
        {
            this.Gender = Gender;
            this.Age = Age;
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
