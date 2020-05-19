using System;

namespace InterCareBackend.Models
{
    public class User: IUser
    {
        
        public string id;
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set;}
        public string AccessLevel { get; set; }
        public string Type { get; set; }
        
        public User(string Email, string FullName, string Type)
        {
            this.Email = Email;
            this.FullName = FullName;
            this.Type = Type;
        }

        public User(string id, string Email, string Password, string FullName, string AccessLevel, string Type)
        {
            this.id = id;
            this.Email = Email;
            this.Password = Password;
            this.FullName = FullName;
            this.AccessLevel = AccessLevel;
            this.Type = Type;
        }

        public User(string Email, string Password, string FullName, string AccessLevel, string Type)
        {
            this.Email = Email;
            this.Password = Password;
            this.FullName = FullName;
            this.AccessLevel = AccessLevel;
            this.Type = Type;
        }
     
    }
}
