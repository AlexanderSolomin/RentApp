using System;
using System.ComponentModel.DataAnnotations;

namespace Rent.Shared.Models
{
	public class Deal : BaseEntity
	{
		public Deal()
		{
		}
		[Display(Name = "Дата сделки")]
		public DateTime CreatedAt { get; set; } = DateTime.Now;

		[Required]
		[Display(Name = "Дата начала аренды")]
		public DateTime StartDate { get; set; }

		[Required]
		[Display(Name = "Дата окончания аренды")]
		public DateTime EndDate { get; set; }

		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "Стоимость аренды не может быть меньше 0")]
		[Display(Name = "Стоимость за месяц")]
		public int Rent { get; set; }

		[Required]
		[Display(Name = "Недвижимость")]
		public virtual Realty DealRealty { get; set; }

		[Required]
		public Guid DealRealtyId { get; set; }

		[Required]
		[Display(Name = "Владелец")]
		public virtual AppUser Owner { get; set; }

		[Required]
		[Display(Name = "Наниматель")]
		public virtual AppUser Tenant { get; set; }

		// [Required]
		// [Display(Name = "Отзыв владельца")]
		// public virtual UserFeedback OwnerFeedback { get; set; }

		// [Required]
		// [Display(Name = "Отзыв нанимателя")]
		// public virtual UserFeedback TenantFeedback { get; set; }

	}
}