﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Daos.Interfaces
{
    interface IInterCareAdminDao
    {
        Task<InterCareAdmin> GetFromEmail(string email);
    }
}
