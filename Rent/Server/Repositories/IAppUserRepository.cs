using System.Collections.Generic;
using System.Threading.Tasks;
using Rent.Shared.Models;

namespace Rent.Server.Repositories
{
    public interface IAppUserRepository// : IAppRepository<AppUser>
    {
        Task<AppUser> GetUserById(string id);
        Task<IEnumerable<AppUser>> GetAllUsers();
    }
}
