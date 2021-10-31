using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rent.Shared.Models
{
    public class AppUser : IdentityUser
    {
        public IEnumerable<Realty> Realties { get; set; }

        [InverseProperty("SenderUser")]
        public IEnumerable<UserFeedback> FeedbacksUserSent { get; set; }

        [InverseProperty("RecipientUser")]
        public IEnumerable<UserFeedback> FeedbacksUserRecieved { get; set; }
        public IEnumerable<RealtyFeedback> FeedbacksRealtySent { get; set; }
        public double Rate { get; set; }
    }
}
