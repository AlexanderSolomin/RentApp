using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;
using Rent.Shared.Models;
using Rent.Server.Repositories;

namespace Rent.Server.Data.Configuration
{
	public class DealConfiguration : IEntityTypeConfiguration<Deal>
	{
		public void Configure(EntityTypeBuilder<Deal> builder)
		{
			builder.HasOne(d => d.DealRealty)
				.WithMany(p => p.RealtyDeals)
				.OnDelete(DeleteBehavior.Cascade);
			builder.HasOne(d => d.Owner)
				.WithMany(p => p.DealsAsOwner)
				.OnDelete(DeleteBehavior.Cascade);
			builder.HasOne(d => d.Tenant)
				.WithMany(p => p.DealsAsTenant)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}