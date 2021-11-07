using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using Rent.Shared.Models;

namespace Rent.Server.Data.Configuration
{
	public class CityConfiguration : IEntityTypeConfiguration<City>
	{
		public void Configure(EntityTypeBuilder<City> builder)
		{
			var cities = new List<City>();
			using (StreamReader sr = new StreamReader(@"./Data/SeedJson/addresses.json"))
			{
				string json = sr.ReadToEnd();
				cities = JsonConvert.DeserializeObject<List<City>>(json);
			}
			foreach (City city in cities)
			{
				city.Id = Guid.NewGuid();
			}

			City spb = new()
			{
				Id = Guid.Parse("3edcd162-ec30-47ec-bc47-28b44c23efbf"),
				District = "Северо-Западный",
				Title = "Санкт-Петербург",
				Population = 5384342,
				Subject = "Санкт-Петербург"
			};
			builder.HasData(cities);
			builder.HasData(spb);
		}
	}
}