using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _374Cloud.Dto
{
    public class AddCatDto
    {
        public int parent_id { get; set; } = 0;
        public string cat { get; set; }
    }
}
