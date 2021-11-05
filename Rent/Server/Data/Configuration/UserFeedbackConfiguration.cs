using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Rent.Shared.Models;

namespace Rent.Server.Data.Configuration
{
	public class UserFeedbackConfiguration : IEntityTypeConfiguration<UserFeedback>
	{
		public void Configure(EntityTypeBuilder<UserFeedback> builder)
		{
			builder.HasOne(d => d.UserFrom)
                .WithMany(p => p.FeedbacksSent)
                .OnDelete(DeleteBehavior.Cascade);
			builder.HasOne(d => d.UserTo)
				.WithMany(p => p.FeedbacksRecieved)
				.OnDelete(DeleteBehavior.Cascade);
		}

	}
}