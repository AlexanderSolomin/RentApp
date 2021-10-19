using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Rent.Shared.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Realty> Realties { get; set; }
        public double Rate { get; set; }
    }
}
