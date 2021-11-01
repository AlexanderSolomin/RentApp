
namespace Rent.Shared.Models
{
    public class City : BaseEntity
    {
        public string Subject { get; set; } = "Default Subject";
        public int Population { get; set; } = 1;
        public string District { get; set; } = "Default District";
    }
}