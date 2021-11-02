using System.ComponentModel.DataAnnotations;

namespace Rent.Shared.Models
{
	public class UserRealty : BaseEntity
	{
		public UserRealty()
		{
		}
        [Required]
        [Display(Name = "Владелец")] 
        public AppUser Owner { get; set; }
        
        [Required]
        [Display(Name = "Недвижимость")] 
        public Realty Realty { get; set; }

	}
}