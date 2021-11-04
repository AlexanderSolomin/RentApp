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
				.HasForeignKey(d => d.UserFromId)
                .OnDelete(DeleteBehavior.Cascade);
			builder.HasOne(d => d.UserTo)
				.WithMany(p => p.FeedbacksRecieved)
				.HasForeignKey(d => d.UserToId)
				.OnDelete(DeleteBehavior.Cascade);
		}

	}
}