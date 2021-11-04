using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Rent.Shared.Models;
using Rent.Server.Data.Configuration;


namespace Rent.Server.Data
{
	public class AppDbContext : ApiAuthorizationDbContext<AppUser>
	{
		public AppDbContext(
			DbContextOptions options,
			IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
		{
		}
		public DbSet<City> Cities { get; set; }
		public DbSet<Realty> Realties { get; set; }
		public DbSet<Deal> Deals { get; set; }
		public DbSet<UserFeedback> UserFeedbacks { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.ApplyConfiguration(new AppUserConfiguration());
			builder.ApplyConfiguration(new IdentityRoleConfiguration());
			builder.ApplyConfiguration(new IdentityUserRoleConfiguration());
			builder.ApplyConfiguration(new CityConfiguration());
			builder.ApplyConfiguration(new RealtyConfiguration());
            builder.ApplyConfiguration(new DealConfiguration());
            builder.ApplyConfiguration(new UserFeedbackConfiguration());
		}
	}
}