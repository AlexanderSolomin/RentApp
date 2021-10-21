using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rent.Shared.Models
{
    public abstract class BaseEntity
    { 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
