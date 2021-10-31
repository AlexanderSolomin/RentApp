using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rent.Shared.Models
{
    public class Realty : BaseEntity
    {
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Введите описание")]
        [StringLength(2000, ErrorMessage = "Описание не может быть более 2000 символов")]  
        public string Description { get; set; }

        [Required(ErrorMessage = "Введите год")]
        [Range(1800, 2022)]  
        public int BuildYear { get; set; }
        [Required(ErrorMessage = "Введите площадь")]
        [Range(0, 3000)]  
        public double Area { get; set; }
        [Required(ErrorMessage = "Введите стоимость")]
        [Range(1000, 10000000)]  
        public int Rent { get; set; }
        [Required(ErrorMessage = "Введите этажность здания")]
        [Range(1, 50)]  
        public int Storeys { get; set; }
        [Required(ErrorMessage = "Введите этаж")]
        [Range(1, 50)]  
        public int Floor { get; set; }
        public double Rate { get; set; }
        public Status Status { get; set; }

        [Required(ErrorMessage = "Выберите категорию помещения")]
        public Category Category { get; set; }

        [Required(ErrorMessage = "Укажите город")]
        public City City { get; set; }

        public AppUser Owner { get; set; }     
        public IEnumerable<RealtyFeedback> Feedbacks { get; set; }
        public IEnumerable<Deal> Deals { get; set; }
        public string ImgPath { get; set; }
        public bool IsActive { get; set; }
    }
}
