using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Masivian.Models
{
    public class Client
    {
        public string id_client { get; set; }
        public bool isWinner { get; set; } = false;
        public double earnings { get; set; } = 0;
        public double balance { get; set; } = 10000;
    }
}
