using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rent.Shared.Models;
using Rent.Shared.Request;
using Rent.Server.Data;
using Rent.Server.Repositories.Extensions;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;


namespace Rent.Server.Repositories 
	{
		public class CityRepository : AppRepository<City>, ICityRepository
		{
			private readonly AppDbContext _dbContext;
			public CityRepository(AppDbContext dbContext) : base(dbContext)
			{
				_dbContext = dbContext;
			}

			public async Task<PagedList<City>> GetAllCities(PagingParameters pagedParameters)
			{
				var result = await _dbContext.Cities.Search(pagedParameters.SearchTerm).ToListAsync();
				return PagedList<City>.ToPagedList(result, pagedParameters.PageNumber, pagedParameters.PageSize);
			}

    
		}
	}

