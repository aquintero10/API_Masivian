using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Masivian.Models
{
    public class Bet
    {
        public Guid id_roullete { get; set; }
        public string id_client { get; set; }
        public int number { get; set; }
        public string colour { get; set; }
        public double amount { get; set; }
    }
}
