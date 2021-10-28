using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Rent.Shared.Models;
using Rent.Shared.Request;


namespace Rent.Client.Features
{
    public class PagedResponse<T> where T : class
    {
		public List<T> Items { get; set; }
    	public MetaData MetaData { get; set; }
	}
}