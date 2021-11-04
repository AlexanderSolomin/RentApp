using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Rent.Shared.Models
{
	public class City : BaseEntity
	{
		public City()
		{
			CityRealties = new HashSet<Realty>();
		}
		[Required(ErrorMessage = "Обязательное поле")]
		[StringLength(60, ErrorMessage = "Название не может быть более 60 символов")]
        [Display(Name = "Название")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Субъект")]
		public string Subject { get; set; }

		[Required(ErrorMessage = "Обязательное поле")]
		[Range(1, int.MaxValue, ErrorMessage = "Численность населения не может быть меньше 1")]
        [Display(Name = "Население")]
		public int Population { get; set; }
		
        [Required(ErrorMessage = "Обязательное поле")]	        
        [Display(Name = "Регион")]
	    public string District { get; set; }
		
		public virtual ICollection<Realty> CityRealties { get; set; }
	}
}