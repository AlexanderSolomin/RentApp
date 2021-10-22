using System;
using System.Collections.Generic;   
using System.ComponentModel.DataAnnotations;

namespace Rent.Shared.Models
{
    public class Deal : BaseEntity
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int RentPerMonth { get; set; }
        [Required]
        public ApplicationUser Owner { get; set; }
        [Required]
        public ApplicationUser Tenant { get; set; }
        [Required]
        public Realty Realty { get; set; }
        [Required]
        public IEnumerable<UserFeedback> Feedbacks { get; set; }


    }
}