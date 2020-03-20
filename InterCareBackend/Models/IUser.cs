using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Models
{
    public interface IUser
    {

        String Email { get; set; }
        String Password { get; set; }
        String FullName { get; set; }
        int AccessLevel { get; set; }

        void Login();
        void Logout(); 

    }
}
