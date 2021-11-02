using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rent.Shared.Models
{
    public class AppUser : IdentityUser
    {
        public double Rate { get; set; } = 0;
    }
}
