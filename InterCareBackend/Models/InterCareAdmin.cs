using System;

namespace InterCareBackend.Models
{
    public class InterCareAdmin : User, IUser
    {

      
        public InterCareAdmin(string id, string Email, string Password, string FullName, string AccessLevel, string Type) : base(id, Email, Password, FullName, AccessLevel, Type)
        {

        }



    }
}
