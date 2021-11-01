using System.ComponentModel.DataAnnotations;

namespace Rent.Shared.Models
{
    public class City : BaseEntity
    {
        [Required(ErrorMessage = "Обязательное поле")]
        public string Subject { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Численность населения не может быть меньше 1")]
        public int Population { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public string District { get; set; }
    }
}