using System;
using System.Collections.Generic;

namespace _374Cloud.Entities
{
    public partial class CatalogRef
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int? Seq { get; set; }
        public string Cat { get; set; }
    }
}
