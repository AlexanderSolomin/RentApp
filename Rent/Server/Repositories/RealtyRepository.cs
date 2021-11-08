using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rent.Shared.Models;
using Rent.Shared.Request;
using Rent.Server.Data;
using Rent.Server.Repositories.Extensions;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using System;

namespace Rent.Server.Repositories 
{
	public class RealtyRepository : AppRepository<Realty>, IRealtyRepository
	{
        private readonly AppDbContext _dbContext;
		public RealtyRepository(AppDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
        public async Task<PagedList<Realty>> GetRealties(PagingParameters pagingParameters)
        {
            var result = await _dbContext.Realties
										.Search(pagingParameters.SearchTerm)
										.OrderBy(pagingParameters.OrderBy)
										.ToListAsync();
			return PagedList<Realty>.ToPagedList(result, pagingParameters.PageNumber, pagingParameters.PageSize);
        }

		public async Task<PagedList<Realty>> GetUserRealties(PagingParameters pagingParameters)
		{

			var result = await _dbContext.Realties
										//.Where(u => u.OwnerId == userId)
										.Search(pagingParameters.SearchTerm)
										.OrderBy(pagingParameters.OrderBy)
										.ToListAsync();
			return PagedList<Realty>.ToPagedList(result, pagingParameters.PageNumber, pagingParameters.PageSize);
		}


	}
}
