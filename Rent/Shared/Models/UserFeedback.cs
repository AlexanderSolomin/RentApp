using System;
using System.ComponentModel.DataAnnotations;

namespace Rent.Shared.Models
{
	public class UserFeedback : BaseEntity
	{
		[Display(Name = "Дата сделки")]
		public DateTime CreatedAt { get; set; } = DateTime.Now;

		[Required]
		[Display(Name = "Заголовок")]
		[StringLength(60, ErrorMessage = "Заголовок не может быть более 60 символов")]
		public string Title { get; set; }

		[Required]
		[Display(Name = "Отзыв")]
		public string Text { get; set; }

		[Required(ErrorMessage = "Введите оценку (1 - 5)")]
		[Range(1, 5)]
		[Display(Name = "Оценка")]
		public int Rate { get; set; }

		[Display(Name = "Автор")]
		public virtual AppUser UserFrom { get; set; }

		[Required]
		public string UserFromId { get; set; }

		[Display(Name = "Получатель")]
		public virtual AppUser UserTo { get; set; }

		[Required]
		public string UserToId { get; set; }

		[Display(Name = "Сделка")]
		public virtual Deal Deal { get; set; }

		[Required]
		public Guid DealId { get; set; }

	}
}