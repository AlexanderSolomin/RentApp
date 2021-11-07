using System;
using System.Threading.Tasks;
using Rent.Shared.Models;

namespace Rent.Client.Services
{
    public interface IAppUserService : IAppService<AppUser>
    {
        Task<AppUser> GetUserById(string Id);
    }
}
