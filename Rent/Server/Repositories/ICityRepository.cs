using System.Threading.Tasks;
using Rent.Shared.Models;
using Rent.Shared.Request;
using Rent.Server.Data;

namespace Rent.Server.Repositories
{
    public interface ICityRepository : IAppRepository<City>
    {
        Task<PagedList<City>> GetAllCities(CityPagingParameters cityPagingParameters);
        Task<City> GetCityByTitle(string title);
    }
}