using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Rent.Shared.Models;

namespace Rent.Shared.Dto
{
	public class RealtyDto 
	{
		public string Title { get; set; }
		public DateTime CreatedAt { get; set; }
		public string Description { get; set; }
		public int BuildYear { get; set; }
		public double Area { get; set; }
		public int Rent { get; set; }
		public int Storeys { get; set; }
		public int Floor { get; set; }
		public int Rooms { get; set; }
		public double Rate { get; set; } 
		public Status Status { get; set; } 
		public Category Category { get; set; }
		public string ImgPath { get; set; } 
		public bool IsActive { get; set; } 
		public string OwnerId { get; set; }
		public Guid CityId { get; set; }
	}
}
