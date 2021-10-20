using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rent.Shared.Models
{
    public class AppDataResult<T>
    {
        public IEnumerable<T> Result { get; set; }
        public int Count { get; set; }
    }
}