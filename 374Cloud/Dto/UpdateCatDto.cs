using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _374Cloud.Dto
{
    public class UpdateCatDto
    {
        public int id { get; set; }
        public int parent_id { get; set; }
        public string cat { get; set; }
    }
}
