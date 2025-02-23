﻿using System;
using System.Threading.Tasks;
using Rent.Shared.Models;
using Rent.Shared.Request;
using Rent.Client.Features;
using System.Net.Http;
using System.Collections.Generic;

namespace Rent.Client.Services
{
    public interface ICitiesService : IAppService<City>
    {
        Task<IEnumerable<City>> GetCities();
        Task<PagedResponse<City>> GetCitiesPaged(CityPagingParameters cityPagingParameters);
        Task<City> GetCityById(string Id);
        Task AddCity(City city);
        Task EditCity(City city);
        Task DeleteCity(Guid id);
        Task<string> UploadImage(MultipartFormDataContent content);
    }
}
