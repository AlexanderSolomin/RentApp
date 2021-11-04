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
				.HasForeignKey(d => d.DealRealtyId)
				.OnDelete(DeleteBehavior.Cascade);
			builder.HasOne(d => d.Owner)
				.WithMany(p => p.DealsAsOwner)
				.HasForeignKey(d => d.OwnerId)
				.OnDelete(DeleteBehavior.Cascade);
			builder.HasOne(d => d.Tenant)
				.WithMany(p => p.DealsAsTenant)
				.HasForeignKey(d => d.TenantId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}