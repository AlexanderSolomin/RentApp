using System;

namespace Rent.Shared.Models
{
    public class Deal : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RentPerMonth { get; set; }
        public ApplicationUser Owner { get; set; }
        public ApplicationUser Tenant { get; set; }
        public Realty Realty { get; set; }
        public int OwnerRate { get; set; }
        public int TenantRate { get; set; }
    }
}