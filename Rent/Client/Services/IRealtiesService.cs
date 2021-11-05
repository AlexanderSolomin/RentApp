using System;
using System.Threading.Tasks;
using Rent.Shared.Models;
using Rent.Shared.Request;
using Rent.Client.Features;
using System.Net.Http;

namespace Rent.Client.Services
{
    public interface IRealtiesService : IAppService<Realty>
    {
        Task<PagedResponse<Realty>> GetRealtiesPaged(PagingParameters pagingParameters);
        Task<Realty> GetRealtyById(string Id);
        Task AddRealty(Realty realty);
        Task EditRealty(Realty realty);
        Task DeleteRealty(Guid id);
        Task<string> UploadImage(MultipartFormDataContent content);
    }
}