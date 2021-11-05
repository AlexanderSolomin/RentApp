using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rent.Shared.Models
{
	public class Realty : BaseEntity
	{
		public Realty()
		{
		}

		[Required(ErrorMessage = "Обязательное поле")]
		[StringLength(60, ErrorMessage = "Заголовок не может быть более 60 символов")]
		[Display(Name = "Заголовок")]
		public string Title { get; set; }

		[Display(Name = "Создано")]
		public DateTime CreatedAt { get; set; } = DateTime.Now;

		[Required(ErrorMessage = "Введите описание")]
		[StringLength(2000, ErrorMessage = "Описание не может быть более 2000 символов")]
		[Display(Name = "Описание")]
		public string Description { get; set; }

		[Required(ErrorMessage = "Введите год постройки")]
		[Range(1800, 2022, ErrorMessage = "Год не может быть больше текущего")]
		[Display(Name = "Год постройки")]
		public int BuildYear { get; set; }

		[Required(ErrorMessage = "Введите площадь")]
		[Range(1, int.MaxValue, ErrorMessage = "Площадь не может быть меньше 1")]
		[Display(Name = "Площадь помещения")]
		public double Area { get; set; }

		[Required(ErrorMessage = "Введите стоимость")]
		[Range(0, int.MaxValue, ErrorMessage = "Стоимость не может быть меньше 0")]
		[Display(Name = "Стоимость аренды")]
		public int Rent { get; set; }

		[Required(ErrorMessage = "Введите этажность здания")]
		[Range(1, 50, ErrorMessage = "(1 - 50)")]
		[Display(Name = "Этажность здания")]
		public int Storeys { get; set; }

		[Required(ErrorMessage = "Введите этаж")]
		[Range(1, 50, ErrorMessage = "(1 - 50)")]
		[Display(Name = "Этаж")]
		public int Floor { get; set; }

		[Required(ErrorMessage = "Введите количество комнат")]
		[Range(1, 20, ErrorMessage = "(1 - 20)")]
		[Display(Name = "Комнат")]
		public int Rooms { get; set; }

		[Display(Name = "Рейтинг")]
		public double Rate { get; set; } = 0;

		[Display(Name = "Статус")]
		public Status Status { get; set; } = Status.AVAILABLE;

		[Required(ErrorMessage = "Выберите категорию помещения")]
		[Display(Name = "Категория")]
		public Category Category { get; set; }

		[Required]
		[Display(Name = "Изображение")]
		public string ImgPath { get; set; } = "../Shared/Img/DefaultRealty.jpg";

		[Display(Name = "Активно")]
		public bool IsActive { get; set; } = true;

		public virtual AppUser Owner { get; set; }

		public virtual City RealtyCity { get; set; }

		public virtual ICollection<Deal> RealtyDeals { get; set; } = new List<Deal>();
	}
}
