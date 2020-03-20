using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Daos.Interfaces
{
    interface IOrganizationDao
    {
        Task<IEnumerable<Organization>> GetAll();
        Task<Organization> GetFromName(String name);
        Task<String> Create(Organization organization);
        Task<String> Update(String name, Organization organization);
        Task<String> Delete(String name);
    }
}
