using System;
using System.ComponentModel.DataAnnotations;

namespace Rent.Shared.Models
{
    public class UserFeedback : BaseEntity
    {
 		public string Text { get; set; }
		[Required]
		public AppUser SenderUser { get; set; }
		[Required]
		public AppUser RecipientUser { get; set; }
		[Required]
		public Deal UserDeal { get; set; }
		[Required(ErrorMessage = "Введите оценку (1 - 5)")]
        [Range(1, 5)] 
		public int Rate { get; set; }
	}
}