using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Rent.Server.Data.Configuration
{
	public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
	{
		public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
		{
            builder.HasData(  
                new { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" },  
                new { RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330", UserId = "5f2c82e4-13c7-443a-b63d-7b92030fb09f" }  
                );  
		}
	}
}