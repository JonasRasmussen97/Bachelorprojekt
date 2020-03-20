using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Models
{
    interface User
    {
        string Email { get;set;}
        string Password { get; set; }

        string FullName { get; set; }


    }
}
