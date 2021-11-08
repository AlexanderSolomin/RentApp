using System.Threading.Tasks;
using Rent.Shared.Models;
using Rent.Shared.Request;
using Rent.Server.Data;

namespace Rent.Server.Repositories
{
    public interface IRealtyRepository : IAppRepository<Realty>
    {
        Task<PagedList<Realty>> GetRealties(PagingParameters pagingParameters);
        Task<PagedList<Realty>> GetUserRealties(PagingParameters pagingParameters);
    }
}