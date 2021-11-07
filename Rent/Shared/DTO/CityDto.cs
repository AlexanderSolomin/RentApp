using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Rent.Shared.Dto
{
	public class CityDto
	{
		public string Title { get; set; }
		public string Subject { get; set; }
		public int Population { get; set; }
	    public string District { get; set; }
	}
}