using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Masivian.Models
{
    public class Roulette
    {
        public Guid id { get; set; }
        public bool isOpen { get; set; } = false;
    }
}
