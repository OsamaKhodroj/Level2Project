using Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Interfaces
{
    public interface IUser
    {
        Task AddAsync(User user); 
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id);
        Task<User> GetByIdAsync(Guid id);
        Task<List<User>> GetAllAsync(); 
    }
}
