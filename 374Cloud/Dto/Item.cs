using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _374Cloud.Dto
{
    public class Item
    {
        public int code { get; set; }
        public string description { get; set; }
        public string cat { get; set; }
        public string scat { get; set; }
        public string sscat { get; set; }
        public decimal price  { get; set; }
    }
}
