using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _374Cloud.Entities
{
    public partial class CatalogRef
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int? Seq { get; set; }

        [Required(ErrorMessage = "You should input a category value.")]
        public string Cat { get; set; }

        public int? LayerLevel { get; set; }
    }
}
