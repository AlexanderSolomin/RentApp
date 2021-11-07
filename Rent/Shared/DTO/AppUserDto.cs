using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Rent.Shared.Models
{
	public class AppUser : IdentityUser
	{
		public virtual ICollection<Realty> UserRealties { get; set; }
		public virtual ICollection<UserFeedback> FeedbacksSent { get; set; }
		public virtual ICollection<UserFeedback> FeedbacksRecieved { get; set; }
        public virtual ICollection<Deal> DealsAsOwner { get; set; }
        public virtual ICollection<Deal> DealsAsTenant { get; set; }
		public double Rate { get; set; }

		public AppUser()
		{
			FeedbacksSent = new HashSet<UserFeedback>();
			FeedbacksRecieved = new HashSet<UserFeedback>();
			UserRealties = new HashSet<Realty>();
            DealsAsOwner = new HashSet<Deal>();
            DealsAsTenant = new HashSet<Deal>();
            Rate = 0;
		}
	}
}
