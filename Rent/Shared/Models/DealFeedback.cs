using System.ComponentModel.DataAnnotations;

namespace Rent.Shared.Models
{
	public class DealFeedback : BaseEntity
	{
		public DealFeedback()
		{
		}
        [Required]
        [Display(Name = "Отзыв")] 
        public UserFeedback UserFeedback { get; set; }
        
        [Required]
        [Display(Name = "Сделка")] 
        public Deal Deal { get; set; }

	}
}