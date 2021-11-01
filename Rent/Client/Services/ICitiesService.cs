using System;
using System.Threading.Tasks;
using Rent.Shared.Models;
using Rent.Shared.Request;
using Rent.Client.Features;

namespace Rent.Client.Services
{
    public interface ICitiesService : IAppService<City>
    {
        Task<PagedResponse<City>> GetCitiesPaged(PagingParameters pagingParameters);
        Task AddCity(City city);
    }
}
