using System.ComponentModel.DataAnnotations;

namespace Rent.Shared.Models
{
	public class City : BaseEntity
	{
		public City()
		{

		}
		[Required(ErrorMessage = "Обязательное поле")]
		[StringLength(60, ErrorMessage = "Название не может быть более 60 символов")]
        [Display(Name = "Название")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Субъект")]
		public string Subject { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = "Численность населения не может быть меньше 1")]
        [Display(Name = "Население")]
		public int Population { get; set; }
		
        [Required(ErrorMessage = "Обязательное поле")]	        
        [Display(Name = "Регион")]
	    public string District { get; set; }
	}
}