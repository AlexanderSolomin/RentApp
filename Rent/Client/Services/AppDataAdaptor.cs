using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;
using Rent.Shared.Models;

namespace Rent.Client.Services
{
    public class AppDataAdaptor<T> : DataAdaptor where T : BaseEntity
    {
        private readonly IService<T> _service;
        public AppDataAdaptor(IService<T> _service)
        {
            this._service = _service;
        }
        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
            string orderByString = null;
            if(dataManagerRequest.Sorted != null)
            {
                List<Sort> sortList = dataManagerRequest.Sorted;
                sortList.Reverse();
                orderByString = string.Join(",", sortList.Select(s => string.Format("{0} {1}", s.Name, s.Direction)));
            }
            AppDataResult<T> result = await _service.List(dataManagerRequest.Skip, dataManagerRequest.Take, orderByString);
            DataResult dataResult = new DataResult()
            {
                Result = result.Result,
                Count = result.Count
            };
            return dataResult;
        }
    }
}