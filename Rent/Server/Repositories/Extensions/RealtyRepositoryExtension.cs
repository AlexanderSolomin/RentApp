using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rent.Shared.Models;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;

namespace Rent.Server.Repositories.Extensions
{
	public static class RealtyRepositoryExtension
	{
		public static IQueryable<Realty> Search(this IQueryable<Realty> realties, string searchTerm)
		{
			if (string.IsNullOrWhiteSpace(searchTerm))
				return realties;
			return realties.Where(p => p.Title.ToLower().Contains(searchTerm.Trim().ToLower()));
		}

		public static IQueryable<Realty> Sort(this IQueryable<Realty> realties, string orderByQueryString)
		{
			if (string.IsNullOrWhiteSpace(orderByQueryString))
				return realties.OrderBy(e => e.Title);

			var orderParams = orderByQueryString.Trim().Split(',');
			var propertyInfos = typeof(Realty).GetProperties(BindingFlags.Public | BindingFlags.Instance);
			var orderQueryBuilder = new StringBuilder();

			foreach (var param in orderParams)
			{
				if (string.IsNullOrWhiteSpace(param))
					continue;

				var propertyFromQueryName = param.Split(" ")[0];
				var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

				if (objectProperty == null)
					continue;

				var direction = param.EndsWith(" desc") ? "descending" : "ascending";
				orderQueryBuilder.Append($"{objectProperty.Name} {direction}, ");
			}

			var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
			if (string.IsNullOrWhiteSpace(orderQuery))
				return realties.OrderBy(e => e.Title);

			return realties.OrderBy(orderQuery);
		}
	}
}