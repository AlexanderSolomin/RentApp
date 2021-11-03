using System.ComponentModel.DataAnnotations;

namespace Rent.Shared.Models
{
	public class Address : BaseEntity
	{
		public Address()
		{
		}
        public string Street { get; set; }
        public string Building { get; set; }
        public string Apt { get; set; }
	}
}