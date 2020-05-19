using System;

namespace InterCareBackend.Models
{
    public class Client : User, IUser
    {
        public string Gender { get; set; }
        public string Age { get; set; }


        public Client(string id, string Email, string Password, string FullName, string AccessLevel, string Type, string Gender, string Age) : base(id, Email, Password, FullName, AccessLevel, Type)
        {
            this.Gender = Gender;
            this.Age = Age;
        }
    }
}
