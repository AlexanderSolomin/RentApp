using System;
using System.Collections.Generic;

namespace Rent.Shared.Models
{
    public class Realty : BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public int BuildYear { get; set; }
        public double Area { get; set; }
        public int Rent { get; set; }
        public int Storeys { get; set; }
        public int Floor { get; set; }
        public double Rate { get; set; }
        public Status Status { get; set; }
        public Category Category { get; set; }
        public City City { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ImgPath { get; set; }
    }
}
