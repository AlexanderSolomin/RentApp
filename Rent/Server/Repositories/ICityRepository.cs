using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Rent.Shared.Models;
using Rent.Shared.Request;
using Rent.Server.Data;

namespace Rent.Server.Repositories
{
    public interface ICityRepository : IAppRepository<City>
    {
        Task<PagedList<City>> GetAllCities(PagingParameters realtyParameters);
        Task<City> GetCityByTitle(string title);
    }
}