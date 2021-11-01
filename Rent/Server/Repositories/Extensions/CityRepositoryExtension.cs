using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rent.Shared.Models;
using Rent.Shared.Request;
using Rent.Server.Data;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;

namespace Rent.Server.Repositories.Extensions
{
	public static class CityRepositoryExtension
	{
		public static IQueryable<City> Search(this IQueryable<City> cities, string searchTerm)
		{
			if (string.IsNullOrWhiteSpace(searchTerm))
				return cities;
			return cities.Where(p => p.Title.ToLower().Contains(searchTerm.Trim().ToLower()));
		}
	}
}

