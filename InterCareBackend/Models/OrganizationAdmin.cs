using System;
using System.Collections;
using System.Collections.Generic;

namespace InterCareBackend.Models
{
    public class OrganizationAdmin : User, IUser
    {
        
        
        public OrganizationAdmin(string id, string Email, string Password, string FullName, string AccessLevel, string Type) : base(id, Email, Password, FullName, AccessLevel, Type)
        {

        }
        public OrganizationAdmin(string Email, string Password, string FullName, string AccessLevel, string Type) : base(Email, Password, FullName, AccessLevel, Type)
        {

        }



    }
}
