using System;

namespace Rent.Shared.Models
{
    public class City : BaseEntity
    {
        public string Subject { get; set; }
        public int Population { get; set; }
    }
}