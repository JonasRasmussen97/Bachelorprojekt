using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Daos.Interfaces
{
    interface IClientDao
    {
        Task<IEnumerable<Client>> GetAll();
        Task<Client> GetFromEmail(string email);
        Task<String> Create(IClientDao client);
        Task<String> Update(String email, Client client);
        Task<String> Delete(String email);
       
    }
}
